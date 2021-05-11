﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="topadmin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>头部</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    $(function () {
        //顶部导航切换
        $(".nav li a").click(function () {
            $(".nav li a.selected").removeClass("selected")
            $(this).addClass("selected");
        })
    })

    function About() {
        $.dialog({
            width:400,
            height: 10,
            title: '关于',
            max: false,
            min: false,
            content: '版权所有：宁波市AH水产有限公司' 
        });
    }
</script>

</head>
<body style="background:url(images/topbg.gif) repeat-x;">
    <form id="form1" runat="server">
    <div class="topleft">
    <a href="main.aspx" target="_parent"><img src="images/logo.png" title="系统首页" /></a>
    </div>
        
    <ul class="nav">
    <li><a href="home.aspx" target="rightFrame" class="selected"><img src="images/ico01.png" title="后台首页"  width="45" height="45"/><h2>后台首页</h2></a></li>
    <li><a href="ordermanager/order_list.aspx" target="rightFrame"><img src="images/i04.png" title="提货订单" width="45" height="45"/><h2>提货订单</h2></a></li>
    <li><a href="ordermanager/consignment_list.aspx"  target="rightFrame"><img src="images/13.png" title="发货管理" width="45" height="45"/><h2>发货管理</h2></a></li>
	<li><a href="ticketmanager/ticket_list.aspx"  target="rightFrame"><img src="images/icon01.png" title="礼券管理" width="45" height="45"/><h2>礼券管理</h2></a></li>
		<li><a href="productmanager/product_list.aspx"  target="rightFrame"><img src="images/i08.png" title="礼品管理" width="45" height="45"/><h2>礼品管理</h2></a></li>
        <li><a href="sysmanager/service_list.aspx"  target="rightFrame"><img src="images/i06.png" title="售后服务" width="45" height="45"/><h2>售后服务</h2></a></li>
    <li><a href="sysmanager/my_info.aspx"  target="rightFrame"><img src="images/i07.png" title="我的信息" width="45" height="45"/><h2>我的信息</h2></a></li>
    </ul>
            
    <div class="topright">    
    <ul>
    <li><span><img src="images/loginsj.png" title="系统首页"  class="helpimg"/></span><a href="index.aspx"  target="_blank">系统首页</a></li>
    <li><a href="javascript:About();">关于</a></li>

    <li><asp:LinkButton ID="lbtnExit" runat="server" onclick="lbtnExit_Click">退出</asp:LinkButton></li>
    </ul>
     
    <div class="user">
    <span><asp:Literal ID="Lit_Name" runat="server"></asp:Literal></span>
    </div>    
    
    </div>
    </form>
</body>
</html>
