<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Admin.Managers.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	用户管理 - 熠镜后台管理中心
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadScripts" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Top" runat="server">
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
			DataKeyNames="ManagerId">
			
			<Columns>
				<asp:BoundField DataField="Name" HeaderText="登录账号" />
				<asp:BoundField DataField="NickName" HeaderText="用户昵称" />
				<asp:BoundField DataField="Pwd" HeaderText="加密密码" />
				<asp:TemplateField HeaderText="操作">
					<ItemTemplate>
						<a title="Edit" href="Create.aspx?mid=<%# Eval("ManagerId") %>">
							<img alt="Edit" src="/admin/content/images/icons/pencil.png" /></a>
					</ItemTemplate>
					<FooterTemplate>
						<a href="Create.aspx" class="button">新建账号</a>
					</FooterTemplate>
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				<table>
					<thead>
						<tr>
							<th>登录账号</th>
							<th>用户昵称</th>
							<th>操作</th>
						</tr>
					</thead>
					<tfoot>
						<tr>
							<td colspan="7">
								<div>
									<a href="Create.aspx" class="button">新建账号</a>
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
<asp:Content ID="Content6" ContentPlaceHolderID="Bottom" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
