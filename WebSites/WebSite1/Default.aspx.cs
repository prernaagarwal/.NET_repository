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
    SqlConnection con = null;
    SqlDataAdapter adap = null;
    DataSet ds = null;
    DataTable dt = null;
    DataRow dr = null;
    int total;
    int count;
    public _Default()
    {
        
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        adap = new SqlDataAdapter("select * from tblEmployee", con);
        ds = new DataSet();
        adap.Fill(ds);
        dt = ds.Tables[0];
        count = 0;
        total = dt.Rows.Count;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (ViewState["xyz"] != null)
        {
            count = (int)ViewState["xyz"];
        }
        if (count < total)
        {
            DataRow dr = dt.Rows[count];
            txtEmpId.Text = Convert.ToString(dr[0]);
            txtEmpName.Text = Convert.ToString(dr[1]);
            txtEmpSalary.Text = Convert.ToString(dr[2]);
            txtEmpDoj.Text = Convert.ToString(dr[3]);
            count++;
            ViewState["xyz"] = count;
        }

            /*for (int i = 0; i < count; i++)
        {
            DataRow dr = dt.Rows[i];
            txtEmpId.Text = Convert.ToString(dr[0]);
            txtEmpName.Text = Convert.ToString(dr[1]);
            txtEmpSalary.Text = Convert.ToString(dr[2]);
            txtEmpDoj.Text = Convert.ToString(dr[3]);
        }
        */

    }
}