using Sell_Buy.DB_Operation;
using Sell_Buy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sell_Buy.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        public ActionResult Index()
        {
            Sell_Buy_Entities sel = new Sell_Buy_Entities();
            DB_Country country = new DB_Country();
           // List<string> countries = sel.Countries.Select(d => d.name_country).ToList();
            List<Country> countries = country.GetallCountries();
          

           // List<string> regions = sel.Regions.Select(d => d.name_region).ToList();
           // List<string> sites = sel.Sites.Select(d => d.name_sity).ToList();
            ViewBag.Countries = countries[0];
           // ViewBag.Regions = regions;
           // ViewBag.Sites = sites;
            
           
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Modal_Registration newUser)
        {
            Sell_Buy_Entities db = new Sell_Buy_Entities();


            var idCounrty = (from u in db.Countries
                    where u.name_country == newUser.Country
                    select u.id).ToList();

            var idRegion = (from u in db.Regions
                    where u.name_region == newUser.Region
                            select u.id).ToList();

            var idSity = (from u in db.Sites
                    where u.name_sity == newUser.Sity
                          select u.id).ToList();

        
                DateTime dateTime = new DateTime();
                string date_reg_user = dateTime.ToString("yyyy-MM-dd HH':'mm':'ss");
            User user = new User
            {
                name_first = newUser.NameFirst,
                name_last = newUser.NameLast,
                name_middle = newUser.NameMiddle,
                phone = newUser.Phone,
                mail = newUser.Mail,
                id_country = Convert.ToInt32(idCounrty[0]),
                id_region =  Convert.ToInt32(idRegion[0]),
                id_sity = Convert.ToInt32(idSity[0]),
                C_status = 1,
                active = 1,
                id_language = 1,
                date_register = date_reg_user,
                register_magazine = "",
                C_image = newUser.Image
            };

            DB_User new_user = new DB_User();
            new_user.InsertUser(user);
           // return View();
            return RedirectToRoute("AuthenticatioName");
        }

        public void UploadImage()
        {
            var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            var id = System.Web.HttpContext.Current.Request.Form["id"];
           // var elementId = System.Web.HttpContext.Current.Request.Form["elementid"];
            var fileName = "P";
            fileName += 12;
            fileName += "_";
           
            fileName += "Us.jpg";
            //            var path = Path.Combine(Server.MapPath("~/Content/images/pdf"), fileName.Trim());
            // var path = Path.Combine(Server.MapPath("Content/images/pdf"), fileName.Trim());
            var path = Path.Combine(Server.MapPath("~/Content/images/usersPhotos"), fileName.Trim());
            pic.SaveAs(path);
            var imgpath = "~/Content/images/usersPhotos" + fileName.Trim();
            ViewBag.PhotoUser = fileName.Trim();
           // var jsonResult = Json(imgpath, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult Getregions(int id)
        {
            // Sell_Buy_Entities db = new Sell_Buy_Entities();
            //List<string> jsonResult = new List<string>();


            DB_Regions reg = new DB_Regions();

            var regions = reg.GetRegionToIdCountry(id);

            //var idCounrty = (from u in db.Regions
            //                 where u.name_region == Name
            //                 select u.id).ToList();


            return Json(regions);
        }
    }
}