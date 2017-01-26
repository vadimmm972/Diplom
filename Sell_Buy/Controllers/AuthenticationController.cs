using Sell_Buy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sell_Buy.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(Modal_Auntufication at)
        {
            Sell_Buy_Entities db = new Sell_Buy_Entities();

            var aut = db.Users.FirstOrDefault(u => u.C_login == at.Login && u.C_password == at.Password);

            if (aut != null)
            {
                HttpCookie aCookie = new HttpCookie("Authentication");

                aCookie.Value = at.Login;
                //aCookie.HasKeys = at.Password;
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);
                // Response.Redirect("");
                return RedirectToAction("Index", "StartPage");
            }
            else
            {
                ViewBag.ErrorMessage = "Неверный логин или пароль!";
            }
            return View();
        }

         public ActionResult LogOut()
        {
            
            //@Html.ActionLink("Log out ", "ViewProduct", "LogUser") 
            HttpCookie myCookie = new HttpCookie("Authentication");
            // lblLogin.Text = "Cookie = " + myCookie.Value;
            myCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(myCookie);
            return RedirectToAction("index", "Authentication");
        }

    
    }
}