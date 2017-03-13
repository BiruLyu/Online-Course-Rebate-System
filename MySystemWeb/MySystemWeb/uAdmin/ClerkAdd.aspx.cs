using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class ClerkAdd : System.Web.UI.Page
    {
        public string qx = "";
        public string username = "";
        public string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
                username = cookie.Values["user"].ToString();
                userid = cookie.Values["uid"].ToString();
            }
            string getSql = "select isoccupy from H_User where id=" + userid + "";
            string isoccupy = DbHelperSQL.GetSingle(getSql).ToString();
            if (isoccupy == "1")
            {
                Response.Redirect("RepeateError.aspx");
            }
            if (qx=="4")
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Model.H_Clerk clerk = new Model.H_Clerk();
            string strSql = "update H_User set isoccupy=1 where id=" + userid + "";
            int count = DbHelperSQL.ExecuteSql(strSql);
            clerk.username = username;
            clerk.name = this.TextName.Value.Trim();
            clerk.phone = this.TextPhone.Value.Trim();
            clerk.telphone = this.TextTel.Value.Trim();
            clerk.TeamViewerID = this.TextTeamViewerID.Value.Trim();
            clerk.zhifubao = this.TextZhifubao.Value.Trim();
            clerk.bank_name = this.TextBank_name.Value.Trim();
            clerk.bank_region = this.TextBank.Value.Trim();
            clerk.bank_number = this.TextBank_number.Value.Trim();
            clerk.region_province = this.HiddenProvince.Value.ToString();
            clerk.region_city = this.HiddenCity.Value.ToString();
            clerk.region_county = this.HiddenArea.Value.ToString();  
            if (H_ClerkClass.Add(clerk)&&count>0)
            {
                JScript.Alert("操作成功！", "a2", this);
            }
            else 
            {
                JScript.Alert("操作失败！", "a2", this);
            }
        }
    }
}