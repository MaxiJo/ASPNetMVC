using ASPNetMVC.Contacts;
using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC.Controllers
{
    public class DivisionController : Controller
    {
        private MyContext myContext = new MyContext();
        // GET: Division
        public ActionResult Index()
        {
            return View(myContext.Divisions.ToList());
        }

        // GET: Division/Details/5
        public ActionResult Details(int id)
        {
            return View(myContext.Divisions.Find(id));
        }

        // GET: Division/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Division/Create
        [HttpPost]
        public ActionResult Create(Division division)
        {
            myContext.Divisions.Add(division);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Division/Edit/5
        public ActionResult Edit(int id)
        {
            return View(myContext.Divisions.Find(id));
        }

        // POST: Division/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Division division)
        {
            myContext.Entry(division).State = EntityState.Modified;
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Division/Delete/5
        public ActionResult Delete(int id)
        {
            return View(myContext.Divisions.Find(id));
        }

        // POST: Division/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Division division)
        {
            var deleteDivision = myContext.Divisions.Find(id);
            myContext.Divisions.Remove(deleteDivision);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
