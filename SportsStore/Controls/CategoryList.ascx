<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="SportsStore.Controls.CategoryList" %>

<a href="<%= HomeLink %>" <%if (CurrentCategory == null) { %>class="selected"<%} %> >Home</a>
<% foreach (var category in Categories) {%>
<a href="<%= GetCategoryLink(category) %>" <%if (category == CurrentCategory) { %>class="selected"<%} %> ><%= category %></a>
<%}%>