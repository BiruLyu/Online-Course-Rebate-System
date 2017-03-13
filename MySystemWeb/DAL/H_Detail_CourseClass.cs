using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
  public partial  class H_Detail_CourseClass
    {
      public H_Detail_CourseClass(){}
      #region  Method

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public static bool Add(Model.H_Detail_Course model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("insert into H_Detail_Course(");
          strSql.Append("subordinate_course_id,course_name,course_ori_price,course_sel_price,course_pur_price,student_share,clerk_share,service_share)");
          strSql.Append(" values (");
          strSql.Append("@subordinate_course_id,@course_name,@course_ori_price,@course_sel_price,@course_pur_price,@student_share,@clerk_share,@service_share)");
          strSql.Append(";select @@IDENTITY");
          SqlParameter[] parameters = {
					new SqlParameter("@subordinate_course_id", SqlDbType.Int,4),
					new SqlParameter("@course_name", SqlDbType.NVarChar,50),
					new SqlParameter("@course_ori_price", SqlDbType.Float,9),
					new SqlParameter("@course_sel_price", SqlDbType.Float,9),
					new SqlParameter("@course_pur_price", SqlDbType.Float,9),
					new SqlParameter("@student_share", SqlDbType.Float,9),
					new SqlParameter("@clerk_share", SqlDbType.Float,9),
					new SqlParameter("@service_share", SqlDbType.Float,9)};
          parameters[0].Value = model.subordinate_course_id;
          parameters[1].Value = model.course_name;
          parameters[2].Value = model.course_ori_price;
          parameters[3].Value = model.course_sel_price;
          parameters[4].Value = model.course_pur_price;
          parameters[5].Value = model.student_share;
          parameters[6].Value = model.clerk_share;
          parameters[7].Value = model.service_share;

          return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
      }
      /// <summary>
      /// 更新一条数据
      /// </summary>
      public static bool Update(Model.H_Detail_Course model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update H_Detail_Course set ");
          strSql.Append("subordinate_course_id=@subordinate_course_id,");
          strSql.Append("course_name=@course_name,");
          strSql.Append("course_ori_price=@course_ori_price,");
          strSql.Append("course_sel_price=@course_sel_price,");
          strSql.Append("course_pur_price=@course_pur_price,");
          strSql.Append("student_share=@student_share,");
          strSql.Append("clerk_share=@clerk_share,");
          strSql.Append("service_share=@service_share");
          strSql.Append(" where id=@id");
          SqlParameter[] parameters = {
					new SqlParameter("@subordinate_course_id", SqlDbType.Int,4),
					new SqlParameter("@course_name", SqlDbType.NVarChar,50),
					new SqlParameter("@course_ori_price", SqlDbType.Float,9),
					new SqlParameter("@course_sel_price", SqlDbType.Float,9),
					new SqlParameter("@course_pur_price", SqlDbType.Float,9),
					new SqlParameter("@student_share", SqlDbType.Float,9),
					new SqlParameter("@clerk_share", SqlDbType.Float,9),
					new SqlParameter("@service_share", SqlDbType.Float,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
          parameters[0].Value = model.subordinate_course_id;
          parameters[1].Value = model.course_name;
          parameters[2].Value = model.course_ori_price;
          parameters[3].Value = model.course_sel_price;
          parameters[4].Value = model.course_pur_price;
          parameters[5].Value = model.student_share;
          parameters[6].Value = model.clerk_share;
          parameters[7].Value = model.service_share;
          parameters[8].Value = model.id;

          return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
      }


      /// <summary>
      /// 删除一条数据
      /// </summary>
      public static bool Delete(string id)
      {

          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete from H_Detail_Course ");
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
      public static Model.H_Detail_Course GetModel(string id)
      {

          StringBuilder strSql = new StringBuilder();
          strSql.Append("select  top 1 id,subordinate_course_id,course_name,course_ori_price,course_sel_price,course_pur_price,student_share,clerk_share,service_share from H_Detail_Course ");
          strSql.Append(" where id=@id");
          SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
          parameters[0].Value = id;

          Model.H_Detail_Course model = new Model.H_Detail_Course();
          DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
          if (ds.Tables[0].Rows.Count > 0)
          {
              if (ds.Tables[0].Rows[0]["id"].ToString() != "")
              {
                  model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
              }
              if (ds.Tables[0].Rows[0]["subordinate_course_id"].ToString() != "")
              {
                  model.subordinate_course_id = int.Parse(ds.Tables[0].Rows[0]["subordinate_course_id"].ToString());
              }
              model.course_name = ds.Tables[0].Rows[0]["course_name"].ToString();
              if (ds.Tables[0].Rows[0]["course_ori_price"].ToString() != "")
              {
                  model.course_ori_price = double.Parse(ds.Tables[0].Rows[0]["course_ori_price"].ToString());
              }
              if (ds.Tables[0].Rows[0]["course_sel_price"].ToString() != "")
              {
                  model.course_sel_price = double.Parse(ds.Tables[0].Rows[0]["course_sel_price"].ToString());
              }
              if (ds.Tables[0].Rows[0]["course_pur_price"].ToString() != "")
              {
                  model.course_pur_price = double.Parse(ds.Tables[0].Rows[0]["course_pur_price"].ToString());
              }
              if (ds.Tables[0].Rows[0]["student_share"].ToString() != "")
              {
                  model.student_share = double.Parse(ds.Tables[0].Rows[0]["student_share"].ToString());
              }
              if (ds.Tables[0].Rows[0]["clerk_share"].ToString() != "")
              {
                  model.clerk_share = double.Parse(ds.Tables[0].Rows[0]["clerk_share"].ToString());
              }
              if (ds.Tables[0].Rows[0]["service_share"].ToString() != "")
              {
                  model.service_share = double.Parse(ds.Tables[0].Rows[0]["service_share"].ToString());
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
          mypara[0].Value = "H_Detail_Course";
          mypara[1].Value = "*";
          mypara[2].Value = "id desc";//
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
