/// <reference path="bootstrap-editable.min.js" />
var view_map = 215;
var viewheight = $(window).height();
$(".before-map").css("height", viewheight - view_map);
$(".MainContent").css("height", viewheight - view_map);
$(".Menu").css("height", viewheight - view_map);
$(window).resize(function () {          //当浏览器大小变化时
    var viewheight = $(window).height();
    $(".MainContent").height(viewheight - view_map);
    $(".Menu").height(viewheight - view_map);
});

//测站搜索
var marker; var label;
function search() {
    var a = document.getElementById("stationSearch").value;
    document.getElementById("stationSearch").value = "";
    var B = 10; L = 108.3548;
    var ii;
    var afstn = fstn + "," + tsn;
    var afstns = new Array();
    afstns = afstn.split(",");
    var afstlat = fstlat + "," + tslat;
    var afstlats = new Array();
    afstlats = afstlat.split(",");
    var afstlon = fstlon + "," + tslon;
    var afstlons = new Array();
    afstlons = afstlon.split(",");
    for (ii = 0; ii < afstlons.length; ii++) {
        if (a == afstns[ii]) {
            B = afstlats[ii];
            L = afstlons[ii];
            break;
        }
    }
    if (B != 10) {

        map.removeOverLay(marker);
        map.centerAndZoom(new TLngLat(L, B), 12);
        //var winHtml = "站名：" + a + "<br>纬度：" + B + "<br>经度" + L;
        var winHtml = a;
        var lnglat = new TLngLat(L, B);
        marker = new TMarker(lnglat);
        var infoWin = new TInfoWindow(lnglat, new TPixel([0, 0]));
        //infoWin.setLabel("站名：" + a + "<br>纬度：" + Math.round(B * 10000) / 10000 + "<br>经度：" + Math.round(L * 10000) / 10000);
        infoWin.setLabel(a);
        map.addOverLay(infoWin);
        map.addOverLay(marker);
    }
}
//生成二维码
function makeCode() {
    var qrcode = new QRCode(document.getElementById("qrcode"), {
        width: 300,
        height: 300
    });
    var url = "http://qm.qq.com/cgi-bin/qm/qr?k=6wiJfyhYg6bJL3jF5vBlodESi_8w4rvu";
    qrcode.makeCode(url);
}
$("#qrimg_s").click(
  function () {
      var html = '<div id="qrcode"></div>';
      parent.layer.open({
          type: 1,
          title: "江苏省CORS群",
          skin: 'layui-layer-rim', //加上边框
          //area: ['512', '600'], //宽高
          content: html
      });
      makeCode();
  });


function makeCode1() {
    var qrcode = new QRCode(document.getElementById("qrcode"), {
        width: 300,
        height: 300
    });
    var url = window.location.origin + "/apk/NNCORS.apk";
    qrcode.makeCode(url);
}
$("#NN_APP").click(
  function () {
      var html = '<div id="qrcode"></div>';
      parent.layer.open({
          type: 1,
          title: "APP下载",
          skin: 'layui-layer-rim', //加上边框
          //area: ['512', '600'], //宽高
          content: html
      });
      makeCode1();
  });

//侧边栏点击事件
$("#slide-link-btn").click(function () {
    //缩进去了
    if ($(".slide-get-in").length > 0) {
        $(".slide-bar").removeClass("slide-bar-in");
        $(".sidebar-toggle-btn").removeClass("slide-get-in");
        $(".main-map").removeClass("main-map-big");
        $(".right").removeClass("right-big");
        setTimeout(function () { $(".slide-body").removeClass("hidden"); }, 900);
    }
        //显示在外面的
    else {
        $(".slide-bar").addClass("slide-bar-in");
        $(".sidebar-toggle-btn").addClass("slide-get-in");
        $(".main-map").addClass("main-map-big");
        $(".right").addClass("right-big");
        $(".slide-body").addClass("hidden");
    }
});

$("#initial_location").click(function () {
    map.centerAndZoom(new TLngLat(110, 22.2), 8);
});

$(".ionoProduct").click(function () {
    parent.layer.open({
        type: 2,
        title: '电离层预报柱状图',
        shadeClose: true,
        shade: 0.8,
        area: ['60%', '500px'],
        content: '../forms/publicforms/IonoChart.aspx' //iframe的url
    });
}
);

