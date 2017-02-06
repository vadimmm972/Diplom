using Sell_Buy.DB_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sell_Buy.Controllers
{
    public class CreateMagazineController : Controller
    {
        // GET: CreateMagazine
        public ActionResult Index()
        {

            Sell_Buy_Entities db = new Sell_Buy_Entities();
            DB_Category cat = new DB_Category();
            var categories = cat.GetallCategory();


      

            ViewBag.Categories = categories;

            return View();
        }

        public ActionResult CreateMagazine(string nameMagazine , string photo , int idCategory)
        {
            Sell_Buy_Entities db = new Sell_Buy_Entities();
            Magazine mg = new Magazine
            {
                name_magazine = nameMagazine,
                C_image = photo,
                id_category = idCategory
            };
            int idmagazine = 0;
            DB_Magazine newMag = new DB_Magazine();
           idmagazine = newMag.InsertMagazine(mg);
           if (idmagazine != 0 || idmagazine != null)
            {
                int Id_user = 0;
                string logUser = Request.Cookies["Authentication"].Values.ToString();
               if(logUser != null)
               {
                   var idUser = (from u in db.Users
                                 where u.C_login == logUser
                                    select u.id).ToList();

                   if(idUser != null)
                   {
                       Id_user = Convert.ToInt32(idUser[0]);
                   }
               }
               
                UserMagazine usMag = new UserMagazine
                {
                    id_user = Id_user,
                    id_magazine = idmagazine
                };
                
                if(usMag != null)
                {
                    bool flagCreate = false;
                    DB_UsersMagazine usMagNew = new DB_UsersMagazine();
                   flagCreate= usMagNew.InsertUserMagazine(usMag);
                    if(flagCreate)
                    {
                        //ViewBag.CreateMagazineInfo = "Магазин создан";
                        return RedirectToAction("Index", "StartPage");
                    }
                }
            }

           return View();
            
        }
    }
}