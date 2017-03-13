using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class ServiceEdit : System.Web.UI.Page
    {
        public string qx = "";
        public void InitData() 
        {
            if(Request.QueryString["pid"]!=null)
            {
                string pid = Request.QueryString["pid"].ToString();
                Model.H_Service service = H_ServiceClass.GetModel(pid);
                this.TextName.Value= service.name ;
               this.TextTeamViewerID.Value =service.TeamViewerID  ;
               this.TextTel.Value =service.telephone ;
               this.TextZhifubao.Value = service.zhifubao;
               this.TextBank.Value = service.bank;
               this.TextBank_name.Value = service.bankname;
               this.TextBank_number.Value = service.banknumber;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx=="3"||qx=="4")
            {
                Response.Write("Error.aspx");
            }
            if (!Page.IsPostBack) 
            {
                InitData();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Service service = new Model.H_Service();          
            
            service.name = this.TextName.Value.Trim();
            service.TeamViewerID = this.TextTeamViewerID.Value.Trim();
            service.telephone = this.TextTel.Value.Trim();
            service.zhifubao = this.TextZhifubao.Value.Trim();
            service.bank = this.TextBank.Value.Trim();
            service.bankname = this.TextBank_name.Value.Trim();
            service.banknumber = this.TextBank_number.Value.Trim();
            service.id =int.Parse( Request.QueryString["pid"]);
            if (H_ServiceClass.Update(service))
            {
                //JScript.Alert("操作成功", "a2", this);
                JScript.AlertAndRedirect("操作成功！", "ServiceList.aspx", this);
            }
            else 
            {
                JScript.Alert("操作失败","a2",this);

            }
        }
    }
}