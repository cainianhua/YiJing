﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="false" CodeBehind="Add.aspx.cs" Inherits="YiJingWebUI.Admin.Focuses.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	添加文章 - 熠镜后台管理中心
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadStyles" runat="server">
	<link rel="stylesheet" href="<%= this.ResolveUrl("~/Admin/Scripts/uploadify/uploadify.css")%>" type="text/css" media="screen" />	
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadScripts" runat="server">
	<script type="text/javascript" src="<%= this.ResolveUrl("~/Admin/Scripts/uploadify/jquery.uploadify.min.js") %>"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<div class="content-box-content">
        <div class="tab-content default-tab" id="tab1">
            <!-- This is the target div. id must match the href of this div's tab -->
			<asp:PlaceHolder ID="MessageContainer" runat="server"></asp:PlaceHolder>

            <form id="form1" runat="server" autocomplete="off">
            <fieldset>
				<p>
					<label>缩略图(<strong>*</strong>)：</label>
					<asp:TextBox ID="Pic" MaxLength="255" CssClass="text-input medium-input" runat="server" style="display:none;"></asp:TextBox>
					<br />
					<asp:Image ID="imgPic" ImageUrl="/Admin/Content/images/default.jpg" CssClass="bg-preview" runat="server" />
					<input id="file_upload" name="file_upload" type="file" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Pic" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="请上传缩略图"></asp:RequiredFieldValidator>
				</p>
				<p>
					<label>描述：</label>
					<asp:TextBox ID="Description" CssClass="text-input textarea" TextMode="MultiLine" MaxLength="255" runat="server"></asp:TextBox>
					<br />
					<small>描述最长255个字符，超长自动截断。</small>
				</p>
				<p>
					<label>链接(<strong>*</strong>)：</label>
					<asp:TextBox ID="LinkTo" CssClass="text-input large-input" MaxLength="255" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="LinkTo" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="链接必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>以http开头的链接，请勿使用相对路径。</small>
				</p>
				<p>
					<label>排序字段(<strong>*</strong>)：</label>
					<asp:TextBox ID="SortOrder" CssClass="text-input small-input" MaxLength="6" runat="server">9999</asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="SortOrder" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="排序字段必须填写"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="SortOrder" ValidationExpression="\d+" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="排序字段必须为整型数值"></asp:RegularExpressionValidator>
					<br />
					<small>如无特殊排序要求，保留默认值即可。</small>
				</p>
                <p>
                    <asp:HiddenField ID="FocusArticleId" runat="server" />
					<asp:Button ID="btnSave" runat="server" Text="保存焦点图" CssClass="button" onclick="btnSave_Click" />
                </p>
            </fieldset>
            </form>
        </div>
        <!-- End #tab1 -->
    </div>
    <!-- End .content-box-content -->
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		jQuery(function ($) {
			$('#file_upload').uploadify(uploadifyConfig);
			$('#file_upload').uploadify("settings", "onUploadSuccess", function (file, data, response) {
				var returns = data.split("|");
				if (returns.length == 2 && returns[0] == "success") {
					$("img[id$=imgPic]").attr("src", returns[1]);
					$("input[id$=Pic]").val(returns[1]);
					$("span[id$=RequiredFieldValidator2]").hide();
				}
			});
		});
	</script>
</asp:Content>
