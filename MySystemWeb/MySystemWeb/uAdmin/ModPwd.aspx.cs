using System;
using System.Collections.Generic;
using System.Linq;

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
    public partial class ModPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["qx"] != null)
                {
                     string username = HttpUtility.UrlDecode(Request.Cookies["qx"].Values["user"].ToString(), Encoding.UTF8);
                     this.LiteralUser.Text = username;
                }
            }
        }

        protected void ButtonSub_Click(object sender, EventArgs e)
        {
            string khmc = HttpUtility.UrlDecode(Request.Cookies["qx"].Values["user"].ToString(), Encoding.UTF8);
            string oldpwd = this.TextOldPwd.Value;
            if (H_UserClass.CheckLogin(khmc, oldpwd).Rows.Count <= 0)
            {
                JScript.Alert("旧密码不正确", "a1", this);
                return;
            }
            if (H_UserClass.ChangePwd(khmc, this.TextNewPwd.Value))
            {
                JScript.Alert("修改成功", "a2", this);
            }
            else
                JScript.Alert("修改失败", "a3", this);
        }
       }
  }
