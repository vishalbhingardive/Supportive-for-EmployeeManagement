using EmployeeServices.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServices.Services
{
    public class EmployeeService
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;


        public List<Employees> GetAll()
        {
            var employees = new List<Employees>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "GetAll_Employees";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new Employees
                            {
                               EmployeeId = (int)reader["EmployeeId"],
                               Name = (string)reader["Name"],
                               Gender=(string)reader["Gender"],
                               Age = (int)reader["Age"],
                                Address = (string)reader["Address"],
                                Department = (string)reader["Department"],
                                DateOfJoining= (DateTime)reader["DateOfJoining"],
                                Email = (string)reader["Email"],
                                JobId = (int)reader["JobId"]
                            };
                            employees.Add(employee);
                        }
                    }
                }

            }
            return employees;
        }

        public void Add(Employees employee)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "Add_Employees";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@JobId", employee.JobId);
                   
                  
                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");

                }
            }
        }

        public void Update(Employees employee)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "Employee_Update";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@JobId", employee.JobId);

                    connection.Open();
                    var rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected != 1)

                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");

                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "Employee_Delete";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", id);
                    connection.Open();
                    var rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected != 1)

                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");

                }
            }
        }

        public Employees GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "Employee_GetById";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var employees = new Employees
                            {
                                EmployeeId = (int)reader["EmployeeId"],
                                Name = (string)reader["Name"],
                                Gender = (string)reader["Gender"],
                                Age = (int)reader["Age"],
                                Address = (string)reader["Address"],
                                Department = (string)reader["Department"],
                                DateOfJoining = (DateTime)reader["DateOfJoining"],
                                Email = (string)reader["Email"],
                                JobId = (int)reader["JobId"],
                               
                            };
                            return employees;
                        }
                    }
                }
            }

            return null;
        }
    }
}
