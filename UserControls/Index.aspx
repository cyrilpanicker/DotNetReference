<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UserControls.Index" %>
<%@ Register TagPrefix="custom" TagName="productTable" Src="~/ProductTable.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Product Table</h2>
        <custom:productTable runat="server" />
    </div>
    </form>
</body>
</html>
