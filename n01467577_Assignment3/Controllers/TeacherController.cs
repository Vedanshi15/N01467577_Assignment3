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

        //GET : /Teacher/New_Ajax
        public ActionResult New_Ajax()
        {
            return View();

        }

        //GET : /Teacher/NewTeacher
        public ActionResult NewTeacher()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            if (TeacherFname == "" || TeacherLname == "" || EmployeeNumber == "")
            {
                return RedirectToAction("Error");
            }
            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);
            return RedirectToAction("ListTeachers");
        }


        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult DeleteTeacher(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("ListTeachers");
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
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