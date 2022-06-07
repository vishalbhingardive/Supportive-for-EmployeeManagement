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
    public class JobService
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;


        public List<Job> GetAll()
        {
            var jobs = new List<Job>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "GetAll_Jobs";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var job = new Job
                            {
                               JobId = (int) reader["JobId"],
                               Title = (string) reader["Title"],
                               NumberofPositions = (int)reader["NumberofPositions"],
                               Location = (string)reader["Location"],
                               SalaryRange = (int)reader["SalaryRange"]
                            };
                            jobs.Add(job);
                        }
                    }
                }

            }
            return jobs;
        }

        public void Add(Job job)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "Add_Job";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Title", job.Title);
                    command.Parameters.AddWithValue("@NumberofPositions", job.NumberofPositions);
                    command.Parameters.AddWithValue("@Location", job.Location);
                    command.Parameters.AddWithValue("@SalaryRange", job.SalaryRange);
                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");

                }
            }
        }

        public void Update(Job job)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "Job_Update";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@JobId", job.JobId);
                    command.Parameters.AddWithValue("@Title", job.Title);
                    command.Parameters.AddWithValue("@NumberofPositions", job.NumberofPositions);
                    command.Parameters.AddWithValue("@Location", job.Location);
                    command.Parameters.AddWithValue("@SalaryRange", job.SalaryRange);
                    
                    

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
                const string cmdText = "Job_Delete";
                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@JobId", id);
                    connection.Open();
                    var rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected != 1)

                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");

                }
            }
        }

        public Job GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string cmdText = "Job_GetById";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@JobId", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var job = new Job
                            {
                                JobId = (int)reader["JobId"],
                                Title = (string)reader["Title"],
                                NumberofPositions = (int)reader["NumberofPositions"],
                                Location = (string)reader["Location"],
                                SalaryRange = (int)reader["SalaryRange"],
                               

                            };
                            return job;
                        }
                    }
                }
            }

            return null;
        }
    }
}

