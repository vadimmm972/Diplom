using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Sites
    {
        public string InsertRegion(Site sity)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Sites.Add(sity);
                db.SaveChanges();
                return sity.name_sity + " was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public string UpdateRegion(int id, Site sity)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Site s = db.Sites.Find(id);
                s.id_region = sity.id_region;
                s.id_country = sity.id_country;
                s.name_sity = sity.name_sity;

                db.SaveChanges();
                return s.name_sity + " was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteRegion(int id)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Site sity = db.Sites.Find(id);

                db.Sites.Attach(sity);
                db.Sites.Remove(sity);
                db.SaveChanges();

                return sity.name_sity + " was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public List<Site> GetallRegion()
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    List<Site> sity = (from x in db.Sites
                                           select x).ToList();
                    return sity;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}