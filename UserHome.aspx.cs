using System;
using MLApp;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Threading;

namespace Final_Project
{
    public partial class UserHome : System.Web.UI.Page
    {
        string name = "Prasad";

        public Index Index
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Encrypter Encrypter
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Search Search
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie user_cook = null;
            //HttpCookie pass_cook = null;
            //HttpCookie type_cook = null;
            //user_cook = Request.Cookies["username"];
            //pass_cook = Request.Cookies["password"];
            //type_cook = Request.Cookies["usertype"];
            //if (user_cook == null || pass_cook == null || type_cook == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            //if (type_cook.Value != "DataUser")
            //{
            //    Response.Redirect("Default.aspx");
            //}
            //name = user_cook.Value;
            sc = new Search();
        }
        Search sc;
        protected void Search_Click(object sender, EventArgs e)
        {
            string search_keys_comp = Keywords.Text;
            string[] search_keys = search_keys_comp.Split(new char[] { ' ', '\n', '\t', ',', '.', '(', ')', ':', ';', '[', ']', '?', '\'', '\\', '/', '>', '<', '!', '@', '`', '~', '#', '$', '%', '^', '&', '*', '_', '+', '=','-','\"','\'' });
            OleDbConnection con = null, con1 = null;
            OleDbCommand cmd;
            try
            {
                con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Cloud.accdb");
                con1.Open();
                con.Open();
                cmd = con1.CreateCommand();
                cmd.CommandText = "select * from Keywords  ";
                OleDbDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                    i++;
                char[] ch = new char[i];
                for (int j = 0; j < ch.Length; j++)
                    ch[j] = '0';
                i = 0;
                dr.Close();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bool flag = true;
                    foreach (string s in search_keys)
                    {
                        if (s.Equals(dr.GetString(0)))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag == false)
                        ch[int.Parse(dr.GetString(1)) - 1] = '1';//no:of times a keyword occurs...
                }
                dr.Close();
                string final = new string(ch);
                string[] filenames =sc.SearchFiles(final);
                Thread.Sleep(2000);
                try
                {
                    con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM FileDetails";
                    dr = cmd.ExecuteReader();
                    int files = 0;
                    while (dr.Read())
                        files++;
                    files = filenames.Length;
                    if (files > 10)
                        files = 10;
                    dr.Close();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    //char c = char.Parse(files.ToString());
                    switch (files)
                    { 
                        case 10:
                            Panel10.Visible = true;
                            File_Name10.Text = filenames[9];
                            File_Owner10.Text = getName(filenames[9]);
                            dr.Read();
                            goto case 9;
                        case 9:
                            Panel9.Visible = true;
                            File_Name9.Text = filenames[8];
                            File_Owner9.Text = getName(filenames[8]);
                            if (dr.Read())
                                goto case 8;
                            else
                            {
                                break;
                            }
                        case 8:
                            Panel8.Visible = true;
                            File_Name8.Text = filenames[7];
                            File_Owner8.Text = getName(filenames[7]);
                            if (dr.Read())
                                goto case 7;
                            else
                            {
                                break;
                            }
                        case 7:
                            Panel7.Visible = true;
                            File_Name7.Text = filenames[6];
                            File_Owner7.Text = getName(filenames[6]);
                            if (dr.Read())
                                goto case 6;
                            else
                            {
                                break;
                            }
                        case 6:
                            Panel6.Visible = true;
                            File_Name6.Text = filenames[5];
                            File_Owner6.Text = getName(filenames[5]);
                            if (dr.Read())
                                goto case 5;
                            else
                            {
                                break;
                            }

                        case 5:
                            Panel5.Visible = true;
                            File_Name5.Text = filenames[4];
                            File_Owner5.Text = getName(filenames[4]);
                            if (dr.Read())
                                goto case 4;
                            else
                            {
                                break;
                            }

                        case 4:
                            Panel4.Visible = true;
                            File_Name4.Text = filenames[3];
                            File_Owner4.Text = getName(filenames[3]);
                            if (dr.Read())
                                goto case 3;
                            else
                            {
                                break;
                            }
                        case 3:
                            Panel3.Visible = true;
                            File_Name3.Text = filenames[2];
                            File_Owner3.Text = getName(filenames[2]);
                            if (dr.Read())
                                goto case 2;
                            else
                            {
                                break;
                            }
                        case 2:
                            Panel2.Visible = true;
                            File_Name2.Text = filenames[1];
                            File_Owner2.Text = getName(filenames[1]);
                            if (dr.Read())
                                goto case 1;
                            else
                            {
                                break;
                            }
                        case 1:
                            Panel1.Visible = true;
                            File_Name1.Text = filenames[0];
                            File_Owner1.Text = getName(filenames[0]);
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
                catch (Exception asd)
                {
                    Response.Write(asd.ToString());
                }
            }
            catch (Exception asdf)
            {
               
            }
        }
        protected void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string k = "", s = b.ID, owner = "";
            if (s.Equals("Button8"))
            {
                owner = File_Owner8.Text;
                k = File_Name8.Text;
            }
            else if (s.Equals("Button7"))
            {
                owner = File_Owner7.Text;
                k = File_Name7.Text;
            }
            else if (s.Equals("Button6"))
            {
                owner = File_Owner6.Text;
                k = File_Name6.Text;
            }
            else if (s.Equals("Button5"))
            {
                owner = File_Owner5.Text;
                k = File_Name5.Text;
            }
            else if (s.Equals("Button4"))
            {
                owner = File_Owner4.Text;
                k = File_Name4.Text;
            }
            else if (s.Equals("Button3"))
            {
                owner = File_Owner3.Text;
                k = File_Name3.Text;
            }
            else if (s.Equals("Button2"))
            {
                owner = File_Owner2.Text;
                k = File_Name2.Text;
            }
            else if (s.Equals("Button1"))
            {
                owner = File_Owner1.Text;
                k = File_Name1.Text;
            }
            else if (s.Equals("Button10"))
            {
                owner = File_Owner10.Text;
                k = File_Name10.Text;
            }
            else if (s.Equals("Button9"))
            {
                owner = File_Owner9.Text;
                k = File_Name9.Text;
            }
            OleDbConnection con1 = null;
            try
            {
                con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con1.Open();
                OleDbCommand cmd = con1.CreateCommand();
                cmd.CommandText = "insert into Requests values('" + owner + "','" + k + "','" + name + "','')";
                int t = cmd.ExecuteNonQuery();
                if (t != 1)
                    Debug.WriteLine("Error");
            }
            catch (Exception asd)
            {
                Debug.WriteLine(asd.ToString());
            }
            finally
            {
                con1.Close();
            }
            Response.Write("<script>alert('Request sent to " + owner + "! Please check your mail');</script>");
            OleDbConnection con;
            try
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM FileDetails where File_Id like '" + k + "'";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                dr.Read();
                filecontents.Text = dr.GetString(1);
                filename.Text = dr.GetString(0);
                After_Req.Visible = true;
                dr.Close();
            }
            catch (Exception sad)
            {

                Response.Write(/*"<script>Alert('Error occurred " +*/ sad.ToString() + "'");
            }
            finally
            {
                After_Req.Visible = true;
            }
        }

        protected void decrypt_Click(object sender, EventArgs e)
        {
            string text = Encrypter.DecryptText(filecontents.Text, key.Text,Response);
            filecontents.Text = text;
        }

        public string getName(string name)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from FileDetails where File_Id like '" + name + "'";
                OleDbDataReader dr = cmd.ExecuteReader();
                string owner = "";
                while (dr.Read())
                    owner = dr.GetString(3);
                return owner;
            }
            catch (Exception easdf)
            {
            }
            return null;
        }

    }
}