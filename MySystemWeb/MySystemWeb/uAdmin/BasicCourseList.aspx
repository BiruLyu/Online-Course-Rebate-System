<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicCourseList.aspx.cs" Inherits="MySystemWeb.uAdmin.BasicCourseList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>课程分类</title>
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
             $(".edit").hide();
              $(".delete").hide();            
            }
 
   
        })
        function checkdel(pid)
        {
            if (confirm("确实要删除吗？"))
            {
                $.post("ajax/basic_coursedel.aspx", { pid: pid }, function (data)
                {
                    alert(data.info);
                    if (data.sta == "1") { window.location.reload(); }
                }, "json");
             }
         }
        function checkgo()
        {
            window.location.href = "BasicCourseAdd.aspx";
        }
    </script>
   </head>
<body>
  <div class="container1 separator">
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
								<th class="left">课程名称</th>
                                <th>操作</th>
									
									
								</tr>
							</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr >
                            <td><%#Eval("subcourse")%></td>   
                            <td><a class="edit"  href="BasicCourseEdit.aspx?pid=<%#Eval("id")%>">修改|</a><a class="delete" href="###" onclick="checkdel(<%#Eval("id")%>)">删除|</a> <a  href="DetailCourseList.aspx?pid=<%#Eval("id")%>">详细信息</a></td>                    
                            
                      </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
                <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
                     	<div class="buttons">
					<input type="button" id="button" value=" 添加课程分类 " class="ui-state-custom"  onclick="checkgo()"/>
							
							</div>
						
						
				
       	    </div>
</body>
</html>

