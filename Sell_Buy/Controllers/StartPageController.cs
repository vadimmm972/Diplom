using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sell_Buy.Controllers
{
    class UserInfo
    {
      
        public string NameFirst { get; set; }
       
        public string NameLast { get; set; }

        public string NameMiddle { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }
       
        public string Country { get; set; }
        
        public string Region { get; set; }
        
        public string Sity { get; set; }


    }

    public class StartPageController : Controller
    {
        
        // GET: StartPage
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetInfoUser()
        {
            
            Sell_Buy_Entities db = new Sell_Buy_Entities();
            string loginUser = Request.Cookies["Authentication"].Values.ToString();
            var date = db.Users.FirstOrDefault(u => u.C_login == loginUser);
            var country = date.Country.name_country;
            var region = date.Region.name_region;
            var sity = date.Site.name_sity;


            List<UserInfo> UserInfo = new List<UserInfo>();
            UserInfo.Add(new UserInfo { NameFirst = date.name_first, NameLast = date.name_last, NameMiddle = date.name_middle, Phone = date.phone, Mail = date.mail, Country = country ,Region=region,Sity=sity});

            return Json(UserInfo);
        }
    }
}