using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Text;
namespace MySystemWeb.uAdmin
{
    public partial class Attendance : System.Web.UI.Page
    {
        public string qx = "";
        public string username = "";
        public void InitData()
        {
            string strWhere = "1=1";
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
                username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
            }
            if (qx == "2")
            {
                strWhere += " and username='" + username + "'";
            }
            if (Request.QueryString["username"] != null)
            {
                string username = HttpUtility.UrlDecode(Request.QueryString["username"].ToString(), Encoding.UTF8);
                strWhere += " and username='" + username + "'";
            }
            if (Request.QueryString["begintime"] != null)
            {
                string begintime = DateTime.Parse(Request.QueryString["begintime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                strWhere += " and attendance_time>='" + begintime + "'";

            }
            if (Request.QueryString["endtime"] != null)
            {
                string endtime = DateTime.Parse(Request.QueryString["endtime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                strWhere += " and attendance_time<='" + endtime + "'";

            }
            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }

            int PageSize = 31;
            int TotalCount = 0;            
            DataTable dt = H_AttendanceClass.GetList(PageSize, PageIndex, strWhere, out TotalCount);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            this.LiteralTotal.Text = dt.Rows.Count.ToString() + "天";
            this.LiteralPage.Text = PageClass.BuildPage(PageIndex, TotalCount, PageSize);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}