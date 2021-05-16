<%@ Page Language="C#" AutoEventWireup="true" CodeFile="identityLoad.aspx.cs" Inherits="identityLoad" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>AH礼券自助提货系统-真伪查询</title>
<meta http-equiv="keywords" content="">
<meta http-equiv="description" content=""> 	
<link rel="stylesheet" type="text/css" href="image/index.css">
<link rel="stylesheet" type="text/css" href="image/style.css">
<script language="javascript" type="text/javascript" src="image/qiehuan.js"></script>
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
        <div class="header">
			<a href="index.aspx" class="logo">江西理工大学提货系统</a>
		</div>
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

			<div class="rightcontact">
				<div class="right_title"><img src="image/bz_05.jpg"><span>真伪查询</span></div>
				<div class="right_contact">
					<p><img src="image/intttop.jpg"></p>
					
						<div class="right_contact1">
							<span><font>提货编码：</font><input type="text" id="orderno"  runat="server" maxlength="8" name="orderno" value=""  class="txtinput_search"></span>
							
							<span>
								
                                 <asp:Button ID="btnSubmit" runat="server" Text="" CssClass="searchbtn" onclick="btnSubmit_Click"  OnClientClick="return tijiao();"/>

							</span>
						</div>	
					
					<p><img src="image/inttbottom20.jpg"></p>
				</div>
				
				
			</div>
		</div>
		<!--main end-->
    
		<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
		<script language="javascript" type="text/javascript" src="image/index.js"></script>
		<script type="text/javascript" src="image/jquery.artDialog.min.js"></script>
		<script type="text/javascript" src="image/artDialog.plugins.min.js"></script>
				<script type="text/javascript" src="image/demo.js"></script>
		<script type="text/javascript">
		    function tijiao() {
		        var val = $("#orderno").val().replace(/\s/g, "");
		        if (val == "") {
		            $.alert("请输入提货编码！").time(5000);
		            return false;
		        }
	
		        //验证4位数随机验证码
		        var checkcode = $("#checkcode").val().replace(/\s/g, "");
		        if (checkcode == "") {
		            $.alert("<div class='message'>请输入验证码</div>").time(5000);
		            return false;
		        } 

		    }
		    /*切换验证码*/
		    function ToggleCode(obj, codeurl) {
		        $(obj).children("img").eq(0).attr("src", codeurl + "?time=" + Math.random());
		        return false;
		    }
		</script>
	
    </form>
</body>
</html>
