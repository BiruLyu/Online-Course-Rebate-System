<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="MySystemWeb.uAdmin.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户信息</title>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen" />
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen" />
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkdel(pid) {
            if (confirm("确实要删除吗？")) {
                $.post("ajax/userdel.aspx", { pid: pid }, function (data) {

                    alert(data.info);
                    if (data.sta == "1") { window.location.reload(); }
                }, "json");
            }
        }
        //        function select_userkind()
        //        {
        //            $("#HiddenUserKind").val($("#SelectUserType").val());
        //            
        //           
        //         }
        function checkgo() {
            window.location.href = "UserAdd.aspx";
        }
        function checkfind() {
            var url = "UserList.aspx?s=pf";
            var username = document.getElementById("TextUser").value;
            if (username != "")
                url += "&user_name=" + encodeURI(username);
            var user_kind = document.getElementById("SelectUserType").value;
            if (user_kind != "-1") {
                url += "&qxid=" + encodeURI(user_kind);
            }
            window.location.href = url;
        }
    </script>
</head>
<body>
    <div class="container1 separator">
        <h4>
            用户信息</h4>
        用户名:<input type="text" id="TextUser" class="small" runat="server" />
        用户性质：<select id="SelectUserType">
            <option value="-1">--请选择--</option>
            <option value="2">客服人员</option>
            <option value="3">工作人员</option>
            <option value="4">注册学员</option>
        </select><input id="HiddenUserKind" type="hidden" runat="server" />
        <input id="Button1" type="button" value="查询" onclick="checkfind()" class="ui-state-custom" />
    </div>
    <div class="container1">
        <table cellspacing="0" class="aroom_table">
            <thead>
                <tr>
                    <th class="left">
                        序号
                    </th>
                    <th>
                        用户名
                    </th>
                    <th>
                        用户性质
                    </th>
                    <th>
                        密码
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("rowid")%>
                            </td>
                            <td>
                                <%#Eval("username")%>
                            </td>
                            <td>
                                <%#Eval("qxid").ToString()=="1"?"站长":Eval("qxid").ToString()=="3"?"客服人员":Eval("qxid").ToString()=="2"?"工作人员":"学员"%>
                            </td>
                            <td>
                                <%#Eval("password")%>
                            </td>
                            <td>
                                <a href="###" onclick="checkdel(<%#Eval("id")%>)">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
        <div class="buttons">
            <input type="button" id="button" value=" 用户登记 " class="ui-state-custom" onclick="checkgo()" />
        </div>
</body>
</html>
