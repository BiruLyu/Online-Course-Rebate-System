<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayStudent.aspx.cs" Inherits="MySystemWeb.uAdmin.PayStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>应返还学员学费清单</title>
        <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" />  
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>   
       <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkfind()
        {
            var url = "PayStudent.aspx?s=pf";
            var student_name = document.getElementById("TextStu_name").value;
            if (student_name != "")
            {
                url += "&student_name=" + encodeURI(student_name);
            }
            var begintime = $("#TextBegin").val();
            if (begintime != "")
            { url += "&begintime=" + begintime; }
            var endtime = $("#TextEnd").val();
            if (endtime != "")
            { url += "&endtime=" + endtime; }
            window.location.href = url;
         }

 
    </script>
   </head>
<body>
  <div class="container1 separator">
<%--  学员名：<input id="TextStu_name" type="text" />时间：<input id="TextBegin" type="text" onclick="WdatePicker()" readonly="readonly" />至<input id="TextEnd" type="text"onclick="WdatePicker()" readonly="readonly"  />
   <input id="Buttonfind" type="button" value="查询" onclick="checkfind()" />--%>
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
								<th class="left">序号</th>
                                <th>学员名</th>
                                <th>姓名</th>
                                <th>应返学费</th>
                                <th>支付宝</th>
                                <th>开户银行</th>                                
                                <th>户名</th>
                                <th>账号</th>
                                <th>详细信息</th>
                                                      
								
				</tr>
				</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr>   
                                                    
                           <td><%#Eval("rowid")%></td> 
                           <td><%#Eval("name")%></td>                          
                            <td><%#Eval("student_name")%></td>   
                            <td><%#Eval("pay_student")%></td>  
                            <td><%#Eval("zhifubao") %></td>  
                            <td><%#Eval("bank") %></td> 
                            <td><%#Eval("bank_name")%></td>                                          
                           <td><%#Eval("bank_num")%></td> 
                           <td><a  href="OrderList.aspx?isexam=1&ispaystudent=0&student_name=<%#Eval("student_name")%>">详细信息</a></td>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
                
                <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
                     
						
				
       	    </div>
</body>
</html>
