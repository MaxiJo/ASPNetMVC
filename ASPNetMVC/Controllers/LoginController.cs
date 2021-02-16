using ASPNetMVC.Contacts;
using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC.Controllers
{
    public class LoginController : Controller
    {
        MyContext myContext = new MyContext();
        // GET: Login/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Login(User user)
        {
            var verifyUserList = myContext.Employees
            .Join(myContext.Accounts,
                e => e.employeeId,
                a => a.AccountId,
                (e, a) => new
                {
                    employeePhone = e.Phone,
                    employeeEmail = e.Email,
                    accountPasswords = a.Passwords
                }
            ).ToList();
            var verifyUser = verifyUserList.FirstOrDefault(
                m => (m.employeeEmail == user.employees.Email
                    || m.employeePhone == user.employees.Phone)
                    && m.accountPasswords == user.accounts.Passwords);
            if (verifyUser != null)
            {
                //add session
                Session["SignIn"] = user.employees.Email.ToString();
                Session["Password"] = verifyUser.accountPasswords.ToString();
                var dEmployees = myContext.Employees.Where(e => e.Email == user.employees.Email|| e.Phone == user.employees.Phone).ToList();
                Session["id"] = dEmployees.FirstOrDefault().employeeId;
                int logSignIn = Convert.ToInt32(Session["id"]);
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                ViewBag.error = "Login Failed";
                return RedirectToAction("Login");
            }
        }
        public ActionResult Register()
        {
            Division division = new Division();
            List<Division> RegLists = myContext.Divisions.ToList();
            ViewBag.RegistrasiDivisiList= new SelectList(RegLists, "DivisionId", "NamaDivisi");
            
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register register)
        {
            
            var checkEmail = myContext.Employees.SingleOrDefault(e => e.Email.Equals(register.Email));
            var checkPhone = myContext.Employees.SingleOrDefault(e => e.Phone.Equals(register.Phone));
            if (checkEmail == null && checkPhone == null)
            {
                Employee employee = new Employee();
                Account account = new Account();
                account.Passwords = register.Passwords;
                employee.Nama = register.Nama;
                employee.BirthDate = register.BirthDate;
                employee.Address = register.Address;
                employee.Email = register.Email;
                employee.Phone = register.Phone;
                employee.divisionId = register.divisionId;
                myContext.Employees.Add(employee);
                myContext.Accounts.Add(account);
                myContext.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "Email or Phone Already Existed";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["employeeId"] = null;
            Session.Remove("employeeId");
            Session.Clear();
            return RedirectToAction("Login");
        }
        //public ActionResult ForgotPassword()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Session["id"] !=null)
        //        {

        //        }

        //    }
        //    return View();
        //}


    }
}
