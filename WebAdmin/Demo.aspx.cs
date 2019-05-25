using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace WebAdmin
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            //khai báo webservice
            Service.WebServiceSoapClient webService = new Service.WebServiceSoapClient();

            //Lay dữ liệu từ webservice
            string json = webService.GetArticleList(1, 10);

            //chuyển đổi chuổi Json sang dạng Article 
            JavaScriptSerializer js = new JavaScriptSerializer();
            //dich tu chuoi sang doi tuong
            List<Article> item = js.Deserialize<List<Article>>(json);

            Repeater_Main.DataSource = item.ToList()
                
                
                
                
                ;
            Repeater_Main.DataBind();

        }
    }
}