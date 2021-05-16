<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>AH礼券自助提货系统</title>
<meta http-equiv="keywords" content="">
<meta http-equiv="description" content=""> 	
<link rel="stylesheet" type="text/css" href="image/index.css">
<link rel="stylesheet" type="text/css" href="image/style.css">
<link rel="stylesheet" type="text/css" href="image/hotel_geo.css">
<script language="javascript" type="text/javascript" src="image/qiehuan.js"></script>
<!--[if gte IE 7]><!-->
<link rel="stylesheet" href="image/sp100.css">
<!--<![endif]-->
<!--[if lt IE 7]>
<link rel="stylesheet" href="image/default.css" />
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
<div id="main">
			<!--头部 开始-->
			
			<div class="header">
				<a href="index.aspx" class="logo">江西理工大学提货系统</a>
			</div>
			
			<!--头部end-->
			<div class="clear"></div>
			<!--left 快速导航 开始-->
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
					<li class="libg li4" onclick="window.location.href='product.aspx'" style="border: none; cursor: pointer;">
						<strong class="nav4"></strong>
						<div>
							<a href="product.aspx" style="color: rgb(255, 255, 255);">产品中心</a>
							<span style="color: rgb(121, 135, 149);">Product center</span>
						</div>
						<em class="embg"></em>
					</li>
				</ul>
				<p><img src="image/leftbottom.jpg"></p>
			</div>
			<!--left 快速导航 end-->
			<!--banner 开始-->
			<div class="banner">
				<!-- 图片展示 开始 -->
				  <div class="zhanshi">
						 <div id="shutter" class="shutter" style="float:left">
							<ul style="display: none;">
  <asp:Repeater ID="rptList_notice" runat="server">
    <ItemTemplate> 
    <li><a href="article_info.aspx?id=<%#Eval("id")%>"  target="_blank"><img src="<%#Eval("img_url")%>"></a></li>
    </ItemTemplate>
<FooterTemplate>
  <%#rptList_notice.Items.Count == 0 ? "<li><font color=red>暂无记录</font></li>" : ""%>
</FooterTemplate>
</asp:Repeater>
							
							</ul>
						
                        <div style="position: absolute; right: 0px; bottom: 0px; padding: 8px 0px;">
                        </div>
                        </div>
				
						<script type="text/javascript">
						<!--
						    var shutterH = new Hongru.shutter.init('shutterH', {
						        id: 'shutter'
						    });
				
						//-->
						</script>
				
				    
				  </div>
				  <!-- 图片展示 结束 -->
				
			</div>
			<!--banner end-->
			<div class="clear"></div>
					
		</div>
<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
<script language="javascript" type="text/javascript" src="image/index.js"></script>
<script type="text/javascript" src="image/jquery.artDialog.min.js"></script>
<script type="text/javascript" src="image/artDialog.plugins.min.js"></script>
<script type="text/javascript" src="image/api"></script>
<script type="text/javascript" src="image/getscript"></script>


    </form>
</body>
</html>


