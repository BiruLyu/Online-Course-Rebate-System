<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceAdd.aspx.cs" Inherits="MySystemWeb.uAdmin.ServiceAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>添加客服人员</title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>    
	<script type="text/javascript">

	    function checkadd()
	    {


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
	    }
	    function checkback()
	    {
	        window.history.back();
	    }
    </script>
</head>
<body>
    <!-- forms -->
				<div class="container1">
                <h4>工作人员添加:</h4>
					<form id="form1"  runat="server">
					<div class="form">
						<div class="fields">                      
	
                           
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
									<label for="input-small">手机:</label>
								</div>
								<div class="input">
									<input type="text" id="TextTel"  class="small"  runat="server"/>
								</div>
							</div>   
                            <div class="field">
								<div class="label">
									<label for="input-small">TeamViewerID:</label>
								</div>
								<div class="input">
									<input type="text" id="TextTeamViewerID"  class="small"  runat="server"/>
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

