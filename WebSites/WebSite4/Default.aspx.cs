using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



public partial class _Default : System.Web.UI.Page
{
    DataTable dtEmp = null;
    int rowIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getemp();
            showEmp(dtEmp, rowIndex);
        }
    }

    private void getemp()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tblEmployee", con))
                {
                    con.Open();
                    using(SqlDataReader sdr = cmd.ExecuteReader())

                    {
                        if (sdr.HasRows)
                        {
                            dtEmp = new DataTable();
                            dtEmp.Load(sdr);
                            ViewState["dt"] = dtEmp;
                            //Cache["dt"] = dtEmp;
                        }
                        else
                        {
                            Response.Write("<script>alert('No more records to display!')</script>");
                        }
                    }
                }
            }
        }
        catch(Exception)
        {
            Response.Write("<script>alert('internal issue')</script>");
        }
    }

    private void showEmp(DataTable dtEmp, int rowIndex)
    {
        if (rowIndex < dtEmp.Rows.Count)
        {
            txtEmpId.Text = (dtEmp.Rows[rowIndex][0]).ToString();
            txtEmpName.Text = (dtEmp.Rows[rowIndex][1]).ToString();
            txtEmpSalary.Text = (dtEmp.Rows[rowIndex][2]).ToString();
            txtEmpDoj.Text = (dtEmp.Rows[rowIndex][3]).ToString();
        }
        else
        {
            Response.Write("<script>alert('No more records to display!')</script>");
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (ViewState["dt"] != null)
        {
            dtEmp = (DataTable)ViewState["dt"];
        }
        if (ViewState["rowIndex"]!=null)
        {
            rowIndex = (int)ViewState["rowIndex"];
        }
        rowIndex++;
        showEmp(dtEmp,rowIndex);
        ViewState["rowIndex"] = rowIndex;
    }
}