using ASPNetMVC.Contacts;
using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ASPNetMVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        private MyContext myContext = new MyContext();
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                List<Division> list = myContext.Divisions.ToList();
                ViewBag.Nama_Divisi = new SelectList(list, "DivisionId", "NamaDivisi");
                return RedirectToAction("Update", "Employees", new { Id = Session["id"] });
            }
            else
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }
        }
        public ActionResult Details(int id)
        {
            return View(myContext.Employees.Find(id));
        }
        public ActionResult Create()
        {
            List<Division> CreateLists = myContext.Divisions.ToList();
            ViewBag.NamaDivisi = new SelectList(CreateLists, "DivisionId", "NamaDivisi");
            return View();  
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        { 
            List<Division> CreateLists = myContext.Divisions.ToList();
            ViewBag.NamaDivisi = new SelectList(CreateLists, "DivisionId", "NamaDivisi");
            myContext.Employees.Add(employee);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            if (Session["id"] != null)
            {
                List<Division> list = myContext.Divisions.ToList();
                ViewBag.Nama_Divisi = new SelectList(list, "DivisionId", "NamaDivisi");
                return View(myContext.Employees.Find(id));
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            List<Division> list = myContext.Divisions.ToList();
            ViewBag.Nama_Divisi = new SelectList(list, "DivisionId", "NamaDivisi");
            myContext.Entry(employee).State = EntityState.Modified;
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(myContext.Employees.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(Employee employee ,Account account,int id)
        {
            var deleteEmployee = myContext.Employees.Find(id);
            var deleteAccount = myContext.Accounts.Find(id);
            myContext.Employees.Remove(deleteEmployee);
            myContext.Accounts.Remove(deleteAccount);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}