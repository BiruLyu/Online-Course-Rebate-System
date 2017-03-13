using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
namespace MySystemWeb.uAdmin
{
    public partial class ClerkEdit : System.Web.UI.Page
    {
        public string qx = "";
        private void initData() 
        {
              if(Request.QueryString["pid"]!=null)
              {
                  string id=Request.QueryString["pid"].ToString();
                  Model.H_Clerk clerk=H_ClerkClass.GetModel(id);
                  this.TextName.Value = clerk.name;
                  this.TextPhone.Value = clerk.phone;
                  this.TextTel.Value = clerk.telphone;
                  this.TextTeamViewerID.Value = clerk.TeamViewerID;
                  this.TextZhifubao.Value = clerk.zhifubao;
                  this.TextBank.Value = clerk.bank_region;
                  this.TextBank_name.Value = clerk.bank_name;
                  this.TextBank_number.Value = clerk.bank_number;
              }
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx == "4")
            {
                Response.Redirect("Error.aspx");
            }
            if (!Page.IsPostBack) 
            {
                initData();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Clerk clerk = new Model.H_Clerk();
            clerk.id = int.Parse(Request.QueryString["pid"]);
            clerk.name = this.TextName.Value.Trim();
            clerk.username = H_ClerkClass.GetModel(Request.QueryString["pid"].ToString()).username;
            clerk.phone = this.TextPhone.Value.Trim();
            clerk.TeamViewerID = this.TextTeamViewerID.Value.Trim();
            clerk.telphone = this.TextTel.Value.Trim();
            clerk.zhifubao = this.TextZhifubao.Value.Trim();
            clerk.bank_region = this.TextBank.Value.Trim();
            clerk.bank_name = this.TextBank_name.Value.Trim();
            clerk.bank_number = this.TextBank_number.Value.Trim();
            clerk.region_province = this.HiddenProvince.Value.ToString();
            clerk.region_city = this.HiddenCity.Value.ToString();
            clerk.region_county = this.HiddenArea.Value.ToString(); 
 
            if (H_ClerkClass.Update(clerk))
            {
                JScript.AlertAndRedirect("操作成功！", "ClerkList.aspx", this);
            }
            else 
            {
                JScript.Alert("操作失败！","a2",this);
            }

        }
    }
}