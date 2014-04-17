<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Admin.Master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Admin.Articles.Default" %>
<asp:Content ContentPlaceHolderID="PageTitle" runat="server">
	文章列表 - 熠镜后台管理中心
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<div class="content-box-content" style="display: block;">
		<div id="tab1" class="tab-content default-tab" style="display: block;">
		<form id="form1" runat="server">
		<fieldset>
			<div>
				<asp:DropDownList ID="drpCategories" CssClass="small-input" runat="server"></asp:DropDownList>
				<asp:TextBox ID="txtSearchText" CssClass="text-input small-input" runat="server"></asp:TextBox>
				<asp:Button ID="btnSearch" CssClass="button" Text="搜索" runat="server" OnClick="btnSearch_OnClick" />
			</div>
		</fieldset>

		<asp:GridView 
			ID="GridView1" 
			runat="server" 
			AutoGenerateColumns="false" 
			ShowHeader="True"
			ShowFooter="True"
			DataKeyNames="ArticleId">
			
			<Columns>
				<asp:TemplateField>
					<HeaderTemplate>
						<input class="check-all" type="checkbox" />
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="cbArticleItem" runat="server" />
					</ItemTemplate>
					<FooterTemplate>
						<asp:LinkButton ID="btnBatchDelete" CssClass="button" runat="server" Text="批量删除" CommandName="BatchDelete"></asp:LinkButton>
						<a href="Add.aspx" class="button">添加文章</a>
						<webdiyer:aspnetpager id="AspNetPager1" runat="server"
							CssClass="pagination" 
							ImagePath="/Admin/Content/Images"
							PagingButtonSpacing="0px" 
							showcustominfosection="Never" 
							urlpaging="True" 
							UrlPageIndexName="pn"
							PagingButtonsClass="number"
							PrevNextButtonsClass=""
							FirstLastButtonsClass=""
							CurrentPageButtonTextFormatString="<a class=&quot;current&quot; href=&quot;javascript:void(0);&quot;>{0}</a>"
							PrevPageText="&laquo;上一页" 
							NextPageText="下一页 &raquo;"
							ShowFirstLast="true"
							FirstPageText="&laquo; 首页"
							LastPageText="尾页&raquo;" 
							NumericButtonCount="5" ShowDisabledButtons ="false"
							AlwaysShowFirstLastPageNumber="true"></webdiyer:aspnetpager>
					</FooterTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="标题（中文/英文）">
					<ItemStyle VerticalAlign="Top" />
					<ItemTemplate>
						<asp:TextBox ID="ArticleTitle" CssClass="text-input textarea" ReadOnly="true" TextMode="MultiLine" runat="server"></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="描述">
					<ItemStyle VerticalAlign="Top" />
					<ItemTemplate>
						<asp:TextBox ID="Description" CssClass="text-input textarea" ReadOnly="true" TextMode="MultiLine" runat="server"></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:ImageField HeaderText="缩略图" DataImageUrlField="Thumbnail" NullImageUrl="/Admin/Content/images/default_article.png">
					<ControlStyle CssClass="preview" />
				</asp:ImageField>
				<asp:TemplateField HeaderText="背景色">
					<ItemStyle VerticalAlign="Top" />
					<ItemTemplate>
						<div class="colorbox" style="background-color:#<%# Eval("BgColor") %>"></div>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:ImageField HeaderText="背景图" DataImageUrlField="BgPic" NullImageUrl="/Admin/Content/images/default_article.png">
					<ControlStyle CssClass="preview" />
				</asp:ImageField>
				<asp:TemplateField HeaderText="操作">
					<ItemTemplate>
						<a title="Edit" href="Add.aspx?aid=<%# Eval("ArticleId") %>">
							<img alt="Edit" src="/admin/content/images/icons/pencil.png" /></a>
						<asp:LinkButton ID="deleteButton" ToolTip="Delete" CommandName="Delete" CommandArgument='<%# Eval("CategoryId") %>' OnClientClick="return confirm('确定要删除吗?')" runat="server">
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
							<th>标题（中文/英文）</th>
							<th>描述</th>
							<th>背景色</th>
							<th>背景图</th>
							<th>其他</th>
							<th>操作</th>
						</tr>
					</thead>
					<tfoot>
						<tr>
							<td colspan="7">
								<div>
									<a href="Add.aspx" class="button">添加文章</a>
								</div>
								<div class="clear"></div>
							</td>
						</tr>
					</tfoot>
					<tbody>
						<tr><td colspan="7">没有文章数据</td></tr>
					</tbody>
				</table>
			</EmptyDataTemplate>
		</asp:GridView>

		<asp:DataList runat="server">
			
				
			<ItemTemplate>
			
			</ItemTemplate>
		</asp:DataList>
		</form>
		</div>
		<!-- End #tab1 -->
	</div>
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
