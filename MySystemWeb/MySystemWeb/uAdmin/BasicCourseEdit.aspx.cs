using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
namespace MySystemWeb.uAdmin
{
    public partial class BasicCourseEdit : System.Web.UI.Page
    {
        public string qx = "";
        private void InitData() 
        {
            if (Request.QueryString["pid"] != null) 
            {
                string pid = Request.QueryString["pid"].ToString();
                Model.H_Basic_Course basic_course = H_Basic_CourseClass.GetModel(pid);         
              
                this.TextBasicCourse.Value = basic_course.basiccourse;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx!="1" )
            {
                Response.Write("Error.aspx");
            }
            if (!Page.IsPostBack)
                InitData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Basic_Course basic_course = new Model.H_Basic_Course();
            basic_course.id = int.Parse(Request.QueryString["pid"]);
            basic_course.basiccourse = this.TextBasicCourse.Value.Trim();
          
            if (H_Basic_CourseClass.Update(basic_course))
            {
                JScript.AlertAndRedirect("操作成功", "BasicCourseList.aspx", this);
            }
            else 
            {
                JScript.AlertAndRedirect("操作失败","a2",this);
            }
        }
    }
}