<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="MySystemWeb.uAdmin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta name="viewport" content="width=device-width; initial-scale=1.0"/>
   <title>网络教学平台返利系统</title>

<link href="css/style.css" rel="stylesheet" type="text/css"/>
    <link href="css/Default.css" rel="stylesheet" type="text/css" />
    <link href="css/xtree.css" rel="stylesheet" type="text/css" />
    <link href="css/User_Login.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).keydown(function (event)
    {
        var e = event || window.event || arguments.callee.caller.arguments[0];
        if (e && e.keyCode == 13)
            checklogin();
    });
    function checklogin()
    {
        var user =  $("#textUser").val();
        if (user == "") { alert("账号不能为空！"); $("#textUser").focus(); return false; }
        var pwd = $("#textPwd").val();
        if (pwd == "") { alert("密码不能为空！"); $("#textPwd").focus(); return false; }
        $.post("ajax/checklogin.aspx", { user:user,pwd:pwd }, function (data)
        {
            if (data.sta == "1")
            { window.location.href = "Main.aspx"; }
            else
            { alert(data.info); }

        }, "json");
    }
    function register()
    {
        window.location.href = "StudentAdd.aspx";
    }
</script>
</head>
<body  id="user_login"  background="images/bg_01.jpg">
    
<div id="div1" style="margin-top:200px"     >
<dl>

  <dd id="user_top">
    <ul>
       <li class="user_top_l"></li>
       <li class="user_top_c"></li>
       <li class="user_top_r"></li>
    </ul>
  </dd>
  <dd id="user_main">
  <ul>
    <li class="user_main_l"></li>
    <li class="user_main_c">
    <div class="user_main_box">
  <ul>
      <li class="user_main_text">用户名： </li>
      <li class="user_main_input"><input class="TxtUserNameCssClass"  id="textUser"  type="text"
      maxlength="20" /> </li></ul>
    <ul>
      <li class="user_main_text">密 码： </li>
      <li class="user_main_input"><input class="TxtPasswordCssClass"  id="textPwd" 
      type="password" name="TxtPassword" /> </li></ul>
  <ul>
      <li class="user_main_text">还没有注册？ </li>
      <li class="user_main_input"><a  href="###" onclick="register()">学员注册</a>
      </li>
  </ul>
  </div>
  </li>
    <li class="user_main_r"><a href="###" onclick="checklogin()"><img class="IbtnEnterCssClass" id="IbtnEnter" 
    style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px" 
    
    src="images/user_botton.gif" /></a> </li></ul>
    </dd>
  <dd id="user_bottom">
  <ul>
    <li class="user_bottom_l"></li>
    <li class="user_bottom_c"> </li>
    <li class="user_bottom_r"></li>
  </ul>
  </dd>
  </dl>
  </div>

</body>
</html>
