<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareWidget.ascx.cs" Inherits="YiJingWebUI.UserControls.ShareWidget" %>

<div class="yijing-bshare-custom clearfix">
<a title="分享到腾讯微信" class="yijing-bshare-weixin" onclick="javascript:bShare.share(event,'weixin');return false;"></a>
<a title="分享到新浪微博" class="yijing-bshare-sinaminiblog" onclick="javascript:bShare.share(event,'sinaminiblog');return false;"></a>
<a title="分享到腾讯微博" class="yijing-bshare-qqmb" onclick="javascript:bShare.share(event,'qqmb');return false;"></a>
<a title="分享到人人网" class="yijing-bshare-renren" onclick="javascript:bShare.share(event,'renren');return false;"></a>
<a title="分享到QQ空间" class="yijing-bshare-qzone" onclick="javascript:bShare.share(event,'qzone');return false;"></a>
<a title="更多平台" class="yijing-bshare-more" onclick="javascript:bShare.more(event);return false;"></a>
</div>
<script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/button.js#style=-1&amp;uuid=ec68bba8-f039-4b51-a855-4ba3dee7f547&amp;pophcol=2&amp;lang=zh"></script><a class="bshareDiv" onclick="javascript:return false;"></a><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/bshareC0.js"></script>
