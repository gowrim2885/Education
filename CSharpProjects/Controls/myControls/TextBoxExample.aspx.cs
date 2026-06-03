using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Controls
{
    public partial class TextBoxExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                txtName.Focus();
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string strName = txtName.Text;
            string strPassword = txtPassword.Text;
            string strAdd = txtAddress.Text;

            result1.Text = "Name:" + strName +"<br/>"+ "Password :" + strPassword + "<br/>" + "Address :" + strAdd + "<br/>";

        }


        protected void txtAutoPost_TextChanged(object sender, EventArgs e)
        {

            result2.Text = "Text Changed  :" + txtAutoPost.Text;
        }

    }
}