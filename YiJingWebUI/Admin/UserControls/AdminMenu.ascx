<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.ascx.cs" Inherits="YiJingWebUI.Admin.UserControls.AdminMenu" %>

<li>
    <!-- Add the class "no-submenu" to menu items with no sub menu -->
    <a href="<%= this.ResolveUrl("../Default.aspx")%>" class="nav-top-item no-submenu">控制面板</a>
</li>
<li>
	<a href="javascript:void(0);" class="nav-top-item">文章系统管理</a>
	<ul>
        <li><a href="<%= this.ResolveUrl("../Articles/")%>">文章列表</a></li>
        <li><a href="<%= this.ResolveUrl("../Articles/Add.aspx")%>">添加文章</a></li>
    </ul>
</li>
<li>
    <a href="javascript:void(0);" class="nav-top-item">类别管理</a>
	<ul>
        <li><a href="<%= this.ResolveUrl("../Categories/")%>">类别列表</a></li>
        <li><a href="<%= this.ResolveUrl("../Categories/Add.aspx")%>">添加类别</a></li>
    </ul>
</li>
<li>
    <a href="javascript:void(0);" class="nav-top-item">焦点图管理</a>
	<ul>
        <li><a href="<%= this.ResolveUrl("../Focuses/")%>">焦点图列表</a></li>
        <li><a href="<%= this.ResolveUrl("../Focuses/Add.aspx")%>">添加焦点图</a></li>
    </ul>
</li>
<li>
    <a href="javascript:void(0);" class="nav-top-item">账号管理</a>
	<ul>
        <li><a href="<%= this.ResolveUrl("../Managers/")%>">账号列表</a></li>
        <li><a href="<%= this.ResolveUrl("../Managers/Create.aspx")%>">新建账号</a></li>
    </ul>
</li>
<li>
    <a href="javascript:void(0);" class="nav-top-item">系统管理</a>
	<ul>
        <li><a href="<%= this.ResolveUrl("../Settings/")%>">配置列表</a></li>
        <li><a href="<%= this.ResolveUrl("../Settings/Add.aspx")%>">添加联系方式</a></li>
		<li><a href="<%= this.ResolveUrl("../Settings/EditLogo.aspx")%>">修改LOGO</a></li>
		<li><a href="<%= this.ResolveUrl("../Settings/EditWords.aspx?code=CutureWords")%>">修改文字</a></li>
    </ul>
</li>

<script type="text/javascript">
	var $ul = $("#main-nav");
	var current = document.location.href.toLowerCase();
	if (current.substr(-1, 1) == "/") current += "default.aspx";

	$ul.find("a").each(function (index, item) {
		var $this = $(item);
		var path = $this.attr("href").toLowerCase();
		if (path.substr(-1, 1) == "/") path += "default.aspx";
		
		if (current.indexOf(path) != -1) {
			if (!$this.attr("class")) {
				$this.parent().parent().prev().addClass("current");
			}
			$this.addClass("current");
		}
	});
</script>