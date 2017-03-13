<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailCourseAdd.aspx.cs" Inherits="MySystemWeb.uAdmin.DetailCourseAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>详细课程添加</title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>    
	<script type="text/javascript">
	    $(document).ready(function ()
	    {
	        $("#TextDetailCourse").blur(function checkusername()
	        {
                var basic_courseID=<%=pid%>               
	            var detailcourse = document.getElementById("TextDetailCourse").value;
	            if (detailcourse != "")
	            {

	                $.post("ajax/checkdetailcourse.aspx", {basic_courseID:basic_courseID,detailcourse: detailcourse }, function (data)
	                {

	                    if (data.sta == "1")
	                    {
	                        $("#LabelDetailCourse").show();
	                        $("#LabelDetailCourse").text(data.info);
	                        $("#TextDetailCourse").focus();

	                    }
	                    else
	                    {
	                        $("#LabelDetailCourse").hide();

	                    }


	                }, "json");
	            }

	        });

	    });
	    function checkadd()
	    {

	        var detailcourse = document.getElementById("TextDetailCourse").value;
	        if (detailcourse == "")
	        {
	            document.getElementById("TextDetailCourse").className = "medium error";
	            alert("课程名称不能为空");
	            return false;
	        }
	        var pur_price = document.getElementById("TextPur_Price").value;
	        if (pur_price == "")
	        {
	            document.getElementById("TextPur_Price").className = "medium error";
	            alert("课程进价不能为空");
	            return false;
	        }
	        var sel_price = document.getElementById("TextSel_Price").value;
	        if (sel_price == "")
	        {
	            document.getElementById("TextSel_Price").className = "medium error";
	            alert("课程售价不能为空");
	            return false;
	        }
	        var student_share = document.getElementById("TextStudent_Share").value;
	        if (student_share == "")
	        {
	            document.getElementById("TextStudent_Share").className = "medium error";
	            alert("学员分成不能为空");
	            return false;
	        }
	        var clerk_share = document.getElementById("TextClerk_Share").value;
	        if (clerk_share == "")
	        {
	            document.getElementById("TextClerk_Share").className = "medium error";
	            alert("业务分成不能为空");
	            return false;
	        }
	        var service_share = document.getElementById("TextService_Share").value;
	        if (service_share == "")
	        {
	            document.getElementById("TextService_Share").className = "medium error";
	            alert("客服人员分成不能为空");
	            return false;
	        }
	    }
	    function checkback()
	    {
	        window.location.href = "DetailCourseList.aspx";
	    }
    </script>
</head>
<body>
    <!-- forms -->
				<div class="container1">
                <h4>课程添加</h4>
					<form id="form1"  runat="server">
					<div class="form">
						<div class="fields">                      
	
                            <div class="field">
								<div class="label">
									<label for="input-small">课程名称:</label>
								</div>
								<div class="input">
									<input type="text" id="TextDetailCourse"  class="small"  runat="server"/><asp:Label ID="LabelDetailCourse" runat="server" ></asp:Label>
								</div>
							</div>
                                    <div class="field">
								<div class="label">
									<label for="input-small">课程进价:</label>
								</div>
								<div class="input">
									<input type="text" id="TextPur_Price"  class="small"  runat="server"/>
								</div>
							</div>
                                       <div class="field">
								<div class="label">
									<label for="input-small">课程售价:</label>
								</div>
								<div class="input">
									<input type="text" id="TextSel_Price"  class="small"  runat="server"/>
								</div>
							</div>
						    <div class="field">
								<div class="label">
									<label for="input-small">学员分成:</label>
								</div>
								<div class="input">
									<input type="text" id="TextStudent_Share"  class="small"  runat="server" value="0.15"/>
								</div>
							</div>   
                            <div class="field">
								<div class="label">
									<label for="input-small">业务分成:</label>
								</div>
								<div class="input">
									<input type="text" id="TextClerk_Share"  class="small"  runat="server" value="0.25"/>
								</div>
							</div> 
                            <div class="field">
								<div class="label">
									<label for="input-small">客服人员分成:</label>
								</div>
								<div class="input">
									<input type="text" id="TextService_Share"  class="small"  runat="server" value="0.07"/>
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

