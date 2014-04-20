<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" ValidateRequest="false" AutoEventWireup="false" CodeBehind="Add.aspx.cs" Inherits="YiJingWebUI.Admin.Articles.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	添加文章 - 熠镜后台管理中心
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeadStyles" runat="server">
	<link rel="stylesheet" href="<%= this.ResolveUrl("~/Admin/Scripts/ColorPicker/css/colpick.css")%>" type="text/css" media="screen" />	
	<link rel="stylesheet" href="<%= this.ResolveUrl("~/Admin/Scripts/uploadify/uploadify.css")%>" type="text/css" media="screen" />	
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="HeadScripts" runat="server">	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="content-box-content">
        <div class="tab-content default-tab" id="tab1">
            <!-- This is the target div. id must match the href of this div's tab -->
			<asp:PlaceHolder ID="MessageContainer" runat="server"></asp:PlaceHolder>

            <form id="form1" runat="server" autocomplete="off">
            <fieldset>
				<p>
					<label>中文标题(*)：</label>
					<asp:TextBox ID="ArticleTitleLocal" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ArticleTitleLocal" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="中文标题必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>中文标题最长50个字符，实际长度根据界面展示效果自行调整。</small>
				</p>
                <p>
					<label>英文标题(*)：</label>
					<asp:TextBox ID="ArticleTitle" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ArticleTitle" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="英文标题必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>英文名称最长50个字符，实际长度根据界面展示效果自行调整。</small>
				</p>
				<p>
					<label>副标题：</label>
					<asp:TextBox ID="ArticleSubtitle" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<br />
					<small>只限于熠镜案例使用，其他分类填写无效。50个字符长度。</small>
				</p>
				<p>
					<label>文章备注：</label>
					<asp:TextBox ID="Remarks" CssClass="text-input textarea" TextMode="MultiLine" MaxLength="255" runat="server"></asp:TextBox>
					<br />
					<small>只限于熠镜案例使用，其他分类填写无效，255个字符长度，可以输入HTML代码</small>
				</p>
				<p>
					<label>标题栏文字颜色(*)：</label>
					<asp:TextBox ID="TitleColor" CssClass="text-input small-input" MaxLength="6" runat="server"></asp:TextBox>
					<button class="button picker">选择</button>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator99" ControlToValidate="TitleColor" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="标题栏文字颜色不能为空"></asp:RequiredFieldValidator>
					<br />
					<small>标题栏文字颜色默认为白色。</small>
				</p>
				<p>
					<label>关键字：</label>
					<asp:TextBox ID="Keywords" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<br />
					<small>主要用于SEO，关键字最长50个字符。</small>
				</p>
				<p>
					<label>文章简介：</label>
					<asp:TextBox ID="Description" CssClass="text-input textarea" TextMode="MultiLine" MaxLength="255" runat="server"></asp:TextBox>
					<br />
					<small>文章简介最长255个字符。</small>
				</p>
				<p>
					<label>缩略图(*)：</label>
					<asp:TextBox ID="Thumbnail" MaxLength="255" runat="server" style="display:none;"></asp:TextBox>
					<asp:Image ID="imgThumbnail" ImageUrl="/Admin/Content/images/default_article.png" CssClass="thumbnail-preview" runat="server" />
					<input id="file_upload_thumbnail" name="file_upload" type="file" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="Thumbnail" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="请上传缩略图"></asp:RequiredFieldValidator>
				</p>
				<p>
					<label>文章标签：</label>
					<asp:TextBox ID="Tags" CssClass="text-input medium-input" MaxLength="50" runat="server"></asp:TextBox>
					<br />
					<small>多个文章标签用英文空格分隔。</small>
				</p>
				<p>
					<label>文章内容(*)：</label>
					<asp:TextBox ID="HtmlContent" CssClass="text-input textarea" style="height:300px;" TextMode="MultiLine" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="HtmlContent" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="文章内容必须填写"></asp:RequiredFieldValidator>
				</p>
				<p>
					<label>背景颜色(*)：</label>
					<asp:TextBox ID="BgColor" CssClass="text-input small-input" MaxLength="6" runat="server"></asp:TextBox>
					<button class="button picker">选择</button>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="BgColor" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="背景颜色必须填写"></asp:RequiredFieldValidator>
					<br />
					<small>背景颜色默认为白色。</small>
				</p>
				<p>
					<label>背景图片：</label>
					<asp:HiddenField ID="BgPic" runat="server" />
					<asp:Image ID="imgBgPic" ImageUrl="/Admin/Content/images/default.jpg" CssClass="bg-preview" runat="server" />
					<br />
					<input type="button" id="btnRemove" class="button" value="清除图片" />
					<input id="file_upload_bg_pic" class="upload-control" name="file_upload" type="file" />
				</p>
				<p>
					<label>排序字段(*)：</label>
					<asp:TextBox ID="SortOrder" CssClass="text-input small-input" MaxLength="6" runat="server">9999</asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="SortOrder" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="排序字段必须填写"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="SortOrder" ValidationExpression="\d+" Display="Dynamic" runat="server" CssClass="input-notification error png_bg" ErrorMessage="排序字段必须为整型数值"></asp:RegularExpressionValidator>
					<br />
					<small>如无特殊排序要求，保留默认值即可。</small>
				</p>
				<p>
                    <label>所属分类(*)：</label>
                    <asp:DropDownList ID="drpCategoryId" CssClass="medium-input" runat="server"></asp:DropDownList>
					<asp:CustomValidator ID="CustomValidator1" runat="server" 
						ClientValidationFunction="clientValidationHandler" ControlToValidate="drpCategoryId" Display="Dynamic" 
						CssClass="input-notification error png_bg" ErrorMessage="请选择文章所属分类" 
						onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </p>
                <p>
					<asp:HiddenField ID="ArticleId" runat="server" />
					<asp:Button ID="btnSave" runat="server" Text="保存文章" CssClass="button" onclick="btnSave_Click" />
                </p>
            </fieldset>
            </form>
        </div>
        <!-- End #tab1 -->
    </div>
    <!-- End .content-box-content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript" src="<%= this.ResolveUrl("~/Admin/Scripts/ColorPicker/js/colpick.js") %>"></script>
	<script type="text/javascript" src="<%= this.ResolveUrl("~/Admin/Scripts/uploadify/jquery.uploadify.min.js") %>"></script>
	<script type="text/javascript" src="<%= this.ResolveUrl("~/ueditor/1.3.6/ueditor.config.js") %>"></script>
	<script type="text/javascript" src="<%= this.ResolveUrl("~/ueditor/1.3.6/ueditor.all.min.js") %>"></script>
	<script type="text/javascript" src="<%= this.ResolveUrl("~/ueditor/1.3.6/lang/zh-cn/zh-cn.js") %>"></script>
	<script type="text/javascript">
		jQuery(function ($) {
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
			// 图片上传
			$('#file_upload_bg_pic, #file_upload_thumbnail').uploadify(uploadifyConfig);
			$('#file_upload_bg_pic').uploadify("settings", "onUploadSuccess", function (file, data, response) {
				var returns = data.split("|");
				if (returns.length == 2 && returns[0] == "success") {
					$("img[id$=imgBgPic]").attr("src", returns[1]);
					$("input[id$=BgPic]").val(returns[1]);
				}
			});
			$('#file_upload_thumbnail').uploadify("settings", "onUploadSuccess", function (file, data, response) {
				var returns = data.split("|");
				if (returns.length == 2 && returns[0] == "success") {
					$("img[id$=imgThumbnail]").attr("src", returns[1]);
					$("input[id$=Thumbnail]").val(returns[1]);
					$("span[id$=RequiredFieldValidator6]").hide();
				}
			});
			$("#btnRemove").on("click", function (e) {
				var self = $(this);
				self.prev().prev().attr("src", "/Admin/Content/images/default.jpg");
				self.prev().prev().prev().val("");
			});
			// 富文本编辑器
			var editor = UE.getEditor('<%= HtmlContent.ClientID %>', { initialFrameWidth: 1200 });
		});

		function clientValidationHandler(source, args) {
			args.IsValid = false;
			if (args.Value > 0) {
				args.IsValid = true;
			}
		}
	</script>
</asp:Content>
