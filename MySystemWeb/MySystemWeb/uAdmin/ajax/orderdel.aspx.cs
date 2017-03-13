using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class orderdel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["pid"] != null)
            {
                string pid = Request.Form["pid"].ToString();
                string getSql = "select isexam from H_Order where id="+pid+"";
                string isexam = DbHelperSQL.GetSingle(getSql).ToString();                
                if (isexam=="1")
                {
                    Response.Write(Tool.CreateJson("该订单已核对，不能被删除", "2"));


                }
                else
                {
                    if (H_OrderClass.Delete(pid))
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