using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;

namespace MySystemWeb.uAdmin
{
    public partial class BasicCourseList : System.Web.UI.Page
    {
        public string qx = "";
        private void InitData() 
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
            }
            if (qx != "1") 
            {
                Response.Redirect("Error.aspx");
            }
            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }

            int PageSize = 10;
            int TotalCount = 0;
            string strWhere = " 1=1 ";
            DataTable dt = H_Basic_CourseClass.GetList(PageSize, PageIndex, strWhere, out TotalCount);
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