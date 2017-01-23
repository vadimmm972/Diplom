using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Category
    {
        public string InsertCategory(Category category)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Categories.Add(category);
                db.SaveChanges();
                return category.name_category + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }

        public string UpdateCategory(int id, Category category)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Category c = db.Categories.Find(id);
                c.name_category = category.name_category;

                db.SaveChanges();
                return c.name_category + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteCategory(int id)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Category category = db.Categories.Find(id);

                db.Categories.Attach(category);
                db.Categories.Remove(category);
                db.SaveChanges();

                return category.name_category + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public List<Category> GetallCategory()
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    List<Category> category = (from x in db.Categories
                                             select x).ToList();
                    return category;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}