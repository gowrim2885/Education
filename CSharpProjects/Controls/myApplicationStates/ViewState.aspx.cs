using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        int Click_Count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(this.GetType().ToString());

            if (!IsPostBack)
            {
                TextBox1.Text = "0";
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (ViewState["Click"] != null)
            {
                Click_Count = (int)ViewState["Click"] + 1;

            }

            ViewState["Click"] = Click_Count;

            TextBox1.Text = Click_Count.ToString();
        }
    }
}