using System.Data;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
namespace MVCDemo.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public static List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Employee";

                SqlDataReader dr = cmd.ExecuteReader();
              

                while (dr.Read())
                {
                    Employee obj = new Employee();
                    

                    obj.Name = dr.GetString("Name"); ;
                    obj.EmpNo = dr.GetInt32("EmpNo");
                    obj.Basic = dr.GetDecimal("Basic");
                    obj.DeptNo = dr.GetInt32("DeptNo");
                    employees.Add(obj);
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
            return employees;
        }
        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee obj = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Employee where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj = new Employee();
                    obj.Name = dr.GetString("Name"); ;
                    obj.EmpNo = dr.GetInt32("EmpNo");
                    obj.Basic = dr.GetDecimal("Basic");
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
