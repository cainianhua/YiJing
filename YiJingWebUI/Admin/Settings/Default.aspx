<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" ValidateRequest="false" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Admin.Settings.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	配置列表 - 熠镜后台管理中心
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadScripts" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<div class="content-box-content" style="display: block;">
		<div id="tab1" class="tab-content default-tab" style="display: block;">
		<form id="form1" runat="server">
		<asp:GridView 
			ID="GridView1" 
			runat="server" 
			AutoGenerateColumns="false" 
			ShowHeader="True"
			ShowFooter="True" 
			DataKeyNames="ConstantId">
			
			<Columns>
				<asp:TemplateField HeaderText="说明">
					<ItemTemplate>
						<asp:TextBox ID="Description" CssClass="text-input large-input" ReadOnly="true" runat="server"></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="内容">
					<ItemTemplate>
						<asp:TextBox ID="TextValue" CssClass="text-input large-input" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
						<asp:Image ID="imgTextValue" CssClass="preview" Visible="false" runat="server" />
						<div id="colorTextValue" class="colorbox" visible="false" runat="server"></div>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="SortOrder" HeaderText="排序值" />
				<asp:TemplateField HeaderText="其他">
					<ItemTemplate>
						<asp:Literal ID="Others" runat="server"></asp:Literal>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="操作">
					<ItemTemplate>
						<a title="Edit" id="editButton" runat="server">
							<img alt="Edit" src="/admin/content/images/icons/pencil.png" /></a>
						<asp:LinkButton ID="deleteButton" ToolTip="Delete" CommandName="Delete" Visible="false" OnClientClick="return confirm('确定要删除吗?')" runat="server">
							<img alt="Delete" src="/admin/content/images/icons/cross.png" /></a>
						</asp:LinkButton>
						<a title="Add" id="addButton" href="Add.aspx" visible="false" runat="server">
							<img alt="Edit" src="/admin/content/images/icons/add.png" /></a>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				<table>
					<thead>
						<tr>
							<th>说明</th>
							<th>内容</th>
							<th>排序值</th>
							<th>其他</th>
							<th>操作</th>
						</tr>
					</thead>
					<tbody>
						<tr><td colspan="7">没有数据，请先添加</td></tr>
					</tbody>
				</table>
			</EmptyDataTemplate>
		</asp:GridView>
		</form>
		</div>
		<!-- End #tab1 -->
	</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Bottom" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
