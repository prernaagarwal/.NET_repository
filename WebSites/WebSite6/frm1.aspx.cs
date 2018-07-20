using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm1 : System.Web.UI.Page
{
    int count = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn1_Click(object sender, EventArgs e)
    {
         if (ViewState["count"]!=null)
        {
            count = (int)ViewState["count"];
        }

        if (count == 1)
        {
            lbl.Text += "You have clicked me 1 time <br />";
            
        }
        else if (count > 1 )
        {
            lbl.Text += "You have clicked me "+count+" times <br />";
        }
        count++;
        ViewState["count"] = count;
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frm2.aspx");
    }
}