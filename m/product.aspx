<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="m_product" %>
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
	<nav><a href="javascript:history.go(-1)" class="black"><b></b></a>商品展示<a href="index.aspx" class="house right_house"><s></s></a></nav>
				
		<div id="main"> 
		     
			     
			     	<div class="addres networkdiv packagelist">
				                 <asp:Repeater ID="repCategory" runat="server">
    <ItemTemplate> 
					
				      	
					    	<dl class="packagedl">
					        	
								
									<dt><img src="<%#Eval("img_url")%>"></dt>
								
					            <dd>
					            	<h3><%#Eval("title")%></h3>
					         
					                
					                	<p>面值：<em class="oragecolor">￥<%#Eval("click")%></em></p> 
					                
					                
								    
					            </dd>
					        </dl> 	
				</ItemTemplate>			
	</asp:Repeater>		         
				      
				      
				    </div>
			     
			     
		     
		    
			<div class="pagediv">
				
		    		
		    	<%--	
		    			<a style="background-image: linear-gradient(#ECEAEA,#E4E1E1);color: #9EA5AC;">首页</a>
						<a style="background-image: linear-gradient(#ECEAEA,#E4E1E1);color: #9EA5AC;">上一页</a>
		    		
	    		
	    		1<span>/</span>11
				
		    		
		    			<a href="">下一页</a>
						<a href="">尾页</a>
		    			--%>
		    		
		    		
	    		
			</div>
			
		</div>
		<div class="clear"></div>
		   	<uc1:end ID="end1" runat="server" />
            <div class="mask filterdiv" id="showfm"></div>
		<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
		<script language="javascript" type="text/javascript" src="image/index.js"></script>
		<script type="text/javascript">
		    function search(infocode) {
		        $("#keys").val("");
		        if (infocode > 0) {
		            $("#infocode").val(infocode);
		        } else if (infocode == 0) {
		            $("#infocode").val(infocode);
		        } else {
		            $("#infocode").val("");
		        }
		        document.myform.action = "/packagesInfoAction!getPackagesInfo.do";
		        document.myform.submit();
		        return false;
		    }
		    function search1(infocode) {
		        $("#infocode").val("");
		        document.myform.action = "/packagesInfoAction!getPackagesInfo.do";
		        document.myform.submit();
		        return false;
		    }
		</script>
    </form>
</body>
</html>
