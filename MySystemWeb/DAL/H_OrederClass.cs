using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public partial class H_OrderClass
    {
       public H_OrderClass() { }
       #region  Method

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public static bool Add(Model.H_Order model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into H_Order(");
           strSql.Append("order_number,username,course_id,create_time,isexam,exam_handler,exam_time,ispaystudent,pay_stu_handler,pay_stu_time,ispayclerk,pay_cle_handler,pay_cle_time,ispayservice,pay_ser_time)");
           strSql.Append(" values (");
           strSql.Append("@order_number,@username,@course_id,@create_time,@isexam,@exam_handler,@exam_time,@ispaystudent,@pay_stu_handler,@pay_stu_time,@ispayclerk,@pay_cle_handler,@pay_cle_time,@ispayservice,@pay_ser_time)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@order_number", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@course_id", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@isexam", SqlDbType.TinyInt,1),
					new SqlParameter("@exam_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@exam_time", SqlDbType.DateTime),
					new SqlParameter("@ispaystudent", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_stu_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@pay_stu_time", SqlDbType.DateTime),
					new SqlParameter("@ispayclerk", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_cle_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@pay_cle_time", SqlDbType.DateTime),
					new SqlParameter("@ispayservice", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_ser_time", SqlDbType.DateTime)};
           parameters[0].Value = model.order_number;
           parameters[1].Value = model.username;
           parameters[2].Value = model.course_id;
           parameters[3].Value = model.create_time;
           parameters[4].Value = model.isexam;
           parameters[5].Value = model.exam_handler;
           parameters[6].Value = model.exam_time;
           parameters[7].Value = model.ispaystudent;
           parameters[8].Value = model.pay_stu_handler;
           parameters[9].Value = model.pay_stu_time;
           parameters[10].Value = model.ispayclerk;
           parameters[11].Value = model.pay_cle_handler;
           parameters[12].Value = model.pay_cle_time;
           parameters[13].Value = model.ispayservice;
           parameters[14].Value = model.pay_ser_time;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }
       public static SqlParameter[] Param(Model.H_Order model)
       {
           SqlParameter[] parameters = {
	                new SqlParameter("@ispaystudent", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_stu_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@pay_stu_time", SqlDbType.DateTime),
					new SqlParameter("@ispayclerk", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_cle_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@pay_cle_time", SqlDbType.DateTime),
					new SqlParameter("@ispayservice", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_ser_time", SqlDbType.DateTime),
                    new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = model.ispaystudent;
           parameters[1].Value = model.pay_stu_handler;
           parameters[2].Value = model.pay_stu_time;
           parameters[3].Value = model.ispayclerk;
           parameters[4].Value = model.pay_cle_handler;
           parameters[5].Value = model.pay_cle_time;
           parameters[6].Value = model.ispayservice;
           parameters[7].Value = model.pay_ser_time;
           parameters[8].Value = model.id;
           return parameters;
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public static bool Update(Model.H_Order model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update H_Order set ");
           strSql.Append("order_number=@order_number,");
           strSql.Append("username=@username,");
           strSql.Append("course_id=@course_id,");
           strSql.Append("create_time=@create_time,");
           strSql.Append("isexam=@isexam,");
           strSql.Append("exam_handler=@exam_handler,");
           strSql.Append("exam_time=@exam_time,");
           strSql.Append("ispaystudent=@ispaystudent,");
           strSql.Append("pay_stu_handler=@pay_stu_handler,");
           strSql.Append("pay_stu_time=@pay_stu_time,");
           strSql.Append("ispayclerk=@ispayclerk,");
           strSql.Append("pay_cle_handler=@pay_cle_handler,");
           strSql.Append("pay_cle_time=@pay_cle_time,");
           strSql.Append("ispayservice=@ispayservice,");
           strSql.Append("pay_ser_time=@pay_ser_time");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@order_number", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@course_id", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@isexam", SqlDbType.TinyInt,1),
					new SqlParameter("@exam_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@exam_time", SqlDbType.DateTime),
					new SqlParameter("@ispaystudent", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_stu_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@pay_stu_time", SqlDbType.DateTime),
					new SqlParameter("@ispayclerk", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_cle_handler", SqlDbType.NVarChar,50),
					new SqlParameter("@pay_cle_time", SqlDbType.DateTime),
					new SqlParameter("@ispayservice", SqlDbType.TinyInt,1),
					new SqlParameter("@pay_ser_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = model.order_number;
           parameters[1].Value = model.username;
           parameters[2].Value = model.course_id;
           parameters[3].Value = model.create_time;
           parameters[4].Value = model.isexam;
           parameters[5].Value = model.exam_handler;
           parameters[6].Value = model.exam_time;
           parameters[7].Value = model.ispaystudent;
           parameters[8].Value = model.pay_stu_handler;
           parameters[9].Value = model.pay_stu_time;
           parameters[10].Value = model.ispayclerk;
           parameters[11].Value = model.pay_cle_handler;
           parameters[12].Value = model.pay_cle_time;
           parameters[13].Value = model.ispayservice;
           parameters[14].Value = model.pay_ser_time;
           parameters[15].Value = model.id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public static bool Delete(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from H_Order ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
           parameters[0].Value = id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public static Model.H_Order GetModel(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,order_number,username,course_id,create_time,isexam,exam_handler,exam_time,ispaystudent,pay_stu_handler,pay_stu_time,ispayclerk,pay_cle_handler,pay_cle_time,ispayservice,pay_ser_time from H_Order ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
           parameters[0].Value = id;

           Model.H_Order model = new Model.H_Order();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               model.order_number = ds.Tables[0].Rows[0]["order_number"].ToString();
               model.username = ds.Tables[0].Rows[0]["username"].ToString();
               if (ds.Tables[0].Rows[0]["course_id"].ToString() != "")
               {
                   model.course_id = int.Parse(ds.Tables[0].Rows[0]["course_id"].ToString());
               }
               if (ds.Tables[0].Rows[0]["create_time"].ToString() != "")
               {
                   model.create_time = DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
               }
               if (ds.Tables[0].Rows[0]["isexam"].ToString() != "")
               {
                   model.isexam = int.Parse(ds.Tables[0].Rows[0]["isexam"].ToString());
               }
               model.exam_handler = ds.Tables[0].Rows[0]["exam_handler"].ToString();
               if (ds.Tables[0].Rows[0]["exam_time"].ToString() != "")
               {
                   model.exam_time = DateTime.Parse(ds.Tables[0].Rows[0]["exam_time"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ispaystudent"].ToString() != "")
               {
                   model.ispaystudent = int.Parse(ds.Tables[0].Rows[0]["ispaystudent"].ToString());
               }
               model.pay_stu_handler = ds.Tables[0].Rows[0]["pay_stu_handler"].ToString();
               if (ds.Tables[0].Rows[0]["pay_stu_time"].ToString() != "")
               {
                   model.pay_stu_time = DateTime.Parse(ds.Tables[0].Rows[0]["pay_stu_time"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ispayclerk"].ToString() != "")
               {
                   model.ispayclerk = int.Parse(ds.Tables[0].Rows[0]["ispayclerk"].ToString());
               }
               model.pay_cle_handler = ds.Tables[0].Rows[0]["pay_cle_handler"].ToString();
               if (ds.Tables[0].Rows[0]["pay_cle_time"].ToString() != "")
               {
                   model.pay_cle_time = DateTime.Parse(ds.Tables[0].Rows[0]["pay_cle_time"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ispayservice"].ToString() != "")
               {
                   model.ispayservice = int.Parse(ds.Tables[0].Rows[0]["ispayservice"].ToString());
               }
               if (ds.Tables[0].Rows[0]["pay_ser_time"].ToString() != "")
               {
                   model.pay_ser_time = DateTime.Parse(ds.Tables[0].Rows[0]["pay_ser_time"].ToString());
               }
               return model;
           }
           else
           {
               return null;
           }
       }
       public static DataTable GetList(int M_PageSize, int M_PageIndex, string M_WhereString, out int M_TotalRecord)
       {
           SqlParameter[] mypara = new SqlParameter[7];
           mypara[0] = new SqlParameter("@TableName", SqlDbType.NVarChar, 50);
           mypara[1] = new SqlParameter("@ReFieldsStr", SqlDbType.NVarChar, 200);
           mypara[2] = new SqlParameter("@OrderString", SqlDbType.NVarChar, 200);
           mypara[3] = new SqlParameter("@WhereString", SqlDbType.NVarChar, 1000);
           mypara[4] = new SqlParameter("@PageSize", SqlDbType.Int, 4);
           mypara[5] = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
           mypara[6] = new SqlParameter("@TotalRecord", SqlDbType.Int, 4);
           mypara[0].Value = "H_OrderView";
           mypara[1].Value = "*";
           mypara[2].Value = "id desc";
           mypara[3].Value = M_WhereString;
           mypara[4].Value = M_PageSize;
           mypara[5].Value = M_PageIndex;
           mypara[6].Direction = ParameterDirection.Output;//返回记录数


           DataTable dt = DbHelperSQL.RunProcedure("Proc_Page2005", mypara, "page").Tables["page"];
           M_TotalRecord = (int)mypara[6].Value;
           return dt;
       }
       #endregion  Method
    }
}
