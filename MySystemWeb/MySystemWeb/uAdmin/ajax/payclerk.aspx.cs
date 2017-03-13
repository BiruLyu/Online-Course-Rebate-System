﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MySystemWeb.uAdmin.ajax
{
    public partial class payclerk : System.Web.UI.Page
    {
        public string qx = "";
        public string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["qx"];
            if (cookie != null)
            {
                qx = cookie.Values["qxid"].ToString();
                username = HttpUtility.UrlDecode(cookie.Values["user"].ToString(), Encoding.UTF8);
                if (qx == "3" || qx == "4")
                {
                    Response.Redirect("Error.aspx");
                }
            }
                if (Request.Form["idArray"] != null)
                {
            string idArray = Request.Form["idArray"].ToString();
                        
                    string[] split = idArray.Split(new char[] { '|' });
                    Dictionary<string, SqlParameter[]> dic = new Dictionary<string, SqlParameter[]>();
                    foreach (string pid in split)
                    {
                        if (pid != "")
                        {
                            Model.H_Order order = H_OrderClass.GetModel(pid);
                            order.id = int.Parse(pid);
                            order.ispayclerk = 1;
                            order.pay_cle_handler = username;
                            order.pay_cle_time = System.DateTime.Now;
                            dic.Add(pid, H_OrderClass.Param(order));
                        }
                    }
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update H_Order set ");
                    strSql.Append("ispayclerk=@ispayclerk,");
                    strSql.Append("pay_cle_handler=@pay_cle_handler,");
                    strSql.Append("pay_cle_time=@pay_cle_time");
                    strSql.Append(" where id=@id");
                    if (DbHelperSQL.ExecuteSqlTran(strSql.ToString(), dic))
                    {
                        Response.Write(Tool.CreateJson("操作成功！", "1"));

                    }
                    else
                    {
                        Response.Write(Tool.CreateJson("操作失败！", "2"));

                    }

                }
                else
                {
                    Response.Write(Tool.CreateJson("缺少参数", "3"));
                }
                Response.End();
            }
         }
  }
