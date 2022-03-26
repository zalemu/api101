using api101.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace api101.Services
{
    public class CourseService
    {
        private static string dataSource = "dbsrv1001.database.windows.net";
        private static string initialCatalog = "db1001";
        private static string userID = "sqladmin";
        private static string password = "AdminP@$$w0rd";
        //private SqlConnection GetConnection()
        //{
        //    var builder = new SqlConnectionStringBuilder();
        //    builder.DataSource = dataSource;
        //    builder.InitialCatalog = initialCatalog;
        //    builder.UserID = userID;
        //    builder.Password = password;
        //    return new SqlConnection(builder.ConnectionString);
        //}

        //public IEnumerable<Course> GetCourses()
        //{
        //    List<Course> courses = new List<Course>();
        //    string statement = "select * from Course";
        //    SqlConnection connection = GetConnection();
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(statement,connection);
        //    using(SqlDataReader reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            Course course = new Course()
        //            {
        //                Id = reader.GetInt32(0),
        //                Title = reader.GetString(1),
        //                Credit = reader.GetInt32(2),
        //                InsertedDate = reader.GetDateTime(3)
        //            };
        //            courses.Add(course);
        //        }
        //    }
        //    connection.Close();
        //    return courses;
        //}


        private SqlConnection GetConnection(string conStr)
        {           
            return new SqlConnection(conStr);
        }

        public IEnumerable<Course> GetCourses(string conStr)
        {
            List<Course> courses = new List<Course>();
            string statement = "select * from Course";
            SqlConnection connection = GetConnection(conStr);
            connection.Open();
            SqlCommand command = new SqlCommand(statement, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Credit = reader.GetInt32(2),
                        InsertedDate = reader.GetDateTime(3)
                    };
                    courses.Add(course);
                }
            }
            connection.Close();
            return courses;
        }


    }



}
