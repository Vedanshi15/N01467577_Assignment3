using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using n01467577_Assignment3.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace n01467577_Assignment3.Controllers
{
    public class TeacherDataController : ApiController
    {

        private SchoolDbContext Teacher = new SchoolDbContext();

        /// <summary>
        /// Returns a list of Teachers whose Salary is greater than or equal to entered salary
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers/55</example>
        /// <param name="Salary">Salary field in the database</param>
        /// <returns>
        /// A list of Teacher objects whose salary is greater than or equal to 55.
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{Salary?}")]
        public IEnumerable<Teacher> ListTeachers(decimal Salary = 0)
        {
            //Create an instance of a connection
            MySqlConnection Conn = Teacher.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            
            cmd.CommandText = "Select * from Teachers where salary >= @key";
            //Add Parameters
            cmd.Parameters.AddWithValue("@key",Salary);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = Convert.ToInt32(ResultSet["Teacherid"]);
                string TeacherFname = ResultSet["Teacherfname"].ToString();
                string TeacherLname = ResultSet["Teacherlname"].ToString();
                string EmployeeNumber = ResultSet["Employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["Hiredate"];
                decimal Salary1 = (decimal)ResultSet["Salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary1;


                //Add the Teacher data to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Teachers
            return Teachers;
        }


        /// <summary>
        /// Returns an individual Teacher from the database by specifying the primary key Teacherid
        /// </summary>
        /// <param name="id">the Teacher's ID in the database</param>
        /// <returns>An Teacher object</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();
         
            //Create an instance of a connection
            MySqlConnection Conn = Teacher.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where teacherId= @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = ResultSet["Teacherfname"].ToString();
                string TeacherLname = ResultSet["Teacherlname"].ToString();
                string EmployeeNumber = ResultSet["Employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["Hiredate"];
                decimal Salary = (decimal)ResultSet["Salary"];
              

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }
            return NewTeacher;
        }

    }
}
