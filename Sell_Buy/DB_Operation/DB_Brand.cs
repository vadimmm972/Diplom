using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Brand
    {
        public string InsertBrand(Brand brand)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Brands.Add(brand);
                db.SaveChanges();
                return brand.name_brand + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }
        public string UpdateBasket(int id, Brand brand)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Brand b = db.Brands.Find(id);
                b.name_brand = brand.name_brand;
                db.SaveChanges();
                return b.name_brand + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }
    }
}