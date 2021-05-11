<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedback_info.aspx.cs" Inherits="sysmanager_feedback_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看售后投诉建议</title>
 <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div class="mainindext">
<!--/我的信息-->
<div class="tab-content">

  <dl>  
    <dt>标题：</dt>
    <dd><asp:Literal ID="lbltitle" runat="server"></asp:Literal></dd>
  </dl> 

    <dl>
    <dt>单位：</dt>
    <dd><asp:Literal ID="lblco" runat="server"></asp:Literal></dd>
  </dl>

     <dl>
    <dt>地址：</dt>
    <dd><asp:Literal ID="lbladdress" runat="server"></asp:Literal></dd>
  </dl>

    <dl >
    <dt>内容：</dt>
    <dd><asp:Literal ID="lblcontent" runat="server"></asp:Literal></dd>
  </dl>
 
    <dl>  
    <dt>联系人：</dt>
    <dd><asp:Literal ID="lbluser_name" runat="server"></asp:Literal></dd>
  </dl> 

    <dl>
    <dt>电话：</dt>
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

