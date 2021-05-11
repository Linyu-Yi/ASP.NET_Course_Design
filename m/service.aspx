<%@ Page Language="C#" AutoEventWireup="true" CodeFile="service.aspx.cs" Inherits="m_service" %>
<%@ Register src="end.ascx" tagname="end" tagprefix="uc1" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>AH礼券自助提货系统-退换货申请</title>		
		<meta name="apple-mobile-web-app-capable" content="yes">
		<meta name="apple-mobile-web-app-status-bar-style" content="black">
		<meta content="telephone=no" name="format-detection">
		<meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no">
      	<link rel="stylesheet" type="text/css" href="image/style1.css">
        	<link rel="stylesheet" type="text/css" href="image/index.css">
	</head>
<body>
    <form id="form1" runat="server">
	 <nav>退换货申请</nav>
	 <div id="main">
	 <div class="edittitle" id="apply" style="cursor: pointer;"><img src="image/edit.png"><span>退换货申请</span></div>
	    <div class="applyorder" style="display:block;">	      
	        <div class="orderwrite">	        
	      
	        <div class="ordershowsss">如遇到损坏可申请货物退换</div>
	        <div class="ordershow">注：<em class="oragecolor">*</em>为必填项</div>
		     	<div class="orderwr pborder" style="display:block;">
		        	<font><em class="oragecolor">*</em>货物订单号：</font>
		        	<p><input type="text" runat="server"  id="orderno" name="orderno" value="" maxlength="24" class="txtinput_order"></p>
		            <font><em class="oragecolor">*</em>物流单号：</font>
		            <p><input type="text" runat="server"  id="expno" name="expno" value="" maxlength="24" class="txtinput_order"></p>
		            <font><em class="oragecolor">*</em>退换原因：</font>
		            <p><textarea id="memo" runat="server"  name="memo" placeholder="请填写原因！"></textarea></p>           		        
		            <font><em class="oragecolor">*</em>退换凭证图：</font>
		            <p>                                                   
		             	<asp:FileUpload ID="FileUpload1" runat="server" Font-Size="9pt" Width="167px" />
		            </p>
		            <font><em class="oragecolor">*</em>退换凭证图：</font>
		            <p>
		            	<asp:FileUpload ID="FileUpload2" runat="server" Font-Size="9pt" Width="167px" />
		            </p>
		        	<font><em class="oragecolor">*</em>申请人姓名：</font>
		        	<p><input type="text" runat="server"  id="linkman" name="linkman" value="" maxlength="10" class="txtinput_order"></p>
		            <font><em class="oragecolor">*</em>申请人电话：</font>
		            <p><input type="text" runat="server"   id="linkphone" name="linkphone" value="" maxlength="24" class="txtinput_order"></p>
		            <font><em class="oragecolor">*</em>验证码：</font>
		            <p><input type="text"  runat="server" id="checkcode" name="checkcode" class="txtinput_order" maxlength="4" style="width:50%;">
                     <a href="javascript:;" onclick="ToggleCode(this, '../tools/m_code.ashx');return false;"><img src="../tools/m_code.ashx"   width="100" height="38"  border="0" /> </a>
                    </p>   
		  <asp:Button ID="btnSQ" runat="server" Text="立即申请" CssClass="yzbtn" onclick="btnSQ_Click"  OnClientClick="return questionord();"/>
		   			
		        </div>
		 
		   </div>
	    </div>
	    <div class="edittitle" id="cproposals" style="cursor: pointer;"><img src="image/bz_03.png" style="padding:10px;"><span>投诉建议</span></div>
	    <div class="c_proposals">
	    	<div class="orderwrite">
	    	
	    	  <div class="ordershowsss">感谢大家为我们提供更多更好的建议</div>			
				<div class="ordershow">注：<em class="oragecolor">*</em>为必填项</div>
				<div class="orderwr" style="display:block;">
					<p><font><em class="oragecolor">*</em>请填写标题：</font><input type="text" runat="server"  id="title" name="title" value="" maxlength="30" class="txtinput_order"></p>
					<p><font>请填写单位：</font><input type="text" runat="server"  id="cmpname" name="cmpname" value="" maxlength="25" class="txtinput_order"></p>
					<p><font>请填写地址：</font><input type="text" runat="server"  id="addr" name="addr" value="" class="txtinput_order"></p>
					<p><font><em class="oragecolor">*</em>请填写联系人：</font><input type="text" runat="server"  id="name" name="name" value="" maxlength="10" class="txtinput_order"></p>
					<p><font><em class="oragecolor">*</em>请填写电话：</font><input type="text" runat="server" id="tel" name="tel" value="" maxlength="20" class="txtinput_order"/></p>
					<p><font>请填写内容：</font><textarea id="content"  runat="server" name="content" class="textareaorder" placeholder="请填写原因！"></textarea></p>
					<p><font><em class="oragecolor">*</em>验证码：</font>
					   <input type="text" runat="server"  id="checkcodes" name="checkcodes" class="txtinput_order" maxlength="4" style="width:50%;">
                       <a href="javascript:;" onclick="ToggleCode(this, '../tools/m_code.ashx');return false;"><img src="../tools/m_code.ashx"   width="100" height="38"  border="0" /> </a>

					</p>
                      <asp:Button ID="btnSubmit" runat="server" Text="立即提交" CssClass="yzbtn" onclick="btnSubmit_Click"  OnClientClick="return suggestion();"/>
		
				</div>	
			
			</div>
		</div>
		</div>	 
	 <div class="clear"></div>
     <uc1:end ID="end1" runat="server" />

     	 <script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
	 <script language="javascript" type="text/javascript" src="image/index.js"></script>
	 <script language="javascript" type="text/javascript" src="image/sp.js"></script>
	 <script type="text/javascript">
	     //提交退换货申请
	     function questionord() {
	         var val = $("#orderno").val().replace(/\s/g, "");
	         if (val == "") {
	             alert("订单号不能为空");
	             return false;
	         } 

	         if ($("#expno").val() == "") {
	             alert("物流单号不能为空");
	             return false;
	         }
	         val = $("#memo").val();
	         if (val == "") {
	             alert("退换原因不能为空");
	             return false;
	         } else if (val.length > 100) {
	             alert("退换原因长度限制100字以内");
	             return false;
	         }

	         if ($("#linkman").val() == "") {
	             alert("联系人姓名不能为空");
	             return false;
	         }

	         if ($("#linkphone").val() == "") {
	             alert("联系人电话不能为空");
	             return false;
	         }
	         //验证4位数随机验证码
	         val = $("#checkcode").val();
	         if (!/^\d{4}$/.test(val)) {
	             alert("请输入验证码");
	             return false;
	         }

	     }
	     //提交投诉建议
	     function suggestion() {
	         if ($("#title").val().replace(/\s/g, "") == "") {
	             alert("标题不能为空");
	             return false;
	         }
	         if ($("#addr").val().length > 50) {
	             alert("内容长度限制50字以内").time(5000);
	             return false;
	         }
	         if ($("#name").val().replace(/\s/g, "") == "") {
	             alert("联系人不能为空");
	             return false;
	         }
	         if ($("#tel").val().replace(/\s/g, "") == "") {
	             alert("联系电话不能为空");
	             return false;
	         }
	         if ($("#content").val().length > 200) {
	             alert("内容长度限制200字以内");
	             return false;
	         }
	         if (!/^\d{4}$/.test($("#checkcodes").val())) {
	             alert("请输入验证码");
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
