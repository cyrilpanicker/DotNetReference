<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Routing.Pages.Index" %>
<%@ Import Namespace="System.Web.Routing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .selected{
            font-weight:bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%foreach (var product in GetProducts()) {%>
        <div class="product">
            <h3><%=product.Name %></h3>
            <p><%=product.Description %></p>
            <p><%=product.Price %></p>
        </div>
        <%}%>
    </div>
        <div>
            <%for (int i = 1; i <= MaxPage; i++) {
                    var link = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary { { "page", i } }).VirtualPath;%>
            <a <%if (i == CurrentPage) { %>class="selected"<%} %> href="<%=link %>"><%=i %></a>
            <%}%>
        </div>
    </form>
</body>
</html>
