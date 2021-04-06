using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using n01467577_Assignment3.Models;
using MySql.Data.MySqlClient;

namespace n01467577_Assignment3.Controllers
{
    public class StudentDataController : ApiController
    {
        private SchoolDbContext Student = new SchoolDbContext();
        /// <summary>
        /// Returns a list of Students whose enrol date is greater than or equal to entered date
        /// </summary>
        /// <param name="enrol_date">the enroldate in the database</param>
        /// <example>GET api/StudentData/ListStudents/2018-06-06</example>
        /// <returns>
        /// A list of Student objects whose enrol date is greater than or equal to entered date.
        /// </returns>
        [HttpGet]
        [Route("api/StudentData/ListStudents/{enrol_date?}")]
        public IEnumerable<Student> ListStudents(DateTime? enrol_date = null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = Student.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();       

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            
            cmd.CommandText = "Select * from Students where enroldate >= @key";
            cmd.Parameters.AddWithValue("@key", enrol_date);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Students
            List<Student> Students = new List<Student> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;
                Students.Add(NewStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Students
            return Students;
        }

        /// <summary>
        /// Returns an individual Student from the database by specifying the primary key Studentid
        /// </summary>
        /// <param name="id">the Student's ID in the database</param>
        /// <returns>An Student object</returns>
        [HttpGet]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            //Create an instance of a connection
            MySqlConnection Conn = Student.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Students where Studentid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];


                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;

            }

            return NewStudent;
        }
    }
}
