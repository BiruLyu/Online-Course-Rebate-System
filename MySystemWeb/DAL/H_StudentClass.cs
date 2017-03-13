using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
  public partial  class H_StudentClass
    {
      public H_StudentClass() { }
  
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(Model.H_Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into H_Student(");
			strSql.Append("name,username,email,telphone,zhifubao,bank,bank_name,bank_num,region_province,region_city,region_county)");
			strSql.Append(" values (");
			strSql.Append("@name,@username,@email,@telphone,@zhifubao,@bank,@bank_name,@bank_num,@region_province,@region_city,@region_county)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@zhifubao", SqlDbType.NVarChar,50),
					new SqlParameter("@bank", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_name", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_num", SqlDbType.NVarChar,50),
					new SqlParameter("@region_province", SqlDbType.NVarChar,50),
					new SqlParameter("@region_city", SqlDbType.NVarChar,50),
					new SqlParameter("@region_county", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.username;
			parameters[2].Value = model.email;
			parameters[3].Value = model.telphone;
			parameters[4].Value = model.zhifubao;
			parameters[5].Value = model.bank;
			parameters[6].Value = model.bank_name;
			parameters[7].Value = model.bank_num;
			parameters[8].Value = model.region_province;
			parameters[9].Value = model.region_city;
			parameters[10].Value = model.region_county;

			return  DbHelperSQL.ExecuteSql(strSql.ToString(),parameters)>0;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(Model.H_Student model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update H_Student set ");
			strSql.Append("name=@name,");
			strSql.Append("username=@username,");
			strSql.Append("email=@email,");
			strSql.Append("telphone=@telphone,");
			strSql.Append("zhifubao=@zhifubao,");
			strSql.Append("bank=@bank,");
			strSql.Append("bank_name=@bank_name,");
			strSql.Append("bank_num=@bank_num,");
			strSql.Append("region_province=@region_province,");
			strSql.Append("region_city=@region_city,");
			strSql.Append("region_county=@region_county");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@zhifubao", SqlDbType.NVarChar,50),
					new SqlParameter("@bank", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_name", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_num", SqlDbType.NVarChar,50),
					new SqlParameter("@region_province", SqlDbType.NVarChar,50),
					new SqlParameter("@region_city", SqlDbType.NVarChar,50),
					new SqlParameter("@region_county", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.username;
			parameters[2].Value = model.email;
			parameters[3].Value = model.telphone;
			parameters[4].Value = model.zhifubao;
			parameters[5].Value = model.bank;
			parameters[6].Value = model.bank_name;
			parameters[7].Value = model.bank_num;
			parameters[8].Value = model.region_province;
			parameters[9].Value = model.region_city;
			parameters[10].Value = model.region_county;
			parameters[11].Value = model.id;

			return  DbHelperSQL.ExecuteSql(strSql.ToString(),parameters)>0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from H_Student ");
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
		public  static Model.H_Student GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,username,email,telphone,zhifubao,bank,bank_name,bank_num,region_province,region_city,region_county from H_Student ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			Model.H_Student model=new Model.H_Student();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				model.username=ds.Tables[0].Rows[0]["username"].ToString();
				model.email=ds.Tables[0].Rows[0]["email"].ToString();
				model.telphone=ds.Tables[0].Rows[0]["telphone"].ToString();
				model.zhifubao=ds.Tables[0].Rows[0]["zhifubao"].ToString();
				model.bank=ds.Tables[0].Rows[0]["bank"].ToString();
				model.bank_name=ds.Tables[0].Rows[0]["bank_name"].ToString();
				model.bank_num=ds.Tables[0].Rows[0]["bank_num"].ToString();
				model.region_province=ds.Tables[0].Rows[0]["region_province"].ToString();
				model.region_city=ds.Tables[0].Rows[0]["region_city"].ToString();
				model.region_county=ds.Tables[0].Rows[0]["region_county"].ToString();
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
            mypara[0].Value = "H_Student";
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
