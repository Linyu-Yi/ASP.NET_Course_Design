<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="end.ascx" tagname="end" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 	<title>AH礼券自助提货系统</title>
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
		<%--		<div class="clear"></div>
		<div class="content">									 					 
					<div class="search">
						<input type="hidden" id="infocode" name="infocode" value="">					
						<input type="text" class="search_input" id="keys" name="keys" value="请输入关键字" onclick="this.value=&#39;&#39;">
						<input type="image" src="image/search.gif" onclick="search1(&#39;&#39;)" class="search_submit">
					</div>							
			</div>--%>
			<table cellpadding="0" cellspacing="0" class="packagetab">
				<tbody><tr class="packagetr" style="margin:0;">
					<td colspan="2">商品列表</td>
				</tr>
                  <asp:Repeater ID="repCategory" runat="server">
    <ItemTemplate> 
							<tr>
								<td style="float:left;position: relative;">
									<div class="imgborder">
									<a href="article_info.aspx?id=<%#Eval("id")%>"  target="_blank"><img src="<%#Eval("img_url")%>"></a>								
									</div>
									<dl>
										<dt><a href="article_info.aspx?id=<%#Eval("id")%>"  target="_blank"><%#Eval("title")%></a></dt>
										<dd>
																			
											      <span>面值：<em>￥<%#Eval("click")%></em></span>
									</dd>
									</dl>
								</td>								
							</tr>
		</ItemTemplate>			
	</asp:Repeater>						
			</tbody></table>			
			<div class="page">
<webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   
        CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
        FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="5" PrevPageText="上一页"  ShowCustomInfoSection="Left" 
        ShowInputBox="Never" onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Center" LayoutType="Table" 
        HorizontalAlign="Center" Wrap="False" 
        CustomInfoSectionWidth="20%" CustomInfoHTML="  &nbsp;   &nbsp;   &nbsp; 共<font color='red'><b>%RecordCount%</b></font>条，共%PageCount%页，每页%PageSize%条" >
        </webdiyer:AspNetPager>
			</div>		
			<div class="clear"></div>
		</div>
            <uc2:end ID="end1" runat="server" />
            <script type="text/javascript" src="image/jquery-1.9.1.js" language="javascript"></script>
		<script type="text/javascript" src="image/jquery.tabify.js" charset="utf-8"></script>
		<script type="text/javascript" src="image/index.js" language="javascript"></script>
		<script type="text/javascript" src="image/jquery.artDialog.min.js"></script>
		<script type="text/javascript" src="image/artDialog.plugins.min.js"></script>
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
