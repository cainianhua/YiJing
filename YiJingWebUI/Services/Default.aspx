﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Content.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Services.Default" %>
<%@ Register src="~/UserControls/Footer2.ascx" tagname="Footer2" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SideBar.ascx" tagname="SideBar" tagprefix="uc3" %>
<%@ Register src="~/UserControls/AboutDetail.ascx" tagname="AboutDetail" tagprefix="uc1" %>
<%@ Register src="~/UserControls/AboutHeader.ascx" tagname="AboutHeader" tagprefix="uc4" %>
<%@ Register src="~/UserControls/ArticleMetas.ascx" tagname="ArticleMetas" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Metas" runat="server">
	<uc5:ArticleMetas ID="ArticleMetas1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
	<uc4:AboutHeader ID="AboutHeader1" Sort="Services" runat="server" />
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer2 ID="Footer21" runat="server" />
	<uc3:SideBar ID="SideBar1" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		var carousel = new Carousel("#container", {
			"totalPane": totalCount,
			"currPaneIndex": currentPageNo - 1, // base on 0;
			"currSort": currentSort,
			"onPageIndexChanged": function (pageIndex, item) {
				var pageNo = pageIndex + 1;

				if (Modernizr.history) {
					document.title = item.title;
					document.getElementsByName("keywords")[0].content = item.keywords;
					document.getElementsByName("description")[0].content = item.description;
					window.history.pushState(null, title, "/services/?pn=" + pageNo);
				}
				else {
					window.location = "/services/?pn=" + pageNo;
				}
			}
		});
		carousel.init();
	</script>
</asp:Content>
