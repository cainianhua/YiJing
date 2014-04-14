<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Admin.Categories.Default" %>
<asp:Content ContentPlaceHolderID="PageTitle" runat="server">
	分类列表 - 熠镜后台管理中心
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<div class="content-box-content" style="display: block;">
		<div id="tab1" class="tab-content default-tab" style="display: block;">
		<form id="form1" runat="server">
		<asp:GridView 
			ID="gvCategories" 
			runat="server" 
			AutoGenerateColumns="false" 
			ShowHeader="True"
			ShowFooter="True" 
			DataKeyNames="CategoryId">
			
			<Columns>
				<asp:TemplateField HeaderText="名称（中文/英文）">
					<ItemStyle VerticalAlign="Top" />
					<ItemTemplate>
						<asp:TextBox ID="Name" CssClass="text-input textarea" ReadOnly="true" TextMode="MultiLine" runat="server"></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="描述">
					<ItemStyle VerticalAlign="Top" />
					<ItemTemplate>
						<asp:TextBox ID="Description" CssClass="text-input textarea" ReadOnly="true" TextMode="MultiLine" runat="server"></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="背景色">
					<ItemStyle VerticalAlign="Top" />
					<ItemTemplate>
						<div class="colorbox" style="background-color:#<%# Eval("BgColor") %>"></div>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:ImageField HeaderText="背景图" DataImageUrlField="BgPic" NullImageUrl="/Admin/Content/images/default.jpg">
					<ControlStyle CssClass="preview" />
				</asp:ImageField>
				<asp:BoundField DataField="SortOrder" HeaderText="排序值" />
				<asp:TemplateField HeaderText="其他">
					<ItemTemplate>
						<asp:Literal ID="Others" runat="server"></asp:Literal>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="操作">
					<ItemTemplate>
						<a title="Edit" href="Add.aspx?action=Edit&id=<%# Eval("CategoryId") %>">
							<img alt="Edit" src="/admin/content/images/icons/pencil.png" /></a>
						<asp:LinkButton ID="deleteButton" ToolTip="Delete" CommandName="Delete" CommandArgument='<%# Eval("CategoryId") %>' OnClientClick="return confirm('确定要删除此分类吗?')" runat="server">
							<img alt="Delete" src="/admin/content/images/icons/cross.png" /></a>
						</asp:LinkButton>
						<a title="Add" id="addButton" runat="server">
							<img alt="Edit" src="/admin/content/images/icons/add.png" /></a>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				没有分类的数据
			</EmptyDataTemplate>
		</asp:GridView>
		</form>
		</div>
		<!-- End #tab1 -->
	</div>
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
