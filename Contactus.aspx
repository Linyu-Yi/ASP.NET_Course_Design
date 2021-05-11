<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contactus.aspx.cs" Inherits="Contactus" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="end.ascx" tagname="end" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  	<title>AH礼券自助提货系统-联系我们</title>
		<meta http-equiv="keywords" content="">
		<meta http-equiv="description" content="">
		<link rel="stylesheet" type="text/css" href="image/index.css">
		<link rel="stylesheet" type="text/css" href="image/style.css">
		<link rel="stylesheet" type="text/css" href="image/hotel_geo.css">
		
		<!--[if gte IE 7]><!-->
		    <link rel="stylesheet" href="image/sp100.css">
		<!--<![endif]-->
		<!--[if lt IE 7]>
		    <link rel="stylesheet" href="images/default.css" />
		<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <uc1:top ID="top1" runat="server" />
    <div class="clear"></div>

			
<div class="left">
				<p><img src="image/lefttop.jpg"></p>
				<h1 style=" padding:0 0 0 25px; color:#34495e;font-weight: 100;">快速导航</h1>
				<ul>
					<li class="libg li1" onclick="window.location.href='identityLoad.aspx'">
						<strong class="nav1"></strong>
						<div>
							<a href="identityLoad.aspx">真伪查询</a>
							<span>check the authenticity</span>
						</div>
					</li>
					<li class="libg li2" onclick="window.location.href='putLoad.aspx'">
						<strong class="nav2"></strong>
						<div>
							<a href="putLoad.aspx">申请提货</a>
							<span>Apply for delivery</span>
						</div>
						<em class="embg"></em>
					</li>
					<li class="libg li3" onclick="window.location.href='orderInfoLoad.aspx'">
						<strong class="nav3"></strong>
						<div>
							<a href="orderInfoLoad.aspx">查询订单</a>
							<span>Query order</span>
						</div>
						<em class="embg"></em>
					</li>
					<li class="libg li4" onclick="window.location.href='helpList.aspx'" style="border: none; cursor: pointer;">
						<strong class="nav4"></strong>
						<div>
							<a href="helpList.aspx" style="color: rgb(255, 255, 255);">帮助中心</a>
							<span style="color: rgb(121, 135, 149);">Help center</span>
						</div>
						<em class="embg"></em>
					</li>
				</ul>
				<p><img src="image/leftbottom.jpg"></p>
			</div>

			<div class="rightcontact">
				<div class="right_title"><img src="image/contact_03.jpg"><span>联系我们</span></div>
				<div class="right_contact">
					<p><img src="image/intttop.jpg"></p>
					<div class="contactdiv">
						<h3 style="font-size:18px;">联系方式</h3>
                    <asp:Literal ID="LitContactus" runat="server"></asp:Literal>
					</div>
					<p><img src="image/inttbottom20.jpg"></p>
				</div>
				<div class="right_contact">
					<p><img src="image/intttop.jpg"></p>
					<div class="contactdiv" style="background-image:none;">
						<h3 style="font-size:18px;">公司位置：</h3>
						<h4>
    <!--引用百度地图API-->
<style type="text/css"> 
    html,body{margin:0;padding:0;}
    .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
    .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
</style>
<script type="text/javascript" src="http://api.map.baidu.com/api?key=&v=1.1&services=true"></script>
 <div style="width:570px;height:400px;border:#ccc solid 1px;" id="dituContent"></div>
 
<script type="text/javascript">
    //创建和初始化地图函数：
    function initMap() {
        createMap(); //创建地图
        setMapEvent(); //设置地图事件
        addMapControl(); //向地图添加控件
        addMarker(); //向地图中添加marker
    }

    //创建地图函数：
    function createMap() {
        var map = new BMap.Map("dituContent"); //在百度地图容器中创建一个地图
        var point = new BMap.Point(121.61478, 29.911596); //定义一个中心点坐标
        map.centerAndZoom(point, 14); //设定地图的中心点和坐标并将地图显示在地图容器中
        window.map = map; //将map变量存储在全局
    }

    //地图事件设置函数：
    function setMapEvent() {
        map.enableDragging(); //启用地图拖拽事件，默认启用(可不写)
        map.enableScrollWheelZoom(); //启用地图滚轮放大缩小
        map.enableDoubleClickZoom(); //启用鼠标双击放大，默认启用(可不写)
        map.enableKeyboard(); //启用键盘上下左右键移动地图
    }

    //地图控件添加函数：
    function addMapControl() {
        //向地图中添加缩放控件
        var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map.addControl(ctrl_nav);
    }

    //标注点数组
    var markerArr = [{ title: "宁波市AH水产有限公司", content: "地址：浙江省宁波市江北区路林市场风华路171-173号", point: "121.61478|29.911596", isOpen: 1, icon:

{ w: 23, h: 25, l: 46, t: 21, x: 9, lb: 12 }
    }
		 ];
    //创建marker
    function addMarker() {
        for (var i = 0; i < markerArr.length; i++) {
            var json = markerArr[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var point = new BMap.Point(p0, p1);
            var iconImg = createIcon(json.icon);
            var marker = new BMap.Marker(point, { icon: iconImg });
            var iw = createInfoWindow(i);
            var label = new BMap.Label(json.title, { "offset": new BMap.Size(json.icon.lb - json.icon.x + 10, -20) });
            marker.setLabel(label);
            map.addOverlay(marker);
            label.setStyle({
                borderColor: "#808080",
                color: "#333",
                cursor: "pointer"
            });

            (function () {
                var index = i;
                var _iw = createInfoWindow(i);
                var _marker = marker;
                _marker.addEventListener("click", function () {
                    this.openInfoWindow(_iw);
                });
                _iw.addEventListener("open", function () {
                    _marker.getLabel().hide();
                })
                _iw.addEventListener("close", function () {
                    _marker.getLabel().show();
                })
                label.addEventListener("click", function () {
                    _marker.openInfoWindow(_iw);
                })
                if (!!json.isOpen) {
                    label.hide();
                    _marker.openInfoWindow(_iw);
                }
            })()
        }
    }
    //创建InfoWindow
    function createInfoWindow(i) {
        var json = markerArr[i];
        var iw = new BMap.InfoWindow("<b class='iw_poi_title' title='" + json.title + "'>" + json.title + "</b><div class='iw_poi_content'>" + json.content + "</div>");
        return iw;
    }
    //创建一个Icon
    function createIcon(json) {
        var icon = new BMap.Icon("http://openapi.baidu.com/map/images/us_mk_icon.png", new BMap.Size(json.w, json.h), { imageOffset: new BMap.Size(-json.l, -

json.t), infoWindowOffset: new BMap.Size(json.lb + 5, 1), offset: new BMap.Size(json.x, json.h)
        })
        return icon;
    }

    initMap(); //创建和初始化地图
</script>
                        
                        </h4>
					</div>
					<p><img src="image/inttbottom20.jpg"></p>
				</div>
			</div>
		</div>
		<!--main end-->
    <uc2:end ID="end1" runat="server" />
    
		<script language="javascript" type="text/javascript" src="image/jquery-1.9.1.js"></script>
		<script language="javascript" type="text/javascript" src="image/index.js"></script>

    </form>
</body>
</html>
