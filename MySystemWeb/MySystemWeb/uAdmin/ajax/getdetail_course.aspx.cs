using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class getdetail_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["basic_courseID"] != null) 
            {
                string basic_courseID = Request.Form["basic_courseID"];
                string strWhere = " subordinate_course_id="+basic_courseID+"";
                string getSql = "select * from H_Detail_Course where "+strWhere;
                DataTable dt = DbHelperSQL.Query(getSql).Tables[0];
                StringBuilder sb = new StringBuilder();
                if (Request.Form["pid"] == null)
                {
                    sb.Append("<option value='-1'>--请选择--</option>");
                }
                int total = dt.Rows.Count;
                for (int i = 0; i < total; i++)
                {
                    string detail_courseID = dt.Rows[i][0].ToString();
                    string detail_course = dt.Rows[i][2].ToString();
                    sb.Append("<option value='"+detail_courseID+"'>"+detail_course+"</option>");

                }
                Response.Write(sb.ToString());
            }
            Response.End();
        }

    }
}