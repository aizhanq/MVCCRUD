using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Student.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model) 
        {
            _context.Student.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var data = _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student Model) 
        {
            var data = _context.Student.Where(x => x.StudentId ==  Model.StudentId).FirstOrDefault();
            if(data != null)
            {
                data.StudentCity = Model.StudentCity;
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Student.Where(x =>x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id) 
        {
            var data = _context.Student.Where(x =>x.StudentId == id).FirstOrDefault();
            _context.Student.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}