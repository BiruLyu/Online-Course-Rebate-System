using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using System.Web.Security;
using System.Text;
namespace MySystemWeb.uAdmin.ajax
{
    public partial class checklogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["user"] != null && Request.Form["pwd"] != null)
            {
                string user = Request.Form["user"].ToString();
                string pwd = Request.Form["pwd"].ToString();
                DataTable dt = H_UserClass.CheckLogin(user, pwd);
                if (dt.Rows.Count > 0)
                {
                    HttpCookie khcookie = new HttpCookie("qx");
                    //khcookie.Expires = DateTime.Now.AddMinutes(30);
                    khcookie.Values.Add("uid", dt.Rows[0]["id"].ToString());
                    khcookie.Values.Add("user",HttpUtility.UrlEncode( dt.Rows[0]["username"].ToString(),Encoding.UTF8));
                    khcookie.Values.Add("qxid", dt.Rows[0]["qxid"].ToString());
                    khcookie.Values.Add("isoccupy", dt.Rows[0]["isoccupy"].ToString());
                    Response.Cookies.Add(khcookie);
                    FormsAuthentication.SetAuthCookie(dt.Rows[0]["username"].ToString(), false);
                    //Response.Redirect("Main.aspx");
                    Response.Write(Tool.CreateJson("登陆成功！", "1"));
                    
                }
                else
                    Response.Write(Tool.CreateJson("密码或账号不正确！", "2"));
            }
            else
                Response.Write(Tool.CreateJson("缺少参数！", "3"));
            Response.End();
        

        }
    }
}