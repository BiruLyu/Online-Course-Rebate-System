<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdd.aspx.cs" Inherits="MySystemWeb.uAdmin.StudentAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>学员注册</title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>        
	<script type="text/javascript">
	    $(document).ready(function ()
	    {
	       
	        $.post("ajax/getprovince.aspx", function (data)
	        {

	            $("#SelectProvince").html(data);

	        }, "html");
	    })

	    function checkcity() {
	        var province = document.getElementById("SelectProvince").value;
	        $.post("ajax/getcity.aspx", { province: province }, function (data) {
	            $("#SelectCity").html(data);
	        }, "html");

	    }
	    function checkarea() {
	        var city = document.getElementById("SelectCity").value;
	        $.post("ajax/getarea.aspx", { city: city }, function (data) {
	            $("#SelectArea").html(data);
	        }, "html");

	    }
	    $(document).ready(function ()
	    {
	        $("#TextUser").blur(function checkusername()
	        {

	            var username = document.getElementById("TextUser").value;
	            if (username != "")
	            {

	                $.post("ajax/checkusername.aspx", { username: username }, function (data)
	                {

	                    if (data.sta == "1")
	                    {
	                        $("#LabelUser").show();
	                        $("#LabelUser").text(data.info);
	                        $("#TextUser").focus();

	                    }
	                    else
	                    {
	                        $("#LabelUser").hide();

	                    }


	                }, "json");
	            }

	        });

	    });
	    function checkadd()
	    {
	        var user = document.getElementById("TextUser").value;
	        if (user == "") { alert("用户名不能为空"); return false; }
	        var pwd = document.getElementById("TextPwd").value;
	        if (pwd == "") { alert("密码不能为空！"); return false; }
	        var repwd = document.getElementById("TextRePwd").value;
	        if (repwd == "") { alert("确认密码不能为空！"); return false; }
	        if (pwd != repwd) { alert("两次输入的密码不一致！"); return false; }

	        var name = document.getElementById("TextName").value;
	        if (name == "")
	        {
	            document.getElementById("TextName").className = "medium error";
	            alert("姓名不能为空");
	            return false;
	        }
	        var tel = document.getElementById("TextTel").value;
	        if (tel == "")
	        {
	            document.getElementById("TextTel").className = "medium error";
	            alert("电话不能为空");
	            return false;
	        }
	        var zhifubao = document.getElementById("TextZhifubao").value;
	        var bank = document.getElementById("TextBank").value;
	        var bank_name = document.getElementById("TextBank_name").value;
	        var bank_number = document.getElementById("TextBank_number").value;
	        if (zhifubao == "" && bank == "")
	        {
	            document.getElementById("TextZhifubao").className = "medium error";
	            document.getElementById("TextBank").className = "medium error";
	            alert("支付宝和银行必须填写一个");
	            return false;
	        }
	        if (bank != "")
	        {
	            if (bank_name == "")
	            {
	                document.getElementById("TextBank_name").className = "medium error";
	                alert("银行户名不能为空");
	                return false;
                 }
	            if (bank_number == "")
	            {
	                document.getElementById("TextBank_number").className = "medium error";
	                alert("银行账号不能为空");
	                return false;
	            }
	        }
	        var province = document.getElementById("SelectProvince").value;
	        if (province == "-1")
	        {
	            document.getElementById("SelectProvince").className = "medium error"
	            alert("省不能为空");
	            return false;
	        }
	        var city = document.getElementById("SelectCity").value;
	        if (province == "-1")
	        {
	            document.getElementById("SelectCity").className = "medium error"
	            alert("市不能为空");
	            return false;
	        }
	        var area = document.getElementById("SelectArea").value;
	        if (area == "-1")
	        {
	            document.getElementById("SelectArea").className = "medium error"
	            alert("县/区不能为空");
	            return false;
	        }
	        $("#HiddenProvince").val($("#SelectProvince").val());
	        $("#HiddenCity").val($("#SelectCity").val());
	        $("#HiddenArea").val($("#SelectArea").val());
	    }
	    function checkback()
	    {
	        window.location.href = "AdminLogin.aspx";
	    }
    </script>
</head>
<body>
    <!-- forms -->
				<div class="container1">
                <h4>学员注册 <asp:Label ID="Label1" runat="server" Text="(请填写YY教育网上的注册用户名，否则订单审核不予通过)" ForeColor="red"></asp:Label>:</h4>
					<form id="form1"  runat="server">
					<div class="form">
						<div class="fields">                      
	
                            <div class="field">
								<div class="label">
									<label for="input-small">用户名:</label>
								</div>
								<div class="input">
									<input type="text" id="TextUser"  class="small"  runat="server"/><asp:Label ID="LabelUser" runat="server" ></asp:Label>
								</div>
							</div>
                           <div class="field">
								<div class="label">
									<label for="input-small">密码:</label>
								</div>
								<div class="input">
									<input type="password" id="TextPwd"  class="small"  runat="server"/>
								</div>
							</div>
                            <div class="field">
								<div class="label">
									<label for="input-small">确认密码:</label>
								</div>
								<div class="input">
									<input type="password" id="TextRePwd"  class="small"  runat="server"/>
								</div>
							</div>
                                    <div class="field">
								<div class="label">
									<label for="input-small">姓名:</label>
								</div>
								<div class="input">
									<input type="text" id="TextName"  class="small"  runat="server"/>
								</div>
							</div>
                                       <div class="field">
								<div class="label">
									<label for="input-small">Email:</label>
								</div>
								<div class="input">
									<input type="text" id="TextEmail"  class="small"  runat="server"/>
								</div>
							</div>
						    <div class="field">
								<div class="label">
									<label for="input-small">电话:</label>
								</div>
								<div class="input">
									<input type="text" id="TextTel"  class="small"  runat="server"/>
								</div>
							</div>   
                            <div class="field">
								<div class="label">
									<label for="input-small">支付宝账号:</label>
								</div>
								<div class="input">
									<input type="text" id="TextZhifubao"  class="small"  runat="server"/>
								</div>
							</div> 
                            <div class="field">
								<div class="label">
									<label for="input-small">开户行:</label>
								</div>
								<div class="input">
									<input type="text" id="TextBank"  class="small"  runat="server"/>
								</div>
							</div> 
                                           <div class="field">
								<div class="label">
									<label for="input-small">银行开户名:</label>
								</div>
								<div class="input">
									<input type="text" id="TextBank_name"  class="small"  runat="server" />
								</div>
							</div> 
                            <div class="field">
								<div class="label">
									<label for="input-small">银行账号:</label>
								</div>
								<div class="input">
									<input type="text" id="TextBank_number"  class="small"  runat="server" />
								</div>
							</div>
                            <div class="field">
								<div class="label">
									<label for="input-small">地区:</label>
								</div>
								<div class="input">
									 <select id="SelectProvince" runat="server" onchange="checkcity()">
                                       <option value="-1">--请选择--</option>
                                     </select>
                                     <select id="SelectCity" runat="server" onchange="checkarea()">
                                       <option value="-1">--请选择--</option>
                                     </select>
                                     <select id="SelectArea" runat="server" >
                                      <option value="-1">--请选择--</option>
                                     </select>
                                  <input id="HiddenProvince" type="hidden" runat="server" />
                                  <input id="HiddenCity" type="hidden"  runat="server" />
                                  <input id="HiddenArea" type="hidden" runat="server" />
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
