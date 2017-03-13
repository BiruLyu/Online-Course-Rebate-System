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
    public partial class getsubordinate_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["basiccourse"] != null)
            {
                string basicId = Request.Form["basiccourse"].ToString();
                string getSql = "select * from H_Subordinate_Course where father=" + basicId;
                DataTable dt = DbHelperSQL.Query(getSql).Tables[0];
                StringBuilder sb = new StringBuilder();
                int total = dt.Rows.Count;
                sb.Append("<option value='-1'>--请选择--</option>");
                for (int i = 0; i < total; i++)
                {
                    string SubID = dt.Rows[i][0].ToString();
                    string Subname = dt.Rows[i][1].ToString();
                    sb.Append("<option value='" + SubID + "'>" + Subname + "</option>");
                }
                Response.Write(sb.ToString());
                Response.End();
            }
        }
    }
}