using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public partial class H_ServiceClass
    {
       public H_ServiceClass() { }
       #region  Method

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public static bool Add(Model.H_Service model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into H_Service(");
           strSql.Append("username,name,telephone,TeamViewerID,zhifubao,bank,bankname,banknumber)");
           strSql.Append(" values (");
           strSql.Append("@username,@name,@telephone,@TeamViewerID,@zhifubao,@bank,@bankname,@banknumber)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@TeamViewerID", SqlDbType.NVarChar,50),
					new SqlParameter("@zhifubao", SqlDbType.NVarChar,50),
					new SqlParameter("@bank", SqlDbType.NVarChar,50),
					new SqlParameter("@bankname", SqlDbType.NVarChar,50),
					new SqlParameter("@banknumber", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.username;
           parameters[1].Value = model.name;
           parameters[2].Value = model.telephone;
           parameters[3].Value = model.TeamViewerID;
           parameters[4].Value = model.zhifubao;
           parameters[5].Value = model.bank;
           parameters[6].Value = model.bankname;
           parameters[7].Value = model.banknumber;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public static bool Update(Model.H_Service model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update H_Service set ");
           strSql.Append("username=@username,");
           strSql.Append("name=@name,");
           strSql.Append("telephone=@telephone,");
           strSql.Append("TeamViewerID=@TeamViewerID,");
           strSql.Append("zhifubao=@zhifubao,");
           strSql.Append("bank=@bank,");
           strSql.Append("bankname=@bankname,");
           strSql.Append("banknumber=@banknumber");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@TeamViewerID", SqlDbType.NVarChar,50),
					new SqlParameter("@zhifubao", SqlDbType.NVarChar,50),
					new SqlParameter("@bank", SqlDbType.NVarChar,50),
					new SqlParameter("@bankname", SqlDbType.NVarChar,50),
					new SqlParameter("@banknumber", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = model.username;
           parameters[1].Value = model.name;
           parameters[2].Value = model.telephone;
           parameters[3].Value = model.TeamViewerID;
           parameters[4].Value = model.zhifubao;
           parameters[5].Value = model.bank;
           parameters[6].Value = model.bankname;
           parameters[7].Value = model.banknumber;
           parameters[8].Value = model.id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public static bool Delete(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from H_Service ");
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
       public static Model.H_Service GetModel(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,username,name,telephone,TeamViewerID,zhifubao,bank,bankname,banknumber from H_Service ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
           parameters[0].Value = id;

           Model.H_Service model = new Model.H_Service();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               model.username = ds.Tables[0].Rows[0]["username"].ToString();
               model.name = ds.Tables[0].Rows[0]["name"].ToString();
               model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
               model.TeamViewerID = ds.Tables[0].Rows[0]["TeamViewerID"].ToString();
               model.zhifubao = ds.Tables[0].Rows[0]["zhifubao"].ToString();
               model.bank = ds.Tables[0].Rows[0]["bank"].ToString();
               model.bankname = ds.Tables[0].Rows[0]["bankname"].ToString();
               model.banknumber = ds.Tables[0].Rows[0]["banknumber"].ToString();
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
           mypara[0].Value = "H_Service";
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
