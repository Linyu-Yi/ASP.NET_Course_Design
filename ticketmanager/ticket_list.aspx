<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ticket_list.aspx.cs" Inherits="ticketmanager_ticket_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>礼券管理</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/lhgcore.min.js"></script>
<script type="text/javascript" src="../js/lhgcalendar.min.js"></script>
<script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
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
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">礼券管理</a></li>
    </ul>
    </div>  
    <div class="rightinfo">    
    <div class="tools">  
    	<ul class="toolbar">
           <li><span><img src="../images/t02.png" /></span><a href="javascript:;" onclick="checkAll(this);">全选</a></li>
        <li class="click"><asp:LinkButton ID="btnFF" runat="server" CssClass="del" OnClientClick="return FFPostBack('btnFF');" onclick="btnFF_Click"><span><img src="../images/t05.png" /></span>批量发放</asp:LinkButton></li>
                <li class="click">
        到期日期：<asp:TextBox ID="txtAddTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s+$|^\d{4}\-\d{1,2}\-\d{1,2}$/"  />
       <asp:LinkButton ID="btnDQ" runat="server" CssClass="del" OnClientClick="return DQPostBack('btnDQ');" onclick="btnDQ_Click"><span><img src="../images/time.png" /></span>【批量修改】</asp:LinkButton>
               
                </li>
        <a href="ticket_edit.aspx?action=Add"><li><span><img src="../images/t01.png" /></span>单个添加</li></a>
          <a href="ticket_inset.aspx"><li><span><img src="../images/t01.png" /></span>批量生成</li></a>
           <asp:LinkButton ID="btnExport" runat="server" CssClass="save" onclick="btnExport_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton>
        </ul>       
   
    </div>
    
    <dl class="seachform"> 
    <dd><label>礼券编号</label><span class="single-select"><asp:TextBox ID="txtKeywords" runat="server" CssClass="scinput"></asp:TextBox></span></dd>
   	<dd><label>到期起始日期</label><span class="single-select"><input  type="text" class="timeinput" id="txtstart_time" name="txtstart_time" readonly="readonly" runat="server" /></span></dd>
	<dd><label>到期结束日期</label><span class="single-select"><input type="text" class="timeinput" id="txtstop_time" name="txtstop_time" readonly="readonly" runat="server"/></span></dd>
    <dd><label>礼券规格</label>  
    <span class="rule-single-select">
<asp:DropDownList ID="ddlCategoryId"  runat="server" AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged">
</asp:DropDownList>
    </span>
    </dd>
    <dd><label>状态</label>  
    <span class="rule-single-select">
      <asp:DropDownList ID="ddlStatus"  runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">==全部==</asp:ListItem>
             <asp:ListItem Value="1">未发放</asp:ListItem>
             <asp:ListItem Value="2">已发放</asp:ListItem>
             <asp:ListItem Value="3">已提货</asp:ListItem>
          </asp:DropDownList>
    </span>
    </dd>
      <dd class="cx"> <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button></dd> 
    </dl>
    
    <!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
    <table class="tablelist">
    	<thead>
    	<tr>
          <th width="50px;">选择</th>
        <th width="50px;">序号</th>
         <th>礼券规格</th>
        <th width="120px;">礼券编号</th>
        <th width="90px;">礼券密码</th>
        <th width="120px;">到期时间</th>
        <th width="90px;">状态</th>
        <th width="90px;">操作</th>
        </tr>
        </thead>
   <tbody>
</HeaderTemplate>
<ItemTemplate> 
        <tr>
        	<td><asp:CheckBox ID="chkId" CssClass="checkall" Enabled='<%#bool.Parse((Convert.ToInt32(Eval("status")) < 3 ).ToString())%>'  runat="server" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
		<td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>	
		<td><%#new ax_article().GetTitle(Convert.ToInt32(Eval("pid")))%></td>

        <td><%# Eval("ticket_no")%></td>
        <td><%# Eval("ticket_pw")%></td>
       <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
        <td><%#GetOrderStatus(Convert.ToInt32(Eval("status")))%></td>
		<td><a href="ticket_edit.aspx?action=Edit&id=<%#Eval("id")%>&status=<%=status%>&category_id=<%=category_id%>&keywords=<%=keywords%>&page=<%=page%>" class="tablelink"><font color =green><%# Convert.ToInt32(Eval("status")) == 3 ? "" : "[修改]"%></font></a>  &nbsp;&nbsp;<asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('是否真的要删除？')" onclick="lbtnDelCa_Click"><font color =red><%# Convert.ToInt32(Eval("status")) == 3 ? "" : "[删除]"%></font></asp:LinkButton></td>
        </tr> 
     </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater>  
   <!--列表-->
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
