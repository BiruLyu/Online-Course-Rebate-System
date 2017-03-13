using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class checkbasiccourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["basic_course"] != null)
            {
                string basic_course = Request.Form["basic_course"].ToString();
                string getSql = "select count(*) from H_Basic_Course where basiccourse=" + "'" + basic_course + "'";
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