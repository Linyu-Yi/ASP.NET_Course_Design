<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_express.aspx.cs" Inherits="dialog_dialog_express" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>订单送货窗口</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确定',
        focus: true,
        callback: function () {
            submitForm();
            return false;
        }
    }, {
        name: '取消'
    });

    //提交表单处理
    function submitForm() {
        //验证表单
        if ($("#ddlDepotId").val() == "") {
            W.$.dialog.alert('请选择发货仓库！', function () { $("#ddlDepotId").focus(); }, api);
            return false;
        }
        if ($("#ddlExpressId").val() == "") {
            W.$.dialog.alert('请选择快递公司！', function () { $("#ddlExpressId").focus(); }, api);
            return false;
        }
        if ($("#txtExpressNo").val() == "") {
            W.$.dialog.alert('请填写物流单号！', function () { $("#txtExpressNo").focus(); }, api);
            return false;
        }
        //组合参数
        var postData = {
            "order_no": $("#spanOrderNo", W.document).text(), "edit_type": "order_express",
            "express_id": $("#ddlExpressId").val(), "depot_category_id": $("#ddlDepotId").val(), "express_no": $("#txtExpressNo").val()
        };
        //
    
            W.$.dialog.confirm('您确定填写的信息都没有错误码吗？确定后收货信息和快递信息都无法修改！',
            function () {
                //发送AJAX请求
                W.sendAjaxUrl(api, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
            },
            function () {
                $("#txtExpressNo").focus();
            },
            api);
            return false;
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="div-content">
  <dl>
    <dt>发货仓库</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlDepotId" runat="server"></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>快递公司</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlExpressId" runat="server"></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>物流单号</dt>
    <dd><asp:TextBox ID="txtExpressNo" runat="server" CssClass="input txt"></asp:TextBox></dd>
  </dl>
</div>
</form>
</body>
</html>
