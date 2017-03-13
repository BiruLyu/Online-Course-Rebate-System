using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text;
namespace MySystemWeb.uAdmin.ajax
{
    public partial class checkexam : System.Web.UI.Page
    {
       
        public string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                
                username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
            }
            if (Request.Form["pid"] != null)
            {
                
                string pid = Request.Form["pid"].ToString();
                string changeSql = "update H_Order set isexam=1,exam_handler='" + username + "',exam_time='" + System.DateTime.Now + " ' where id=" + pid;              
                if (DbHelperSQL.ExecuteSql(changeSql)>0)
                {
                    Response.Write(Tool.CreateJson("操作成功！", "1"));
                }
                else
                {
                    Response.Write(Tool.CreateJson("操作失败！", "2"));
                }

            }
            else 
            {
                Response.Write(Tool.CreateJson("缺少参数", "3"));
               
            }
            Response.End();
        }
    }
}