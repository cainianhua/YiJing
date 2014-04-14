<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Admin.Focuses.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	焦点图列表 - 熠镜后台管理中心
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
			DataKeyNames="FocusArticleId">
			
			<Columns>
				<asp:TemplateField HeaderText="描述">
					<ItemTemplate>
						<asp:TextBox ID="Description" CssClass="text-input textarea" ReadOnly="true" TextMode="MultiLine" runat="server"></asp:TextBox>
					</ItemTemplate>
					<FooterTemplate>
						<a href="Add.aspx" class="button">添加焦点图</a>
					</FooterTemplate>
				</asp:TemplateField>
				<asp:ImageField HeaderText="缩略图" DataImageUrlField="Pic" NullImageUrl="/Admin/Content/images/default.jpg">
					<ControlStyle CssClass="preview" />
				</asp:ImageField>
				<asp:TemplateField HeaderText="链接">
					<ItemTemplate>
						<a href="<%# Eval("LinkTo") %>" target="_blank">点击查看</a>
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
						<a title="Edit" href="Add.aspx?faid=<%# Eval("FocusArticleId") %>">
							<img alt="Edit" src="/admin/content/images/icons/pencil.png" /></a>
						<asp:LinkButton ID="deleteButton" ToolTip="Delete" CommandName="Delete" OnClientClick="return confirm('确定要删除吗?')" runat="server">
							<img alt="Delete" src="/admin/content/images/icons/cross.png" /></a>
						</asp:LinkButton>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				<table>
					<thead>
						<tr>
							<th><input class="check-all" type="checkbox" /></th>
							<th>描述</th>
							<th>缩略图</th>
							<th>链接</th>
							<th>排序值</th>
							<th>其他</th>
							<th>操作</th>
						</tr>
					</thead>
					<tfoot>
						<tr>
							<td colspan="7">
								<div>
									<a href="Add.aspx" class="button">添加焦点图</a>
								</div>
								<div class="clear"></div>
							</td>
						</tr>
					</tfoot>
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
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
