using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Language
    {
        public string InsertLanguage(Language language)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Languages.Add(language);
                db.SaveChanges();
                return language.translate + "was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public string UpdateLanguage(int id, Language language)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Language l = db.Languages.Find(id);
                l.translate = language.translate;
                l.C_status = language.C_status;
                db.SaveChanges();
                return l.translate + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }
        public string DeleteLanguage(int id)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Language language = db.Languages.Find(id);

                db.Languages.Attach(language);
                db.Languages.Remove(language);
                db.SaveChanges();

                return language.translate + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public List<Language> GetallLanguages()
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    List<Language> language = (from x in db.Languages
                                             select x).ToList();
                    return language;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}