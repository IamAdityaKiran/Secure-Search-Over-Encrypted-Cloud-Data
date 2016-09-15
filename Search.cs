using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Web;
using System.Diagnostics;
using CSML;

namespace Final_Project
{
    public class Search
    {
        public string[] SearchFiles(string queryVector)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Aditya Project\Cloud.accdb");
                OleDbCommand cmd;
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from Ind";
                OleDbDataReader dr = cmd.ExecuteReader();
                int n = 0;
                while (dr.Read())
                    n++;
                dr.Close();
                Dictionary<string, int> score = new Dictionary<string, int>();
                dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                { 
                    char[] p1 = queryVector.ToCharArray();
                    char[] p2 = dr.GetString(1).ToCharArray();
                    Debug.WriteLine(dr.GetString(1)+"  ,  "+queryVector);
                    int res = 0;
                    for (int l = 0; l < p1.Length; l++)
                    {
                        if (p1[l] == '1' && p2[l] == '1')
                            res += 1;
                        else
                            res += 0;
                    }
                    i++;
                    
                    score.Add(dr.GetString(0), res);
                    Debug.WriteLine(dr.GetString(0) + "  score is   " + res);
                }
                var items = from pair in score
                            orderby pair.Value descending
                            select pair;

                List<string> asl = new List<string>();
                foreach (KeyValuePair<string, int> pair in items)
                {
                    asl.Add(pair.Key);
                }
                return asl.ToArray();
            }
                
            catch (Exception easd)
            {
                Debug.Write("EE RRR ORR" + easd);
            }
            
                return null;
            
        }

        public float[,] original, inverse, original1, inverse1;

        public void genTrapdoor(string qvector)
        {
            string q_dash,q_2dash;
            split(qvector,out q_dash,out q_2dash);
            int order = qvector.Length;

            char[] vec = q_dash.ToCharArray();
            string[] qvec = new string[vec.Length];
            float[] fqvector = new float[vec.Length];
            for (int i = 0; i < vec.Length; i++)
            {
                qvec[i] = vec[i].ToString();
                fqvector[i] = float.Parse(vec[i].ToString());
            }
            vec = q_dash.ToCharArray();
            qvec = new string[vec.Length];
            float[] fqvector1 = new float[vec.Length];
            for (int i = 0; i < vec.Length; i++)
            {
                qvec[i] = vec[i].ToString();
                fqvector1[i] = float.Parse(vec[i].ToString());
            }

            genMatrix(order, out inverse, out original);
            genMatrix(order, out inverse1, out original1);
            //multiplication function definition
            fqvector=multiply(inverse, fqvector, fqvector.Length);
            fqvector1=multiply(inverse1, fqvector1, fqvector1.Length);
            Debug.WriteLine("succesfully searched and generated the vector");
        }

        private float[] multiply(float[,] inverse1, float[] fqvector1,int len)
        {
            float sum = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    sum = sum + inverse[i, j] * fqvector1[i];
                }
                fqvector1[i] = sum;
                sum = 0;
            }
            return fqvector1;
            throw new NotImplementedException();
        }

        public char[] ch;
        public bool asd = true;

        private void split(string qvector, out string q_dash, out string q_2dash)
        {
            int len = qvector.Length;
            ch = new char[len];
            if (asd)
            {
                Random rand = new Random();
                for (int i = 0; i < len; i++)
                    ch[i] = Convert.ToChar(rand.Next(0, 2).ToString());
                asd = false;
            }
            q_dash=exor(qvector,ch);
            q_2dash=exor(qvector, ch);
        }

        private string exor(string qvector, char[] ch)
        {
            if (qvector.Length != ch.Length)
                throw new InvalidCastException("Shitted again");
            char[] c = qvector.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == '0' && c[i] == '0')
                {
                    ch[i] = '0';
                }
                else if (ch[i] == '0' && c[i] == '1')
                {
                    ch[i] = '1';
                }
                else if (ch[i] == '1' && c[i] == '0')
                {
                    ch[i] = '1';
                }
                else if (ch[i] == '1' && c[i] == '1')
                {
                    ch[i] = '0';
                }
            }
            return new string(ch);
        }

        public string removestring(string s)
        {
            char[] ch = s.ToCharArray();
            string ks = "", test = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (ch[i] != '\n')
                    test = test + ch[i];
            }
            char[] temp = test.ToCharArray();
            test = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (ch[i] != ' ' && ch[i] != '\t')
                {
                    if (ch[i] == '\\')
                    {
                        ;
                    }
                    else
                    {
                        test = test + ch[i];
                    }
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (ch[i] != ' ' && ch[i] != '\t')
                {
                    if (ch[i] == '\\')
                    {
                        ;
                    }
                    else
                    {
                        ks = ks + ch[i];
                    }
                }
            }
            return test + ks;
        }

        ///<summary>
        ///<para>Order is the size of array to be returned</para>
        ///<para>generates two matrices <code>res_mat</code> is the inverse and <code>res_mat1</code> is the original matrix</para>
        ///</summary>
        public void genMatrix(int order,out float[,] res_mat,out float[,] res_mat1)
        {
            res_mat = null;
            res_mat1 = null;
            try
            {
                int l = 1;
                int h = 10;
                int[,] matrix = GenerateMatrix(order, l, h);
                string ma = "";
                int j;
                for (int i = 0; i < 2; i++)
                {
                    for (j = 0; j < 1; j++)
                    {
                        ma = ma + matrix[i, j] + ",";
                        //Debug.Write(matrix[i, j] + "    ");
                    }
                    if (i != 1)
                        ma = ma + matrix[i, j] + ";";
                    else
                        ma = ma + matrix[i, j];
                    //Debug.Write(matrix[i, j] + "    ");
                }
                Matrix m = new Matrix(ma);
                Matrix ask = m;
                Complex c = m.Determinant();
                Matrix mas = m.Inverse();
                string result_matrix = removestring(mas.ToString());
                res_mat = new float[order, order];
                string[] part = result_matrix.Split(new char[] { ';', '\\', '\t' });
                //Console.Write(part.Length);
                int p = 0, k = 0;
                foreach (string a in part)
                {
                    res_mat[p, k] = (float)int.Parse(a);
                    k++;
                    if (k == order)
                    {
                        k = 0;
                        p++;
                    }
                }
                mas = ask;
                result_matrix = removestring(mas.ToString());
                res_mat1 = new float[order, order];
                part = result_matrix.Split(new char[] { ';', '\\', '\t' });
                //Console.Write(part.Length);
                p = 0;
                k = 0;
                foreach (string a in part)
                {
                    res_mat1[p, k] =(float)int.Parse(a);
                    k++;
                    if (k == order)
                    {
                        k = 0;
                        p++;
                    }
                }
            }
            catch (Exception eSAD)
            {
                Debug.WriteLine(eSAD.ToString());
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