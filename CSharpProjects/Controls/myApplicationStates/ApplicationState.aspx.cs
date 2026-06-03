using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ApplicationState : System.Web.UI.Page
    {
        int Click_Count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "0";
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Application["Click"] != null)
            {
                Click_Count = (int)Application["Click"] + 1;

            }
            Application["Click"] = Click_Count;

            TextBox1.Text = Click_Count.ToString();

        }
    }
}