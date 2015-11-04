<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductTable.ascx.cs" Inherits="UserControls.ProductTable" %>

<table border="1" style="border-collapse: collapse;">
    <thead>
        <tr>
            <th>Name</th>
            <th>Category</th>
            <th>Description</th>
            <th>Price</th>
        </tr>
    </thead>
    <tbody>
        <%foreach (var product in Products) {%>
        <tr>
            <td><%= product.Name %></td>
            <td><%= product.Category %></td>
            <td><%= product.Description %></td>
            <td><%= product.Price %></td>
        </tr>
        <%}%>
    </tbody>
</table>