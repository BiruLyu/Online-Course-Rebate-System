using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class UserList : System.Web.UI.Page
    {
        private void InitUserData()
        {
            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }

            int PageSize = 10;
            int TotalCount = 0;
            string strWhere = "id>1";
            if (Request.QueryString["user_name"] != null)
            {
                string user_name = HttpUtility.UrlDecode(Request.QueryString["user_name"].ToString(), Encoding.UTF8);
                strWhere += "and username like'%" + user_name + "%'";
            }
            if (Request.QueryString["qxid"] != null)
            {
                string qxid = HttpUtility.UrlDecode(Request.QueryString["qxid"].ToString(), Encoding.UTF8);
                strWhere += "and qxid="+ qxid +"";
            }
            DataTable dt = H_UserClass.GetList(PageSize, PageIndex, strWhere, out TotalCount);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            this.LiteralPage.Text = PageClass.BuildPage(PageIndex, TotalCount, PageSize);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                if(cookie.Values["qxid"] != "1")
                {
                    Response.Redirect("Error.aspx");
                }

            }
            InitUserData();
        }
    }
}