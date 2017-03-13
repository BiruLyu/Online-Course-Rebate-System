using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class userdel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["pid"] != null)
            {

                string pid = Request.Form["pid"].ToString();
                string getName="select username from H_User where id=" + pid + "";
                string username =DbHelperSQL.GetSingle(getName).ToString();
                string getSql = "select * from H_OrderView where student_name='" + username + "' or clerk_name='" + username + "' or exam_handler='" + username + "' or pay_stu_handler='" + username + "' or pay_cle_handler='" + username + "'";             
                DataTable dt = DbHelperSQL.Query(getSql).Tables[0];              
                if (dt.Rows.Count > 0)
                {
                    Response.Write(Tool.CreateJson("对不起，该用户还有其他业务", "2"));


                }
                else
                {
                    if (H_UserClass.Delete(pid))
                        Response.Write(Tool.CreateJson("操作成功", "1"));
                    else
                        Response.Write(Tool.CreateJson("操作失败", "2"));
                }
            }
            else
            {
                Response.Write(Tool.CreateJson("缺少参数", "3"));
            }
            Response.End();
        }
    }
}