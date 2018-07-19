using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    DataTable dtEmp = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            showOriginal();
            buildtable();
        }
    }

    private void buildtable()
    {
        dtEmp = new DataTable();
        dtEmp.Columns.Add("pkEmpID", typeof(int));
        dtEmp.Columns.Add("EmpName", typeof(String));
        dtEmp.Columns.Add("EmpSalary", typeof(float));
        dtEmp.Columns.Add("EmpDoj", typeof(DateTime));
        Cache["dtEmp"] = dtEmp;
 
    }
    private void showOriginal()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblEmployee", conn))
                {
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            gridview1.DataSource = sdr;
                            gridview1.DataBind();
                        }
                    }
                }

            }
        }
        catch(Exception)
        {
            Response.Write("<script>alert('Connection could not be established')</script");
        }

    }

    private void ClearText()
    {
        lblEmpName.Text = String.Empty;
        lblEmpSalary.Text = String.Empty;
        lblEmpDoj.Text = String.Empty;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Cache["dtEmp"]!=null)
        {
            dtEmp = (DataTable)Cache["dtEmp"];
        }
        DataRow dr = dtEmp.NewRow();
        dr[1] = Convert.ToString(lblEmpName.Text);
        dr[2] = Convert.ToInt64(lblEmpSalary.Text);
        dr[3] = Convert.ToDateTime(lblEmpDoj.Text);
        dtEmp.Rows.Add(dr);
        gridview2.DataSource = dtEmp;
        gridview2.DataBind();
        Cache["dtEmp"] = dtEmp;
        ClearText();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter adap = new SqlDataAdapter("Select * form tblEmployee where 1=2", conn);

        if (Cache["dtEmp"] != null)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(adap);
            adap.InsertCommand = builder.GetInsertCommand();
            dtEmp = (DataTable)Cache["dtEmp"];
            int temp = adap.Update(dtEmp);
            if (temp > 0)
            {
                showOriginal();
                dtEmp.Clear();
                gridview2.DataSource = dtEmp;
                gridview2.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Table not updated')</script");
            }
        }
        else
        {
            Response.Write("<script>alert('Error')</script");
        }
    }
}