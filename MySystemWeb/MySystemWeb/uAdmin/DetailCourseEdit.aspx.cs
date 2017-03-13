using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class DetailCourseEdit : System.Web.UI.Page
    {
        public string qx="";
        private void InitData() 
        {
            if (Request.QueryString["pid"] != null) 
            {
                string pid = Request.QueryString["pid"].ToString();
                Model.H_Detail_Course detail_course = H_Detail_CourseClass.GetModel(pid);
                this.TextDetailCourse.Value = detail_course.course_name;
                this.TextPur_Price.Value = detail_course.course_pur_price.ToString();
                this.TextSel_Price.Value = detail_course.course_sel_price.ToString();
                this.TextStudent_Share.Value = detail_course.student_share.ToString();
                this.TextClerk_Share.Value = detail_course.clerk_share.ToString();
                this.TextService_Share.Value = detail_course.service_share.ToString();               
               
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx != "1")
            {
                Response.Write("Error.aspx");
            }
            if(!Page.IsPostBack)
            InitData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.H_Detail_Course detail_course = new Model.H_Detail_Course();
            detail_course.id = int.Parse(Request.QueryString["pid"]);
            detail_course.course_name = this.TextDetailCourse.Value.Trim();
            detail_course.course_pur_price=double.Parse(this.TextPur_Price.Value.Trim());
            detail_course.course_sel_price = double.Parse(this.TextSel_Price.Value.Trim());
            detail_course.student_share = double.Parse(this.TextStudent_Share.Value.Trim());
            detail_course.clerk_share = double.Parse(this.TextClerk_Share.Value.Trim());
            detail_course.service_share = double.Parse(this.TextService_Share.Value.Trim());
            if (H_Detail_CourseClass.Update(detail_course))
            {
                JScript.AlertAndRedirect("操作成功", "DetailCourseList.aspx", this);

            }
            else 
            {
                JScript.Alert("操作失败","a2",this);
            }

        }
    }
}