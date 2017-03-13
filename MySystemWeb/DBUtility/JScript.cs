using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

/// <summary>
/// һЩ���õ�Js����
/// ����°�˵�������ھɰ��ձ����Response.Write(string msg)�ķ�ʽ���js�ű�������
/// ��ʽ�����js�ű�����htmlԪ�ص�&lt;html&gt;&lt;/html&gt;��ǩ֮�⣬�ƻ�������xhtml�Ľṹ,
/// ���°汾�����ClientScript.RegisterStartupScript(string msg)�ķ�ʽ���������ı�xhtml�Ľṹ,
/// ����Ӱ��ִ��Ч����
/// Ϊ�����¼��ݣ������°汾���������صķ�ʽ���°汾��Ҫ��һ��System.Web.UI.Page���ʵ����
/// ����ʱ�䣺2006-9-13
/// �����ߣ����ȹ�
/// �°����ߣ��ܹ�
/// �޸����ڣ�2007-4-17
/// �޸İ淢����ַ��http://blog.csdn.net/zhoufoxcn
/// </summary>
public class JScript
{
    #region �°汾
    /// <summary>
    /// ����JavaScriptС����
    /// </summary>
    /// <param name="js">������Ϣ</param>
    public static void Alert(string message,string key,Page page)
    {
        #region
        string js = @"<Script language='JavaScript'>alert('" + message + "');</Script>";
        //HttpContext.Current.Response.Write(js);
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), key))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), key, js);
        }
        #endregion
    }

    /// <summary>
    /// ������Ϣ����ת���µ�URL
    /// </summary>
    /// <param name="message">��Ϣ����</param>
    /// <param name="toURL">���ӵ�ַ</param>
    public static void AlertAndRedirect(string message, string toURL, Page page)
    {
        #region
        string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
        //HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "AlertAndRedirect"))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "AlertAndRedirect", string.Format(js, message, toURL));
        }
        #endregion
    }

    /// <summary>
    /// �ص���ʷҳ��
    /// </summary>
    /// <param name="value">-1/1</param>
    public static void GoHistory(int value, Page page)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
        //HttpContext.Current.Response.Write(string.Format(js, value));
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "GoHistory"))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "GoHistory", string.Format(js, value));
        }
        #endregion
    }

    //        /// <summary>
    //        /// �رյ�ǰ����
    //        /// </summary>
    //        public static void CloseWindow()
    //        {
    //            #region
    //            string js = @"<Script language='JavaScript'>
    //                    parent.opener=null;window.close();  
    //                  </Script>";
    //            HttpContext.Current.Response.Write(js);
    //            HttpContext.Current.Response.End();
    //            #endregion
    //        }

    /// <summary>
    /// ˢ�¸�����
    /// </summary>
    public static void RefreshParent(string url, Page page)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    window.opener.location.href='" + url + "';window.close();</Script>";
        //HttpContext.Current.Response.Write(js);
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "RefreshParent"))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "RefreshParent", js);
        }
        #endregion
    }


    /// <summary>
    /// ˢ�´򿪴���
    /// </summary>
    public static void RefreshOpener(Page page)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
        //HttpContext.Current.Response.Write(js);
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "RefreshOpener"))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "RefreshOpener", js);
        }
        #endregion
    }


    /// <summary>
    /// ��ָ����С���´���
    /// </summary>
    /// <param name="url">��ַ</param>
    /// <param name="width">��</param>
    /// <param name="heigth">��</param>
    /// <param name="top">ͷλ��</param>
    /// <param name="left">��λ��</param>
    public static void OpenWebFormSize(string url, int width, int heigth, int top, int left, Page page)
    {
        #region
        string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";
        //HttpContext.Current.Response.Write(js);
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "OpenWebFormSize"))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "OpenWebFormSize", js);
        }
        #endregion
    }


    /// <summary>
    /// ת��Url�ƶ���ҳ��
    /// </summary>
    /// <param name="url">���ӵ�ַ</param>
    public static void JavaScriptLocationHref(string url, Page page)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
        js = string.Format(js, url);
        //HttpContext.Current.Response.Write(js);
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "JavaScriptLocationHref"))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "JavaScriptLocationHref", js);
        }
        #endregion
    }

    /// <summary>
    /// ��ָ����Сλ�õ�ģʽ�Ի���
    /// </summary>
    /// <param name="webFormUrl">���ӵ�ַ</param>
    /// <param name="width">��</param>
    /// <param name="height">��</param>
    /// <param name="top">������λ��</param>
    /// <param name="left">������λ��</param>
    public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left, Page page)
    {
        #region
        string features = "dialogWidth:" + width.ToString() + "px"
            + ";dialogHeight:" + height.ToString() + "px"
            + ";dialogLeft:" + left.ToString() + "px"
            + ";dialogTop:" + top.ToString() + "px"
            + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
        ShowModalDialogWindow(webFormUrl, features, page);
        #endregion
    }
    /// <summary>
    /// ����ģ̬����
    /// </summary>
    /// <param name="webFormUrl"></param>
    /// <param name="features"></param>
    public static void ShowModalDialogWindow(string webFormUrl, string features, Page page)
    {
        string js = ShowModalDialogJavascript(webFormUrl, features);
        //HttpContext.Current.Response.Write(js);
        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "ShowModalDialogWindow"))
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "ShowModalDialogWindow", js);
        }
    }
    /// <summary>
    /// ����ģ̬����
    /// </summary>
    /// <param name="webFormUrl"></param>
    /// <param name="features"></param>
    /// <returns></returns>
    public static string ShowModalDialogJavascript(string webFormUrl, string features)
    {
        #region
        string js = @"<script language=javascript>                            
        showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
        return js;
        #endregion
    }
    #endregion
}