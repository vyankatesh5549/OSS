using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;
namespace DAL
{
    public class EmployeeDAL
    {
        public static string ConnectionString = @"server=localhost;user=root;database=knowitdb;password='vyankatesh@2004'";
       

        public static List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            IDbConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                string query = "SELECT * From employee";
                IDbCommand cmd = new MySqlCommand(query, conn as MySqlConnection);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Employee emp = new Employee();
                    emp.ID = int.Parse(reader["eid"].ToString());
                    emp.Name = reader["name"].ToString();
                    emp.Location = reader["location"].ToString();
                    emp.MobNo = reader["mobNo"].ToString();
                    emp.salary = reader["salary"].ToString();
                    employees.Add(emp);
                }
                reader.Close();
            }
            catch(MySqlException e)
            {
                string er = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return employees;
        }

       

        public static BOL.Employee GetById(int id)
        {
            BOL.Employee emp = new BOL.Employee();
           
            IDbConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                string query = "SELECT * From employee where eid=" + id;
                IDbCommand cmd = new MySqlCommand(query, conn as MySqlConnection);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    emp.ID = int.Parse(reader["eid"].ToString());
                    emp.Name = reader["name"].ToString();
                    emp.Location = reader["location"].ToString();
                    emp.MobNo = reader["mobNo"].ToString();
                    emp.salary = reader["salary"].ToString();

                }
                reader.Close();
            }
            catch(MySqlException e)
            {
                string err = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return emp;
        }
        public static bool Delete(int id)
        {
            bool flag = false;
            IDbConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                string query = "DELETE From employee where eid=" + id;
                IDbCommand cmd = new MySqlCommand(query, conn as MySqlConnection);
                cmd.CommandType = CommandType.Text;
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    flag = true;
                }
            }
            catch (MySqlException e)
            {
                string err = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public static bool Insert(Employee emp)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(ConnectionString);
            try
            {
                con.Open();
                string query = "INSERT INTO employee (eid,name,location,mobNo,salary) values(" +
                                      emp.ID + ",'" + emp.Name + "','" + emp.Location + "','"+emp.MobNo+"','"+emp.salary+"')";
                IDbCommand cmd = new MySqlCommand(query, con as MySqlConnection);
                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                string exeMessage = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return status;
        }
        public static bool Update(Employee emp)
        {
            bool flag = false;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                string query = "UPDATE employee SET name='" + emp.Name + "',location='"
                                + emp.Location + "',mobNo='" + emp.MobNo + "',salary='" + emp.salary + "'WHERE eid=" + emp.ID;

                IDbCommand cmd = new MySqlCommand(query,conn as MySqlConnection);
            
                cmd.CommandType = CommandType.Text; 
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    flag = true;
                }

            }
            catch(MySqlException e)
            {
                string err = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }

    }
}
