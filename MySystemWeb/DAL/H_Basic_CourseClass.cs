using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public partial class H_Basic_CourseClass
    {
       public H_Basic_CourseClass() 
       { }
       #region  Method
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(Model.H_Basic_Course model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into H_Subordinate_Course(");
            strSql.Append("subcourse,father)");
			strSql.Append(" values (");
			strSql.Append("@basiccourse,@province)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@basiccourse", SqlDbType.NVarChar,50),
					new SqlParameter("@province", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.basiccourse;
			parameters[1].Value = model.province;

			return  DbHelperSQL.ExecuteSql(strSql.ToString(),parameters)>0;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(Model.H_Basic_Course model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update H_Subordinate_Course set ");
            strSql.Append("subcourse=@basiccourse,");
			strSql.Append("father=@province");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@basiccourse", SqlDbType.NVarChar,50),
					new SqlParameter("@province", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.basiccourse;
			parameters[1].Value = model.province;
			parameters[2].Value = model.id;

			return  DbHelperSQL.ExecuteSql(strSql.ToString(),parameters)>0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from H_Subordinate_Course ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			return  DbHelperSQL.ExecuteSql(strSql.ToString(),parameters)>0;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  static Model.H_Basic_Course GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,subcourse,father from H_Subordinate_Course ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			Model.H_Basic_Course model=new Model.H_Basic_Course();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
                model.basiccourse = ds.Tables[0].Rows[0]["subcourse"].ToString();
				model.province=ds.Tables[0].Rows[0]["father"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
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
            mypara[0].Value = "H_Subordinate_Course";
            mypara[1].Value = "*";
            mypara[2].Value = "id asc";//
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

