<%@ Page Language="C#" AutoEventWireup="true" CodeFile="role_list.aspx.cs" Inherits="sysmanager_role_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>角色权限管理</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>

<script type="text/javascript" src="../js/layout.js"></script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">角色权限管理</a></li>
    </ul>
    </div>   
    <div class="rightinfo">    
    <div class="tools">
    
    	<ul class="toolbar">
        <a href="role_edit.aspx?action=Add"><li><span><img src="../images/t01.png" /></span>添加</li></a>
      
        </ul>        
        <ul class="toolbar1">
        <asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"> <li><span><img src="../images/t05.png" /></span>保存排序</li></asp:LinkButton>
        </ul>
    
    </div>
    <!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
    <table class="tablelist ">
    	<thead>
    	<tr>
        <th width="50px;">序号</th>
        <th>角色名称</th>
        	<th>排序</th>
        <th width="100px;">操作</th>
        </tr>
        </thead>
   <tbody>
</HeaderTemplate>
<ItemTemplate> 
        <tr>
		<td><%# Container.ItemIndex + 1%><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>	
        <td><%# Eval("role_name")%></td>
        <td><asp:TextBox ID="txtSortId" runat="server" Height="25"  Text='<%#Eval("role_type")%>' CssClass="scinput" Width="40" onkeydown="return checkNumber(event);" /></td>
		<td><a href="role_edit.aspx?action=Edit&id=<%#Eval("id")%>" class="tablelink"><font color =green>[修改]</font></a>&nbsp;&nbsp;<asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('是否真的要删除？')" onclick="lbtnDelCa_Click"><font color =red>[删除]</font></asp:LinkButton></td>
        </tr> 
     </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater>  
  
    </div>
    </form>
</body>
</html>

