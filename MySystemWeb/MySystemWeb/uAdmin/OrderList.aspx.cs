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
    public partial class OrderList : System.Web.UI.Page
    {
        public string qx = "";
        public string id = "";
        public string strWhere = " 1=1 ";
        public string isexam = "";
        public string ispaystudent = "";
        public string ispayservice = "";
        public string ispayclerk = "";
        public string username = "";
        public string getSql = "";
        private void InitData() 
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
                username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
            }
            if (qx == "4")
            {
                string student_name = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);                
                strWhere = "student_name='" + student_name + "'";
            }
            if (qx == "3")
            {
                string clerk_name = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
                strWhere = "clerk_name='" + clerk_name + "'";
            }
            if (Request.QueryString["order_number"] != null)
            {
                string order_number = HttpUtility.UrlDecode(Request.QueryString["order_number"].ToString(), Encoding.UTF8);
                strWhere += " and order_number='" + order_number + "'";
            }
            if (Request.QueryString["student_name"] != null) 
            {
                string student_name =HttpUtility.UrlDecode(Request.QueryString["student_name"].ToString(),Encoding.UTF8);
                strWhere += " and student_name like '%" + student_name + "%'";
            }
            if (Request.QueryString["clerk_name"] != null)
            {
                if (qx == "4")
                {
                    Response.Redirect("Error.aspx");
                }
                string clerk_name = HttpUtility.UrlDecode(Request.QueryString["clerk_name"].ToString(), Encoding.UTF8);
                strWhere += " and clerk_name='" + clerk_name + "'";
            }

            if (Request.QueryString["course_name"] != null)
            {
                string course_name = HttpUtility.UrlDecode(Request.QueryString["course_name"].ToString(), Encoding.UTF8);
                strWhere += " and course_name like '%" + course_name + "%'";
            }
            if (Request.QueryString["isexam"] != null)
            {
                isexam = Request.QueryString["isexam"].ToString();
                strWhere += " and isexam =" + isexam;
            }
            if (Request.QueryString["ispaystudent"] != null)
            {

                if (qx == "3")
                {
                    Response.Redirect("Error.aspx");
                }
                ispaystudent =Request.QueryString["ispaystudent"].ToString();
                strWhere += " and ispaystudent =" + ispaystudent;
            }
            if (Request.QueryString["ispayclerk"] != null)
            {
                if (qx == "4")
                {
                    Response.Redirect("Error.aspx");
                }
                ispayclerk = Request.QueryString["ispayclerk"].ToString();
                strWhere += " and ispayclerk =" + ispayclerk;
            }
            if (Request.QueryString["ispayservice"] != null)
            {
                if (qx == "4" || qx == "3")
                {
                    Response.Redirect("Error.aspx");
                }
                ispayservice = Request.QueryString["ispayservice"].ToString();
                strWhere += " and ispayservice =" + ispayservice;
            }
            if (Request.QueryString["begintime"] != null)
            {
                string begintime=DateTime.Parse(Request.QueryString["begintime"].ToString()).ToString("yyyy-MM-dd");
          
                    strWhere += " and create_time>='" + begintime+"'";
             
            }
            if (Request.QueryString["endtime"] != null)
            {
                string endtime = DateTime.Parse(Request.QueryString["endtime"].ToString()).ToString("yyyy-MM-dd");

                strWhere += " and create_time<='" + endtime+"'";

            }
            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }

            int PageSize = 10;
            int TotalCount = 0;
            DataTable dt;
            if (qx == "3")
            {
                dt = H_OrderClass2.GetList(PageSize, PageIndex, strWhere, out TotalCount);
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            else
            {
                dt = H_OrderClass.GetList(PageSize, PageIndex, strWhere, out TotalCount);
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            this.LiteralPage.Text = PageClass.BuildPage(PageIndex, TotalCount, PageSize);
             if (qx == "4")
             {
                
                 getSql = "select sum(student_share)from H_OrderView where " + strWhere;
                object objzj = DbHelperSQL.GetSingle(getSql);
                if (objzj != null)
                {
                    this.LiteralTotal.Text = objzj.ToString();
                }
             }
             if (qx == "3") 
             {

                 getSql = "select sum(clerk_share)from H_OrderView2 where " + strWhere;
                 object objzj = DbHelperSQL.GetSingle(getSql);
                 if (objzj != null)
                 {
                     this.LiteralTotal.Text = objzj.ToString();
                 }
             }
          
            
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}