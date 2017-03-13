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
    public partial class ClerkList : System.Web.UI.Page
    {
        public string qx = "";
        public string id = "";
        public string strWhere = " 1=1 ";
        private void InitData()
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx == "4")
            {
                Response.Redirect("Error.aspx");
            }
            if (qx == "3")
            {
                string username = HttpUtility.UrlDecode(Request.Cookies["qx"].Values["user"].ToString(), Encoding.UTF8);
                strWhere = "username='"+username+"'";
            }
            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }

            int PageSize = 10;
            int TotalCount = 0;
             ;
            DataTable dt = H_ClerkClass.GetList(PageSize, PageIndex, strWhere, out TotalCount);
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