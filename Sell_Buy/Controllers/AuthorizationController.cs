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


        //[HttpPost]
        //public JsonResult GetAllCRS()
        //{
        //    Sell_Buy_Entities db = new Sell_Buy_Entities();
        //    DB_Country country = new DB_Country();
        //    var str = "" ;
        //    //List<Country> countries = country.GetallCountries();
        //    List<Country> countries = (from u in db.Countries
        //                             select u).ToList();

        //    var reionGet = countries[0].Regions.ToList();
        //    List<CountryListController> countryClass = new List<CountryListController>();
        //   // StringBuilder countryBufer = new StringBuilder();
        //  //  StringBuilder RegionBufer = new StringBuilder();
        // //   StringBuilder SityBufer = new StringBuilder();
          
        //    for (int i = 0; i < countries.Count;i++)
        //    {
        //        countryClass.Add(new CountryListController { id = countries[i].id, NameCountry = countries[i].name_country });
               
        //        //if (countries[i].Regions.Count != 0)
        //        //{
        //        for (int r = 0; r < reionGet.Count; r++)
        //            {

        //                regions.Add(new RegionsListController { id = reionGet[r].id, NameRegion = reionGet[r].name_region});
        //            }
        //        }

              
                
            

        //    return Json(new { countries = countryClass, region = regions });
        //}


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
        public JsonResult GetSities(int id)
        {
            int idRegion = 0;
            Sell_Buy_Entities db = new Sell_Buy_Entities();
            //List<string> jsonResult = new List<string>();

            List<SitiesListController> sities = new List<SitiesListController>();
           



            //var idCounrty = (from u in db.Countries
            //                 where u.name_country == Name
            //                 select u.id).ToList();


          //  idCountryToGetRegions = Convert.ToInt32(idCounrty[0]);
            //var regions = reg.GetRegionToIdCountry(id);

            var AllSitiesToid = (from u in db.Sites
                                  where u.id_region == id
                                  select u).ToList();


            for (int i = 0; i < AllSitiesToid.Count; i++)
            {
                sities.Add(new SitiesListController { id = AllSitiesToid[i].id, NameSity = AllSitiesToid[i].name_sity });
            }

            return Json(sities);
        }
    }
}
