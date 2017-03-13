using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class basiccoursedel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["pid"] != null)
            {
                string pid = Request.Form["pid"].ToString();
                string getSql = "select * from H_Detail_Course where subordinate_course_id=" + pid;
                int count = DbHelperSQL.Query(getSql).Tables[0].Rows.Count;
                if (count > 0)
                {
                    Response.Write(Tool.CreateJson("此基础课程下有详细课程，不能被删除掉", "2"));
                    Response.End();
                    return;

                }
                else
                {
                    if (H_Basic_CourseClass.Delete(pid))
                    {
                        Response.Write(Tool.CreateJson("操作成功", "1"));
                    }
                    else
                    {
                        Response.Write(Tool.CreateJson("操作失败", "2"));
                    }

                }
            }
            else 
            {
                Response.Write(Tool.CreateJson("缺少参数","3"));
              
            }
            Response.End();
        }
    }
}