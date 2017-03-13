using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
   public partial class H_UserClass
    {
       public H_UserClass() { }
       #region  Method

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public static bool Add(Model.H_User model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into H_User(");
           strSql.Append("username,password,qxid,isoccupy)");
           strSql.Append(" values (");
           strSql.Append("@username,@password,@qxid,@isoccupy)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,50),
					new SqlParameter("@qxid", SqlDbType.TinyInt,1),
					new SqlParameter("@isoccupy", SqlDbType.TinyInt,1)};
           parameters[0].Value = model.username;
           parameters[1].Value = model.password;
           parameters[2].Value = model.qxid;
           parameters[3].Value = model.isoccupy;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public static bool Update(Model.H_User model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update H_User set ");
           strSql.Append("username=@username,");
           strSql.Append("password=@password,");
           strSql.Append("qxid=@qxid,");
           strSql.Append("isoccupy=@isoccupy");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,50),
					new SqlParameter("@qxid", SqlDbType.TinyInt,1),
					new SqlParameter("@isoccupy", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = model.username;
           parameters[1].Value = model.password;
           parameters[2].Value = model.qxid;
           parameters[3].Value = model.isoccupy;
           parameters[4].Value = model.id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public static bool Delete(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from H_User ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
           parameters[0].Value = id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }
       /// <summary>
       /// 修改密码
       /// </summary>
       /// <param name="username"></param>
       /// <param name="password"></param>
       /// <returns></returns>
       public static bool ChangePwd(string username, string password)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update  H_User ");
           strSql.Append("set password=@password where username=@username");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,50)
                                        };
           parameters[0].Value = username;
           parameters[1].Value = password;
           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
       }
       public static DataTable CheckLogin(string UserName, string password)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * from H_User ");
           strSql.Append(" where username=@username and password=@password");
           SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,50)
                                        };
           parameters[0].Value = UserName;
           parameters[1].Value = password;
           return DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public static Model.H_User GetModel(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,username,password,qxid,isoccupy from H_User ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
           parameters[0].Value = id;

           Model.H_User model = new Model.H_User();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               model.username = ds.Tables[0].Rows[0]["username"].ToString();
               model.password = ds.Tables[0].Rows[0]["password"].ToString();
               if (ds.Tables[0].Rows[0]["qxid"].ToString() != "")
               {
                   model.qxid = int.Parse(ds.Tables[0].Rows[0]["qxid"].ToString());
               }
               if (ds.Tables[0].Rows[0]["isoccupy"].ToString() != "")
               {
                   model.isoccupy = int.Parse(ds.Tables[0].Rows[0]["isoccupy"].ToString());
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

           mypara[0].Value = "H_User";
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
