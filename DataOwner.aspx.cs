using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Diagnostics;
using System.Net;

namespace Final_Project
{
    public partial class DataOwner : System.Web.UI.Page
    {
        string owner = "Aditya";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ENC.Enabled = false;
            //HttpCookie user_cook=null;
            //HttpCookie pass_cook=null;
            //HttpCookie type_cook=null;
            //user_cook = Request.Cookies["username"];
            //pass_cook = Request.Cookies["password"];
            //type_cook = Request.Cookies["usertype"];
            //if (user_cook==null || pass_cook==null || type_cook==null)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            //if (type_cook.Value != "DataOwner")
            //{
            //    Response.Redirect("Default.aspx");
            //}
            //owner = user_cook.Value;
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            upload_panel.Visible = true;
            check_panel.Visible = false;
        }

        protected void Check_Click(object sender, EventArgs e)
        {
            upload_panel.Visible = false;
            check_panel.Visible = true;
        }
        string fname = "", fcontent = "";
        protected void Keys_Click(object sender, EventArgs e)
        {
            if (!fileupload.HasFile)
            {
                Response.Write("Please choose a file");
                return;
            }
            fname = fileupload.FileName;
            StreamReader sr;
            using (sr = new StreamReader(fileupload.FileContent))
            {
                fcontent = sr.ReadToEnd();
                sr.Close();
            }
            using (sr = new StreamReader(File.Open(@"C:\Aditya Project\aditya.keys", FileMode.Open)))
            {
                List<string> res = new List<string>();
                string content = fcontent;
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string keyword_sep = sr.ReadToEnd();
                string[] seps = keyword_sep.Split(new char[] { ',' });
                string[] con = content.ToLower().Split(new char[] { ' ', '\n','\t', ',', '.', '(', ')', ':', ';', '[', ']', '?', '\'', '\\', '/', '>', '<', '!', '@', '`', '~', '#', '$', '%', '^', '&', '*', '_', '+', '=','\'','"' });
                int i = 0;
                bool flag=false;
                foreach (string s in con)
                {
                    flag = false;
                    foreach (string s1 in seps)
                    {
                        Debug.WriteLine(s1 + "     " + s);
                        if (s.Equals(s1))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        res.Add(s);
                    }
                }
                TextBox1.Text = "";
                OleDbConnection co = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                co.Open();
                OleDbCommand cmd = co.CreateCommand();
                foreach (string s2 in res)
                {
                    if (s2 != "")
                    {
                        cmd.CommandText = "select * from keywords";
                        OleDbDataReader dr = cmd.ExecuteReader();
                        int row = 0;
                        while (dr.Read())
                        {
                            if (s2.Equals(dr.GetString(0)))
                            {
                                dr.Close();
                                goto Lab;
                            }
                            row++;
                        }
                        dr.Close();
                        cmd.CommandText = "insert into keywords values('" + s2 + "','" + (row + 1) + "')";
                        row = cmd.ExecuteNonQuery();
                        if (row != 1)
                            Response.Write("error");
                    Lab: ;// TextBox1.Text = TextBox1.Text + s2 + "\n";
                    }
                }
                sr.Close();
                Index.Gen_Index(res.ToArray(), fname);
            }
            ENC.Enabled = true;
            Gen_Keys.Enabled = false;
        }
        string pass;
        protected void ENC_Click(object sender, EventArgs e)
        {
            string text = fcontent;
            text = Encrypter.EncryptText(text,out pass);
            TextBox1.Text = text;
            ENC.Enabled = false;
            string name = fname;
            string content = text; ;
            OleDbConnection con;
            try
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                con.CreateCommand();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into FileDetails values('" + name + "','" + content + "','" + pass + "','" + owner + "')";
                int rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                    Response.Write("Rows insertion not done");
                con.Close();
            }
            catch (Exception eds)
            {
                Response.Write(eds.ToString());
            }
        }

        protected void check_panel_Load(object sender, EventArgs e)
        {
            OleDbConnection con;
            try
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from Requests where Data_Owner like '" + owner + "'";
                OleDbDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                    Checked_Results.Text = "No Pending Requests";
                else
                {
                    int files = 0;
                    while (dr.Read())
                        files++;
                    if (files > 5)
                        files = 5;
                    dr.Close();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    char c = char.Parse(files.ToString());
                    switch (int.Parse(c.ToString()))
                    {
                        case 5:
                            Panel5.Visible = true;
                            File_Name5.Text = dr.GetString(1);
                            File_User5.Text = dr.GetString(2);
                            if (dr.Read())
                                goto case 4;
                            else
                            {
                                break;
                            }

                        case 4:
                            Panel4.Visible = true;
                            File_Name4.Text = dr.GetString(1);
                            File_User4.Text = dr.GetString(2);
                            if (dr.Read())
                                goto case 3;
                            else
                            {
                                break;
                            }
                        case 3:
                            Panel3.Visible = true;
                            File_Name3.Text = dr.GetString(1);
                            File_User3.Text = dr.GetString(2);
                            if (dr.Read())
                                goto case 2;
                            else
                            {
                                break;
                            }
                        case 2:
                            Panel2.Visible = true;
                            File_Name2.Text = dr.GetString(1);
                            File_User2.Text = dr.GetString(2);
                            if (dr.Read())
                                goto case 1;
                            else
                            {
                                break;
                            }
                        case 1:
                            Panel1.Visible = true;
                            File_Name1.Text = dr.GetString(1);
                            File_User1.Text = dr.GetString(2);
                            if (dr.Read())
                                goto case 0;
                            else
                            {
                                break;
                            }
                        case 0:
                        default:
                            break;
                    }
                    dr.Close();
                }
                con.Close();
            }
            catch (Exception ees)
            {
                Response.Write(ees.ToString());
            }
        }

        protected void Accept_click(object sender, EventArgs e)
        {
            OleDbConnection con;
            OleDbCommand cmd;
            string filename = "", username = "";
            try
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                Button b = (Button)sender;
                if (b.ID.Equals("Accept1"))
                {
                    filename = File_Name1.Text;
                    username = File_User1.Text;
                }
                else if (b.ID.Equals("Accept2"))
                {
                    filename = File_Name2.Text;
                    username = File_User2.Text;
                }
                else if (b.ID.Equals("Accept3"))
                {
                    filename = File_Name3.Text;
                    username = File_User3.Text;
                }
                else if (b.ID.Equals("Accept4"))
                {
                    filename = File_Name4.Text;
                    username = File_User4.Text;
                }
                else if (b.ID.Equals("Accept5"))
                {
                    filename = File_Name5.Text;
                    username = File_User5.Text;
                }
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from Requests where File_Name like '" + filename + "' and Data_User like '" + username + "'";
                OleDbDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    Debug.WriteLine(cmd.CommandText);
                    Response.Write("<script>alert(\"Sorry error occured\");</script>");
                    dr.Close();
                    Response.Redirect("http://www.rvrjcce.ac.in");
                }
                dr.Close();
                cmd.CommandText = "update Requests set Access = 'Accepted' where File_Name like '" + filename + "' and Data_User like '" + username + "';";
                mailto("Enjoy");
                int rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                    Response.Write("Shit something happened");
                cmd.CommandText = "delete from Requests where File_Name like '" + filename + "' and Data_User like '" + username + "'";
                rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                    Response.Write("Shit something happened");
                Response.Redirect("DataOwner.aspx");
            }
            catch (Exception cse)
            {
                Debug.WriteLine(cse.ToString());
            }
        }

        protected void mailto(string message)
        {
            WebRequest.DefaultWebProxy = new WebProxy("10.1.1.4", 8080);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("project991927966@gmail.com");
                mail.To.Add("aditya.pentyala@outlook.com");
                mail.Subject = "For Data Using";
                mail.Body = message;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("project991927966@gmail.com", "991927966");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                Debug.WriteLine(Environment.NewLine + "message sent");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Message not sent" + ex.ToString());
            }
        }

        protected void Reject_click(object sender, EventArgs e)
        {
            OleDbConnection con;
            OleDbCommand cmd;
            string filename = "", username = "";
            try
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                Button b = (Button)sender;
                if (b.ID.Equals("Reject1"))
                {
                    filename = File_Name1.Text;
                    username = File_User1.Text;
                }
                else if (b.ID.Equals("Reject2"))
                {
                    filename = File_Name2.Text;
                    username = File_User2.Text;
                }
                else if (b.ID.Equals("Reject3"))
                {
                    filename = File_Name3.Text;
                    username = File_User3.Text;
                }
                else if (b.ID.Equals("Reject4"))
                {
                    filename = File_Name4.Text;
                    username = File_User4.Text;
                }
                else if (b.ID.Equals("Reject5"))
                {
                    filename = File_Name5.Text;
                    username = File_User5.Text;
                }
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from Requests where File_Name like '" + filename + "' and Data_User like '" + username + "'";
                OleDbDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    Debug.WriteLine(cmd.CommandText);
                    Response.Write("<script>alert(\"Sorry error occured\");</script>");
                    dr.Close();
                    Response.Redirect("http://www.rvrjcce.ac.in");
                }
                dr.Close();
                cmd.CommandText = "update Requests set Access = 'Rejected' where File_Name like '" + filename + "' and Data_User like '" + username + "';";
                int rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                    Response.Write("Shit something happened");
                //Mail code here. Key is automatically mailed to user
                cmd.CommandText = "delete from Requests where File_Name like '" + filename + "' and Data_User like '" + username + "'";
                rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                    Response.Write("Shit something happened");
                Response.Redirect("DataOwner.aspx");
            }
            catch (Exception cse)
            {
                Debug.WriteLine(cse.ToString());
            }
        }

        

        public Encrypter Encrypter1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}