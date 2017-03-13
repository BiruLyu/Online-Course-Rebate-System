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
    public partial class getbasic_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
           
    
            string getSql = "select * from H_Basic_Course";
            DataTable dt = DbHelperSQL.Query(getSql).Tables[0];
            
            int total = dt.Rows.Count;
            StringBuilder sb = new StringBuilder();
             sb.Append("<option value='-1'>--请选择--</option>");
          
            for (int i = 0; i < total; i++) 
            {
                string basic_courseID = dt.Rows[i][0].ToString();
                string basic_course = dt.Rows[i][1].ToString();
                sb.Append("<option value='"+basic_courseID+"'>"+basic_course+"</option>");
            }
            Response.Write(sb.ToString());
            Response.End();
        }
    }
}