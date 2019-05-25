using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        #region Account
        [WebMethod]
        public bool CheckLogin(string userName, string passWord)
        {
            //Kết nối db
            DBEntities db = new DBEntities();

            //Viet query kiem tra thong tin dang nhap
            var query = from x in db.Accounts
                        where x.Username == userName && x.Password == passWord
                        select x;

            //var query1 = db.Accounts.FirstOrDefault(x => x.Password == passWord && x.Username == userName);
            //thuc thi truy van
            var data = query.FirstOrDefault();

            //tra ve ket qua 
            if (data == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        [WebMethod]
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            DBEntities dB = new DBEntities();

            //kiem tra tk da ton tai chua
            bool invalid = CheckLogin(userName, oldPassword);
            if (invalid == false)
                return false;

            //Neu hop le doi mat khau

            //tim tai khoan can doi mat khau
            var item = from x in dB.Accounts
                       where x.Username == userName && x.Password == oldPassword
                       select x;

            var data = item.FirstOrDefault();

            //cap nhat mat khau moi
            data.Password = newPassword;
            //luu db
            dB.SaveChanges();

            return true;

        }
        #endregion

        #region Article
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetArticleDetail(int ID)
        {
            DBEntities db = new DBEntities();

            var query = db.Articles.FirstOrDefault(x => x.ArticleID == ID);

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(query);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetArticleList(int page, int pageSize)
        {
            DBEntities db = new DBEntities();

            var query = db.Articles.OrderBy(x => x.CreateTime);

            //Tính số hàng bỏ qua khi phân trang 
            int skip = (page - 1) + pageSize;

            var data = query.Skip(skip).Take(pageSize).ToList();

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(data);
        }

        [WebMethod]
        public bool AddArticle(string itemJson)
        {
            //chuyển đổi chuổi Json sang dạng Article 
            JavaScriptSerializer js = new JavaScriptSerializer();
            //dich tu chuoi sang doi tuong
            Article item = js.Deserialize<Article>(itemJson);

            DBEntities db = new DBEntities();

            db.Articles.Add(item);

            db.SaveChanges();

            return true;
        }

        [WebMethod]
        public bool UdateArticle(string itemJson)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            Article item = js.Deserialize<Article>(itemJson);

            DBEntities db = new DBEntities();

            var dbItem = db.Articles.FirstOrDefault(x => x.ArticleID == item.ArticleID);

            if (dbItem == null)
            {
                return false;
            }
            else
            {
                dbItem.Title = item.Title;
                dbItem.Desciption = item.Desciption;
                dbItem.Avatar = item.Avatar;
                dbItem.Content = item.Content;
                dbItem.CreateTime = item.CreateTime;
                dbItem.CreateBy = item.CreateBy;
            }

            db.SaveChanges();

            return true;
        }

        [WebMethod]
        public bool RemoveArticle(int id)
        {
            DBEntities db = new DBEntities();

            var dbItem = db.Articles.FirstOrDefault(x => x.ArticleID == id);

            if (dbItem == null)
            {
                return false;
            }

            db.Articles.Remove(dbItem);

            db.SaveChanges();

            return true;
        }
        #endregion
    }
}
