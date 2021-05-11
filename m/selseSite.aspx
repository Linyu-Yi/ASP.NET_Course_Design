<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selseSite.aspx.cs" Inherits="m_selseSite" %>
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
  <nav><a href="javascript:history.go(-1)" class="black"><b></b></a>销售网点<a href="index.aspx" class="house right_house"><s></s></a></nav>
	 <div class="banner">
	 	<div style="position:absolute; z-index:0; top:0; left:0;height:200px;overflow: hidden;"><img src="image/bannerbg.jpg"></div>
	 	<div style="position:absolute; z-index:11;">
	 		
		 		<h1>欢迎使用AH礼券自助提货系统</h1>
		    	<h6>Welcome to the gift card self-service delivery system</h6>
		    
		     
	    </div>
	 </div>

	 <div id="main">	 	
	    
	    
			<div class="addres networkdiv packagelist">
				                 <asp:Repeater ID="repCategory" runat="server">
    <ItemTemplate> 
					
				      	
					    	<dl class="packagedl">
					        	
								
									<dt><img src="<%#Eval("img_url")%>"></dt>
								
					            <dd>
					            	<h3><%#Eval("title")%></h3>
					         
					                
					                	<p><%#Eval("content")%></p> 
					                
					                
								    
					            </dd>
					        </dl> 	
				</ItemTemplate>			
	</asp:Repeater>		         
				      
				      
				    </div>
		
		
	 </div>
	 <div class="clear"></div>
	 <uc1:end ID="end1" runat="server" />
      <script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
	 <script language="javascript" type="text/javascript" src="image/jquery.tabify.js" charset="utf-8"></script>
	 <script language="javascript" type="text/javascript" src="image/index.js"></script>

    </form>
</body>
</html>
