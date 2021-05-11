<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_edit.aspx.cs" Inherits="ordermanager_order_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑订单信息</title>
    <script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("#btnComplete").click(function () { OrderComplete(); }); //完成订单
        $("#btnCancel").click(function () { OrderCancel(); });     //取消订单
        $("#btnEditRemark").click(function () { EditOrderRemark(); });    //修改订单备注
        $("#btnEditAcceptInfo").click(function () { EditAcceptInfo(); }); //修改收货信息
        $("#btnEditExpress").click(function () { OrderExpress(); });   //修改物流信息
    });


    //完成订单
    function OrderComplete() {
        var dialog = $.dialog.confirm('订单完成后，说明商品客户已经签收，订单完成，确认要继续吗？', function () {
            var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_complete" };
            //发送AJAX请求
            sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
            return false;
        });
    }
    //取消订单
    function OrderCancel() {
        var dialog = $.dialog({
            title: '取消订单',
            content: '操作提示信息：<br />1、请与下单客户沟通；<br />2、取消订单后礼券作废；<br />3、请单击相应按钮继续下一步操作！',
            min: false,
            max: false,
            lock: true,
            icon: 'confirm.gif',
            button: [{
                name: '确认取消',
                callback: function () {
                    var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_cancel", "check_revert": 0 };
                    //发送AJAX请求
                    sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                    return false;
                }
            }, {
                name: '关闭'
            }]
        });

    }
    //确认送货
    function OrderExpress() {
        var dialog = $.dialog({
            title: '确认发货',
            content: 'url:../dialog/dialog_express.aspx?order_no=' + $("#spanOrderNo").text(),
            min: false,
            max: false,
            lock: true,
            width: 450,
            height: 280
        });
    }
    //修改收货信息
    function EditAcceptInfo() {
        var dialog = $.dialog({
            title: '修改收货信息',
            content: 'url:../dialog/dialog_accept.aspx',
            min: false,
            max: false,
            lock: true,
            width: 650,
            height: 320
        });
    }
    //修改订单备注
    function EditOrderRemark() {
        var dialog = $.dialog({
            title: '订单备注',
            content: '<textarea id="txtOrderRemark" name="txtOrderRemark" rows="2" cols="20" class="input">' + $("#divRemark").html() + '</textarea>',
            min: false,
            max: false,
            lock: true,
            ok: function () {
                var remark = $("#txtOrderRemark").val();
                if (remark == "") {
                    $.dialog.alert('对不起，请输入订单备注内容！', function () { }, dialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_order_remark", "remark": remark };
                //发送AJAX请求
                sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancel: true
        });
    }
    //
    //=================================工具类的JS函数====================================

    //发送AJAX请求
    function sendAjaxUrl(winObj, postData, sendUrl) {
        $.ajax({
            type: "post",
            url: sendUrl,
            data: postData,
            dataType: "json",
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.dialog.alert('尝试发送失败，错误信息：' + errorThrown, function () { }, winObj);
            },
            success: function (data, textStatus) {
                if (data.status == 1) {
                    winObj.close();
                    $.dialog.tips(data.msg, 2, '32X32/succ.png', function () { location.reload(); }); //刷新页面
                } else {
                    $.dialog.alert('错误提示：' + data.msg, function () { }, winObj);
                }
            }
        });
    }
</script>
</head>
<body>
<form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="order_list.aspx">订单管理</a></li>
    <li><a href="#">编辑订单信息</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>订单详细信息</span></div>
    <!--/订单详细信息-->
<div class="tab-content">
  <dl>
    <dd style="margin-left:50px;text-align:center;">
      <div class="order-flow" style="width:560px">
            <%if (model.status < 4)
          { %>
        <div class="order-flow-left">
          <a class="order-flow-input">提货</a>
          <span><p class="name">订单已提货</p><p><%=model.add_time%></p></span>
        </div>
         <%if (model.status == 1)
          { %>
        <div class="order-flow-wait">
          <a class="order-flow-input">发货</a>
          <span><p class="name">等待发货</p></span>
        </div>
        <%}
          else if (model.status > 1)
          { %>
        <div class="order-flow-arrive">
          <a class="order-flow-input">发货</a>
          <span><p class="name">已发货</p><p><%=model.confirm_time%></p></span>
         </div>
         <%} %>
         <%if (model.status == 3)
           { %>
         <div class="order-flow-right-arrive">
           <a class="order-flow-input">完成</a>
           <span><p class="name">订单完成</p></span>
         </div>
         <%}
           else
           { %>
         <div class="order-flow-right-wait">
           <a class="order-flow-input">完成</a>
           <span><p class="name">订单完成</p></span>
         </div>
         <%} %>
         <%}
          else if (model.status == 4)
          {%>
          <div style="text-align:center;line-height:30px; font-size:20px; color:Red;">该订单已取消</div>
           <%} %>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>订单号</dt>
    <dd><span id="spanOrderNo"><%=model.order_no %></span></dd>
  </dl>
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <dl>
    <dt> 礼券列表</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <thead>
          <tr>
  
            <th>礼品名称</th>
            <th width="20%">礼券编号</th>
            <th width="18%">礼券密码</th>

          </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
        <ItemTemplate>
          <tr class="td_c">
         
            <td style="text-align:left;white-space:normal;"><%#Eval("goods_title")%></td>
            <td><%#Eval("ticket_no")%></td>
           <td><%#new ax_ticket().GetPW(Convert.ToInt32(Eval("ticket_id")))%></td>
        
          </tr>
          </ItemTemplate>
          <FooterTemplate>
        </tbody>
      </table>
    </dd>
  </dl>
  </FooterTemplate>
  </asp:Repeater>
  <dl>
    <dt>收货信息</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
          <tr>
          <th>配送方式</th>
          <td>
             <div class="position">
              <div id="divexpress">
          <%=new ax_product_category().GetTitle(Convert.ToInt32(model.product_category_id))%><%=(model.product_no != "") ? "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;物流单号：" + model.product_no : ""%><%=(model.depot_category_id != 0) ? "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发货仓库：" + new ax_depot_category().GetTitle(Convert.ToInt32(model.depot_category_id)) : ""%>
     </div>
              <input id="btnEditExpress" runat="server" visible="false" type="button" class="ibtn" value="填写信息发货" />
            </div>
            </td>
        </tr>
        

        <tr>
          <th>收货人姓名</th>
          <td>
                <div class="position">
              <div id="divcontact_name">
      <span id="spanAcceptName"><asp:Label ID="contact_name" runat="server" /></span>
     </div>
             <input id="btnEditAcceptInfo" runat="server" visible="false" type="button" class="ibtn" value="修改收货信息" />
            </div>
          
          </td>
        </tr>
        <tr>
          <th>收货人电话</th>
          <td><span id="spanMobile"><asp:Label ID="contact_tel" runat="server" /></span></td>
        </tr>
             <tr>
          <th>收货人地址</th>
          <td> <span id="spanArea"><%=model.area %></span> <span id="spanAddress"><asp:Label ID="contact_address" runat="server" /></span></td>
        </tr>
          <tr>
          <th>用户留言</th>
          <td><%=model.message %></td>
        </tr>
        <tr>
          <th>订单备注</th>
          <td>
            <div class="position">
              <div id="divRemark"><%=model.remark %></div>
              <input id="btnEditRemark" runat="server" visible="false" type="button" class="ibtn" value="修改" />
            </div>
          </td>
        </tr>
      </table>
    </dd>
  </dl>
  

  
</div>
<!--/订单详细信息-->
    </div>

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <input id="btnComplete" runat="server" visible="false" type="button" value="完成订单" class="btn" />
    <input id="btnCancel" runat="server" visible="false" type="button" value="取消订单" class="btn green" />
    <input id="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>
