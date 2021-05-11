<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderInfoLoad.aspx.cs" Inherits="m_orderInfoLoad" %>
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
	 <nav><a href="index.aspx" class="house"><s></s></a>我的订单</nav>	 
	 <div id="main"> 	
	
		 	<div class="yz">
				<input type="text" runat="server"  id="orderno" name="orderno" value="" maxlength="24" class="txtinput" placeholder="请输入订单号" style="height:20px; line-height:20px;padding:7px 0px 8px 0;">
			<p>
				<input type="text" runat="server"  id="recvmobile" name="recvmobile" value="" maxlength="18" class="txtinput" onfocus="this.type=&#39;number&#39;" onblur="this.type=&#39;text&#39;" placeholder="请输入手机号" style="height:20px; line-height:20px;padding:7px 0px 8px 0;">
			</p>
			<p>
	        	<input type="text" runat="server"  id="checkcode" name="checkcode" class="txtinput" onfocus="this.type=&#39;number&#39;" onblur="this.type=&#39;text&#39;" placeholder="输入验证码" maxlength="4" style="width:40%;height:20px; line-height:20px;padding:7px 0px 8px 0;">
	         	 <a href="javascript:;" onclick="ToggleCode(this, '../tools/m_code.ashx');return false;"><img src="../tools/m_code.ashx"  alt="看不清楚?请点击刷新" width="120" height="40"  border="0" /> </a>
		    </p>
              <asp:Button ID="btnSubmit" runat="server" Text="立即查询" CssClass="yzbtn" onclick="btnSubmit_Click"  OnClientClick="return tijiao();"/>

              <asp:Panel ID="PanelOrder" runat="server" Visible="false">
<table width="100%" border="0" align="center" cellpadding="8" cellspacing="0" >
      <tr>       
      <th width="30%" align="left">提货编码</th>
        <th align="left">礼品名称</th>
      </tr>
  <asp:Repeater ID="rptList" runat="server">
<ItemTemplate> 
      <tr> 
        <td><%# Eval("ticket_no")%></td>  
        <td><%# Eval("goods_title")%></td>  
      </tr>
       </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? " <tr><td colspan=\"2\">暂无数据</td></tr>" : ""%>

</FooterTemplate>
</asp:Repeater> 
        
    	</table>
                           <p>
								<font>快递公司：</font><asp:Literal ID="product_category" runat="server"></asp:Literal>
							</p>
                                  <p>
								<font>快递单号：</font><asp:Literal ID="product_no" runat="server"></asp:Literal>
							</p>
                                  <p>
								<font>发货仓库：</font><asp:Literal ID="depot_category" runat="server"></asp:Literal>
							</p>
                            <p>
								<font>收货人姓名：</font><asp:Literal ID="contact_name" runat="server"></asp:Literal>
							</p>
                                  <p>
								<font>收货人电话：</font><asp:Literal ID="contact_tel" runat="server"></asp:Literal>
							</p>
                                  <p>
								<font>收货人地址：</font><asp:Literal ID="contact_address" runat="server"></asp:Literal>
							</p>
                                  <p>
								<font>用户留言：</font><asp:Literal ID="message" runat="server"></asp:Literal>
							</p>
                                  <p>
								<font>订单备注：</font><asp:Literal ID="remark" runat="server"></asp:Literal>
							</p>
                                </asp:Panel>
			</div>
	
	 </div>
	 <div class="clear"></div>
     	<uc1:end ID="end1" runat="server" />
         <script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
	 <script language="javascript" type="text/javascript" src="image/index.js"></script>
	 <script type="text/javascript">
	     function tijiao() {
	         var val = $("#orderno").val().replace(/\s/g, "");
	         if (val == "") {
	             alert("请输入查询的订单号！");
	             return false;
	         } 
	         var partten = /^0?(13[0-9]|15[012356789]|18[0-9]|14[57])[0-9]{8}$/;
	         val = $("#recvmobile").val();
	         if (val.replace(/\s/g, "") == "") {
	             alert("申请人手机号码不能为空");
	             return false;
	         } else if (!partten.test(val)) {
	             alert("申请人手机号码不正确");
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
