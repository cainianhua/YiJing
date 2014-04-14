<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="false" ValidateRequest="false" CodeBehind="Add.aspx.cs" Inherits="YiJingWebUI.Admin.Categories.Add" %>
<asp:Content ContentPlaceHolderID="PageTitle" runat="server">
	添加分类 - 熠镜后台管理中心
</asp:Content>

<asp:Content ContentPlaceHolderID="HeadStyles" runat="server">
	<link rel="stylesheet" href="<%= this.ResolveUrl("~/Admin/Scripts/ColorPicker/css/colpick.css")%>" type="text/css" media="screen" />	
	<link rel="stylesheet" href="<%= this.ResolveUrl("~/Admin/Scripts/uploadify/uploadify.css")%>" type="text/css" media="screen" />	
</asp:Content>

<asp:Content ContentPlaceHolderID="HeadScripts" runat="server">
	<script type="text/javascript" src="<%= this.ResolveUrl("~/Admin/Scripts/ColorPicker/js/colpick.js") %>"></script>
	<script type="text/javascript" src="<%= this.ResolveUrl("~/Admin/Scripts/uploadify/jquery.uploadify.min.js") %>"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-box-content">
        <div class="tab-content default-tab" id="tab1">
            <!-- This is the target div. id must match the href of this div's tab -->
			<asp:PlaceHolder ID="MessageContainer" runat="server"></asp:PlaceHolder>

            <form id="form1" runat="server" autocomplete="off">
            <fieldset>
                <p id="parentItem" runat="server" visible="false">
                    <label>父级分类：</label>
                    <asp:DropDownList ID="drpParentId" CssClass="small-input" runat="server"></asp:DropDownList>
                    <br />
                    <small>请选择所属的新分类所属的父级分类。</small>
                </p>
				<p>
					<label>中文名称(*)：</label>
					<asp:TextBox ID="NameLocal" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="NameLocal" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="中文名称必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>中文名称最长50个字符，实际长度根据界面展示效果自行调整。</small>
				</p>
                <p>
					<label>英文名称(*)：</label>
					<asp:TextBox ID="Name" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Name" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="英文名称必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>英文名称最长50个字符，实际长度根据界面展示效果自行调整。</small>
				</p>
				<p>
					<label>分类描述：</label>
					<asp:TextBox ID="Description" CssClass="text-input textarea" TextMode="MultiLine" MaxLength="255" runat="server"></asp:TextBox>
					<br />
					<small>分类描述最长255个字符。</small>
				</p>
				<p>
					<label>背景颜色(*)：</label>
					<asp:TextBox ID="BgColor" CssClass="text-input small-input" MaxLength="6" runat="server"></asp:TextBox>
					<button id="picker" class="button">选择</button>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="BgColor" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="背景颜色必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>背景颜色默认为白色。</small>
				</p>
				<p>
					<label>背景图片：</label>
					<asp:HiddenField ID="BgPic" runat="server" />
					<asp:Image ID="imgBgPic" ImageUrl="/Admin/Content/images/default.jpg" CssClass="bg-preview" runat="server" />
					<input id="file_upload" name="file_upload" type="file" />
				</p>
				<p>
					<label>排序字段：</label>
					<asp:TextBox ID="SortOrder" CssClass="text-input small-input" MaxLength="6" runat="server">9999</asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="SortOrder" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="排序字段必须填写"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="SortOrder" ValidationExpression="\d+" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="排序字段必须为整型数值"></asp:RegularExpressionValidator>
					<br />
					<small>如无特殊排序要求，保留默认值即可。</small>
				</p>
                <p>
                    <asp:HiddenField ID="CategoryId" runat="server" />
					<asp:HiddenField ID="AllToAddSubCategory" runat="server" />
					<asp:HiddenField ID="ParentId" runat="server" />
					<asp:Button ID="btnSave" runat="server" Text="保存分类" CssClass="button" onclick="btnSave_Click" />
                </p>
            </fieldset>
            </form>
        </div>
        <!-- End #tab1 -->
    </div>
    <!-- End .content-box-content -->
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		jQuery(function ($) {
			var $bgColor = $("input[id$=BgColor]");

			$('#picker').colpick({
				layout: 'rgbhex',
				onBeforeShow: function (el) {
					var hex = $bgColor.val();
					if (hex) $(this).colpickSetColor(hex);
				},
				onSubmit: function (hsb, hex, rgb, el) {
					$bgColor.val(hex);
					//$(el).css('background-color', '#' + hex);
					$(el).colpickHide();
				}
			});
			$('#file_upload').uploadify(uploadifyConfig);
			$('#file_upload').uploadify("settings", "onUploadSuccess", function (file, data, response) {
				var returns = data.split("|");
				if (returns.length == 2 && returns[0] == "success") {
					$("img[id$=imgBgPic]").attr("src", returns[1]);
					$("input[id$=BgPic]").val(returns[1]);
				}
			});
		});
	</script>
</asp:Content>