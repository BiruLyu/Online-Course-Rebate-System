<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayClerk.aspx.cs" Inherits="MySystemWeb.uAdmin.SailStatic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
      <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" />   
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function ()
        {
            $.post("ajax/getprovince.aspx", function (data)
            {

                $("#SelectProvince").html(data);

            }, "html");
        })

        function checkcity()
        {
            var province = document.getElementById("SelectProvince").value;
            $.post("ajax/getcity.aspx", { province: province }, function (data)
            {
                $("#SelectCity").html(data);
            }, "html");

        }
        function checkarea()
        {
            var city = document.getElementById("SelectCity").value;
            $.post("ajax/getarea.aspx", { city: city }, function (data)
            {
                $("#SelectArea").html(data);
            }, "html");

        }
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
        function checkfind()
        {
            var url = "PayClerk.aspx?s=pf";            
            var province =$("#SelectProvince").val();
            var city = $("#SelectCity").val();
            var area = $("#SelectArea").val();
            var clerk_name = $("#TextName").val();
            var isexam = "<%=isexam%>";
            var ispayclerk = "<%=ispayclerk%>";
            if (area == "-1")
            {
                alert("必须选择地区/县");
                return false;

             }
            if (province != "-1" && city != "-1" && area != "-1")
            { url += "&area=" + encodeURI(area); }
            if(isexam!="")
            {
                url += "&isexam=" + isexam;
            }
            if (ispayclerk != "")
            {
                url += "&ispayclerk=" + ispayclerk;
             }
            if (clerk_name != "")
            {
                url += "&clerk_name=" +encodeURI(clerk_name);
            }
            window.location.href = url;
         }

    </script>
   </head>
<body>
    <form id="form1" runat="server">
  <div class="container1 separator">
                          所属地区： <select id="SelectProvince" runat="server" onchange="checkcity()">
                                       <option value="-1">--请选择--</option>
                                     </select>
                                     <select id="SelectCity" runat="server" onchange="checkarea()">
                                       <option>--请选择--</option>
                                     </select>
                                     <select id="SelectArea" runat="server" >
                                      <option>--请选择--</option>
                                     </select>

                        业务员：<input id="TextName" type="text" />
                         <%-- 时间：<input id="TextBegin" type="text" onclick="WdatePicker()" readonly="readonly" />至<input id="TextEnd" type="text"onclick="WdatePicker()" readonly="readonly"  />--%>

                        <input id="Buttonfind" type="button" value="查询" onclick="checkfind()"  class="ui-state-custom"/>
                        </div>
                       <div class="container1">
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
                   					<th class="left">序号</th>	
                                    <th>所属地区</th>							 
                                    <th>业务员</th> 
                                    <th>销售量</th> 
                                    <th>业务分成</th>                                       
                                    <th>操作</th>                                                            
									
								</tr>
							</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr >   
                                <td><%#Eval("rowid") %></td>                      
                                <td><%#Eval("province")%><%#Eval("city")%><%#Eval("area")%></td> 
                                <td><%#Eval("clerk_name")%></td>                              
                                <td><%#Eval("sail_num")%></td>
                                <td><%#Eval("clerkshare")%></td>                                
                                <td><a  href="OrderList.aspx?isexam=1&ispayclerk=0&area=<%#Eval("area")%>">详细信息</a></td>
                      </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
                合计：<asp:Literal ID="LiteralTotal" runat="server"></asp:Literal>
              <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
                     	
     
						
						
				
       	                  
                     	
     
						
						
				
       	    </div>
    </form>
</body>
</html>
