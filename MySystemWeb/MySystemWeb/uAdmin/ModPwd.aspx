<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModPwd.aspx.cs" Inherits="MySystemWeb.uAdmin.ModPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
      <title>修改密码</title>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
	<script type="text/javascript">
	    function checkmod()
	    {
	        var oldpwd = document.getElementById("TextOldPwd").value;
	        if (oldpwd == "") { alert("旧密码不能为空！"); return false; }
	        var newpwd = document.getElementById("TextNewPwd").value;
	        if (newpwd == "") { alert("新密码不能为空！"); return false; }
	        var repwd = document.getElementById("TextRePwd").value;
	        if (repwd == "") { alert("确认密码不能为空！"); return false; }
	        if (newpwd != repwd) { alert("两次输入的密码不一致！"); return false; }
	    }
	</script>
</head>
<body>
         <!-- forms -->
				<div class="container1">
                <h4>修改密码</h4>
					<form id="form1"  runat="server">
					<div class="form">
						<div class="fields">
							<div class="field">
								<div class="label">
									<label for="input-small">我的账号:</label>
								</div>
								<div class="input">
									<asp:Literal ID="LiteralUser" runat="server"></asp:Literal>
								</div>
							</div>
						
						    <div class="field">
								<div class="label">
									<label for="file">旧密码:</label>
								</div>
								<div class="input input-file">
                                     <input  type="password" id="TextOldPwd"  class="small"  runat="server"/>
								</div>
							</div>
							 <div class="field">
								<div class="label">
									<label for="file">新密码:</label>
								</div>
								<div class="input input-file">
                                   <input  type="password" id="TextNewPwd"  class="small"   runat="server"/>
								</div>
							</div>
							 <div class="field">
								<div class="label">
									<label for="file">确认新密码:</label>
								</div>
								<div class="input input-file">
                                  <input  type="password" id="TextRePwd"  class="small"   runat="server"/>
								</div>
							</div>
							<div class="buttons">
								
                                <asp:Button ID="ButtonSub" runat="server" Text=" 修 改 密 码 "  
                                    CssClass="ui-state-default"  OnClientClick="return checkmod()" 
                                    onclick="ButtonSub_Click"/>
  
							</div>
						</div>
					</div>
					</form>
				</div>
		<!-- end forms -->
		  
</body>
</html>
