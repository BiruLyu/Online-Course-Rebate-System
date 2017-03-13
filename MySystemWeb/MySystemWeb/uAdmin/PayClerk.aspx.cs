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
    public partial class SailStatic : System.Web.UI.Page
    {
        public string qx = "";
        public string isexam = "";
        public string ispayclerk = "";
        public void InitData()
        {
            string strWhere = " 1=1 ";
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx == "3")
            {
                string username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
              strWhere = "clerk_name='" + username + "'";
            }
            if (qx == "4") 
            {
                Response.Redirect("Error.aspx");
            }
            if (Request.QueryString["isexam"] != null)
            {
                isexam = Request.QueryString["isexam"].ToString();
                strWhere += " and isexam =" + isexam;
            }
            if (Request.QueryString["ispayclerk"] != null)
            {
                ispayclerk = Request.QueryString["ispayclerk"].ToString();
                strWhere += " and ispayclerk =" + ispayclerk;
            }
            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }
           

            int PageSize = 10;
            int TotalCount = 0;          
            if (Request.QueryString["area"] != null) 
            {
                string area = HttpUtility.UrlDecode(Request.QueryString["area"].ToString(), Encoding.UTF8);
                strWhere += " and region_county=" +area;
            }
            if (Request.QueryString["clerk_name"] != null) 
            {
                string clerk_name = HttpUtility.UrlDecode(Request.QueryString["clerk_name"].ToString(),Encoding.UTF8);
                strWhere+=" and name like '%"+clerk_name+"%'";
            }
            //string total = DbHelperSQL.GetSingle("select total from H_SumSail where  " + strWhere).ToString();
            DataTable dt = H_SailStaticClass.GetPayClerkList(PageSize, PageIndex, strWhere, out TotalCount);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            //this.LiteralTotal.Text = total;
            this.LiteralPage.Text = PageClass.BuildPage(PageIndex, TotalCount, PageSize);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}