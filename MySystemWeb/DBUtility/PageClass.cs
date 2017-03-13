using System;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
/// <summary>
///PageClass 的摘要说明
/// </summary>
public class PageClass
{
	public PageClass()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static  string BuildPages(int PageIndex, int ToatalCountRecord,int PageSize)
    {
        int Step = 3;//偏移量 
        int LeftNum = 0;//做界限 
        int RightNum = 0;//右界限 
        string PageUrl = GetUrl();
        int PageCount = (int)Math.Ceiling((double)(ToatalCountRecord) / PageSize);
        LeftNum = PageIndex - Step < 1 ? 1 : PageIndex - Step;
        RightNum = PageIndex + Step > PageCount ? PageCount : PageIndex + Step;
      
        StringBuilder st = new StringBuilder();
        #region
        st.Append("<div id=\"pageInfo\" class=\"pages\">\n");
        st.Append("<div class=\"pages\" align=\"left\" style=\"width:40%;float:left;\">\n");
        st.Append("共有" + ToatalCountRecord .ToString()+ "条记录  当前第" + PageIndex.ToString() + "/" + PageCount.ToString()+"页");
        st.Append("</div>\n");
        st.Append("<div class=\"pages\" style=\"width:60%;float:left;\">");
        if (PageIndex > 1)
        {
            st.Append("<a href=\"" + PageUrl + "page=1\" >首页</a>\n");
            st.Append(" <a href='" + PageUrl + "page=" + (PageIndex - 1).ToString() + "'>" + "上一页" + " </a>\n");
        }
        else
        {
            st.Append("<a  disable=\"disable\" >首页</a>\n");
            st.Append("<a  disable=\"disable\" >上一页</a>\n");
        }
        for (int i = LeftNum; i <= RightNum; i++)
        {
            if (i == PageIndex)
                st.Append("<a  class=\"currentbtn\" disable=\"disable\">" + i.ToString() + "</a>\n");
            else
                st.Append("<a href=\"" + PageUrl + "page=" + i.ToString() + "\">" + i.ToString() + "</a>\n");

        }
        if (PageIndex < PageCount)//尾页判断
        {
            st.Append("<a href=\"" + PageUrl + "page=" + (PageIndex + 1).ToString() + "\" >下一页</a>\n");
            st.Append("<a href=\"" + PageUrl + "page=" + PageCount.ToString() + "\" >尾页</a>\n");
        }
        else
        {
            st.Append("<a   disable=\"disable\" >下一页</a>\n");
            st.Append("<a   disable=\"disable\" >尾页</a>\n");
        }
        st.Append("</div>\n");
        st.Append("</div>\n");
        #endregion
        return st.ToString();
    }
   
    private static string GetUrl()
    {
        string ResultUrl =HttpContext.Current.Request.Url.AbsoluteUri;
        ResultUrl = Regex.Replace(ResultUrl, @"page=(\d+)\&?", string.Empty, RegexOptions.IgnoreCase);
        if (ResultUrl.LastIndexOf("?") > 0)
        {
            if (ResultUrl.LastIndexOf("&") + 1 != ResultUrl.Length)
            {
                if (ResultUrl.LastIndexOf("?") + 1 < ResultUrl.Length)
                    ResultUrl = ResultUrl + "&";
            }
        }
        else
            ResultUrl = ResultUrl + "?";
        return ResultUrl;
    }
	/// <summary>
	/// 分页
	/// </summary>
	/// <param name="PageIndex"></param>
	/// <param name="ToatalCountRecord"></param>
	/// <param name="PageSize"></param>
	/// <returns></returns>
	public static string BuildPage(int PageIndex,int ToatalCountRecord, int PageSize)
	{
		
		string PageUrl = GetUrl();
		int PageCount = (int)Math.Ceiling((double)(ToatalCountRecord) / PageSize);
		StringBuilder st = new StringBuilder();
		//左边连接个数
		int LeftSize = 2;
		
		st.Append("<div id=\"pageInfo\" class=\"pages\">\n");

        st.Append("<div style=\"width: 70%; float: right;\">");
		#region 输出上一页
		
		#endregion

		//总长度
		int barSize = LeftSize * 2 + 1;

		#region 输出中间
		//页数小于0
		if (PageCount <= 0)
		{
			return "<center><a class=\"currentbtn\">1</a></center>";
		}

		//总页数小于正常显示的条数 则全部显示出来
		if (PageCount <= barSize)
		{
			for (int i = 1; i <= PageCount; i++)
			{
				if (PageIndex == i)
				{
					st.Append("<a class=\"currentbtn\">");
					st.Append(i);
					st.Append("</a>");
				}
				else
				{
					st.Append("<a href=\"");
					st.Append(string.Format(PageUrl+"page={0}", i));
					st.Append("\" ");

					st.Append(">");
					st.Append(i);
					st.Append("</a>");
				}
			}
		}
		else
		{
			if (PageIndex < LeftSize + 1)
			{
				for (int i = 1; i <= barSize; i++)
				{
					if (PageIndex == i)
					{
						st.Append("<a class=\"currentbtn\">");
						st.Append(i);
						st.Append("</a>");
					}
					else
					{
						st.Append("<a href=\"");
						st.Append(string.Format(PageUrl+"page={0}", i));
						st.Append("\" ");

						st.Append(">");
						st.Append(i);
						st.Append("</a>");
					}
				}
				if (PageIndex >= PageCount)
				{
					st.Append("<a class=\"disabled\">下一页</a>");
				}
				else
				{
					st.Append("<a href=\"");
					st.Append(string.Format(PageUrl + "page={0}", PageIndex + 1));
					st.Append("\" ");

					st.Append(">下一页</a>");
				}
				st.Append("<a href=\"");
				st.Append(string.Format(PageUrl+"page={0}", PageCount));
				st.Append("\" ");

				st.Append(">");
				st.Append("尾页");
				st.Append("</a>");
			}
			else
			{
				st.Append("<a href=\"");
				st.Append(string.Format(PageUrl+"page={0}", 1));
				st.Append("\" ");
				st.Append(">");
				st.Append("首页");
				st.Append("</a>");
				if (PageIndex <= 1)
				{
					st.Append("<a  disable=\"disable\">上一页</a>");
				}
				else
				{
					st.Append("<a href=\"");
					st.Append(string.Format(PageUrl + "page={0}", PageIndex - 1));
					st.Append("\">上一页</a>");
				}

				if (PageIndex < PageCount - LeftSize)
				{
					for (int i = PageIndex - LeftSize; i < PageIndex; i++)
					{
						if (i == 1)
						{
							continue;
						}

						st.Append("<a href=\"");
						st.Append(string.Format(PageUrl+"page={0}", i));
						st.Append("\" ");

						st.Append(">");
						st.Append(i);
						st.Append("</a>");
					}
					for (int i = PageIndex; i <= PageIndex + LeftSize; i++)
					{
						if (PageIndex == i)
						{
							st.Append("<a class=\"currentbtn\">");
							st.Append(i);
							st.Append("</a>");
						}
						else
						{
							st.Append("<a href=\"");
							st.Append(string.Format(PageUrl+"page={0}", i));
							st.Append("\" ");

							st.Append(">");
							st.Append(i);
							st.Append("</a>");
						}
					}
					if (PageIndex >= PageCount)
					{
						st.Append("<a class=\"disabled\">下一页</a>");
					}
					else
					{
						st.Append("<a href=\"");
						st.Append(string.Format(PageUrl + "page={0}", PageIndex + 1));
						st.Append("\" ");

						st.Append(">下一页</a>");
					}
					st.Append("<a href=\"");
					st.Append(string.Format(PageUrl+"page={0}", PageCount));
					st.Append("\" ");

					st.Append(">");
					st.Append("尾页");
					st.Append("</a>");

				}
				else
				{
					
					for (int i = PageCount - LeftSize - LeftSize; i <= PageCount; i++)
					{
						if (PageIndex == i)
						{
							st.Append("<a class=\"currentbtn\">");
							st.Append(i);
							st.Append("</a>");
						}
						else
						{
							st.Append("<a href=\"");
							st.Append(string.Format(PageUrl+"page={0}", i));
							st.Append("\" ");

							st.Append(">");
							st.Append(i);
							st.Append("</a>");
						}
					}
				
				}

			}

		}
		#endregion

		#region 输出下一页
		
		#endregion
		st.Append("</div>\n");
        st.Append("<div style=\"width:25%; float: left; padding-right:20px; text-align:right; font-size:12px;\">\n");
        st.Append("共有" + ToatalCountRecord.ToString() + "条记录  当前第" + PageIndex.ToString() + "/" + PageCount.ToString() + "页");
        st.Append("</div>\n");
		st.Append("</div>\n");
		return st.ToString();
	}
	
	
}
