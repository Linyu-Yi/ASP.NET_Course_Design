<%@ Page Language="C#" AutoEventWireup="true" CodeFile="msg_manager.aspx.cs" Inherits="sysmanager_msg_manager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>短信设置</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">短信设置</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>短信设置</span></div>

<!--/我的信息-->
<div class="tab-content">
 
  <dl>  
    <dt>短信剩余条数</dt>
    <dd><asp:Literal ID="LitMsgNum" runat="server"></asp:Literal>条&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;条数不够用请联系<a href="http://www.olshine.com" target="_blank">奥祥科技</a>充值</dd>
  </dl> 

    <dl>
    <dt>是否启用短信</dt>
    <dd><div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" Checked="True" />
      </div>
      <span class="Validform_checktip">*不启用短信通道关闭不能发送短信</span></dd>
  </dl>

    <dl>
    <dt>短信通道账户</dt>
    <dd><asp:TextBox ID="txtMsgName" runat="server" CssClass="input normal"  datatype="*"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>

  <dl>
    <dt>短信通道密码</dt>
    <dd><asp:TextBox ID="txtMsgPwd" runat="server" CssClass="input normal" datatype="*"></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>

  <dl>
    <dt>注意</dt>
    <dd><font color=red>不确定账密请不要修改，否则造成无法发送短信！</font></dd>
  </dl>


    
 </div>
</div>
<!--/我的信息-->  


    <!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click"  />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>
