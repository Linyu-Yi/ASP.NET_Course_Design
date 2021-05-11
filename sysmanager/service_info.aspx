<%@ Page Language="C#" AutoEventWireup="true" CodeFile="service_info.aspx.cs" Inherits="sysmanager_service_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看售后服务信息</title>
 <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div class="mainindext">
<!--/我的信息-->
<div class="tab-content">

  <dl>  
    <dt>货物订单号：</dt>
    <dd><asp:Literal ID="lblorder_no" runat="server"></asp:Literal></dd>
  </dl> 

    <dl>
    <dt>物流单号：</dt>
    <dd><asp:Literal ID="lblexpress_no" runat="server"></asp:Literal></dd>
  </dl>

   
    <dl >
    <dt>退换原因：</dt>
    <dd><asp:Literal ID="lblcontent" runat="server"></asp:Literal></dd>
  </dl>
      <dl >
         
    <dt>退换凭证图：</dt>
    <dd> <asp:Image ID="Image1" runat="server" /><asp:Image ID="Image2" runat="server" /><asp:Image ID="Image3" runat="server" /><asp:Image ID="Image4" runat="server" /><asp:Image ID="Image5" runat="server" /></dd>
  </dl>
    <dl>  
    <dt>申请人姓名：</dt>
    <dd><asp:Literal ID="lbluser_name" runat="server"></asp:Literal></dd>
  </dl> 

    <dl>
    <dt>申请人电话：</dt>
    <dd><asp:Literal ID="lbluser_tel" runat="server"></asp:Literal></dd>
  </dl>

   
    <dl >
    <dt>提交时间：</dt>
    <dd><asp:Literal ID="lbladd_time" runat="server"></asp:Literal></dd>
  </dl>

</div>
<!--/我的信息--> 
    </div>
    </form>
</body>
</html>

