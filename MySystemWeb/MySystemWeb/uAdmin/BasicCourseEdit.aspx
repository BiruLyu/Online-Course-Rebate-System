<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicCourseEdit.aspx.cs" Inherits="MySystemWeb.uAdmin.BasicCourseEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>基础课程修改</title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>    
	<script type="text/javascript">
	    $(document).ready(function ()
	    {
          $("#TextBasicCourse").blur(function checkusername()
	        {
	            var basic_course = document.getElementById("TextBasicCourse").value;
	            if (basic_course != "")
	            {

	                $.post("ajax/checkbasiccourse.aspx", { basic_course: basic_course }, function (data)
	                {

	                    if (data.sta == "1")
	                    {
	                        $("#LabelBasicCourse").show();
	                        $("#LabelBasicCourse").text(data.info);
	                        $("#TextBasicCourse").focus();

	                    }
	                    else
	                    {
	                        $("#LabelBasicCourse").hide();

	                    }


	                }, "json");
	            }

	        });

	    });

	    $(document).ready(function() 
	    {
	        $.post("ajax/getprovince.aspx", function (data)
	        {

	            $("#SelectProvince").html(data);

	        }, "html");
	        $("#HiddenProvince").val($("#SelectProvince").val());
	    });   
	    function checkadd()
	    {
	       
	        var basiccourse = document.getElementById("TextBasicCourse").value;
	        if (basiccourse == "")
	        {
	            document.getElementById("TextBasicCourse").className = "medium error";
	            alert("课程名称不能为空");
	            return false;
	        }

	    }
	    function checkback()
	    {
	        window.location.href = "BasicCourseList.aspx";
	    }
    </script>
</head>
<body>
    <!-- forms -->
				<div class="container1">
                <h4>基础课程添加</h4>
					<form id="form1"  runat="server">
					<div class="form">
						<div class="fields">                      
							
                            <div class="field">
								<div class="label">
									<label for="input-small">课程名称:</label>
								</div>
								<div class="input">
									<input type="text" id="TextBasicCourse"  class="small"  runat="server"/><asp:Label ID="LabelBasicCourse" runat="server" ></asp:Label>
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

