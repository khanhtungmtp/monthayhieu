using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebAdmin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin();
            SetLoginButtonText();
        }

        public void SetLoginButtonText()
        {

        }

        public void CheckLogin()
        {
            // kiểm tra trang hiện tại, nếu là login thì ko chuyển hướng
            string pageName = Request.Url.LocalPath.ToLower();
            pageName = Path.GetFileName(pageName);
            if(pageName == "login.aspx")
            {
                return;
            }
            if(Session["username"] == null || Session["username"].ToString() == string.Empty)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void LinkButton_Login_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == string.Empty)
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {

                Session["username"] = null;
                Response.Redirect("/Login.aspx");
            }
        }
    }
}