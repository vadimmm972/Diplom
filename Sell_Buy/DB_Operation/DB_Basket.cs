using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Basket
    {
        public string InsertBasket(Basket basket)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Baskets.Add(basket);
                db.SaveChanges();
                return basket.Product.name + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }

        public string UpdateBasket(int id, Basket basket)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Basket b = db.Baskets.Find(id);
                b.id_user = basket.id_user;
                b.id_product = basket.id_product;
                db.SaveChanges();
                return b.id_product.Value + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteBasket(int id)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Basket basket = db.Baskets.Find(id);

                db.Baskets.Attach(basket);
                db.Baskets.Remove(basket);
                db.SaveChanges();

                return basket.Product.name + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public Basket GetCountry(int id)
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    Basket basket = db.Baskets.Find(id);
                    return basket;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}