<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayService3.aspx.cs" Inherits="MySystemWeb.uAdmin.PayService3" %>

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
        var qx="<%=qx%>"
        $(document).ready(function ()
        {
            $("#ButtonService").hide();
            if (qx == "1")
            {
                $("#ButtonService").show();
             }
        });
        var idArray = "";
        function checkpay_service()
        {
            if (confirm("确认支付给客服人员了吗？"))
            {

                $(".hi").each(function ()
                {
                    if ($(this).val() != "")
                     {
                         idArray += $(this).val()+"|" 
                     }

                });
              
                $.post("ajax/payservice.aspx", { idArray: idArray }, function (data)
                {
                    alert(data.info);
                    if (data.sta == "1") { window.location.reload(); }
                }, "json");
            }
        }
        function checkfind()
        {

            var url = "PayService3.aspx?s=pf";

            var begintime = $("#TextBegin").val();

            if (begintime != "")
            {

                url += "&begintime=" + begintime;
            }
            var endtime = $("#TextEnd").val();

            if (endtime != "")
            {

                url += "&endtime=" + endtime;
            }
            window.location.href = url;
        }

    </script>
   </head>
<body>
    <form id="form1" runat="server">
      <div class="container1 separator">
          时间：<input id="TextBegin" type="text" onclick="WdatePicker()" readonly="readonly" />至<input id="TextEnd" type="text"onclick="WdatePicker()" readonly="readonly"  />

                        <input id="Buttonfind" type="button" value="查询" onclick="checkfind()"  class="ui-state-custom"/>
                            </div>
    <div class="container1">
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
                   					<th class="left">序号</th>	
                                    <th>订单号</th>
                                    <th>核对日期</th>                                    							 
                                    <th>工作人员分成</th>                                                                
                                    </tr>
							</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr >  
                           <input id="HiddenOrder_id" type="hidden" class="hi" value="<%#Eval("id")%>"/> 
                                <td><%#Eval("rowid") %></td>                      
                                <td><%#Eval("order_number")%></td> 
                                <td><%#Eval("exam_time")%></td>                              
                                <td><%#Eval("service_share")%></td>
                                                             
                               
                      </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
                合计：<asp:Literal ID="LiteralTotal" runat="server"></asp:Literal>
              <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
             <input id="ButtonService" type="button" value="返还给工作人员" 
          onclick=" checkpay_service()" runat="server" class="ui-state-custom" />	  	
     
						
						
				
       	                  
                     	
     
						
						
				
       	    </div>
    </form>
</body>
</html>
