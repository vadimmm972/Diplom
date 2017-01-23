using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Magazine
    {
        public string InsertMagazine(Magazine magazine)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Magazines.Add(magazine);
                db.SaveChanges();
                return magazine.name_magazine + " was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }


        public string UpdateMagazine(int id, Magazine magazine)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Magazine m = db.Magazines.Find(id);

                m.name_magazine = magazine.name_magazine;
                m.C_image = magazine.C_image;
                m.C_status = magazine.C_status;
                db.SaveChanges();
                return m.name_magazine + " was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteMagazine(int id)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Magazine magazine = db.Magazines.Find(id);

                db.Magazines.Attach(magazine);
                db.Magazines.Remove(magazine);
                db.SaveChanges();

                return magazine.name_magazine + " was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public List<Magazine> GetallMagazine()
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    List<Magazine> magazine = (from x in db.Magazines
                                               select x).ToList();
                    return magazine;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}