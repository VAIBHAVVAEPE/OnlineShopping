using Microsoft.Data.SqlClient;

namespace OnlineShopping.Models
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public UserDAL()
        {
            con = new SqlConnection("Server=LAPTOP-BAI3NT2J\\SQLEXPRESS;Database=Shopping;Trusted_Connection=True;MultipleActiveResultSets=true");

        }
        public int Register(User u)
        {
            string str = "insert into Userrr values (@Name,@EmailId,@Password)";
            cmd= new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name",u.Name);
            cmd.Parameters.AddWithValue("@EmailId",u.Email);
            cmd.Parameters.AddWithValue("@Password",u.Password);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public User Varify(string Email)
        {
            User u = new User();
            string str = "Select * from Userrr where EmailId=@EmailId";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@EmailId", Email);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    u.Password = dr["Password"].ToString();
                    
                }
                con.Close();
                return u;
            }
            con.Close();
            return u;
        }
    }
}
