<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EFReference.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%
        foreach (var employee in GetEmployees()) {
            Response.Write("<div class='employee'>");
            Response.Write(string.Format("<h3>{0}</h3>", employee.Name));
            Response.Write(string.Format("<h4>{0:c}</h4>", employee.Email));
            Response.Write("</div>");
        }
    %>
    </div>
    </form>
</body>
</html>
