using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // nếu load lần đầu thì ẩn thông báo
                div_Message.InnerHtml = "Vui lòng đăng nhập để vào hệ thống";
                div_Message.Visible = true;
            }
        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            string username = input_Username.Value.Trim();
            string password = input_Password.Value.Trim();
            if (username == string.Empty || password == string.Empty)
            {
                div_Message.InnerHtml = " Vui lòng nhập username và password";
                div_Message.Visible = true;
                return;
            }

            //khai báo webservice
            Service.WebServiceSoapClient webService = new Service.WebServiceSoapClient();

            //Lay dữ liệu từ webservice
            bool result = webService.CheckLogin(username,password);

           if(result == false)
            {
                div_Message.InnerHtml = "Tài khoản không đúng, vui lòng kiểm tra lại";
                return; // return để kết thúc, return thì khỏi else
            }

            Session["username"] = username;
            Response.Redirect("/Default.aspx");


        }
    }
}