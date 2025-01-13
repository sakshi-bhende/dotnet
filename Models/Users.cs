using Microsoft.Data.SqlClient;
using System.Data;

namespace MVCDemo.Models
{
    public class Users
    {

        public int UserId { get; set; }
        public string Name { get; set; }

        public int DeptNo { get; set; }


        public static List<Users> GetAllUser()
        {
            List<Users> user = new List<Users>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Users";

                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Users obj = new Users();


                    obj.Name = dr.GetString("Name"); ;
                    obj.UserId = dr.GetInt32("UserId");
                    // obj.Basic = dr.GetDecimal("Basic");
                    obj.DeptNo = dr.GetInt32("DeptNo");
                    user.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return user;
        }

        public static void Update(Users obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                // SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Users set Name=@Name,DeptNo=@DeptNo where UserId=@UserId";

                cmd.Parameters.AddWithValue("@Name", obj.Name);
                // cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.Parameters.AddWithValue("@UserId", obj.UserId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static Users GetSingleUser(int UserId)
        {
            Users obj = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Users where UserID=@UserId";
                cmd.Parameters.AddWithValue("@UserId", UserId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj = new Users();
                    obj.Name = dr.GetString("Name"); ;
                    obj.UserId = dr.GetInt32("UserId");
                   // obj.Basic = dr.GetDecimal("Basic");
                    obj.DeptNo = dr.GetInt32("DeptNo");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }


    }
}
