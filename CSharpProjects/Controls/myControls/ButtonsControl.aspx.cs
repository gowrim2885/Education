using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controls
{
    public partial class ButtonsControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                javascript.Focus();
                MaleRadioButton.Focus();
            }

        }
        protected void MaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            result1.Text = "Male radio button was clicked";
           
        }
        protected void FemaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            result1.Text = "Female radio button was clicked";
        }

        protected void Submit_Click(object sender, EventArgs e) { }
        protected void checkboxSubmit_Click(object sender, EventArgs e)
        {
            if (javascript.Checked)
            {
                Response.Write("Js Selected"+"<br/>");
            }
            if (html.Checked)
            {
                Response.Write("html Selected"+ "<br/>");
            }
            if (css.Checked)
            {
                Response.Write("css Selected"+ "<br/>");
            }

        }

        protected void Jsbox_CheckedChanged(object sender, EventArgs e)
        {
            result2.Text = "js clicked";
        }
        protected void htmlbox_CheckedChanged(object sender, EventArgs e)
        {
            result2.Text = "html clicked";
        }
        protected void cssbox_CheckedChanged(object sender, EventArgs e)
        {
            result2.Text = "css clicked";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem li1 = new ListItem("London");
            ListItem li2 = new ListItem("India");
            ListItem li3 = new ListItem("America");

            DropDownList1.Items.Add(li1);
            DropDownList1.Items.Add(li2);
            DropDownList1.Items.Add(li3);

        }
    }
}