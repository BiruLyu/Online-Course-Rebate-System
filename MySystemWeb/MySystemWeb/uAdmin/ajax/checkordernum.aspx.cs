using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class checkordernum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["order_num"] != null)
            {
                string order_num = Request.Form["order_num"].ToString();
                int len = order_num.Length;
                string getSql = "select count(*) from H_Order where order_number=" + "'" + order_num + "'";
                
                string count = DbHelperSQL.GetSingle(getSql).ToString();
                if (int.Parse(count) > 0)
                {
                    Response.Write(Tool.CreateJson("* 该订单已经存在，请重新填写", "1"));
                  
                }
                else if (len != 6)
                {
                    Response.Write(Tool.CreateJson("* 订单号应为6位数字，请仔细核对，重新填写", "2"));
                }
                else
                {
                    Response.Write(Tool.CreateJson("该订单号符合", "3"));


                }
        
            }
            Response.End();
        }
    }
}