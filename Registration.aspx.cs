using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Event_Management_System
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            con.ConnectionString = @"Data Source=LAPTOP-4H9G3A49\SQLEXPRESS;Initial Catalog=anu;Integrated Security=True";
            con.Open();
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            String ins = "insert into Reg1 values('" + txtname.Text + "','" + txtaddress.Text + "','" + txtcontact.Text + "','" + txtemail.Text + "','" + txtuname.Text + "','" + txtpassword.Text + "','" + txtconpass.Text + "')";
            SqlCommand cmd = new SqlCommand(ins, con);
            cmd.ExecuteNonQuery();

            txtname.Text = "";
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtuname.Text = "";
            txtpassword.Text = "";
            txtconpass.Text = "";
            Response.Redirect("Login.aspx");
        }

        protected void btnviewid_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            String sel = "select id from Reg1 where Name='" + txtname.Text + "'";
            SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtid.Text = dt.Rows[0][0].ToString();
                Response.Write("Your ID is! :-)");
                //Response.Write("<script>alert('Your ID is! :-)')</script>");

            }
            else
            {
                Response.Write("<script>alert('Invalid Username! :-)')</script>");
                Panel2.Visible = false;
                Panel1.Visible = true;
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtuname.Text = "";
            txtpassword.Text = "";
            txtconpass.Text = "";
        }
    }
}