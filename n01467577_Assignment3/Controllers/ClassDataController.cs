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
    public class ClassDataController : ApiController
    {
        private SchoolDbContext Classdb = new SchoolDbContext();
        /// <summary>
        /// Returns a list of Classes in the system based on searchkey
        /// </summary>
        /// <param name="SearchKey">the SearchKey is the ClassCode or ClassName field in the database</param>
        /// <example>GET api/ClassData/ListClasss/SearchKey</example>
        /// <returns>
        /// A list of Class objects.
        /// </returns>
        [HttpGet]
        [Route("api/ClassData/ListClasses/{SearchKey?}")]
        public IEnumerable<ClassInfo> ListClasses(string SearchKey = null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = Classdb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Classes where lower(Classcode) like lower(@key) or lower(Classname) like lower(@key) or lower(concat(classcode, ' ', classname)) like lower(@key)";
            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Classes
            List<ClassInfo> Classes = new List<ClassInfo> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["Classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                DateTime ClassStartDate = (DateTime)ResultSet["startdate"];
                DateTime ClassFinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                ClassInfo NewClass = new ClassInfo();
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.StartDate = ClassStartDate;
                NewClass.FinishDate = ClassFinishDate;
                NewClass.ClassName = ClassName;
                //Add the Class to the List
                Classes.Add(NewClass);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Classes
            return Classes;
        }

        /// <summary>
        /// Returns an individual Class from the database by specifying the primary key Classid
        /// </summary>
        /// <param name="id">the Class's ID in the database</param>
        /// <returns>An Class object</returns>
        [HttpGet]
        public ClassInfo FindClass(int id)
        {
            ClassInfo NewClass = new ClassInfo();

            //Create an instance of a connection
            MySqlConnection Conn = Classdb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Classes where Classid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["Classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                DateTime ClassStartDate = (DateTime)ResultSet["startdate"];
                DateTime ClassFinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                
                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.StartDate = ClassStartDate;
                NewClass.FinishDate = ClassFinishDate;
                NewClass.ClassName = ClassName;

            }
            return NewClass;
        }

    }
}
