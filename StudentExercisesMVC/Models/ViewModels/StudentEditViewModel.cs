using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models.ViewModels
{
    public class StudentEditViewModel
    {
        // A single student
        public Student Student { get; set; } = new Student();

        // All cohorts
        public List<SelectListItem> Cohorts;

        public SqlConnection Connection;

        private int Id { get; set; }


        public StudentEditViewModel() { }

        public StudentEditViewModel(SqlConnection connection, int id)
        {
            Id = id;
            Connection = connection;
            GetAllCohorts();
            getOneStudent(Id);
        }

        public void GetAllCohorts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id, c.Designation from Cohort c";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Designation = reader.GetString(reader.GetOrdinal("Designation"))
                        };

                        cohorts.Add(cohort);
                    }

                    Cohorts = cohorts.Select(li => new SelectListItem
                    {
                        Text = li.Designation,
                        Value = li.Id.ToString()
                    }).ToList();

                    Cohorts.Insert(0, new SelectListItem
                    {
                        Text = "Choose cohort...",
                        Value = "0"
                    });
                }
            }
        }
        public void getOneStudent(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.FirstName, s.LastName, s.SlackHandle, s.CohortId from Student s WHERE s.Id = @Id";

                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        Student.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        Student.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        Student.SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle"));
                        Student.CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"));
                    }
                }
            }
        }
    }
}
