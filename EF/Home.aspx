<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EF.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .employee{
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%foreach(var employee in GetEmployees()) {%>
            <div class="employee">
                <div class="name"><%= employee.Name %></div>
                <div class="email"><%= employee.Email %></div>
            </div>
        <%}%>
    </div>
    </form>
</body>
</html>
