using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Regions
    {
        public string InsertRegion(Region region)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Regions.Add(region);
                db.SaveChanges();
                return region.name_region + " was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public string UpdateRegion(int id, Region region)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Region r = db.Regions.Find(id);
                r.name_region = region.name_region;
                r.id_country = region.id_country;   
                
                db.SaveChanges();
                return r.name_region + " was succefully updated";
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
                Region region = db.Regions.Find(id);

                db.Regions.Attach(region);
                db.Regions.Remove(region);
                db.SaveChanges();

                return region.name_region + " was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public Region GetRegion(int id)
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    Region region = db.Regions.Find(id);
                    return region;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Region> GetRegionToIdCountry(int id)
        {
            Sell_Buy_Entities db = new Sell_Buy_Entities();
            var regionToCountry = (from r in db.Regions
                             where r.id == id
                             select r).ToList();

            return regionToCountry;
        }

        public List<Region> GetallRegion()
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    List<Region> region = (from x in db.Regions
                                               select x).ToList();
                    return region;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}