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
    public partial class ServiceAdd : System.Web.UI.Page
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
                username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
                userid = cookie.Values["uid"].ToString();

            }
            string getSql="select isoccupy from H_User where id="+userid+"";
            string isoccupy = DbHelperSQL.GetSingle(getSql).ToString();
            if (isoccupy == "1") 
            {
                Response.Redirect("RepeateError.aspx");
            }
            if (qx !="2") 
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Service service = new Model.H_Service();
            string strSql = "update H_User set isoccupy=1 where id=" + userid + "";
            int count = DbHelperSQL.ExecuteSql(strSql);
            service.username =username;
            service.name = this.TextName.Value.Trim();
            service.TeamViewerID = this.TextTeamViewerID.Value.Trim();
            service.telephone = this.TextTel.Value.Trim();
            service.zhifubao = this.TextZhifubao.Value.Trim();
            service.bank = this.TextBank.Value.Trim();
            service.bankname = this.TextBank_name.Value.Trim();
            service.banknumber = this.TextBank_number.Value.Trim();
            if (H_ServiceClass.Add(service)&&count>0)
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