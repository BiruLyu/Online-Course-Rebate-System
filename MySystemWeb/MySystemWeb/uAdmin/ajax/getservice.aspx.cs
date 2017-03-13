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
    public partial class getservice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string getSql = "select * from H_User where qxid=2 ";
            DataTable dt = DbHelperSQL.Query(getSql).Tables[0];
            StringBuilder sb = new StringBuilder();
            int total = dt.Rows.Count;
            sb.Append("<option value='-1'>--请选择--</option>");
            for (int i = 0; i < total; i++)
            {
               
                string username = dt.Rows[i][1].ToString();
                sb.Append("<option value='" + username + "'>" + username + "</option>");
            }
            Response.Write(sb.ToString());
            Response.End();

        }
    }
}