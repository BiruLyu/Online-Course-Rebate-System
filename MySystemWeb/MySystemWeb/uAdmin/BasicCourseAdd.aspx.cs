using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class BasicCourseAdd : System.Web.UI.Page
    {
        public string qx = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx!="1")
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Basic_Course basic_course = new Model.H_Basic_Course();
            basic_course.province = this.HiddenProvince.Value.ToString();
            basic_course.basiccourse = this.TextBasicCourse.Value;
            if (H_Basic_CourseClass.Add(basic_course))
            {
                JScript.Alert("操作成功！", "a2", this);
            }
            else 
            {
                JScript.Alert("操作失败！","a2",this);
            }
        }
    }
}