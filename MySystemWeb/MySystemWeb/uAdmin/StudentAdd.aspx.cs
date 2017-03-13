using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class StudentAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_User user = new Model.H_User();
            Model.H_Student student = new Model.H_Student();
            user.username = this.TextUser.Value.Trim();
            user.password = this.TextPwd.Value.Trim();
            user.qxid = 4;
            user.isoccupy = 1;
            student.username = this.TextUser.Value.Trim();
            student.name = this.TextName.Value.Trim();
            student.email = this.TextEmail.Value.Trim();
            student.telphone = this.TextTel.Value.Trim();
            student.zhifubao = this.TextZhifubao.Value.Trim();
            student.bank = this.TextBank.Value.Trim();
            student.bank_name = this.TextBank_name.Value.Trim();
            student.bank_num = this.TextBank_number.Value.Trim();
            student.region_province = this.HiddenProvince.Value.ToString();
            student.region_city = this.HiddenCity.Value.ToString();
            student.region_county = this.HiddenArea.Value.ToString();
            if (H_UserClass.Add(user)&&H_StudentClass.Add(student))
            {
                JScript.Alert("操作成功", "a2", this);
                Response.Redirect("AdminLogin.aspx");

            }
            else 
            {
                JScript.Alert("操作失败","a2",this);
            }
        }
    }
}