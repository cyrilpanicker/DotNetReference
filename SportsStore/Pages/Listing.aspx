﻿<%@ Page 
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Listing.aspx.cs"
    Inherits="SportsStore.Pages.Listing"
    MasterPageFile="~/Pages/Store.Master" 
%>

<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <%foreach (var product in ProductsByPage) {%>
        <div class="item">
            <h3><%= product.Name %></h3>
            <p><%= product.Description %></p>
            <h4><%= product.Price %></h4>
            <button name="add" type="submit" value="<%= product.ProductID %>">Add to Cart</button>
        </div>
        <%}%>
    </div>
    <div class="pager">
        <%for (int i = 1; i <= MaxPage; i++) {
                var path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary { { "page", i }, { "category", CurrentCategory } }).VirtualPath;
        %>
        <a <%if (i == CurrentPage) {%>class="selected"<%} %> href="<%=path%>"><%= i %></a>
        <%}%>
    </div>
</asp:Content>
