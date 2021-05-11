<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="m_index" %>
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
	</head> 
<body>
    <form id="form1" runat="server">
 <nav>AH礼券自助提货系统</nav>	 
	
		 <div id="main">
		 	<div class="main_left">
		    	<div style="width:67%;">
		    		<div>
			        	<a href="identityLoad.aspx" onclick="verify(&#39;codeInfoAction!getCodeInfos.do&#39;);" class="search_zw"><span></span><font>真伪查询</font></a>
			        	
			        		<a href="product.aspx" class="product"><span></span><font>产品中心</font></a>	
			        	
			        	            
			        </div>
			        <div style="float:right;">
			        	<a href="putLoad.aspx" onclick="checkcodes(&#39;template/sp200/com/enlogin1.jsp&#39;)" class="apply_th"><span></span><font>申请提货</font></a>
			        	<a href="selseSite.aspx" class="network"><span></span><font>销售网点</font></a>  
			        </div>
		    	</div>
		        <div style="float:right; width:32%;">
		        	<a href="orderInfoLoad.aspx" class="searchorder"><span></span><font>查询订单</font></a>
		        	<a href="helpList.aspx" class="faq"><span></span><font>常见问题</font></a>
		        </div>		        
		    </div>
		    <div class="main_left">
			    
		    	
		    		<div style="width:100%;">
		    			<div><a href="Contactus.aspx" class="main_contact"><span></span><font>联系客服</font></a></div>
		        		<div style="float:right;"><a href="service.aspx" target="_blank" class="apply"><span></span><font>售后服务</font></a></div>
		    		</div>
		    	
			</div>
		</div>
		<div class="clear"></div>
		
<uc1:end ID="end1" runat="server" />

<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
		<script language="javascript" type="text/javascript" src="image/index.js"></script>
    
    </form>
</body>
</html>
