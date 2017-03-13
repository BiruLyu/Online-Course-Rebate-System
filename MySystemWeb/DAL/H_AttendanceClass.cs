using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public partial class H_AttendanceClass
    {
       public H_AttendanceClass() { }
       #region  Method

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public static bool Add(Model.H_Attendance model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into H_Attendance(");
           strSql.Append("username,attendance_time)");
           strSql.Append(" values (");
           strSql.Append("@username,@attendance_time)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@attendance_time", SqlDbType.Date,3)};
           parameters[0].Value = model.username;
           parameters[1].Value = model.attendance_time;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public static bool Update(Model.H_Attendance model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update H_Attendance set ");
           strSql.Append("username=@username,");
           strSql.Append("attendance_time=@attendance_time");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@attendance_time", SqlDbType.Date,3),
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = model.username;
           parameters[1].Value = model.attendance_time;
           parameters[2].Value = model.id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public static bool Delete(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from H_Attendance ");
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
       public static Model.H_Attendance GetModel(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,username,attendance_time from H_Attendance ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
           parameters[0].Value = id;

           Model.H_Attendance model = new Model.H_Attendance();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               model.username = ds.Tables[0].Rows[0]["username"].ToString();
               if (ds.Tables[0].Rows[0]["attendance_time"].ToString() != "")
               {
                   model.attendance_time = DateTime.Parse(ds.Tables[0].Rows[0]["attendance_time"].ToString());
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
           mypara[0].Value = "H_AttendanceView";
           mypara[1].Value = "*";
           mypara[2].Value = "attendance_time desc";//
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
