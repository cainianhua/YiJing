<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Content.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.AboutUs.Default" %>
<%@ Register src="~/UserControls/Footer2.ascx" tagname="Footer2" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SideBar.ascx" tagname="SideBar" tagprefix="uc3" %>
<%@ Register src="~/UserControls/AboutDetail.ascx" tagname="AboutDetail" tagprefix="uc1" %>
<%@ Register src="~/UserControls/AboutHeader.ascx" tagname="AboutHeader" tagprefix="uc4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
	<uc4:AboutHeader ID="AboutHeader1" Sort="AboutUs" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<asp:PlaceHolder ID="Containers" runat="server"></asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer2 ID="Footer21" runat="server" />
	<uc3:SideBar ID="SideBar1" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript" src="/scripts/modernizr.min.js"></script>
	<script type="text/javascript" src="/scripts/hammer/hammer.min.js"></script>
	<script type="text/javascript" src="/scripts/yijing/carousel_ajax.js"></script>
	<script type="text/javascript">
		var carousel = new Carousel("#container", {
			"totalPane": totalCount,
			"currentPane": currentPageNo - 1,
			"currentCategoryId": currentCategoryId,
			"onShowed": function (pageIndex) {
				var pageNo = pageIndex + 1;
				window.history.pushState(null, null, "/aboutus/?pn=" + pageNo);
			}
		});
		carousel.init();
	</script>
</asp:Content>
