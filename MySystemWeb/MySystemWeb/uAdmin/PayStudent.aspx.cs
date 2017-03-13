using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DAL;
using System.Text;

namespace MySystemWeb.uAdmin
{
    public partial class PayStudent : System.Web.UI.Page
    {
        public string qx = "";
        public string isexam = "";
        public string ispaystudent = "";
        public void InitData()
        {
            string strWhere = " 1=1 ";
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx == "4")
            {
                string username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
                strWhere= "student_name='" + username + "'";
            }
            if (Request.QueryString["isexam"] != null)
            {
                isexam = Request.QueryString["isexam"].ToString();
                strWhere += " and isexam =" + isexam;
            }
            if (Request.QueryString["ispaystudent"] != null)
            {
                ispaystudent = Request.QueryString["ispaystudent"].ToString();
                strWhere += " and ispaystudent =" + ispaystudent;
            }
            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }

            int PageSize = 10;
            int TotalCount = 0;            
            DataTable dt =H_SailStaticClass.GetPayStudentList(PageSize, PageIndex, strWhere, out TotalCount);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            this.LiteralPage.Text = PageClass.BuildPage(PageIndex, TotalCount, PageSize);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}