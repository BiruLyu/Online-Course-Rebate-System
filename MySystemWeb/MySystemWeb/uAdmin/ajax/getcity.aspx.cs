using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace MySystemWeb.uAdmin.ajax
{
    public partial class getcity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["province"] != null)
            {
                string provinceId = Request.Form["province"].ToString();
                string getSql = "select * from City where father=" + provinceId;
                DataTable dt = DbHelperSQL.Query(getSql).Tables[0];
                StringBuilder sb = new StringBuilder();
                int total = dt.Rows.Count;
                sb.Append("<option value='-1'>--请选择--</option>");
                for (int i = 0; i < total; i++)
                {
                    string cityID = dt.Rows[i][1].ToString();
                    string city = dt.Rows[i][2].ToString();
                    sb.Append("<option value='" + cityID + "'>" + city + "</option>");
                }
                Response.Write(sb.ToString());
                Response.End();
            }
        }
    }
}