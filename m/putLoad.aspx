<%@ Page Language="C#" AutoEventWireup="true" CodeFile="putLoad.aspx.cs" Inherits="m_putLoad" %>
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
         <script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
         <script type="text/javascript" src="../js/jquery/PCAS.js"></script>
	</head> 
<body>
    <form id="form1" runat="server">
     <nav><a href="index.aspx" class="house"><s></s></a>AH礼券自助提货系统</nav>
	 <div class="banner">
	 	<div style="position:absolute; z-index:0; top:0; left:0;height:200px;overflow: hidden;"><img src="image/bannerbg.jpg"></div>
	 	<div style="position:absolute; z-index:11;">
	 		
		 		<h1>欢迎使用AH礼券自助提货系统</h1>
		    	<h6>Welcome to the gift card self-service delivery system</h6>
		    
	    </div>
	 </div>
	 <div id="main">
		 	<div class="yz">
		    	<input type="text" runat="server"  id="ticketno" name="ticketno" class="txtinput" value="" onfocus="this.type=&#39;number&#39;" onblur="this.type=&#39;text&#39;" placeholder="请输入提货编码" maxlength="8" style="height:20px; line-height:20px;padding:7px 0px 8px 0;">
		    	<p><input type="password"  runat="server" id="ticketpw" name="ticketpw" class="txtinput" value="" onfocus="this.type=&#39;number&#39;" onblur="this.type=&#39;text&#39;" placeholder="请输入提货密码" maxlength="6" style="height:20px; line-height:20px;padding:7px 0px 8px 0;"></p>
		        <p>
		        	<input type="text" runat="server"  id="checkcode" name="checkcode" class="txtinput" onfocus="this.type=&#39;number&#39;" onblur="this.type=&#39;text&#39;" placeholder="请输入验证码" maxlength="4" style="width:40%;height:20px; line-height:20px;padding:7px 0px 8px 0;">
                   <a href="javascript:;" onclick="ToggleCode(this, '../tools/m_code.ashx');return false;"><img src="../tools/m_code.ashx"  alt="看不清楚?请点击刷新" width="100" height="38"  border="0" /> </a>
		        </p>

		         <asp:Button ID="btnSearch" runat="server" Text="立即验证" CssClass="yzbtn" onclick="btnSearch_Click"  OnClientClick="return tijiao();"/>
  <asp:Panel ID="PanelOrder"  runat="server" Visible="false">
<div class="orderwr" style="display:block;">
 <p> <font><em class="oragecolor">*可以一次提多张礼券一并发货</em></font>   
         
</p>
<table width="100%" border="0" align="center" cellpadding="8" cellspacing="0" >
      <tr>       
      <th width="30%" align="left">提货编码</th>
        <th align="left">礼品名称</th>
        <th width="15%" align="left">操作</th>
      </tr>
  <asp:Repeater ID="rptList" runat="server">
<ItemTemplate> 
      <tr> 
        <td><%# Eval("ticket_no")%></td>  
        <td><%# GetTitle(Convert.ToInt32(Eval("id")))%></td>  
        <td align="center"><asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('是否真的要删除？')" onclick="lbtnDelCa_Click"><font color =red>[删除]</font></asp:LinkButton></td>
      </tr>
       </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? " <tr><td colspan=\"3\">暂无数据</td></tr>" : ""%>

</FooterTemplate>
</asp:Repeater> 
        
    	</table>
<script type="text/javascript">
    $(function () {
        //初始化地区
        var mypcas = new PCAS("province,所属省份", "city,所属城市", "area,所属地区");
    });
</script>
  <p>  
    <font><em class="oragecolor">*</em>地区：</font>  
        <select id="province" name="province" ></select>
        <select id="city" name="city"> </select>
        <select id="area" name="area" ></select>
      	</p>
 <p> <font><em class="oragecolor">*</em>收货人地址：</font>   
             <input type="text" id="address" name="address"   runat="server"   value=""   style="width:90%; height:20px; line-height:20px;padding:7px 0px 8px 0;">
</p>
 <p>
 <font><em class="oragecolor">*</em>收货人姓名：</font>   
								<input type="text" id="user_name" name="user_name"   runat="server" maxlength="50" value=""  style="height:20px; line-height:20px;padding:7px 0px 8px 0;">
	</p>
  <p>
  <font><em class="oragecolor">*</em>收货人手机：</font>   
                            <input type="text" ID="user_tel" runat="server" name="user_tel"   value=""  maxlength="12" style="height:20px; line-height:20px;padding:7px 0px 8px 0;">
</p>

 <p>  <font>用户留言：</font>   
        <textarea id="message" runat="server"  name="message" ></textarea>
                         </p>                               
  <p><asp:Button ID="btnSubmit" runat="server" Text="提交" 
                                    CssClass="yzbtn"   OnClientClick="return questionord();" 
                                    onclick="btnSubmit_Click"/>
							</p>
                            </div>
   </asp:Panel>
</div>
	   
	 </div>
	 <div class="clear"></div>
   	<uc1:end ID="end1" runat="server" />
	 <script language="javascript" type="text/javascript" src="image/index.js"></script>
	 <script type="text/javascript">
	        function tijiao() {
	            if (!/^\d{8}$/.test($("#ticketno").val())) {
	                alert("请输入有效的提货编码");
	                return false;
	            }
	            if (!/^\d{6}$/.test($("#ticketpw").val())) {
	                alert("请输入有效的提货密码");
	                return false;
	            }
	            if (!/^\d{4}$/.test($("#checkcode").val())) {
	                alert("请输入有效的验证码");
	                return false;
	            }
	       
	        }
	        //提交提货
	        function questionord() {
	            if ($("#user_name").val().replace(/\s/g, "") == "") {
	                alert("收货人姓名不能为空");
	                return false;
	            }
	            var partten = /^0?(13[0-9]|15[012356789]|18[0-9]|14[57])[0-9]{8}$/;
	            val = $("#user_tel").val();
	            if (val.replace(/\s/g, "") == "") {
	                alert("收货人手机不能为空");
	                return false;
	            } else if (!partten.test(val)) {
	                alert("收货人手机格式不正确，请确认填写");
	                return false;
	            }
	            if ($("#area").val() == "") {
	                alert("请选择所在地区");
	                return false;
	            }
	            val = $("#address").val().replace(/\s/g, "");
	            if (val == "") {
	                alert("收货人地址不能为空");
	                return false;
	            } else if (val.length > 100) {
	                alert("收货人地址长度限制100字以内");
	                return false;
	            }
	            val = $("#message").val().replace(/\s/g, "");
	            if (val.length > 100) {
	                alert("用户留言长度限制100字以内");
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
