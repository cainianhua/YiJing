<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	控制面板 - 熠镜后台管理中心
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadScripts" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Top" runat="server">
	<ul class="shortcut-buttons-set">
		<%--<li><a class="shortcut-button" href=""><span>
			<img src="<%= this.ResolveUrl("~/Admin/Content/images/icons/pencil_48.png") %>" alt="icon" /><br />
			新增文章 </span></a></li>
		<li><a class="shortcut-button" href="#"><span>
			<img src="<%= this.ResolveUrl("~/Admin/Content/images/icons/image_add_48.png") %>" alt="icon" /><br />
			上传图片 </span></a></li>--%>
		<%--<li><a class="shortcut-button" href="#"><span>
			<img src="<%= Url.Content("~/content/images/icons/paper_content_pencil_48.png") %>" alt="icon" /><br />
			新建页面 </span></a></li>
    
		<li><a class="shortcut-button" href="#"><span>
			<img src="<%= Url.Content("~/content/images/icons/clock_48.png") %>" alt="icon" /><br />
			增加事项 </span></a></li>
		<li><a class="shortcut-button" href="#messages" rel="modal"><span>
			<img src="<%= Url.Content("~/content/images/icons/comment_48.png") %>" alt="icon" /><br />
			系统帮助 </span></a></li>--%>
	</ul>

	<!-- End .shortcut-buttons-set -->
	<div class="clear"></div>
	<!-- End .clear -->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<!-- End .content-box-header -->
    <div class="content-box-content">
        <div class="tab-content default-tab" id="tab1">
			这里是内容简介
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Bottom" runat="server">
	<!-- Start Notifications -->
	<%--<div class="notification attention png_bg">
		<a href="#" class="close">
			<img src="<%= this.ResolveUrl("~/Admin/Content/images/icons/cross_grey_small.png")%>" title="Close this notification"
				alt="close" /></a>
		<div>
			Attention notification. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
			Proin vulputate, sapien quis fermentum luctus, libero.
		</div>
	</div>
	<div class="notification information png_bg">
		<a href="#" class="close">
			<img src="<%= this.ResolveUrl("~/Admin/Content/images/icons/cross_grey_small.png")%>" title="Close this notification"
				alt="close" /></a>
		<div>
			Information notification. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
			Proin vulputate, sapien quis fermentum luctus, libero.
		</div>
	</div>
	<div class="notification success png_bg">
		<a href="#" class="close">
			<img src="<%= this.ResolveUrl("~/Admin/Content/images/icons/cross_grey_small.png")%>" title="Close this notification"
				alt="close" /></a>
		<div>
			Success notification. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin
			vulputate, sapien quis fermentum luctus, libero.
		</div>
	</div>
	<div class="notification error png_bg">
		<a href="#" class="close">
			<img src="<%= this.ResolveUrl("~/Admin/Content/images/icons/cross_grey_small.png")%>" title="Close this notification"
				alt="close" /></a>
		<div>
			Error notification. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin
			vulputate, sapien quis fermentum luctus, libero.
		</div>
	</div>--%>
	<!-- End Notifications -->
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
