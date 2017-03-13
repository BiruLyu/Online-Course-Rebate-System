<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="MySystemWeb.uAdmin.UserAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
      <title>添加用户</title>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
        <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $("#TextUser").blur(function checkusername() {

	            var username = document.getElementById("TextUser").value;
	            if (username != "") {

	                $.post("ajax/checkusername.aspx", { username: username }, function (data) {

	                    if (data.sta == "1") {
	                        $("#LabelUser").show();
	                        $("#LabelUser").text(data.info);
	                        $("#TextUser").focus();

	                    }
	                    else {
	                        $("#LabelUser").hide();

	                    }


	                }, "json");
	            }

	        });
	    });
	    function checkadd() {
	        var user = document.getElementById("TextUser").value;
	        if (user == "") { alert("用户名不能为空"); return false; }
	        var pwd = document.getElementById("TextPwd").value;
	        if (pwd == "") { alert("密码不能为空！"); return false; }
	        var repwd = document.getElementById("TextRePwd").value;
	        if (repwd == "") { alert("确认密码不能为空！"); return false; }
	        if (pwd != repwd) { alert("两次输入的密码不一致！"); return false; }
	    }
	    function checkback() {
	        window.location.href = "UserList.aspx";
	    }
	</script>
</head>
<body>
         <!-- forms -->
				<div class="container1">
                <h4>添加用户 </h4>
					<form id="form1"  runat="server">
					<div class="form">
						<div class="fields">				
						
						    <div class="field">
								<div class="label">
									<label for="file">用户名:</label>
								</div>
								<div class="input input-file">
                                     <input  id="TextUser"  class="small"  runat="server"/><asp:Label ID="LabelUser" runat="server" ></asp:Label>
								    <%-- <asp:Label ID="Label1" runat="server" Text="请使用YY教育网站的用户名注册,否则无法返利。" ForeColor="red" ></asp:Label>--%>
								</div>
							</div>
                          <div class="field">
								<div class="label">
									<label for="file">用户权限:</label>
								</div>
								<div class="input">
									<select id="SelectAuth" runat="server">                                  
                                     <option value="2">客服人员</option>
                                     <option value="3">工作人员</option>                                     
                                    </select>
								</div>
							</div>
							 <div class="field">
								<div class="label">
									<label for="file">密码:</label>
								</div>
								<div class="input input-file">
                                   <input  type="password" id="TextPwd"  class="small"   runat="server"/>
								</div>
							</div>
							 <div class="field">
								<div class="label">
									<label for="file">确认密码:</label>
								</div>
								<div class="input input-file">
                                  <input  type="password" id="TextRePwd"  class="small"   runat="server"/>
								</div>
							</div>
							<div class="buttons">
								
                                <asp:Button ID="Button1" runat="server" Text=" 提 交 "  
                                    CssClass="ui-state-default" onclick="Button1_Click"  OnClientClick="return checkadd()"/>
                                <input type="button" value=" 返 回 " class="ui-state-default"  onclick="checkback()"/>
							</div>
						</div>
					</div>
					</form>
				</div>
		<!-- end forms -->
		 
</body>
</html>

