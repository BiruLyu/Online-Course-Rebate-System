using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class UserAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                if (cookie.Values["qxid"]=="3"||cookie.Values["qxid"]=="4")
                {
                    Response.Redirect("Error.aspx");
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        Model.H_User user = new Model.H_User();
        user.username = this.TextUser.Value.Trim();
        user.qxid = int.Parse(this.SelectAuth.Value);
        user.password = this.TextPwd.Value.Trim();
        user.isoccupy = 0;
        if (H_UserClass.Add(user))
        {
            JScript.AlertAndRedirect("操作成功", "UserList.aspx", this);
        }
        else
            JScript.Alert("操作失败", "a2", this);
    }
        }
   }
