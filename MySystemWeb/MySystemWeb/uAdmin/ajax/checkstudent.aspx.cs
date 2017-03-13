using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class checkstudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["studentname"] != null) 
            {
                string studentname = Request.Form["studentname"].ToString();


            }
        }
    }
}