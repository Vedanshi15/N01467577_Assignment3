using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01467577_Assignment3.Models;


namespace n01467577_Assignment3.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Class/ListClasses/{SearchKey}
        public ActionResult ListClasses(string SearchKey = null)
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<ClassInfo> NewClassInfo = controller.ListClasses(SearchKey);
            return View(NewClassInfo);
        }

        //GET : /Class/ShowClass/{id}
        public ActionResult ShowClass(int id)
        {
            ClassDataController controller = new ClassDataController();
            ClassInfo NewClass = controller.FindClass(id);


            return View(NewClass);
        }
    }

}