<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="MySystemWeb.uAdmin.Attendance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>考勤管理</title>
        <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" />   
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
   <script type="text/javascript">
           $(document).ready(function ()
           {
               var qx = "<%=qx%>";
               if (qx == "2")
               {
                   $(".service").hide();
                   $("#SelectService").hide();
               }
               $.post("ajax/getservice.aspx", function (data)
               {

                   $("#SelectService").html(data);

               }, "html");
           });
        function checkfind()
        {
            var url = "Attendance.aspx?s=pf";
            var service_name = document.getElementById("SelectService").value;
            if (service_name != "-1")
            {
                url += "&username=" + encodeURI(service_name);
            }
            var begintime = $("#TextBegin").val();
            var endtime = $("#TextEnd").val();


            if (begintime != "")
            {

                url += "&begintime=" + begintime;
            }
           
            if (endtime != "")
            {

                url += "&endtime=" + endtime;
            }
            window.location.href = url;
        }
     </script>
   </head>
<body>
  <div class="container1 separator">
   <span class="service">客服人员：</span> <select id="SelectService">
              <option value="-1">--请选择--</option>
          </select>
                          时间：<input id="TextBegin" type="text" onclick="WdatePicker()" readonly="readonly" />至<input id="TextEnd" type="text"onclick="WdatePicker()" readonly="readonly"  />

                        <input id="Buttonfind" type="button" value="查询" onclick="checkfind()" />
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
								<th class="left">序号</th>
                                <th>客服人员</th>
                                <th>签到日期</th>
				</tr>
							</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr >
                            <td><%#Eval("rowid")%></td> 
                            <td><%#Eval("username")%></td>      
                            <td><%#((DateTime)Eval("attendance_time")).ToShortDateString()%></td>  
                      </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
              签到总计： <asp:Literal ID="LiteralTotal" runat="server"></asp:Literal>
                <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
                	    </div>
</body>
</html>
