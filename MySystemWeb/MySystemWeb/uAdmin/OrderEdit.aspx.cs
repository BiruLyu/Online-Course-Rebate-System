using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class OrderEdit : System.Web.UI.Page
    {
        public string qx = "";
        public string basic_courseID = "";
        public string sub_courseID = "";
        public string detail_courseID = "";
        public string pid = "";

        public void InitData()
        {
            if (Request.QueryString["pid"] != null)
            {
                pid = Request.QueryString["pid"].ToString();

                Model.H_Order order = H_OrderClass.GetModel(pid);

                this.TextOrder_num.Value = order.order_number;
                sub_courseID = order.course_id.ToString();
                detail_courseID = order.course_id.ToString();

                string subBasicID = "select subordinate_course_id from H_Detail_Course where id=" + sub_courseID;

                sub_courseID = DbHelperSQL.GetSingle(subBasicID).ToString();
                string getBasicID = "select father from H_Subordinate_Course where id=" + sub_courseID;
                basic_courseID = DbHelperSQL.GetSingle(getBasicID).ToString();
                // this.TextOrder_num.Value = H_OrderClass.GetModel(Request.QueryString["pid"].ToString()).order_number;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();

            }
            if (qx == "3")
            {
                Response.Redirect("Error.aspx");
            }

            if (!Page.IsPostBack)
            {
                InitData();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string order_number = this.TextOrder_num.Value.Trim();
            pid = Request.QueryString["pid"];
            // string order_number = TextOrder_num.Value;
            string courseID = this.HiddenCourse.Value;
            string getSql = "update H_Order set order_number='" + order_number + "',course_id=" + courseID + " where id=" + pid + "";

            if (DbHelperSQL.ExecuteSql(getSql) > 0)
            {

                JScript.AlertAndRedirect("操作成功！", "OrderList.aspx", this);
                //JScript.Alert("操作成功！", "a2", this);
                //Response.Redirect("OrderList.aspx");
            }
            else
            {
                JScript.Alert("操作失败！", "a2", this);
            }
        }
    }
}