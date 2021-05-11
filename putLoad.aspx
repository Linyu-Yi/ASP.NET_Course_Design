<%@ Page Language="C#" AutoEventWireup="true" CodeFile="putLoad.aspx.cs" Inherits="putLoad" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="end.ascx" tagname="end" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>AH礼券自助提货系统-申请提货</title>
<meta http-equiv="keywords" content="">
<meta http-equiv="description" content=""> 	
<link rel="stylesheet" type="text/css" href="image/index.css">
<link rel="stylesheet" type="text/css" href="image/style.css">
<script language="javascript" type="text/javascript" src="image/qiehuan.js"></script>
<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
<script type="text/javascript" src="js/jquery/PCAS.js"></script>
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

			
<div class="left">
				<p><img src="image/lefttop.jpg"></p>
				<h1 style=" padding:0 0 0 25px; color:#34495e;font-weight: 100;">快速导航</h1>
				<ul>
					<li class="libg li1" onclick="window.location.href='identityLoad.aspx'">
						<strong class="nav1"></strong>
						<div>
							<a href="identityLoad.aspx">真伪查询</a>
							<span>check the authenticity</span>
						</div>
					</li>
					<li class="libg li2" onclick="window.location.href='putLoad.aspx'">
						<strong class="nav2"></strong>
						<div>
							<a href="putLoad.aspx">申请提货</a>
							<span>Apply for delivery</span>
						</div>
						<em class="embg"></em>
					</li>
					<li class="libg li3" onclick="window.location.href='orderInfoLoad.aspx'">
						<strong class="nav3"></strong>
						<div>
							<a href="orderInfoLoad.aspx">查询订单</a>
							<span>Query order</span>
						</div>
						<em class="embg"></em>
					</li>
					<li class="libg li4" onclick="window.location.href='helpList.aspx'" style="border: none; cursor: pointer;">
						<strong class="nav4"></strong>
						<div>
							<a href="helpList.aspx" style="color: rgb(255, 255, 255);">帮助中心</a>
							<span style="color: rgb(121, 135, 149);">Help center</span>
						</div>
						<em class="embg"></em>
					</li>
				</ul>
				<p><img src="image/leftbottom.jpg"></p>
			</div>

<div class="rightcontact">
				<div class="right_title"><img src="image/bz_04.jpg"><span>申请提货</span></div>
				<div class="right_contact">
					<p><img src="image/intttop.jpg"></p>
					
						<div class="right_contact1">
							<span><font>提货编码：</font><input type="text" id="ticketno" name="ticketno"   runat="server" maxlength="8" value="" class="txtinput_search"></span>
							<span>
								<font>验证密码：</font>
								<input type="text" id="ticketpw" name="ticketpw" value="" runat="server" maxlength="6" class="txtinput_search">
							</span>
							<span>
								<font>验证码：</font>
								<input type="text" ID="checkcode" name="checkcode" runat="server" class="txtinput_search" maxlength="4" style="width:100px;">
					  			 <a href="javascript:;" onclick="ToggleCode(this, 'tools/verify_code.ashx');return false;"><img src="tools/verify_code.ashx"  alt="看不清楚?请点击刷新" width="100" height="38"  border="0" /> </a>
                                 <asp:Button ID="btnSearch" runat="server" Text="" CssClass="searchbtn" onclick="btnSearch_Click"  OnClientClick="return tijiao();"/>
							</span>
                            <asp:Panel ID="PanelOrder" runat="server" Visible="false">
                   
							<h8></h8>
                             <span class="reds">
								*可以一次提多张礼券一并发货
							</span>
      <table width="582" border="0" align="center" cellpadding="8" cellspacing="0" class="cart_table">
      <tr>       
      <th width="100" align="center">提货编码</th>
        <th align="left">礼品名称</th>
        <th width="50" align="center">操作</th>
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
        <h8></h8>
<script type="text/javascript">
            $(function () {
                //初始化地区
                var mypcas = new PCAS("province,所属省份", "city,所属城市", "area,所属地区");
            });
</script>
                           <span>
								<font><strong class="reds">*</strong>姓名：</font><input type="text" id="user_name" name="user_name"   runat="server" maxlength="50" value="" class="txtinput_search">
							</span>
                                  &nbsp; <span><font><strong class="reds">*</strong>手机：</font><input 
                                    ID="user_tel" runat="server" class="txtinput_search" maxlength="11" 
                                    name="user_tel" type="text" value=""> </input></span> &nbsp;<span><font>
                                    
                    <strong class="reds">*</strong>地区：</font>
    
        <select id="province" name="province" class="select"   ></select>
        <select id="city" name="city" class="select"></select>
        <select id="area" name="area" class="select" ></select>
      	</span>
                                 &nbsp;<span><font>   <strong class="reds">*</strong>地址：</font><input type="text" id="address" name="address"   runat="server"  maxlength="100" value="" class="txtinput_search">
							</span>
                            &nbsp; <span><font>用户留言：</font>                   
                            <textarea ID="message" runat="server"  name="message"  class="textareaorder"></textarea></span> &nbsp;
                                
                                <span><asp:Button ID="btnSubmit" runat="server" Text="提交" 
                                    CssClass="btnbg anniu"   OnClientClick="return questionord();" 
                                    onclick="btnSubmit_Click"/>

									<input type="button" value="重置" onclick="reset()" class="addpackage anniu" style="width:112px;">
							</span>
                                &nbsp;&nbsp;</asp:Panel>
					
					<p><img src="image/inttbottom20.jpg"></p>
				</div>
				
				
			</div>
		</div>
 </div>
		<!--main end-->
    <uc2:end ID="end1" runat="server" />
   
	
		<script language="javascript" type="text/javascript" src="image/index.js"></script>
		<script type="text/javascript" src="image/jquery.artDialog.min.js"></script>
		<script type="text/javascript" src="image/artDialog.plugins.min.js"></script>
			<script type="text/javascript" src="image/demo.js"></script>
		<script type="text/javascript">
		    function tijiao() {
		        var val = $("#ticketno").val().replace(/\s/g, "");
		        if (val == "") {
		            $.alert("请输入提货编码！").time(5000);
		            return false;
		        }
		        val = $("#ticketpw").val();
		        if (val.replace(/\s/g, "") == "") {
		            $.alert("验证密码不能为空").time(5000);
		            return false;
		        }
		        //验证4位数随机验证码
		        var checkcode = $("#checkcode").val().replace(/\s/g, "");
		        if (checkcode == "") {
		            $.alert("<div class='message'>请输入验证码</div>").time(5000);
		            return false;
		        } 
		    }
		    /*切换验证码*/
		    function ToggleCode(obj, codeurl) {
		        $(obj).children("img").eq(0).attr("src", codeurl + "?time=" + Math.random());
		        return false;
		    }

		    //提交提货
        function questionord() {
            if ($("#user_name").val().replace(/\s/g, "") == "") {
                $.alert("收货人姓名不能为空").time(5000);
                return false;
            }
            var partten = /^0?(13[0-9]|15[012356789]|18[0-9]|14[57])[0-9]{8}$/;
            val = $("#user_tel").val();
            if (val.replace(/\s/g, "") == "") {
                $.alert("收货人手机不能为空").time(5000);
                return false;
            } else if (!partten.test(val)) {
                $.alert("收货人手机格式不正确，请确认填写").time(5000);
                return false;
            }
            if ($("#area").val() == "") {
                $.alert("请选择所在地区！").time(5000);
                return false;
            }
            val = $("#address").val().replace(/\s/g, "");
            if (val == "") {
                $.alert("收货人地址不能为空").time(5000);
                return false;
            } else if (val.length > 100) {
                $.alert("收货人地址长度限制100字以内").time(5000);
                return false;
            }
            val = $("#message").val().replace(/\s/g, "");
            if (val.length > 100) {
                $.alert("用户留言长度限制100字以内").time(5000);
                return false;
            }
        }
     </script>

    </form>
</body>
</html>

