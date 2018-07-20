using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class frm3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showGrid();
        }
    }

    public void showGrid()
    {
        SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-SEBSEGR;Initial Catalog=Employeedb;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("select * from tblEmployee", con);
        con.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        grid.DataSource = sdr;
        grid.DataBind();
        con.Close();
    }
}