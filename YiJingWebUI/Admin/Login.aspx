<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YiJingWebUI.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>熠镜管理后台登录</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<link rel="shortcut icon" href="/favicon.ico" />
    <link rel="stylesheet" href="<%= this.ResolveUrl("~/admin/content/reset.css")%>" type="text/css" media="screen" />
    <link rel="stylesheet" href="<%= this.ResolveUrl("~/admin/content/style.css")%>" type="text/css" media="screen" />
    <!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
    <link rel="stylesheet" href="<%= this.ResolveUrl("~/admin/content/invalid.css")%>" type="text/css" media="screen" />	
	<!-- Internet Explorer Fixes Stylesheet -->
	<!--[if lte IE 7]>
		<link rel="stylesheet" href="resources/css/ie.css" type="text/css" media="screen" />
	<![endif]-->
	<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.js"></script>
	<script type="text/javascript" src="<%= this.ResolveUrl("~/admin/scripts/facebox.js") %>"></script>
	<script type="text/javascript" src="<%= this.ResolveUrl("~/admin/scripts/configuration.js") %>"></script>
	<!-- Internet Explorer .png-fix -->
	<!--[if IE 6]>
	<script type="text/javascript" src="resources/scripts/DD_belatedPNG_0.0.7a.js"></script>
	<script type="text/javascript">
		DD_belatedPNG.fix('.png_bg, img, li');
	</script>
	<![endif]-->
</head>
<body id="login">
		<div id="login-wrapper" class="png_bg">
			<div id="login-top">
				<h1>Simpla Admin</h1>
				<!-- Logo (221px width) -->
				<img id="logo" src="<%= this.ResolveUrl("/admin/Content/images/logo.png") %>" alt="Simpla Admin logo" />
			</div> <!-- End #logn-top -->
			
			<div id="login-content">
				<form id="form1" runat="server">
					<asp:Panel ID="pnMessage" CssClass="notification error png_bg" Visible="false" runat="server">
						<div>
							<asp:Literal ID="errorMessage" runat="server"></asp:Literal>
						</div>
					</asp:Panel>
					<p>
						<label>登录名</label>
						<asp:TextBox ID="Name" CssClass="text-input" MaxLength="50" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Name" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="请输入登录名"></asp:RequiredFieldValidator>
					</p>
					<div class="clear"></div>
					<p>
						<label>登录密码</label>
						<asp:TextBox ID="Password" CssClass="text-input" MaxLength="50" TextMode="Password" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Password" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="请输入密码"></asp:RequiredFieldValidator>
					</p>
					<div class="clear"></div>
					<p>
						<asp:Button ID="SignIn" Text="登录系统" CssClass="button" runat="server" OnClick="SignIn_OnClick" />
					</p>
				</form>
			</div> <!-- End #login-content -->
		</div> <!-- End #login-wrapper -->
  </body>
</html>
