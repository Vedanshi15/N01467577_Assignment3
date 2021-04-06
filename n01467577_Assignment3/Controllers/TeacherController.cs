using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01467577_Assignment3.Models;

namespace n01467577_Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Teacher/ListTeachers/{Salary}
        public ActionResult ListTeachers(decimal Salary = 0)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> NewTeacher = controller.ListTeachers(Salary);
            return View(NewTeacher);
        }

        //GET : /Teacher/ShowTeacher/{id}
        public ActionResult ShowTeacher(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }
    }
}