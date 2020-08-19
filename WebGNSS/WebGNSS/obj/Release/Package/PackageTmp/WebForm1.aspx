﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebGNSS.WebForm1" %>


<!doctype html> <html lang="en"> <head> <title>评鉴通 - UI</title> <meta charset="utf-8"> <link href="https://www.benbenla.com/pui/css/commons.chunk.css?ed62d381b07023f4c212&ed62d381b07023f4c212" rel="stylesheet"><script type="text/javascript" src="./js/commons.bundle.js?ed62d381b07023f4c212&ed62d381b07023f4c212"></script><script type="text/javascript" src="./js/page.bundle.js?ed62d381b07023f4c212&ed62d381b07023f4c212"></script><script type="text/javascript" src="./js/vendor.bundle.js?ed62d381b07023f4c212&ed62d381b07023f4c212"></script></head> <body> <div class="pui-menu"> <div class="inner bgc-white" id="innerMenu"> <div class="pui-logo"> <h1 class="pui-title c-primary ffm ant">评鉴通 UI （PUI）</h1> <h6 class="pui-subtitle ffm fs fnormal ant c-gray3">基于 jquery 平台</h6> <div class="sp10"></div> <div class="sp10"></div> </div> <ul class="component-list ffm fb"> <li class="tc"><a href="pui-layout.html" class="c-gray5 ant">布局</a></li> <li class="tc"><a href="pui-form.html" class="c-gray5 ant">表单</a></li> <li class="tc"><a href="pui-fonts.html" class="c-gray5 ant">字体</a></li> <li class="tc"><a href="pui-ceng.html" class="c-gray5 ant">弹层</a></li> <li class="tc"><a href="pui-valid.html" class="c-gray5 ant">验证</a></li> <li class="tc cur"><a href="pui-page.html" class="c-gray5 ant">分页</a></li> <li class="tc"><a href="pui-tab.html" class="c-gray5 ant">标签页</a></li> <li class="tc"> <a href="pui-popop.html" class="c-gray5 ant">气泡</a></li> <li class="tc"><a href="pui-calendar.html" class="c-gray5 ant">日历</a></li> <li class="tc"><a href="pui-table.html" class="c-gray5 ant">表格</a></li> <li class="tc"><a href="pui-tree.html" class="c-gray5 ant">树形</a></li> <li class="tc"><a href="pui-css.html" class="c-gray5 ant">CSS</a></li> </ul> </div> </div> <div class="pui-body"> <div class="content"> <h2 class="pui-category c-red fnormal fs20 ffm">分页（pui.page.js）</h2> <div class="sp50"></div> <div class="pagination" id="pageDemo"></div> <div class="sp10"></div> <pre><code class="language-javascript">
$('#pageDemo').pager({
    totalItem: 111,     // 总条目
    pageSize: 10,       // 每页大小
    pageIndex: 1,       // 当前页
    singlePage: false,  // 此属性仅作用在单页翻页切换场景
    action: function(pi, ps) {
        ceng.msg('pageIndex： ' + pi + '，pageSize： ' + ps);
    }
});
</code></pre> <div class="sp30"></div> </div> </div> </body> </html> 