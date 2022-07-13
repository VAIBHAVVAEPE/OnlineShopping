using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace OnlineShopping.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionStrings);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product> ();
            string str = "Select * from Producttt";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader(); 
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Product p = new Product();
                    p.PId = Convert.ToInt32(dr["PId"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Pprice = Convert.ToInt32(dr["Pprice"]);
                    p.Pdescription = dr["Pdescription"].ToString();
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                return list;
            }

        }
        public Product GetProductById(int PId)
        {
            Product p = new Product();
            string str = "select * from Producttt where PId=@PId";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@PId", PId);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.PId = Convert.ToInt32(dr["PId"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Pdescription = dr["Pdescription"].ToString();
                    p.Pprice = Convert.ToInt32(dr["Pprice"]);

                }
                con.Close();
                return p;    
            }
            else
            {
                con.Close();
                return p;
            }

        }
        public int Save(Product prod)
        {
            string str = "insert into Producttt values(@Pname,@Pprice,@Pdescription)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Pname", prod.Pname);
            cmd.Parameters.AddWithValue("@Pprice", prod.Pprice);
            cmd.Parameters.AddWithValue("@Pdescription", prod.Pdescription);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Update(Product prod)
        {
            string str = "update Producttt set Pname=@Pname,Pprice=@Pprice ,Pdescription=@Pdescription where PId=@PId";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@PId", prod.PId);
            cmd.Parameters.AddWithValue("@Pname", prod.Pname);
            cmd.Parameters.AddWithValue("@Pprice", prod.Pprice);
            cmd.Parameters.AddWithValue("@Pdescription", prod.Pdescription);

            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int PId)
        {
            string str = "delete from Producttt where PId=@PId";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@PId", PId);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

    }
}
