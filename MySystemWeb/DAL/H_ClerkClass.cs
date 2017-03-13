using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public partial class H_ClerkClass
    {
       public H_ClerkClass() { }
       #region  Method

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public static bool Add(Model.H_Clerk model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into H_Clerk(");
           strSql.Append("name,username,TeamViewerID,phone,telphone,zhifubao,bank_region,bank_name,bank_number,region_province,region_city,region_county)");
           strSql.Append(" values (");
           strSql.Append("@name,@username,@TeamViewerID,@phone,@telphone,@zhifubao,@bank_region,@bank_name,@bank_number,@region_province,@region_city,@region_county)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@TeamViewerID", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@zhifubao", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_region", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_name", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_number", SqlDbType.NVarChar,50),
					new SqlParameter("@region_province", SqlDbType.NVarChar,50),
					new SqlParameter("@region_city", SqlDbType.NVarChar,50),
					new SqlParameter("@region_county", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.name;
           parameters[1].Value = model.username;
           parameters[2].Value = model.TeamViewerID;
           parameters[3].Value = model.phone;
           parameters[4].Value = model.telphone;
           parameters[5].Value = model.zhifubao;
           parameters[6].Value = model.bank_region;
           parameters[7].Value = model.bank_name;
           parameters[8].Value = model.bank_number;
           parameters[9].Value = model.region_province;
           parameters[10].Value = model.region_city;
           parameters[11].Value = model.region_county;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public static bool Update(Model.H_Clerk model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update H_Clerk set ");
           strSql.Append("name=@name,");
           strSql.Append("username=@username,");
           strSql.Append("TeamViewerID=@TeamViewerID,");
           strSql.Append("phone=@phone,");
           strSql.Append("telphone=@telphone,");
           strSql.Append("zhifubao=@zhifubao,");
           strSql.Append("bank_region=@bank_region,");
           strSql.Append("bank_name=@bank_name,");
           strSql.Append("bank_number=@bank_number,");
           strSql.Append("region_province=@region_province,");
           strSql.Append("region_city=@region_city,");
           strSql.Append("region_county=@region_county");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@TeamViewerID", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@zhifubao", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_region", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_name", SqlDbType.NVarChar,50),
					new SqlParameter("@bank_number", SqlDbType.NVarChar,50),
					new SqlParameter("@region_province", SqlDbType.NVarChar,50),
					new SqlParameter("@region_city", SqlDbType.NVarChar,50),
					new SqlParameter("@region_county", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = model.name;
           parameters[1].Value = model.username;
           parameters[2].Value = model.TeamViewerID;
           parameters[3].Value = model.phone;
           parameters[4].Value = model.telphone;
           parameters[5].Value = model.zhifubao;
           parameters[6].Value = model.bank_region;
           parameters[7].Value = model.bank_name;
           parameters[8].Value = model.bank_number;
           parameters[9].Value = model.region_province;
           parameters[10].Value = model.region_city;
           parameters[11].Value = model.region_county;
           parameters[12].Value = model.id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public static bool Delete(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from H_Clerk ");
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
       public static Model.H_Clerk GetModel(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,name,username,TeamViewerID,phone,telphone,zhifubao,bank_region,bank_name,bank_number,region_province,region_city,region_county from H_Clerk ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
           parameters[0].Value = id;

           Model.H_Clerk model = new Model.H_Clerk();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               model.name = ds.Tables[0].Rows[0]["name"].ToString();
               model.username = ds.Tables[0].Rows[0]["username"].ToString();
               model.TeamViewerID = ds.Tables[0].Rows[0]["TeamViewerID"].ToString();
               model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
               model.telphone = ds.Tables[0].Rows[0]["telphone"].ToString();
               model.zhifubao = ds.Tables[0].Rows[0]["zhifubao"].ToString();
               model.bank_region = ds.Tables[0].Rows[0]["bank_region"].ToString();
               model.bank_name = ds.Tables[0].Rows[0]["bank_name"].ToString();
               model.bank_number = ds.Tables[0].Rows[0]["bank_number"].ToString();
               model.region_province = ds.Tables[0].Rows[0]["region_province"].ToString();
               model.region_city = ds.Tables[0].Rows[0]["region_city"].ToString();
               model.region_county = ds.Tables[0].Rows[0]["region_county"].ToString();
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
           mypara[0].Value = "H_ClerkView";
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
