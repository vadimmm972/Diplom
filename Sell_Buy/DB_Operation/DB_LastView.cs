using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_LastView
    {
        public string InsertLastView(LastView lastview)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.LastViews.Add(lastview);
                db.SaveChanges();
                return "was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
    }
}