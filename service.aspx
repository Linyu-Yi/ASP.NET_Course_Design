<%@ Page Language="C#" AutoEventWireup="true" CodeFile="service.aspx.cs" Inherits="service" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="end.ascx" tagname="end" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>AH礼券自助提货系统-退换货申请</title>
 <link rel="stylesheet" type="text/css" href="image/index.css">
		<link rel="stylesheet" type="text/css" href="image/style.css">
		<link rel="stylesheet" href="image/default.css">
		<!--[if gte IE 7]><!-->
		    <link rel="stylesheet" href="image/sp100.css">
		<!--<![endif]-->
		<!--[if lt IE 7]>
		    <link rel="stylesheet" href="images/default.css" />
		<![endif]-->
<script type="text/javascript" src="image/jquery-1.9.1.js" language="javascript"></script>
<script type="text/javascript" src="js/swfupload/swfupload.js"></script>
<script type="text/javascript" src="js/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="js/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript">
    $(function () {
      
        //初始化上传控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "tools/upload_ajax.ashx", flashurl: "js/swfupload/swfupload.swf" });
        });

        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });

    });
  
</script>

</head>
<body>
    <form id="form1" runat="server">
   <div id="main">
			<div class="header">
				<a href="#" class="logo">退换货申请</a>
                <span>
		<a href="index.aspx" class="black_index">回到首页</a>
		<span class="phoneimg" style="padding-top:0;">
			<a href="" class="phone_a">手机网站</a>
			<img src="image/api.png" id="phoneimg" style="display: none;">
		</span>
	
	</span>
			</div>
			<div class="clear"></div>
			<div class="edittitle" id="apply" style="cursor: pointer;"><img src="image/edit.jpg"><span>退换货申请</span></div>
			<div class="applyorder" style="display: block;">
				<h1>（<strong class="reds" style="font-weight:100;">货物退换信息</strong>&nbsp;&nbsp;&nbsp;注：<strong class="reds">*</strong>为必填项 如遇到损坏可申请货物退换）</h1>			
				<div class="orderdiv">
					
						<table cellpadding="0" cellspacing="0" class="yztab">					
							<tbody><tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>货物订单号：</td>
								<td><input type="text" runat="server"  id="orderno" name="orderno" maxlength="24" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>物流单号：</td>
								<td><input type="text" runat="server"  id="expno" name="expno" maxlength="24" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>退换原因：</td>
								<td><textarea id="memo" runat="server" name="memo" class="textareaorder"></textarea></td>
							</tr>					
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">退换凭证图1：</td>
								<td>
								    <asp:TextBox ID="txtImgUrl1" runat="server" CssClass="upload-path txtinput" />
                                    <div class="upload-box upload-img"></div> 
								</td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">退换凭证图2：</td>
								<td>
								      <asp:TextBox ID="txtImgUrl2" runat="server" CssClass="upload-path txtinput" />
                                    <div class="upload-box upload-img"></div> 
								    
								</td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">退换凭证图3：</td>
								<td>
								       <asp:TextBox ID="txtImgUrl3" runat="server" CssClass="upload-path txtinput" />
                                    <div class="upload-box upload-img"></div> 
								</td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">退换凭证图4：</td>
								<td>
                                      <asp:TextBox ID="txtImgUrl4" runat="server" CssClass="upload-path txtinput" />
                                    <div class="upload-box upload-img"></div> 
								</td>
							</tr>
                            	<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">退换凭证图5：</td>
								<td>
                                      <asp:TextBox ID="txtImgUrl5" runat="server" CssClass="upload-path txtinput" />
                                    <div class="upload-box upload-img"></div> 
								</td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>申请人姓名：</td>
								<td><input type="text" runat="server"  id="linkman" name="linkman" maxlength="10" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>申请人电话：</td>
								<td><input type="text" runat="server"  id="linkphone" name="linkphone" maxlength="24" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>验证码：</td>
								<td>	
									<input type="text" runat="server"  id="checkcode" name="checkcode" class="txtinput_search" maxlength="4" style="width:100px;">
						  			 <a href="javascript:;" onclick="ToggleCode(this, 'tools/verify_code.ashx');return false;"><img src="tools/verify_code.ashx"  alt="看不清楚?请点击刷新" width="100" height="38"  border="0" /> </a>

								</td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">&nbsp;</td>
								<td>
                                  <span>
							<asp:Button ID="btnSQ" runat="server" Text="申请"  CssClass="btnbg anniu" style="width:112px; margin-right:10px;"   OnClientClick="return questionord();"  onclick="btnSQ_Click"/>
                            	</span>
									<input type="button" value="重置" onclick="reset()" class="addpackage anniu" style="width:112px;">
								</td>
							</tr>
						</tbody></table>
		
				</div>
			</div>
			<div class="edittitle" id="cproposals" style="cursor: pointer;"><img src="image/bz_03.jpg" style="padding:15px 12px 0 0;"><span>投诉建议</span></div>
			<div class="c_proposals">
				<h1>（注：<strong class="reds">*</strong>为必填项 感谢大家为我们提供更多更好的建议）</h1>
				<div class="orderdiv">
					
						<table cellpadding="0" cellspacing="0" class="yztab">
							<tbody><tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>标题：</td>
								<td><input type="text" runat="server"  id="title" name="title" maxlength="30" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">单位：</td>
								<td><input type="text" runat="server"  id="cmpname" name="cmpname" maxlength="25" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">地址：</td>
								<td><input type="text" runat="server"  id="addr" name="addr" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>联系人：</td>
								<td><input type="text" runat="server"  id="name" name="name" maxlength="10" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>电话：</td>
								<td><input type="text" runat="server"  id="tel" name="tel" maxlength="20" class="txtinput"></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">内容：</td>
								<td><textarea id="content"  runat="server" name="content" class="textareaorder"></textarea></td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;"><strong class="reds">*</strong>验证码：</td>
								<td>	
									<input type="text" runat="server"  id="checkcodes" name="checkcodes" class="txtinput_search" maxlength="4" style="width:100px;">
										  			 <a href="javascript:;" onclick="ToggleCode(this, 'tools/verify_code.ashx');return false;"><img src="tools/verify_code.ashx"  alt="看不清楚?请点击刷新" width="100" height="38"  border="0" /> </a>
                                </td>
							</tr>
							<tr>
								<td width="115" style="padding-right: 10px; text-align: right;">&nbsp;</td>
								<td>
                                	<asp:Button ID="btnSubmit" runat="server" Text="提交"   CssClass="btnbg anniu" style="width:112px; margin-right:10px;" OnClientClick="return suggestion();" />

									<input type="button" value="重置" onclick="reset()" class="addpackage anniu" style="width:112px;">
								</td>
							</tr>
						</tbody></table>
					
				</div>
			</div>
			<div class="clear"></div>
			<div class="explaindiv">
				<div><img src="image/sm_top.jpg"></div>
				<span>说明：</span>
				<div>
					<p>1.这里是退换货申请页</p>
					<p>2.主要是让客户可以申请退换货</p>
					<p>4.申请成功后，您就可以等待商家回复您是否符合退换货条件.........</p>
				</div>
				<div><img src="image/sm_bottom.jpg"></div>
			</div>
		</div>
        <uc2:end ID="end1" runat="server" />
        		

		<script type="text/javascript" src="image/index.js" language="javascript"></script> 
		<script type="text/javascript" src="image/jquery.artDialog.min.js"></script>
		<script type="text/javascript" src="image/artDialog.plugins.min.js"></script>
		<script type="text/javascript" src="image/demo.js"></script>
		<script charset="utf-8" src="image/kindeditor.js"></script>
		<script charset="utf-8" src="image/zh_CN.js"></script>
		<script charset="utf-8" src="image/prettify.js"></script>
		
		<script type="text/javascript">
		    /*切换验证码*/
		    function ToggleCode(obj, codeurl) {
		        $(obj).children("img").eq(0).attr("src", codeurl + "?time=" + Math.random());
		        return false;
		    }

		    //提交退换货申请
		    function questionord() {
		        var val = $("#orderno").val().replace(/\s/g, "");
		        if (val == "") {
		            $.alert("订单号不能为空").time(5000);
		            return false;
		        } 

		        if ($("#expno").val().replace(/\s/g, "") == "") {
		            $.alert("物流单号不能为空").time(5000);
		            return false;
		        }

		        val = $("#memo").val().replace(/\s/g, "");
		        if (val == "") {
		            $.alert("退换原因不能为空").time(5000);
		            return false;
		        } else if (val.length > 100) {
		            $.alert("退换原因长度限制100字以内").time(5000);
		            return false;
		        }

		        if ($("#linkman").val().replace(/\s/g, "") == "") {
		            $.alert("申请人姓名不能为空").time(5000);
		            return false;
		        }

		        var partten = /^0?(13[0-9]|15[012356789]|18[0-9]|14[57])[0-9]{8}$/;
		        val = $("#linkphone").val();
		        if (val.replace(/\s/g, "") == "") {
		            $.alert("申请人电话不能为空").time(5000);
		            return false;
		        } else if (!partten.test(val)) {
		            $.alert("申请人电话格式不正确，请确认填写").time(5000);
		            return false;
		        }
		        //验证4位数随机验证码
		        var checkcode = $("#checkcode").val().replace(/\s/g, "");
		        if (checkcode == "") {
		            $.alert("<div class='message'>请输入验证码</div>").time(5000);
		            return false;
		        } 
		 
		    }
		    //提交投诉建议
		    function suggestion() {
		        if ($("#title").val().replace(/\s/g, "") == "") {
		            $.alert("标题不能为空").time(5000);
		            return false;
		        }
		        if ($("#addr").val().length > 50) {
		            $.alert("内容长度限制50字以内").time(5000);
		            return false;
		        }
		        if ($("#name").val().replace(/\s/g, "") == "") {
		            $.alert("联系人不能为空").time(5000);
		            return false;
		        }
		        var partten = /^0?(13[0-9]|15[012356789]|18[0-9]|14[57])[0-9]{8}$/;
		        val = $("#tel").val();
		        if (val.replace(/\s/g, "") == "") {
		            $.alert("申请人电话不能为空").time(5000);
		            return false;
		        } else if (!partten.test(val)) {
		            $.alert("申请人电话格式不正确，请确认填写").time(5000);
		            return false;
		        }
		        if ($("#content").val().length > 200) {
		            $.alert("内容长度限制200字以内").time(5000);
		            return false;
		        }
		        //验证4位数随机验证码
		        var checkcode = $("#checkcodes").val().replace(/\s/g, "");
		        if (checkcode == "") {
		            $.alert("<div class='message'>请输入验证码</div>").time(5000);
		            return false;
		        } 
		    
		    }
		</script>
   
    </form>
</body>
</html>
