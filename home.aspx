<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>系统首页</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 980;
                t_height = 500;
                t_title = '查看售后服务';
                t_url = s_url;
                break;
        }
        $.dialog({
            width: t_width,
            height: t_height,
            title: t_title,
            max: false,
            content: 'url:' + t_url
        });
    } 

</script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统首页</a></li>
    </ul>
    </div>
    <div class="mainbox">    
    <div class="mainleft">
        <div class="leftinfo">
    <div class="listtitle">待发货订单
        </div>      

     <table class="tablelistl">
    	<thead>
    	<tr>

		<th  width="110px;">&nbsp;订单号</th>
		<th width="90px;">&nbsp;收货人姓名</th>
        <th width="100px;">&nbsp;收货人电话</th>

        <th width="90px;">&nbsp;礼券编号</th>
		<th width="120px;">&nbsp;提货时间</th>
         <th width="90px;">&nbsp;操作</th>     
        </tr>
        </thead>
        <tbody>
<asp:Repeater ID="rptList" runat="server">
<ItemTemplate>
        <tr>
 
            <td><%# Eval("order_no")%></td>
           
            <td><%#Eval("user_name").ToString() == "" ? "匿名用户" : Eval("user_name").ToString()%></td>
           <td><%# Eval("user_tel")%></td>

           <td><%# GetTicketNoStatus(Convert.ToInt32(Eval("id")))%></td>	
            <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
            <td><a href="ordermanager/order_edit.aspx?action=Edit&id=<%#Eval("id")%>" class="tablelink"> 发货处理</a> </td>
        </tr> 		
 	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater> 

 
    </div>
    <!--leftinfo end-->
    
    </div>
    <!--mainleft end-->
    <div class="mainright">
    <div class="dflist">
    <div class="listtitle">售后服务</div>    
    <ul class="newlist">
    <asp:Repeater ID="rptList_notice" runat="server">
    <ItemTemplate> 
     <li><a href="javascript:opdg('info','sysmanager/service_info.aspx?id=<%#Eval("id")%>');">订单号：<%# Eval("order_no")%>物流单号：<%# Eval("express_no")%></a></li>
    </ItemTemplate>
<FooterTemplate>
  <%#rptList_notice.Items.Count == 0 ? "<li><font color=red>暂无记录</font></li>" : ""%>
</FooterTemplate>
</asp:Repeater>  
    </ul>        
    </div> 
    </div>
    <!--mainright end--> 
    </div>


    </form>
</body>
</html>
