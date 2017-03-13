using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class checkdetailcourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["detailcourse"] != null && Request.Form["basic_courseID"]!=null)
            {
                string basic_courseID = Request.Form["basic_courseID"].ToString();
                string detailcourse = Request.Form["detailcourse"].ToString();
                string getSql = "select count(*) from H_Detail_Course where course_name=" + "'" + detailcourse + "'" + " and subordinate_course_id="+basic_courseID+"";
                string count = DbHelperSQL.GetSingle(getSql).ToString();
                if (int.Parse(count) > 0)
                {
                    Response.Write(Tool.CreateJson("该课程已经存在，请重新填写", "1"));

                }
                else
                {
                    Response.Write(Tool.CreateJson("该课程名符合", "2"));


                }

            }
            Response.End();
        }
    }
}