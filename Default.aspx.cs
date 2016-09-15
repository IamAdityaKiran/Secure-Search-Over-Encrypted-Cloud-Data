using System;
using CSML;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Globalization;

namespace Final_Project
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///<important>
            ///Need to add a cookie for message. This bit of data is used to show to user in home page.
            ///</important>
        }

        protected void Login_Clicked(object sender, EventArgs e)
        {
            HttpCookie user_cook = new HttpCookie("username");
            DateTime t = DateTime.Now;
            t = t.AddDays(1);
            user_cook.Expires = t;
            HttpCookie pass_cook = new HttpCookie("password");
            HttpCookie type_cook = new HttpCookie("usertype");
            String user = "", pass = "";
            user = username.Text;
            pass = Password.Text;
            if (user == "admin" && pass == "admin")
            {
                user_cook.Value = "admin";
                pass_cook.Value = "admin";
                type_cook.Value = "admin";
                Response.Cookies.Add(user_cook);
                Response.Cookies.Add(pass_cook);
                Response.Cookies.Add(type_cook);
                Response.Redirect("Admin.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                OleDbConnection con;
                try
                {
                    con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandText = "select * from User_Details where Username like '" + user + "'";
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        if (pass != dr.GetString(1))
                        {
                            Response.Redirect("Default.aspx",false);
                            Context.ApplicationInstance.CompleteRequest();
                        } 
                        if (dr.GetString(2) == "DataUser")
                        {
                            user_cook.Value = dr.GetString(0);
                            pass_cook.Value = dr.GetString(1);
                            type_cook.Value = "DataUser";
                            Response.Cookies.Add(user_cook);
                            Response.Cookies.Add(pass_cook);
                            Response.Cookies.Add(type_cook);
                            Response.Redirect("UserHome.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            Response.Write("<script>alert('shafok');</script>");
                            user_cook.Value = dr.GetString(0);
                            pass_cook.Value = dr.GetString(1);
                            type_cook.Value = "DataOwner";
                            Response.Cookies.Add(user_cook);
                            Response.Cookies.Add(pass_cook);
                            Response.Cookies.Add(type_cook);
                            Response.Redirect("DataOwner.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx",false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    con.Close();
                }
                catch (Exception es)
                {
                    Debug.Write("Error at " + es.ToString());
                }
                finally
                {
                    Response.Write("end");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Index.reindex();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int order = 2;
            int l =1;
            int h = 10;
            int[,] matrix = GenerateMatrix(order, l, h);
            Response.Write("<p><h3>");
            string ma = "";
            int j;
            for (int i = 0; i < 2; i++)
            {
                for (j = 0; j < 1; j++)
                {
                    ma = ma + matrix[i, j] + ",";
                    Response.Write(matrix[i, j]+"    ");
                }
                if (i != 1)
                    ma = ma + matrix[i, j] + ";";
                else
                    ma = ma + matrix[i, j];
                Response.Write(matrix[i, j] + "    ");
                Response.Write("<br />");
            }
            Matrix m = new Matrix(ma);
            Complex c = m.Determinant();
            Matrix mas = m.Inverse();
            string result_matrix = mas.ToString();
            //Debug.Write(mas);
            Response.Write(mas);
            float[,] res_mat = new float[2, 2];
            string[] part = result_matrix.Split(new char[] {';'});
            int tempp = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int k = 0; k < 2; k++)
                {
                    
                    part[tempp].Trim();
                    part[tempp].Replace("\t", "");
                    part[tempp].Replace("\\", "");
                    part[tempp].Replace(Environment.NewLine, "");
                    if (part[tempp].Contains(" ") || part[tempp].Equals("\\"))
                    {
                        tempp++;
                        k--;
                        continue;
                    }
                    Debug.WriteLine(part[tempp]);
                    
                   // res_mat[i, k] = float.Parse(part[tempp]);
                    Response.Write(res_mat[i,k].ToString() + " ");
                    tempp++;
                }
                Response.Write(part[tempp] + "    ");
                Response.Write("<br />");
            }
        }
        public int[,] GenerateMatrix(int order, int l, int h)
        {
            int[,] matrix = new int[order, order];
            Random rand = new Random();
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    matrix[i, j] = rand.Next(l, h + 1);
                }
            }
            return matrix;
        }
    }
}