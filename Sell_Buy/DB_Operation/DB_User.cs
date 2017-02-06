using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_User
    {
        public string InsertUser(User user)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Users.Add(user);
                db.SaveChanges();
                return user.name_last + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }


        public string UpdateUser(int id, User user)
        {
            
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                User u = db.Users.Find(id);
                u.name_first = user.name_first;
                u.name_last = user.name_last;
                u.name_middle = user.name_middle;
                u.phone = user.phone;
                u.mail = user.mail;
                u.id_country = user.id_country;
                u.id_region = user.id_region;
                u.id_sity = user.id_sity;
                u.C_status = user.C_status;
                u.active = user.active;
                u.id_language = user.id_language;
                u.C_image = user.C_image;
                u.date_register = user.date_register;
                u.C_login = user.C_login;
                u.C_password = user.C_password;
                db.SaveChanges();
                return u.name_last + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteUser(int id)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                User user = db.Users.Find(id);

                db.Users.Attach(user);
                db.Users.Remove(user);
                db.SaveChanges();

                return user.name_last + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public User GetUser(int id)
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    User user = db.Users.Find(id);
                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<User> GetallUsers()
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    List<User> user = (from x in db.Users
                                              select x).ToList();
                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}