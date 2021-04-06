using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01467577_Assignment3.Models;

namespace n01467577_Assignment3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Student/ListStudents/{enrol_date}
        public ActionResult ListStudents(DateTime? enrol_date = null)
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> NewStudent = controller.ListStudents(enrol_date);
            return View(NewStudent);
        }

        //GET : /Student/ShowStudent/{id}
        public ActionResult ShowStudent(int id)
        {
            StudentDataController controller = new StudentDataController(); 
            Student NewStudent = controller.FindStudent(id);


            return View(NewStudent);
        }
    }
}