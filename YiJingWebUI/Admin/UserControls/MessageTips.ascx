<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageTips.ascx.cs" Inherits="YiJingWebUI.Admin.UserControls.MessageTips" %>


<div class="notification png_bg <%= Status.ToString() %>">
    <a href="javascript:void(0);return false;" class="close">
        <img src="<%= this.ResolveUrl("~/Admin/Content/images/icons/cross_grey_small.png") %>" title="Close this notification" alt="close" /></a>
    <div><%= Text.Trim() %></div>
</div>