using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sell_Buy.Controllers
{
   public class ListMagazines
    {
        public int id_magazine { get; set; }
        public string nameMagazine { get; set; }
        public string imageMagazine { get; set; }
        public int active_magazine { get; set; }
        public string category_magazine { get; set; }
    }

    public class ManagementMagazineController : Controller
    {
        // GET: ManagementMagazine
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllMagazinesUser()
        {
            var autuser = Request.Cookies["Authentication"];
            if (autuser != null)
            {
                string logUser;
               logUser = Convert.ToString(autuser.Values);
           
            Sell_Buy_Entities db = new Sell_Buy_Entities();
            var idUser = (from u in db.Users
                             where u.C_login == logUser
                             select u.id).ToList();


                if(idUser != null)
                {
                     int idM;
                     string nameM;
                     string imageM;
                     int activeM;
                     string categoryM;
                    List<ListMagazines> mgs =new List<ListMagazines>();
                     int idSuMagazine =    Convert.ToInt32(idUser[0]);
                    var magazines = (from u in db.UserMagazines
                                     where u.id_user == idSuMagazine
                             select u).ToList();

                    for(int i=0;i<magazines.Count;i++)
                    {
                        idM = magazines[i].Magazine.id;
                        nameM = magazines[i].Magazine.name_magazine;
                        imageM = magazines[i].Magazine.C_image;
                        activeM =magazines[i].Magazine.C_status;
                        categoryM = magazines[i].Magazine.Category.name_category;
                        mgs.Add(new ListMagazines { id_magazine = idM, nameMagazine = nameM, imageMagazine = imageM, active_magazine = activeM, category_magazine = categoryM });
                    }
                   return Json(mgs);
                }
               
             }

            return Json(null);
        }
    }
}