using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Create_User(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            string pass1 = password1.Text;
            string note = Notes.Text;
            string mail = email.Text;
            string type = Type.SelectedValue;
            if (pass != pass1)
                Response.Redirect("Admin.aspx");
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                OleDbCommand cmd=con.CreateCommand();
                cmd.CommandText = "insert into User_Details values('" + user + "','" + pass + "','" + type + "','" + note + "','" + mail + "')";
                System.Diagnostics.Debug.WriteLine(cmd.CommandText); 
                int rows = cmd.ExecuteNonQuery();
                
                if(rows!=1)
                {
                    throw new Exception();
                }
                con.Close();
                Response.Write("<br><h2>User Creation success</h2>");
            }
            catch(Exception ee)
            {
                Response.Write("Error at"+ee.ToString());
            }
        }
    }
}