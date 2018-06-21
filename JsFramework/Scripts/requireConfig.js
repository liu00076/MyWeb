require.config({
    "paths": {
        //ArtDialog弹出层
        "dialog-plus": "/Scripts/common/dialog-plus",
        "dialog-doc": "/Scripts/artDialog/artDialog-doc",
        
        "jquery-ui": "/Scripts/common/jquery-ui",

        //图片压缩模块
        "compress": "/Scripts/imgMoudle/compress",
        "jquery": "/Scripts/common/jquery-2.2.3",
        "commonHelper": "/Scripts/helper/commonHelper"
    },
    "shim": {
        "jquery-ui": ["jquery"],
        "dialog-plus": ["jquery"],
        "dialog-doc": ["jquery", "dialog-plus"]
    }
});
//如果配置baseUrl，默认加载JS路径： baseUrl + paths
//如果1、以 ".js" 结束.2、以 "/" 开始.3.包含 URL 协议 
//其ID解析会避开常规的"baseUrl + paths"配置，而是直接将其加载为一个相对于当前位置