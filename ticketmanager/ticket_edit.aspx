<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ticket_edit.aspx.cs" Inherits="ticketmanager_ticket_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>编辑礼券</title>
   <link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
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
    <li><a href="ticket_list.aspx">礼券管理</a></li>
    <li><a href="#">编辑礼券</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>礼券信息</span></div>
    <!--/礼券信息-->
<div class="tab-content">
  <dl>
    <dt>礼券规格</dt>
    <dd>
      <span class="rule-single-select">
        <asp:DropDownList id="ddlCategoryId" runat="server" datatype="*" errormsg="请选择礼券规格" sucmsg=" "></asp:DropDownList>
      </span>
    </dd>
  </dl>
  <dl>
    <dt>礼券编号</dt>
    <dd><asp:TextBox ID="txtticket_no" runat="server" CssClass="input normal" datatype="n" MaxLength="8"  sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl> 
   
    <dl>
    <dt>礼券密码</dt>
    <dd><asp:TextBox ID="txtticket_pw" runat="server" CssClass="input normal" datatype="n" MaxLength="6" sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
       <dl>
    <dt>礼券有效期截止日期</dt>
    <dd> 
        <div class="input-date">
        <asp:TextBox ID="txtAddTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s+$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
        <i>日期</i>
      </div>
    <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl >
    <dt>是否发放</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" />
      </div>
      <span class="Validform_checktip">*不发放该礼券无法提货</span>
    </dd>
  </dl>
  
 
</div>
<!--/礼券信息-->    
    </div>

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
