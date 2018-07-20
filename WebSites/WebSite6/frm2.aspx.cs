using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int count = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void button2_Click(object sender, EventArgs e)
    {

        if (ViewState["count"] != null)
        {
            count = (int)ViewState["count"];
        }

        if (count == 1)
        {
            lbl2.Text += "You have clicked me 1 time <br />";

        }
        else if (count > 1)
        {
            lbl2.Text += "You have clicked me " + count + " times <br />";
        }
        count++;
        ViewState["count"] = count;

    }
}