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
    public partial class getarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["city"] != null)
            {
                string cityId = Request.Form["city"].ToString();
                string getSql = "select * from Area where father=" + cityId;
                DataTable dt = DbHelperSQL.Query(getSql).Tables[0];
                StringBuilder sb = new StringBuilder();
                int total = dt.Rows.Count;
                sb.Append("<option value='-1'>--请选择--</option>");
                for (int i = 0; i < total; i++)
                {
                    string areaID = dt.Rows[i][1].ToString();
                    string area = dt.Rows[i][2].ToString();
                    sb.Append("<option value='" + areaID + "'>" + area + "</option>");
                }
                Response.Write(sb.ToString());
                Response.End();
            }
        }
    }
}