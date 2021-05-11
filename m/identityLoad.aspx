<%@ Page Language="C#" AutoEventWireup="true" CodeFile="identityLoad.aspx.cs" Inherits="m_identityLoad" %>
<%@ Register src="end.ascx" tagname="end" tagprefix="uc1" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>AH礼券自助提货系统</title>		
		<meta name="apple-mobile-web-app-capable" content="yes">
		<meta name="apple-mobile-web-app-status-bar-style" content="black">
		<meta content="telephone=no" name="format-detection">
		<meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no">
		<link rel="stylesheet" type="text/css" href="image/index.css">
        <link rel="stylesheet" type="text/css" href="image/style.css">
	</head> 
<body>
    <form id="form1" runat="server">
 <nav><a href="index.aspx" class="house"><s></s></a>AH礼券自助提货系统</nav>
	 <div class="banner">
	 	<div style="position:absolute; z-index:0; top:0; left:0;height:200px;overflow: hidden;">
	 		<img src="image/bannerbg.jpg">
	 	</div>
	 	<div style="position:absolute; z-index:11;">
		 	
		 		<h1>欢迎使用AH礼券自助提货系统</h1>
		    	<h6>Welcome to the gift card self-service delivery system</h6>
		    
	 	</div>
	 </div>
	 <div id="main">
	 	
		 	<div class="yz">
		    	<input type="text" runat="server"  id="code" name="code" class="txtinput" value="" onfocus="this.type=&#39;number&#39;" onblur="this.type=&#39;text&#39;" placeholder="请输入提货编码" maxlength="8" style="height:20px; line-height:20px;padding:7px 0px 8px 0;">
		        <p>
		        	<input type="text" runat="server"  id="checkcode" name="checkcode" class="txtinput" onfocus="this.type=&#39;number&#39;" onblur="this.type=&#39;text&#39;" placeholder="输入验证码" maxlength="4" style="width:60%;height:20px; line-height:20px;padding:7px 0px 8px 0;">
		        	 <a href="javascript:;" onclick="ToggleCode(this, '../tools/m_code.ashx');return false;"><img src="../tools/m_code.ashx"  alt="看不清楚?请点击刷新" width="100" height="38"  border="0" /> </a>
		        </p>
		      <asp:Button ID="btnSubmit" runat="server" Text="立即验证" CssClass="yzbtn" onclick="btnSubmit_Click"  OnClientClick="return tijiao();"/>

		    </div>
	  
	 </div>
	 <div class="clear"></div>
	<uc1:end ID="end1" runat="server" />
    
	<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
	<script language="javascript" type="text/javascript" src="image/index.js"></script>
	<script type="text/javascript">
	    function tijiao() {
	        if (!/^\d{8}$/.test($("#code").val())) {
	            alert("请输入有效的提货编码");
	            return false;
	        }
	        if (!/^\d{4}$/.test($("#checkcode").val())) {
	            alert("请输入有效的验证码");
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
