<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="MySystemWeb.uAdmin.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络教学平台返利系统</title>       
<link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
<link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function ()
    {
        var qx = "<%=qx %>";
        var isoccupy = "<%=isoccupy%>";
        if (qx == "1")
        {
            $("#order_add").hide();
            $("#clerk_add").hide();
            $("#service_add").hide();
        }
        if (qx == "2")
        {
            if (isoccupy == "1")
            {
                $("#service_add").hide();
              
             }
            $("#order_add").hide();
            $("#clerk_add").hide();
            $("#course_manager").hide();
            $("#sys_manager").hide();
        }
        if (qx == "3")
        {
            if (isoccupy == "1")
            {
                $("#clerk_add").hide();

            }
            $("#order_add").hide();
            $("#course_manager").hide();
            $("#sys_manager").hide();
            $("#student_manager").hide();
            $("#service_manager").hide();
            $("#handle_order").hide();
            $("#sail_statistic").hide();
        }
        if (qx == "4")
        {
            $("#course_manager").hide();
            $("#sys_manager").hide();
            $("#service_manager").hide();
            $("#clerk_manager").hide();
            $("#handle_order").hide();
            $("#sail_statistic").hide();
        }

    })
    function checkout()
    {
        window.location.replace("LoginOut.aspx");
        window.event.returnValue = false;
    }
</script>
</head>
<body id="b_main" >
<div id="header">
    <div id="logo">
    <h1 id="header_yicool"><a>网络教学平台返利系统</a></h1>
    <ul id="welcome">
    <li><a href="###" onclick="checkout()">退出</a></li>
    <li>欢迎 <strong>
        <asp:Label ID="LabelUser" runat="server"></asp:Label></strong></li>
    </ul><!--/end #welcome-->
    </div><!--/end #logo-->
</div><!--/end #header-->
<div id="wrapper"><!--holds pretty much everything-->

    <div id="menu_main">
     <div id="course_manager" class="menu_main_section">
            <h4 class="menu_main_h_config">课程管理</h4>
            <ul>
                <li><a href="BasicCourseList.aspx" target="iframe1">课程分类</a></li>
                <li id="basic_course_add"><a href="BasicCourseAdd.aspx" target="iframe1">添加分类</a></li>   
            </ul>           
        </div><!--/end #menu_main_section-->
    <div id="student_manager" class="menu_main_section">
            <h4 class="menu_main_h_config">学员管理</h4>
            <ul>
                <li><a href="StudentList.aspx" target="iframe1">学员信息</a></li>
                   
                        
            </ul>
        </div><!--/end #menu_main_section-->
          <div class="menu_main_section">
            <h4 class="menu_main_h_config">订单管理</h4>
            <ul>
                         
                <li><a href="OrderList.aspx?s=pf" target="iframe1">订单列表</a></li>              
                <li id="order_add"><a href="OrderAdd.aspx" target="iframe1">订单添加</a></li>
                   
                        
            </ul>
        </div><!--/end #menu_main_section-->
         <div id="handle_order" class="menu_main_section">
            <h4 class="menu_main_h_config">处理学员订单</h4>
            <ul>
                <li><a href="OrderList.aspx?s=pf&isexam=0" target="iframe1">未核对订单</a></li>
                <li><a href="OrderList.aspx?isexam=1&ispaystudent=0" target="iframe1">未返还学员订单</a></li>                 
                <li><a href="OrderList.aspx?isexam=1&ispayclerk=0" target="iframe1">未返还客服人员订单</a></li>  

            </ul>
        </div><!--/end #menu_main_section-->
         <div id="sail_statistic" class="menu_main_section">
            <h4  class="menu_main_h_config">销售统计</h4>
            <ul>
                <li><a href="PayService1.aspx" target="iframe1">返还学员统计</a></li>
                <li><a href="PayService2.aspx" target="iframe1">返还给客服人员统计</a></li>   
                <li><a href="PayService3.aspx" target="iframe1">返还给工作人员统计</a></li>                
               

            </ul>
        </div><!--/end #menu_main_section-->
            <div id="clerk_manager" class="menu_main_section">
            <h4  class="menu_main_h_config">客服人员管理</h4>
            <ul>
                 <li><a href="ClerkList.aspx" target="iframe1">客服人员列表</a></li>
                 <li id="clerk_add"><a href="ClerkAdd.aspx" target="iframe1">客服人员信息</a></li>

            </ul>
        </div><!--/end #menu_main_section-->
    
          <div id="service_manager" class="menu_main_section">
            <h4 class="menu_main_h_config">工作人员管理</h4>
            <ul>
                <li><a href="ServiceList.aspx" target="iframe1">工作人员列表</a></li>
                 <li id="service_add"><a href="ServiceAdd.aspx" target="iframe1">工作人员信息</a></li>
                  <li><a href="Attendance.aspx" target="iframe1">考勤管理</a></li>

            </ul>
        </div><!--/end #menu_main_section-->
        <div id="sys_manager" class="menu_main_section">
            <h4 class="menu_main_h_files">系统管理</h4>
            <ul>
                <li><a href="UserList.aspx" target="iframe1">用户列表</a></li>
                <li><a href="UserAdd.aspx" target="iframe1">添加用户</a></li>
              
            </ul>
        </div><!--/end #menu_main_section-->
         <div class="menu_main_section">
            <h4 class="menu_main_h_files">修改密码</h4>
            <ul>
             
                <li><a href="ModPwd.aspx" target="iframe1">修改密码</a></li>
            </ul>
        </div><!--/end #menu_main_section-->
    </div><!--/end #menu_main-->

<div  id="framediv" style="float:left; position:absolute;left:200px">
  <iframe id="iframe1"  name="iframe1" scrolling="no"  width="100%" height="100px" frameborder="0" ></iframe>
</div>     
<div class="clear"></div>
<!--/end #wrapper-->
</div>
<script type="text/javascript">

    function reinitIframe()
    {
        var iframe = document.getElementById("iframe1");
        try
        {
            var bHeight = iframe.contentWindow.document.body.scrollHeight;
            var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
            var height = Math.max(bHeight, dHeight);
            iframe.height = height;
        }
        catch (ex)
        {
        }
    }

    window.setInterval("reinitIframe()", 1000);

    function checkresize()
    {
        try
        {
            var _bw = document.body.scrollWidth;
            var _dw = document.documentElement.scrollWidth;
            var _ww = Math.max(_bw, _dw);
            ///document.getElementById("iframe1").style.width = (_ww - 200) + "px";
            document.getElementById("framediv").style.width = (_ww - 200 - 10) + "px";
        }
        catch (ex)
        {
        }
    }
    var resizeTimer = null;
    window.onresize = function ()
    {
        resizeTimer = resizeTimer ? null : setTimeout("checkresize()", 10);
    }
    checkresize();
</script>
</body>
</html>
