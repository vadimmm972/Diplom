using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_UsersMagazine
    {
        public bool InsertUserMagazine(UserMagazine us_m)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.UserMagazines.Add(us_m);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}