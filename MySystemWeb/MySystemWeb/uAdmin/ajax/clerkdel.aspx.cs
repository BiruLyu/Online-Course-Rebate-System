using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Course_Registration_Sys.uAdmin.ajax
{
    public partial class clerkdel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["pid"] != null)
            {
                string pid = Request.Form["pid"].ToString();
               
                string getSql = "select * from H_OrderView where clerk_name=(select username from H_Clerk where id="+pid+")";
                int count = DbHelperSQL.Query(getSql).Tables[0].Rows.Count;
                if (count > 0)
                {
                    Response.Write(Tool.CreateJson("该工作人员下有相关业务，不能被删除掉", "2"));                 
                    

                }
                else
                {
                    if (H_ClerkClass.Delete(pid))
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
                Response.Write(Tool.CreateJson("缺少参数", "3"));

            }
            Response.End();
        }
    }
}