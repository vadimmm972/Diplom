using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Buy.DB_Operation
{
    public class DB_Comments
    {
        public string InsertComments(Comment comment)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                db.Comments.Add(comment);
                db.SaveChanges();
                return comment.comment1 + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }

        public string UpdateComments(int id, Comment comment)
        {
            try
            {

                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Comment c = db.Comments.Find(id);
                c.id_user = comment.id_user;
                c.id_product = comment.id_product;
                c.comment1 = comment.comment1;

                db.SaveChanges();
                return c.comment1 + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }
        public string DeleteComments(int id)
        {
            try
            {
                Sell_Buy_Entities db = new Sell_Buy_Entities();
                Comment comment = db.Comments.Find(id);

                db.Comments.Attach(comment);
                db.Comments.Remove(comment);
                db.SaveChanges();

                return comment.comment1 + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public List<Comment> GetallComments()
        {
            try
            {
                using (Sell_Buy_Entities db = new Sell_Buy_Entities())
                {
                    List<Comment> comment = (from x in db.Comments
                                               select x).ToList();
                    return comment;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}