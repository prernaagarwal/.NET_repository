using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class _Default : System.Web.UI.Page
{
    DataTable dt = null;
    DataTable newdt = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            getEmployees();
            newTable();
        }
    }
    private void getEmployees()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter adap = new SqlDataAdapter("select * from tblEmployee", con);
        DataSet ds = new DataSet();
        adap.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        Cache["dt"] = ds.Tables[0];

    }

    private void newTable()
    {
        newdt = new DataTable();
        newdt.Columns.Add("pkEmpID", typeof(int));
        newdt.Columns.Add("EmpName", typeof(String));
        newdt.Columns.Add("EmpSalary", typeof(float));
        newdt.Columns.Add("EmpDoj", typeof(DateTime));
        Cache["ndt"] = newdt;
    }

    private void showEmpO()
    {
        if (Cache["dt"]!=null)
        {
            dt = (DataTable)Cache["dt"];
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void showEmpN()
    {
        if (Cache["ndt"] != null)
        {
            newdt = (DataTable)Cache["ndt"];
        }
        GridView2.DataSource = newdt;
        GridView2.DataBind();
    }

    private void ClearText()
    {
        lblEmpName.Text = String.Empty;
        lblEmpSalary.Text = String.Empty;
        lblEmpDoj.Text = String.Empty;
    }

    // Add a new Row
    protected void Button1_Click(object sender, EventArgs e)
    {

        if(Cache["ndt"]!=null)
        {
            newdt = (DataTable)Cache["ndt"];
        }
        DataRow ndr = newdt.NewRow();
        ndr[1] = Convert.ToString(lblEmpName.Text);
        ndr[2] = Convert.ToInt64(lblEmpSalary.Text);
        ndr[3] = Convert.ToDateTime(lblEmpDoj.Text);
        newdt.Rows.Add(ndr);
        Cache["ndt"] = newdt;
        showEmpN();
        ClearText();
    }

    // Final Submit
    protected void Button2_Click(object sender, EventArgs e)
    {
        updatedb();
    }

    private void updatedb()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter adap = new SqlDataAdapter("select * from tblEmployee", con);
        DataSet ds = new DataSet();
        adap.Fill(ds);
        DataTable nndt = ds.Tables[0];
        SqlCommandBuilder builder = new SqlCommandBuilder(adap);

        if (Cache["dt"] != null)
        {
            dt = (DataTable)Cache["dt"];
        }
        if (Cache["ndt"] != null)
        {
            newdt = (DataTable)Cache["ndt"];
        }
     
        foreach (DataRow dr in newdt.Rows)
        {
            //DataRow ndr = dt.NewRow();
            //ndr = dr;
            //ndr[1] =dr[1]
            nndt.Rows.Add(dr.ItemArray);
            dt.Rows.Add(dr.ItemArray);
        }

        Cache["dt"] = dt;

        adap.UpdateCommand = builder.GetInsertCommand();
        adap.Update(nndt);
      
        showEmpO();
    }
}