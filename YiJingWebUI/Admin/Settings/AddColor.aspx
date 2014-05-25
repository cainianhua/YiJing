<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddColor.aspx.cs" Inherits="YiJingWebUI.Admin.Settings.AddColor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadStyles" runat="server">
	<link rel="stylesheet" href="<%= this.ResolveUrl("~/Admin/Scripts/ColorPicker/css/colpick.css")%>" type="text/css" media="screen" />	
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
					<label>颜色(<strong>*</strong>)：</label>
					<asp:TextBox ID="TextValue" CssClass="text-input medium-input" MaxLength="6" runat="server"></asp:TextBox>
					<button class="button picker">选择</button>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextValue" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="中文标题必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>中文标题最长50个字符，实际长度根据界面展示效果自行调整。</small>
				</p>
				<p>
					<label>说明：</label>
					<asp:TextBox ID="Description" CssClass="text-input medium-input" MaxLength="255" runat="server"></asp:TextBox>
					<br />
					<small>说明最长255个字符，只是用于标识此值的含义，便于管理。</small>
				</p>
                <p>
					<asp:TextBox ID="SortOrder" CssClass="text-input medium-input" MaxLength="6" runat="server" style="display:none;">9999</asp:TextBox>
					<asp:HiddenField ID="Code" runat="server" />
					<asp:HiddenField ID="Seq" runat="server" />
					<asp:HiddenField ID="ConstantId" runat="server" />
					<asp:Button ID="btnSave" runat="server" Text="保存联系方式" CssClass="button" onclick="btnSave_Click" />
                </p>
            </fieldset>
            </form>
        </div>
        <!-- End #tab1 -->
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Bottom" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript" src="<%= this.ResolveUrl("~/Admin/Scripts/ColorPicker/js/colpick.js") %>"></script>
	<script type="text/javascript">
		// 颜色选择
		$('.picker').colpick({
			layout: 'rgbhex',
			onBeforeShow: function (el) {
				var hex = $(this).prev().val();
				if (hex) $(this).colpickSetColor(hex);
			},
			onSubmit: function (hsb, hex, rgb, el) {
				$(el).prev().val(hex);
				//$(el).css('background-color', '#' + hex);
				$(el).colpickHide();
			}
		});
	</script>
</asp:Content>
