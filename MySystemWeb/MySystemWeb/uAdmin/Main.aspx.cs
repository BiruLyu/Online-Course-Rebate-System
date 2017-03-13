using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text;
namespace MySystemWeb.uAdmin
{
    public partial class Main : System.Web.UI.Page
    {
        public string qx = "";
        public string username = "";
        public string isoccupy = "";
        public DateTime exam_time = System.DateTime.Now.AddDays(-1);
        protected void Page_Load(object sender, EventArgs e)
        {
        
                HttpCookie cookie = Request.Cookies["qx"];
                if (cookie != null)
                {
                    username=HttpUtility.UrlDecode( cookie.Values["user"].ToString(),Encoding.UTF8);
                    this.LabelUser.Text =username;
                    qx = cookie.Values["qxid"].ToString();                   
                    string getSql = "select isoccupy from H_User where username='" + username + "'";
                    isoccupy = DbHelperSQL.GetSingle(getSql).ToString();
                    //isoccupy = cookie.Values["isoccupy"].ToString();
                    if (qx == "2")
                    {
                        Model.H_Attendance attendance = new Model.H_Attendance();
                        attendance.attendance_time = System.DateTime.Now.Date;
                        attendance.username = username;
                        H_AttendanceClass.Add(attendance);
                    }

                }


                else
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }
    }
