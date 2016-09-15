using System;
using System.Diagnostics;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace Final_Project
{
    public class Index
    {
    
        public static void Gen_Index(string[] keys, string file_id)
        {
            OleDbConnection con = null, con1 = null;
            OleDbCommand cmd;
            try
            {
                for(int k=0;k<keys.Length;k++)
                    Debug.WriteLine(keys[k]);
                con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Cloud.accdb");
                con1.Open();
                con.Open();
                cmd = con1.CreateCommand();
                Thread.Sleep(2000);
                cmd.CommandText = "select count(*) from Keywords";
                OleDbDataReader dr;
                int i = (int)cmd.ExecuteScalar();
                Debug.WriteLine(i);
                char[] ch = new char[i];
                for (int j = 0; j < ch.Length; j++)
                    ch[j] = '0';
                i = 0;
                cmd.CommandText = "select * from Keywords";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bool flag = true;
                    foreach (string s in keys)
                    {
                        // Debug.WriteLine(s + "  " + dr.GetString(0));
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
                OleDbCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "insert into Ind values('" + file_id + "','" + final + "')";
                Debug.WriteLine(cmd2.CommandText);
                int row = cmd2.ExecuteNonQuery();

            }
            catch (Exception es)
            {

                Debug.WriteLine(es.ToString());
            }
            finally
            {
                reindex();
                con.Close();
                con1.Close();
            }
        }

        public static void reindex()
        {
            OleDbConnection con,con1;
            try    
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Cloud.accdb");
                con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from Ind";
                OleDbDataReader dr = cmd.ExecuteReader();
                int len = 0;
                while (dr.Read())
                {
                    if (len < dr.GetString(1).Length)
                        len = dr.GetString(1).Length;
                }
                dr.Close();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string str = dr.GetString(1);
                    if (len > str.Length)
                    {
                        while (str.Length < len)
                        {
                            str = str + "0";
                        }
                        OleDbCommand cmdd = con.CreateCommand();
                        cmdd.CommandText = "update Ind set KeyCode = '" + str + "' where File_Id like '" + dr.GetString(0) + "'";
                        Debug.WriteLine(cmdd.CommandText);
                        int r = cmdd.ExecuteNonQuery();
                        if (r != 1)
                            Debug.WriteLine("Shitted");
                    }
                }
                dr.Close();
            }
            catch (Exception easd)
            {
                Debug.WriteLine("Error in Index.Reindex() " + easd.ToString());
            }

            #region Old_Code
            /* OleDbConnection con = null, con1 = null ;
            OleDbCommand cmd, cmd2;
            try
            {
                con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Project.accdb");
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Cloud.accdb");
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from Ind";
                int i = 0;
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    i++;
                dr.Close();
                string[] files = new string[i];
                string[] codes = new string[i];
                dr = cmd.ExecuteReader();
                i = 0;
                while (dr.Read())
                {
                    files[i] = dr.GetString(0);
                    codes[i] = dr.GetString(1);
                    i++;
                }
                dr.Close();
                int temp = 0;
                for (int s=0; s < files.Length;s++)
                {
                    int count = 0;
                    con1.Open();
                    cmd2 = con1.CreateCommand();
                    char[] ch = codes[s].ToCharArray();
                    for (int j = 0; j < ch.Length; j++)
                    {
                        if (ch[j] == '1')
                        {
                            count++;
                        }
                    }
                    temp = 0;
                    string[] keys = new string[count];
                    for (int j = 0; j < ch.Length; j++)
                    {
                        if (ch[j] == '1')
                        {
                            cmd2.CommandText = "select * from keywords";
                            dr = cmd2.ExecuteReader();
                            dr.Read();
                            for (int t = 1; t < j; t++)
                            {
                                dr.Read();
                            }
                                keys[temp] = dr.GetString(0);
                                temp++;
                            
                            dr.Close();
                        }
                    }
                    foreach (string k in keys)
                        Debug.WriteLine(k+ "  ");
                    cmd = con.CreateCommand();
                    cmd.CommandText = "delete from Ind where File_ID like '" + files[s] + "'";
                    int r = cmd.ExecuteNonQuery();
                    Gen_Index(keys, files[s]);
                    con1.Close();
                }
            }
            catch (Exception asdd)
            {
                Debug.WriteLine(asdd.ToString());
            }
            finally
            {
                con.Close();
                con1.Close();
            }
        }*/

            #endregion

        }
    }
}
