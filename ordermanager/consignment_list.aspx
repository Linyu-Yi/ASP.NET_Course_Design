<%@ Page Language="C#" AutoEventWireup="true" CodeFile="consignment_list.aspx.cs" Inherits="ordermanager_consignment_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>发货管理</title>
  <link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/lhgcore.min.js"></script>
<script type="text/javascript" src="../js/lhgcalendar.min.js"></script>
<script type="text/javascript">
    J(function () {
        J('#txtstart_time').calendar({ btnBar: true });
        J('#txtstop_time').calendar({ btnBar: true });
    });
   
</script> 
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">发货管理</a></li>
    </ul>
    </div>  
    <div class="rightinfo">
    <dl class="seachform"> 
    <dd><label> 订单号</label><span class="single-select"><asp:TextBox ID="txtNote_no" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>

      <dd class="cx"><asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>   
 </dd>
 
    </dl>
            <!--列表-->
	  <table class="tablelistl">
    	<thead>
    	<tr>
        <th width="40px;">序号</th>
		<th  width="110px;">订单号</th>
		<th width="90px;">收货人姓名</th>
        <th width="100px;">收货人电话</th>
          <th >收货人地址</th>
        <th width="90px;">礼券编号</th>
        <th width="8%">订单状态</th>  
		<th width="120px;">提货时间</th>
         <th width="90px;">操作</th>     
        </tr>
        </thead>
        <tbody>
<asp:Repeater ID="rptList" runat="server">
<ItemTemplate>
        <tr>
            <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
            <td><%# Eval("order_no")%></td>
           
            <td><%#Eval("user_name").ToString() == "" ? "匿名用户" : Eval("user_name").ToString()%></td>
           <td><%# Eval("user_tel")%></td>
            <td><%# Eval("area")%><%# Eval("address")%></td>
           <td><%# GetTicketNoStatus(Convert.ToInt32(Eval("id")))%></td>
             <td ><%#GetOrderStatus(Convert.ToInt32(Eval("status")))%></td>      	
            <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
            <td><a href="order_edit.aspx?action=Edit&id=<%#Eval("id")%>" class="tablelink"> 发货处理</a> </td>
        </tr> 		
 	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater> 

    <div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
      
    </div>
    </form>
</body>
</html>

