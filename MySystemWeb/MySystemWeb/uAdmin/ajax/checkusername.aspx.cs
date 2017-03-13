using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class checkusername : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["username"] != null)
            {
                string username = Request.Form["username"].ToString();
                string getSql = "select count(*) from H_User where UserName=" + "'" + username + "'";
                string count = DbHelperSQL.GetSingle(getSql).ToString();
                if (int.Parse(count) > 0)
                {
                    Response.Write(Tool.CreateJson("该用户名已经存在", "1"));
                   
                }
                else
                {
                    Response.Write(Tool.CreateJson("该用户名符合", "2"));
                  

                }
            }
            Response.End();
        }
    }
}