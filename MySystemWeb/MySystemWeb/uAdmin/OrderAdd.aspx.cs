using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text;

namespace MySystemWeb.uAdmin
{
    public partial class OrderAdd : System.Web.UI.Page
    {
        public string qx = "";
        public string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {               
                qx = cookie.Values["qxid"].ToString();
                username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
            }
            if (qx != "4") 
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Order order = new Model.H_Order();
            order.course_id = int.Parse(this.HiddenCourse.Value);
            order.order_number = this.TextOrder_num.Value.Trim();
            order.username = username;
            order.isexam = 0;
            order.ispaystudent = 0;
            order.ispayservice = 0;
            order.ispayclerk = 0;
            order.create_time = System.DateTime.Now;
            if (H_OrderClass.Add(order))
            {
                JScript.AlertAndRedirect("操作成功！", "OrderList.aspx", this);
            }
            else 
            {
                JScript.Alert("操作失败！","a2",this);
            }
        }
    }
}