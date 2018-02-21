using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Event_Management_System
{
    public partial class Add_Venue : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-4H9G3A49\SQLEXPRESS;Initial Catalog=anu;Integrated Security=True";
            con.Open();
        }

        protected void btnaddvenue_Click(object sender, EventArgs e)
        {
            String ins = "insert into Add_venues values('" + txtvname.Text + "','" + txtvadd.Text + "','" + txtvcontact.Text + "','" + txtcapacity.Text + "','" + DropDownList1.SelectedValue + "','" + txtcost.Text + "')";
            SqlCommand cmd = new SqlCommand(ins, con);
            cmd.ExecuteNonQuery();

            txtvname.Text = "";
            txtvadd.Text = "";
            txtvcontact.Text = "";
            txtcapacity.Text = "";
            txtcost.Text = "";
            string fname=Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/images/" + fname));
            string sfname = "/images/" + fname;
        }
        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}