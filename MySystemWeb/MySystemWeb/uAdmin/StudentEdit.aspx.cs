using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    
    public partial class StudentEdit : System.Web.UI.Page
    {
        public string qx = "";
        
        private void InitData() 
        {
            if (Request.QueryString["pid"] != null)
            {
                string pid = Request.QueryString["pid"].ToString();
                Model.H_Student student = H_StudentClass.GetModel(pid);
                
                this.TextName.Value = student.name;
                this.TextEmail.Value = student.email;
                this.TextTel.Value = student.telphone;
                this.TextZhifubao.Value = student.zhifubao;
                this.TextBank.Value = student.bank;
                this.TextBank_name.Value = student.bank_name;
                this.TextBank_number.Value = student.bank_num;          
               


            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx == "3") 
            {
                Response.Redirect("Error.aspx");
            }
            if (!Page.IsPostBack)
                InitData();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Student student = new Model.H_Student();
            student.id = int.Parse(Request.QueryString["pid"]);
            student.name = this.TextName.Value.Trim();
            student.username = H_StudentClass.GetModel(Request.QueryString["pid"].ToString()).username;
            student.email = this.TextEmail.Value.Trim();
            student.telphone = this.TextTel.Value.Trim();
            student.zhifubao = this.TextZhifubao.Value.Trim();
            student.bank = this.TextBank.Value.Trim();
            student.bank_name = this.TextBank_name.Value.Trim();
            student.bank_num = this.TextBank_number.Value.Trim();
            student.region_province = H_StudentClass.GetModel(Request.QueryString["pid"].ToString()).region_province;
            student.region_city = H_StudentClass.GetModel(Request.QueryString["pid"].ToString()).region_city;
            student.region_county = H_StudentClass.GetModel(Request.QueryString["pid"].ToString()).region_county;
            if (H_StudentClass.Update(student))
            {
                JScript.AlertAndRedirect("操作成功！", "StudentList.aspx", this);
            }
            else 
            {
                JScript.AlertAndRedirect("操作失败！","a2",this);
            }
        }
    }
}