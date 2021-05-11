<%@ Page Language="C#" AutoEventWireup="true" CodeFile="article_info.aspx.cs" Inherits="article_info" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="end.ascx" tagname="end" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  	<title>AH礼券自助提货系统-联系我们</title>
		<meta http-equiv="keywords" content="">
		<meta http-equiv="description" content="">
		<link rel="stylesheet" type="text/css" href="image/index.css">
		<link rel="stylesheet" type="text/css" href="image/style.css">
		<link rel="stylesheet" type="text/css" href="image/hotel_geo.css">
		
		<!--[if gte IE 7]><!-->
		    <link rel="stylesheet" href="image/sp100.css">
		<!--<![endif]-->
		<!--[if lt IE 7]>
		    <link rel="stylesheet" href="images/default.css" />
		<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <uc1:top ID="top1" runat="server" />
    <div class="clear"></div>

			
<div class="left">
				<p><img src="image/lefttop.jpg"></p>
				<h1 style=" padding:0 0 0 25px; color:#34495e;font-weight: 100;">快速导航</h1>
				<ul>
					<li class="libg li1" onclick="window.location.href='identityLoad.aspx'">
						<strong class="nav1"></strong>
						<div>
							<a href="identityLoad.aspx">真伪查询</a>
							<span>check the authenticity</span>
						</div>
					</li>
					<li class="libg li2" onclick="window.location.href='putLoad.aspx'">
						<strong class="nav2"></strong>
						<div>
							<a href="putLoad.aspx">申请提货</a>
							<span>Apply for delivery</span>
						</div>
						<em class="embg"></em>
					</li>
					<li class="libg li3" onclick="window.location.href='orderInfoLoad.aspx'">
						<strong class="nav3"></strong>
						<div>
							<a href="orderInfoLoad.aspx">查询订单</a>
							<span>Query order</span>
						</div>
						<em class="embg"></em>
					</li>
					<li class="libg li4" onclick="window.location.href='helpList.aspx'" style="border: none; cursor: pointer;">
						<strong class="nav4"></strong>
						<div>
							<a href="helpList.aspx" style="color: rgb(255, 255, 255);">帮助中心</a>
							<span style="color: rgb(121, 135, 149);">Help center</span>
						</div>
						<em class="embg"></em>
					</li>
				</ul>
				<p><img src="image/leftbottom.jpg"></p>
			</div>

			<div class="rightcontact">
				<div class="right_title"><img src="image/bz_03.jpg" style="padding-top:20px;"><span>内容详情</span></div>
				<div class="right_contact">
					<p><img src="image/intttop.jpg"></p>
					<div class="contactdiv">
						<h3 style="font-size:18px;"> <asp:Literal ID="LitTitle" runat="server"></asp:Literal></h3>
                    <asp:Literal ID="LitContactus" runat="server"></asp:Literal>
					</div>
					<p><img src="image/inttbottom20.jpg"></p>
				</div>
			
			</div>
		</div>
		<!--main end-->
    <uc2:end ID="end1" runat="server" />
    
		<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
		<script language="javascript" type="text/javascript" src="image/index.js"></script>

    </form>
</body>
</html>

