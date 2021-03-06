﻿using System;
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
    public partial class PayService3 : System.Web.UI.Page
    {
        public string qx = "";
        public string username = "";
        public void InitData()
        {
            string strWhere = "isexam=1 and ispayservice=0";
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
                username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
            }
            if (Request.QueryString["begintime"] != null)
            {
                string begintime = DateTime.Parse(Request.QueryString["begintime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                strWhere += " and exam_time>='" + begintime + "'";

            }
            if (Request.QueryString["endtime"] != null)
            {
                string endtime = DateTime.Parse(Request.QueryString["endtime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                strWhere += " and exam_time<='" + endtime + "'";

            }
            string getSql = "select sum(service_share) from H_OrderView where " + strWhere;
            object objzj = DbHelperSQL.GetSingle(getSql);
            string total = "";
            if (objzj != null)
            {
                total = objzj.ToString();
            }

            int PageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"].ToString(), out PageIndex);
            }

            int PageSize = 10;
            int TotalCount = 0;
            DataTable dt = H_OrderClass.GetList(PageSize, PageIndex, strWhere, out TotalCount);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            this.LiteralTotal.Text = total;
            this.LiteralPage.Text = PageClass.BuildPage(PageIndex, TotalCount, PageSize);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}