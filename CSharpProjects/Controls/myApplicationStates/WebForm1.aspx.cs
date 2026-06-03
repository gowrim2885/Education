using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int Click_Count = 0; // value not increasse for the nature of the stateless protocol of HTTP
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                TextBox1.Text = "0";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Click_Count = Convert.ToInt32(TextBox1.Text) + 1;

            TextBox1.Text = Click_Count.ToString();

        }
    }
}