<%@ Page Language="C#" AutoEventWireup="true" CodeFile="helpList.aspx.cs" Inherits="m_helpList" %>
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
 <nav><a href="index.aspx "class="house"><s></s></a>常见问题</nav>
	 	<div id="main">
	 			<div class="faqdiv">
						<dl>
                              <asp:Repeater ID="repCategory" runat="server">
    <ItemTemplate>
                        <p><%#Eval("title")%></p>
                        <p class="showfaq"><%#Eval("content")%></p>

    		</ItemTemplate>			
	</asp:Repeater>	         
                        </dl>
				    
	  		</div>
			<div class="pagediv">
		  		
			    
				
	    		<%--	<a style="background-image: linear-gradient(#ECEAEA,#E4E1E1);color: #9EA5AC;">首页</a>
					<a style="background-image: linear-gradient(#ECEAEA,#E4E1E1);color: #9EA5AC;">上一页</a>
	    		
	    		
				<span>1/1</span>
				
				
		    	
	    			<a style="background-image: linear-gradient(#ECEAEA,#E4E1E1);color: #9EA5AC;">下一页</a>
					<a style="background-image: linear-gradient(#ECEAEA,#E4E1E1);color: #9EA5AC;">尾页</a>--%>
	    		  
			    
			</div>	
	 	</div>
 		<div class="clear"></div>
 		<uc1:end ID="end1" runat="server" />
	<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
		<script language="javascript" type="text/javascript" src="image/index.js"></script>
    </form>
</body>
</html>
