<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="YiJingWebUI.UserControls.Search" %>

<div class="search-box clearfix">
	<asp:TextBox ID="SearchText" CssClass="ipt-search" runat="server"></asp:TextBox>
	<asp:Button ID="btnSearch" CssClass="btn-search" runat="server" OnClick="btnSearch_OnClick" />
</div>