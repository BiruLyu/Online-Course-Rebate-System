<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="MySystemWeb.uAdmin.OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单列表</title>
        <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen"/>
    <link href="css/aspnetpager.css" rel="stylesheet" type="text/css" /> 
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
       <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var qx = "<%=qx%>";
        var ispayservice = "<%=ispayservice%>";
        var isexam = "<%=isexam %>";
        var ispayclerk = "<%=ispayclerk%>";
        var ispaystudent = "<%=ispaystudent%>";
        var rownumber = "";
        var pid = "";
        $(document).ready(function () {
            $(".aroom_table td").click(function () {
                var tdSeq = $(this).parent().find("td").index($(this)[0]);
                var trSeq = $(this).parent().parent().find("tr").index($(this).parent()[0]);
                rownumber = trSeq;
                // alert("第" + (trSeq + 1) + "行，第" + (tdSeq + 1) + "列");
                if ((tdSeq + 1) == 5 && qx==2) {
                    if (confirm("信息核对正确吗？")) {
                        pid = document.getElementsByName("HiddenOrder_id")[rownumber].value;
                        // pid = document.getElementsByName("HiddenOrder_id").value;
                        //pid = document.getElementsByName("HiddenOrder_id")[$(this).parent().parent().find("tr").index($(this).parent()[0]) + 1].value;

                        //                pid = $(this).attr("HiddenOrder_id");
                        //                pid = $(this).attr("HiddenOrder_id")[2];
                        //                pid = document.getElementById("HiddenOrder_id1").value;
                        //var list = document.getElementsByTagName('HiddenOrder_id')[1].valueOf();

                        $.post("ajax/checkexam.aspx", { pid: pid }, function (data) {
                            alert(data.info);
                            if (data.sta == "1") { window.location.reload(); }
                        }, "json");


                    }
                }
            });

            $("#ButtonStudent").hide();
            $("#ButtonClerk").hide();

            $("#Checkbox1").indeterminate = true;
            $("#Checkbox2").indeterminate = true;
            $("#Checkbox3").indeterminate = true;
            $("#Checkbox4").indeterminate = true;
            if (qx == "1") {
                $("#total").hide();
                $(".student").hide();
                $(".clerk").hide();
                $("#ButtonStudent").hide();
                $("#ButtonClerk").hide();
                if (isexam == "1") {

                    //                    if (ispayservice == "0")
                    //                    {
                    //                        $("#ButtonService").show();
                    //                    }
                    if (ispaystudent == "0") {
                      //  $("#ButtonStudent").show();
                    }
                    if (ispayclerk == "0") {
                      //  $("#ButtonClerk").show();
                    }
                }


            }
            if (qx == "3") {
                $(".student").hide();
                $(".students").hide();
                $(".service").hide();
                $(".checkbox_student").removeAttr("checked");
                $("a:first").removeAttr("onclick");

            }
            if (qx == "4") {
                $(".clerk").hide();
                $(".clerks").hide();
                $(".service").hide();

                $("a:first").removeAttr("onclick");

            }
            if (qx == "2") {
                $("#total").hide();
                if (isexam == "1") {

                    if (ispaystudent == "0") {
                        $(".clerk").hide();
                        $(".clerks").hide();
                        $(".service").hide();
                        $("#ButtonStudent").show();
                    }
                    if (ispayclerk == "0") {
                        $(".student").hide();
                        $(".students").hide();
                        $(".service").hide();
                        $("#ButtonClerk").show();
                    }
                }
                if (isexam == "0") {
                    $(".student").hide();
                    $(".students").hide();
                    $(".clerk").hide();
                    $(".clerks").hide();
                    $(".service").hide();
                }
            }
        });

        

        function checkexam()
        {

               
             
            if (confirm("信息核对正确吗？")) {
                pid = document.getElementsByName("HiddenOrder_id").value;
                pid = document.getElementsByName("HiddenOrder_id")[$(this).parent().parent().find("tr").index($(this).parent()[0])+1].value;

//                pid = $(this).attr("HiddenOrder_id");
//                pid = $(this).attr("HiddenOrder_id")[2];
//                pid = document.getElementById("HiddenOrder_id1").value;
                //var list = document.getElementsByTagName('HiddenOrder_id')[1].valueOf();

                $.post("ajax/checkexam.aspx", { pid: pid }, function (data)
                {
                    alert(data.info);
                    if (data.sta == "1") { window.location.reload(); }
                }, "json");
            }
         }
         var idArray = "";
         function checkpay_clerk()
         {
             if (confirm("确认支付给工作人员了吗？"))
             {

                 $("input[type=hidden]").each(function ()
                 {
                     idArray += $(this).val() + "|";

                 });
                
                 $.post("ajax/payclerk.aspx", { idArray: idArray }, function (data)
                 {
                  
                     alert(data.info);
                     if (data.sta == "1") { window.location.reload(); }
                 }, "json");
             }
         }
         function checkpay_student()
         {
             if (confirm("确认支付给学员了吗？"))
             {

                 $("input[type=hidden]").each(function ()
                 {
                     idArray += $(this).val() + "|";

                 });
                 $.post("ajax/paystudent.aspx", { idArray: idArray }, function (data)
                 {
                     
                     alert(data.info);
                     if (data.sta == "1") { window.location.reload(); }
                 }, "json");
             }
         }

      

          function checkfind()
          {
              var url = "OrderList.aspx?s=pf";
              var username = "<%=username%>";

              if (qx == "4")
              {
                  url += "&student_name="+encodeURI(username);

               }
              if (qx == "3")
              {
                url += "&clerk_name="+encodeURI(username);
              }             
              var order_number = $("#TextOrder").val();
              if (order_number != "")
              { url += "&order_number=" + encodeURI(order_number); }
              var student_name = encodeURI($("#TextStudentname").val());
              if (student_name != "")
              { url += "&student_name=" + encodeURI(student_name); }
              var course_name =encodeURI($("#TextCourse").val());
              if (course_name != "")
              { url += "&course_name=" + encodeURI(course_name); }
              if (isexam != "")
              {
                  url += "&isexam=" + isexam;
              }
              if (ispaystudent != "")
              {
                  url += "&ispaystudent=" + ispaystudent;
              }
              if (ispayclerk != "")
              {
                  url += "&ispayclerk=" + ispayclerk;
              }
              if (ispayservice != "")
              {
                  url += "&ispayservice=" + ispayservice;

               }
              if (document.getElementById("Checkbox1").checked == true)
              {
                 
                  url += "&isexam=1";
              }

              if (document.getElementById("Checkbox2").checked == true)
              {

                  url += "&ispaystudent=1";
              }

              if (document.getElementById("Checkbox3").checked == true)
              {

                  url += "&ispayclerk=1";
              }
             
              var begintime = $("#TextBegin").val();
              if (begintime != "")
              { url += "&begintime=" + begintime; }
              var endtime = $("#TextEnd").val();
              if (endtime != "")
              { url += "&endtime=" + endtime; }

                window.location.href = url;
              
          }
          function checkdel(pid)
          {
              if (confirm("确实要删除吗？"))
              {
                  $.post("ajax/orderdel.aspx", { pid: pid }, function (data)
                  {
                      alert(data.info);
                      if (data.sta == "1") { window.location.reload(); }
                  }, "json");
              }
          }


    </script>
    <style type="text/css">
        #buttonfind
        {
            width: 148px;
        }
    </style>
   </head>
<body>
  <div class="container1 separator">
  <table>
  <tr>
  <th>订单号：<input id="TextOrder" type="text" class="small" runat="server" />&nbsp;&nbsp;&nbsp;</th>
  <th>用户名：<input id="TextStudentname" type="text" class="small" runat="server" />&nbsp;&nbsp;&nbsp;</th>
  <th>课程名称：<input id="TextCourse" type="text" class="small" runat="server" />&nbsp;&nbsp;&nbsp;</th>
  <th>时间：<input id="TextBegin" type="text" onclick="WdatePicker()" readonly="readonly" />至</th>
  <th><input id="TextEnd" type="text"onclick="WdatePicker()" readonly="readonly"  /></th>
  </tr>
  <tr><th>&nbsp;</th></tr>
 <tr>
 <th>是否核对：<input id="Checkbox1" type="checkbox" class="student"/></th>
 <th>是否返还学员: <input id="Checkbox2" type="checkbox" class="student"/></th>
 <th>是否返还工作人员：<input id="Checkbox3" type="checkbox" class="clerk"/></th>
 <th>是否返还客服人员：<input id="Checkbox4" type="checkbox" class="service" /></th>
 <th align="right"><input id="buttonfind" type="button" value="查询" onclick="checkfind()"  class="ui-state-custom"/></th>
 </tr>
 </table>
     </div>
    <div class="container1">

 
              <table cellspacing="0" class="aroom_table">
                <thead>
				<tr>
								<th class="left">序号</th>
                                  <th>订单号</th>
                                 <th>用户名</th>
                                 <th>课程名称</th>
                                 <th>是否核对</th>
                                 <th class="students">是否返还学员</th>
                               <%--  <th class="student">支付宝</th>
                                 <th class="student">开户行</th>--%>
                                 <th class="student">户名</th>
                                 <th class="student">账户</th>
                                 <th class="clerks">是否返还客服人员</th>
                                 <%--<th class="clerk">支付宝</th>
                                 <th class="clerk">开户行</th>
                                 <th class="clerk">户名</th>
                                 <th class="clerk">账户</th> --%>                                                               
								 <th class="service">是否返还工作人员</th> 
                                 <th class="students">操作</th>
                                                                                               

				</tr>
				</thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                          <tr>    
                            <input name="HiddenOrder_id" type="hidden" value="<%#Eval("id")%>";/>                       
                            <td><%#Eval("rowid") %></td>                          
                            <td><%#Eval("order_number")%></td>   
                            <td><%#Eval("student_name")%></td>  
                            <td><%#Eval("course_name") %></td>                                           
                            <td class="exam"><%#Eval("isexam").ToString()=="0"?"<a>未核对</a>":"<a style='color:Red'>已核对</a>"%></td>   
                            <td class="students" id="paystudent"><%#Eval("ispaystudent").ToString() == "0" ? "<a>未返还</a>" : "<a style='color:Red'>已返还</a>"%><%#Eval("student_share")%>元</td> 
                            <%--<td class="student"><%#Eval("student_zhifubao")%></td>--%>
                            <%--<td class="student"><%#Eval("student_bank")%></td>--%>
                            <td class="student"><%#Eval("student_bankname")%></td>
                            <td class="student"><%#Eval("student_banknum")%></td>
                            <td class="clerks" id="payclerk"><%#Eval("ispayclerk").ToString() == "0" ? "<a >未返还</a>" : "<a style='color:Red'>已返还</a>"%><%#Eval("clerk_share")%>元</td>
                           <%-- <td class="clerk"><%#Eval("clerk_zhifubao")%></td>
                            <td class="clerk"><%#Eval("clerk_bank")%></td>
                            <td class="clerk"><%#Eval("clerk_bankname")%></td>
                            <td class="clerk"><%#Eval("clerk_banknum")%></td>   --%>
                            <td class="service"id="payservice"><%#Eval("ispayservice").ToString() == "0" ? "<a>未返还</a>" : "<a style='color:Red'>已返还</a>"%><%#Eval("service_share")%>元</td>                          
                            <td class="students"><a href="OrderEdit.aspx?&pid=<%#Eval("id")%>">修改</a>|<a href="###" onclick="checkdel(<%#Eval("id")%>)">删除</a></td>
                       </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    
                        
                    </tbody>
                    
                </table>
         
              <span id="total">合计：<asp:Literal  ID="LiteralTotal"  runat="server"></asp:Literal></span>
                <asp:Literal ID="LiteralPage" runat="server"></asp:Literal>
                <br />
      <input id="ButtonStudent" type="button" value="返还给学员" 
          onclick=" checkpay_student()" runat="server"   class="ui-state-custom"/>
      <input id="ButtonClerk" type="button" value="返还给客服人员" 
          onclick=" checkpay_clerk()" runat="server"   class="ui-state-custom"/>
       	   
</body>
  <script type="text/javascript">

         
       
           </script>
</html>
