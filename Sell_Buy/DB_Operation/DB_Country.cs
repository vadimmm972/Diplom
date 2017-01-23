using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Country
    {
         public string InsertCountry(Country country)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Countries.Add(country);
                db.SaveChanges();
                return country.name_country + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }

          public string UpdateCountry(int id, Country country)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Country c = db.Countries.Find(id);
                c.name_country = country.name_country;
                db.SaveChanges();
                return c.name_country + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

          public string DeleteCountry(int id)
          {
              try
              {
                  Sell_Buy_Entities db = new Sell_Buy_Entities();
                  Country country = db.Countries.Find(id);

                  db.Countries.Attach(country);
                  db.Countries.Remove(country);
                  db.SaveChanges();

                  return country.name_country + "was succefully delited";
              }
              catch (Exception e)
              {
                  return "Error:" + e.Message;
              }
          }

          public Country GetCountry(int id)
          {
              try
              {
                  using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                  {
                      Country country = db.Countries.Find(id);
                      return country;
                  }
              }
              catch (Exception)
              {
                  return null;
              }
          }
          public List<Country> GetallCountries()
          {
              try
              {
                  using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                  {
                      List<Country> country = (from x in db.Countries
                                         select x).ToList();
                      return country;
                  }
              }
              catch (Exception)
              {
                  return null;
              }
          }
    }
}