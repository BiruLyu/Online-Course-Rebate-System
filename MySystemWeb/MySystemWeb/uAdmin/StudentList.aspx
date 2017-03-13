﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="MySystemWeb.uAdmin.StudentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学员列表</title>
        <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" />   
       <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">

    </script>
   </head>
<body>
  <div class="container1 separator">
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
								<th class="left">序号</th>
                                  <th>会员名</th>
                                  <th>姓名</th>
                                 <th>Email</th>
                                 <th>电话</th>
                                 <th>支付宝</th>
                                 <th>开户行</th>
                                 <th>银行账户名</th>
                                 <th>银行账号</th>
                                 <th>操作</th>                                
								
				</tr>
				</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr>    
                           <input id="HiddenOrder_id" type="hidden" value="<%#Eval("id")%>"/>
                           
                           <td><%#Eval("rowid") %></td>  
                           <td><%#Eval("username") %></td>                        
                            <td><%#Eval("name")%></td>   
                            <td><%#Eval("email")%></td>  
                            <td><%#Eval("telphone")%></td>    
                            <td><%#Eval("zhifubao") %></td>        
                            <td><%#Eval("bank") %></td>        
                            <td><%#Eval("bank_name") %></td>        
                            <td><%#Eval("bank_num") %></td>                                               
                            <td><a  href="StudentEdit.aspx?pid=<%#Eval("id")%>">修改</a></td>                
                       </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
                
                <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
                     
						
				
       	    </div>
</body>
</html>