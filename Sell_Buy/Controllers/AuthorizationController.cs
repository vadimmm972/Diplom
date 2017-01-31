using Sell_Buy.DB_Operation;
using Sell_Buy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;



namespace Sell_Buy.Controllers
{
    public class CountryListController
    {
        public int id { get; set; }
        public string NameCountry { get; set; }
    }

    public class RegionsListController
    {
        public int id { get; set; }
        public string NameRegion { get; set; }
    }

    public class SitiesListController
    {
        public int id { get; set; }
        public string NameSity { get; set; }
    }
    
    public class AuthorizationController : Controller
    {
        
        // GET: Authorization
        public ActionResult Index()
        {
            Sell_Buy_Entities sel = new Sell_Buy_Entities();
          
            List<string> countries = sel.Countries.Select(d => d.name_country).ToList();
           
            ViewBag.Countries = countries;



            //User ccc = new User
            //   {
            //       name_first = "test",
            //       name_last = "test",
            //       name_middle = "test",
            //       phone = "222",
            //       mail = "test@mail.ru",
            //       id_country = 1,
            //       id_region = 1,
            //       id_sity = 1,
            //       C_status = 1,
            //       active = 1,
            //       id_language = 1,
            //       C_image = "none",
            //       id_magazine = null,
            //       date_register = "22.02.97",
            //       register_magazine = "222",
            //       C_login = "test",
            //       C_password = "test"
            //   };

          //  DB_User u = new DB_User();
          //  u.InsertUser(ccc);






           
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Modal_Registration newUser)
        {

            Sell_Buy_Entities db = new Sell_Buy_Entities();
            var aut = db.Users.FirstOrDefault(u => u.C_login == newUser.Login);
            if(aut==null)
            {
                var idCounrty = (from u in db.Countries
                        where u.name_country == newUser.Country
                        select u.id).ToList();

                int idRegion =Convert.ToInt32(newUser.Region);

                int idSity = Convert.ToInt32(newUser.Sity);

        
                    DateTime dateTime = new DateTime();
                    string date_reg_user = dateTime.ToString("yyyy-MM-dd HH':'mm':'ss");
                User userAdd = new User
                {
                    name_first = newUser.NameFirst,
                    name_last = newUser.NameLast,
                    name_middle = newUser.NameMiddle,
                    phone = newUser.Phone,
                    mail = newUser.Mail,
                    id_country = Convert.ToInt32(idCounrty[0]),
                    id_region = idRegion,
                    id_sity = idSity,
                    C_status = 1,
                    active = 1,
                    id_language = 1,
                    C_image = newUser.Image.ToString(),
                    id_magazine = null,
                    date_register = date_reg_user,
                    register_magazine = "none",
                    C_login = newUser.Login.ToString(),
                    C_password = newUser.Password.ToString()
                };

                DB_User registerUser = new DB_User();
                registerUser.InsertUser(userAdd);
                return RedirectToRoute("AuthenticatioName");
            }
            else
            {
                ViewBag.ErrorMessage = "Такой пользователь уже существует";
            }
           // return View();
            return View();
        }

        public JsonResult UploadImage()
        {
            Random rand = new Random();

            int temp;

            temp = rand.Next(100000000);
            var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            var id = System.Web.HttpContext.Current.Request.Form["id"];
           // var elementId = System.Web.HttpContext.Current.Request.Form["elementid"];
            var fileName = "P";
            fileName += temp;
            fileName += "_";
           
            fileName += "Us.jpg";
            //            var path = Path.Combine(Server.MapPath("~/Content/images/pdf"), fileName.Trim());
            // var path = Path.Combine(Server.MapPath("Content/images/pdf"), fileName.Trim());
            var path = Path.Combine(Server.MapPath("~/Content/images/usersPhotos"), fileName.Trim());
            pic.SaveAs(path);
            var imgpath = "~/Content/images/usersPhotos" + fileName.Trim();
            ViewBag.PhotoUser = fileName.Trim();
           // var jsonResult = Json(imgpath, JsonRequestBehavior.AllowGet);
            return Json(fileName.Trim());
            
        }

        [HttpPost]
        public JsonResult Getregions(string Name)
        {
            int idCountryToGetRegions = 0;
             Sell_Buy_Entities db = new Sell_Buy_Entities();
            //List<string> jsonResult = new List<string>();

             List<RegionsListController> regions = new List<RegionsListController>();
            DB_Regions reg = new DB_Regions();



            var idCounrty = (from u in db.Countries
                             where u.name_country == Name
                             select u.id).ToList();


            idCountryToGetRegions = Convert.ToInt32(idCounrty[0]);
            //var regions = reg.GetRegionToIdCountry(id);

            var AllRegionsToid = (from u in db.Regions
                                  where u.id_country == idCountryToGetRegions
                                  select u).ToList();
                        

            for (int i = 0; i < AllRegionsToid.Count;i++ )
            {
                regions.Add(new RegionsListController { id = AllRegionsToid[i].id, NameRegion = AllRegionsToid[i].name_region });
            }

            return Json(regions);
        }


        [HttpPost]
        public JsonResult GetSities(int id,string Name)
        {
          //  int idRegion = 0;
            Sell_Buy_Entities db = new Sell_Buy_Entities();
            //List<string> jsonResult = new List<string>();

            List<SitiesListController> sities = new List<SitiesListController>();
           



            //var idCounrty = (from u in db.Countries
            //                 where u.name_country == Name
            //                 select u.id).ToList();


          //  idCountryToGetRegions = Convert.ToInt32(idCounrty[0]);
            //var regions = reg.GetRegionToIdCountry(id);
            //var AllSitiesToid;
            //if(Name != "none")
            //{
            //    var AllSitiesToid = (from u in db.Sites
            //                         where u.id_region == id
            //                         select u).ToList();

            //}
            //else
            //{
            if(Name != "none")
            {
                var idRegion = (from u in db.Regions
                                where u.name_region == Name
                                select u.id).ToList();
                 id = Convert.ToInt32(idRegion[0]);
            }
               
              
                
               var  AllSitiesToid = (from u in db.Sites
                                     where u.id_region == id
                                     select u).ToList();
         //   }

            for (int i = 0; i < AllSitiesToid.Count; i++)
            {
                sities.Add(new SitiesListController { id = AllSitiesToid[i].id, NameSity = AllSitiesToid[i].name_sity });
            }

            return Json(sities);
        }





        [HttpPost]
        public JsonResult GetCountries()
        {
            Sell_Buy_Entities sel = new Sell_Buy_Entities();
            List<CountryListController> country = new List<CountryListController>();
            DB_Country c = new DB_Country();

            var countries = c.GetallCountries().ToList();

            for (int i = 0; i < countries.Count;i++ )
            {
                country.Add(new CountryListController { id = countries[i].id, NameCountry = countries[i].name_country});
            }


                return Json(country);
        }





    }
}
