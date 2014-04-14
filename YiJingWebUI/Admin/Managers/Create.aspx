<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="false" CodeBehind="Create.aspx.cs" Inherits="YiJingWebUI.Admin.Managers.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	新建账号 - 熠镜后台管理中心
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadScripts" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Top" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<div class="content-box-content">
        <div class="tab-content default-tab" id="tab1">
            <!-- This is the target div. id must match the href of this div's tab -->
			<asp:PlaceHolder ID="MessageContainer" runat="server"></asp:PlaceHolder>

            <form id="form1" runat="server" autocomplete="off">
            <fieldset>
				<p>
					<label>登录账号(*)：</label>
					<asp:TextBox ID="Name" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Name" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="登录账号不能为空"></asp:RequiredFieldValidator>
				</p>
				<p>
					<label>用户昵称(*)：</label>
					<asp:TextBox ID="NickName" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="NickName" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="用户昵称不能为空"></asp:RequiredFieldValidator>
				</p>
				<p>
					<label>密码(*)：</label>
					<asp:TextBox ID="Pwd" CssClass="text-input small-input" TextMode="Password" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Pwd" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
				</p>
				<p>
					<label>确认密码(*)：</label>
					<asp:TextBox ID="PwdConfirmed" CssClass="text-input small-input" TextMode="Password" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="PwdConfirmed" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="确认密码不能为空"></asp:RequiredFieldValidator>
					<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="PwdConfirmed" ControlToCompare="Pwd" CssClass="input-notification error png_bg" Display="Dynamic" ErrorMessage="两次输入的密码不一致"></asp:CompareValidator>
				</p>
                <p>
                    <asp:HiddenField ID="ManagerId" runat="server" />
					<asp:Button ID="btnSave" runat="server" Text="保存账号" CssClass="button" onclick="btnSave_Click" />
                </p>
            </fieldset>
            </form>
        </div>
        <!-- End #tab1 -->
    </div>
    <!-- End .content-box-content -->
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Bottom" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
