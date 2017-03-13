<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailCourseList.aspx.cs" Inherits="MySystemWeb.uAdmin.DetailCourseList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" />   
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function ()
        {
            var qx=<%=qx %>;
            if(qx=="3"||qx=="4")
            {
             $(".handle").hide();
                $("#button").hide();       
            }
 
   
        })
        function checkdel(pid)
        {
            if (confirm("确实要删除吗？"))
            {
                $.post("ajax/detail_coursedel.aspx", { pid: pid }, function (data)
                {
                    alert(data.info);
                    if (data.sta == "1") { window.location.reload(); }
                }, "json");
            }
        }
        function checkgo()
        {
            window.location.href = "DetailCourseAdd.aspx?pid=<%=subordinate_course_id%>";
        }
    </script>
   </head>
<body>
  <div class="container1 separator">
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
								<th class="left">课程名称</th>
									<th>课程进价</th>
                                    <th>课程售价</th>
                                    <th>学员分成</th>
                                    <th>业务分成</th>
                                    <th>客服人员分成</th>                                 
									<th class="handle">操作</th>
								</tr>
							</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr >
                                <td><%#Eval("course_name")%></td>                             
                                <td><%#Eval("course_pur_price")%></td>
                                <td><%#Eval("course_sel_price")%></td>
                                <td><%#Eval("student_share")%></td>
                                <td><%#Eval("clerk_share")%></td>
                                <td><%#Eval("service_share")%></td>
                                <td class="handle" ><a  href="DetailCourseEdit.aspx?pid=<%#Eval("id")%>">修改</a>|<a href="###" onclick="checkdel(<%#Eval("id")%>)">删除</a></td>
                      </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
              <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
                     	<div class="buttons">
					<input type="button" id="button" value="课程登记 " class="ui-state-custom"  onclick="checkgo()"/>
							
							</div>   
     
						
						
				
       	    </div>
</body>
</html>
