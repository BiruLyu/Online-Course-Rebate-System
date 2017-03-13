<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderAdd.aspx.cs" Inherits="MySystemWeb.uAdmin.OrderAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加订单</title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="screen" />
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/tabber.css" type="text/css" media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextOrder_num").blur(function checkusername() {

                var order_num = document.getElementById("TextOrder_num").value;


                if (order_num != "") {

                    $.post("ajax/checkordernum.aspx", { order_num: order_num }, function (data) {

                        if (data.sta == "1") {
                            $("#LabelOrder").show();
                            $("#LabelOrder").text(data.info);
                            $("#TextOrder_num").focus();

                        }
                        else if (data.sta == "2") {
                            $("#LabelOrder").show();
                            $("#LabelOrder").text(data.info);
                            $("#TextOrder_num").focus();
                        }
                        else {
                            $("#LabelOrder").hide();

                        }


                    }, "json");
                }

            });

        });
        $(document).ready(function () {
            $.post("ajax/getbasic_course.aspx", function (data) {

                $("#SelectBasicCourse").html(data);

            }, "html");
        }
        );
        function getsubordinate_course() {
            //var basic_courseID = document.getElementById("SelectBasicCourse").value;
            var basiccourse = document.getElementById("SelectBasicCourse").value;
            $.post("ajax/getsubordinate_course.aspx", { basiccourse: basiccourse }, function (data) {
                $("#SelectSubordinateCourse").html(data);
            }, "html");
        }
        function getdetail_course() {
            var sub_courseID = document.getElementById("SelectSubordinateCourse").value;
            $.post("ajax/getdetail_course.aspx", { basic_courseID: sub_courseID }, function (data) {
                $("#SelectDetailCourse").html(data);

            }, "html");
        }
        function checkadd() {
            var order_number = document.getElementById("TextOrder_num").value;
            if (order_number == "") {
                document.getElementById("TextOrder_num").className = "medium error";
                alert("订单号不能为空");
                return false;
            }
            var basic_course = document.getElementById("SelectBasicCourse").value;
            if (basic_course == "-1") {
                document.getElementById("SelectBasicCourse").className = "medium error";
                alert("课程分类信息不完整");
                return false;
            }
            var sub_course = document.getElementById("SelectSubordinateCourse").value;
            if (basic_course == "-1") {
                document.getElementById("SelectSubordinateCourse").className = "medium error";
                alert("课程分类信息不完整");
                return false;
            }
            var detail_course = document.getElementById("SelectDetailCourse").value;
            if (detail_course == "-1") {
                document.getElementById("SelectDetailCourse").className = "medium error";
                alert("详细课程不能为空");
                return false;
            }
            $("#HiddenCourse").val($("#SelectDetailCourse").val());
        }
        function checkback() {
            window.location.href = "OrderList.aspx";
        }
        function SelectBasicCourse_onclick() {

        }

    </script>
</head>
<body>
    <!-- forms -->
    <div class="container1">
        <h4>
            订单添加:</h4>
        <form id="form1" runat="server">
        <div class="form">
            <div class="fields">
                <div class="field">
                    <div class="label">
                        <label for="input-small">
                            订单号:</label>
                    </div>
                    <div class="input">
                        <input type="text" id="TextOrder_num" class="small" runat="server" />
                        &nbsp;&nbsp;<asp:Label ID="LabelOrder" runat="server" ForeColor="red"></asp:Label>
                        </div>
                   
                </div>
                <div class="field">
                    <div class="label">
                        <label for="input-small">
                            课程分类:</label>
                    </div>
                    <div class="input">
                        <select id="SelectBasicCourse" runat="server" onchange="getsubordinate_course()" onclick="return SelectBasicCourse_onclick()">
                            <option value="-1">--请选择--</option>
                        </select>
                        <select id="SelectSubordinateCourse" runat="server" onchange="getdetail_course()">
                            <option value="-1">--请选择--</option>
                        </select>
                    </div>
                </div>
                <div class="field">
                    <div class="label">
                        <label for="input-small">
                            课程名称:</label>
                    </div>
                    <div class="input">
                        <select id="SelectDetailCourse" runat="server">
                            <option value="-1">--请选择--</option>
                        </select>
                    </div>
                    <input id="HiddenCourse" type="hidden" runat="server" />
                </div>
                <div class="buttons">
                    <asp:Button ID="Button1" runat="server" Text=" 提 交 " CssClass="ui-state-default"
                        OnClick="Button1_Click" OnClientClick="return checkadd()" />
                    <input type="button" value=" 返 回 " class="ui-state-default" onclick="checkback()" />
                </div>
            </div>
        </div>
        </form>
    </div>
    <!-- end forms -->
</body>
</html>
