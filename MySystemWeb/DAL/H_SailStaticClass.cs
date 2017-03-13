using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
  public partial  class H_SailStaticClass
    {
      public H_SailStaticClass()
      { }
      public static DataTable GetPayClerkList(int M_PageSize, int M_PageIndex, string M_WhereString, out int M_TotalRecord)
      {
          SqlParameter[] mypara = new SqlParameter[7];
          mypara[0] = new SqlParameter("@TableName", SqlDbType.NVarChar, 50);
          mypara[1] = new SqlParameter("@ReFieldsStr", SqlDbType.NVarChar, 200);
          mypara[2] = new SqlParameter("@OrderString", SqlDbType.NVarChar, 200);
          mypara[3] = new SqlParameter("@WhereString", SqlDbType.NVarChar, 1000);
          mypara[4] = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          mypara[5] = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          mypara[6] = new SqlParameter("@TotalRecord", SqlDbType.Int, 4);
          mypara[0].Value = "H_PayClerkView";
          mypara[1].Value = "*";
          mypara[2].Value = "sail_num desc";//
          mypara[3].Value = M_WhereString;
          mypara[4].Value = M_PageSize;
          mypara[5].Value = M_PageIndex;
          mypara[6].Direction = ParameterDirection.Output;//返回记录数


          DataTable dt = DbHelperSQL.RunProcedure("Proc_Page2005", mypara, "page").Tables["page"];
          M_TotalRecord = (int)mypara[6].Value;
          return dt;
      }
      public static DataTable GetPayStudentList(int M_PageSize, int M_PageIndex, string M_WhereString, out int M_TotalRecord)
      {
          SqlParameter[] mypara = new SqlParameter[7];
          mypara[0] = new SqlParameter("@TableName", SqlDbType.NVarChar, 50);
          mypara[1] = new SqlParameter("@ReFieldsStr", SqlDbType.NVarChar, 200);
          mypara[2] = new SqlParameter("@OrderString", SqlDbType.NVarChar, 200);
          mypara[3] = new SqlParameter("@WhereString", SqlDbType.NVarChar, 1000);
          mypara[4] = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          mypara[5] = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          mypara[6] = new SqlParameter("@TotalRecord", SqlDbType.Int, 4);
          mypara[0].Value = "H_PayStudentView";
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
      public static DataTable GetPayServiceList(int M_PageSize, int M_PageIndex, string M_WhereString, out int M_TotalRecord)
      {
          SqlParameter[] mypara = new SqlParameter[7];
          mypara[0] = new SqlParameter("@TableName", SqlDbType.NVarChar, 50);
          mypara[1] = new SqlParameter("@ReFieldsStr", SqlDbType.NVarChar, 200);
          mypara[2] = new SqlParameter("@OrderString", SqlDbType.NVarChar, 200);
          mypara[3] = new SqlParameter("@WhereString", SqlDbType.NVarChar, 1000);
          mypara[4] = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          mypara[5] = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          mypara[6] = new SqlParameter("@TotalRecord", SqlDbType.Int, 4);
          mypara[0].Value = "H_PayServiceView";
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
    }
}
