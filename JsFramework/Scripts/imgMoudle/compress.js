define(["jquery"], function ($) {
    return function (opt) {
        var compress = {
            defaultOpt: {
                'scale': 0.5, //设置压缩比
                'maxRate': 3 / 4, //图片最大比率
                'minRate': 1 / 2, //图片最小比率
                'limtSize': 4, //大小限制,以M为单位
                'maxNum': 50, //图片数量限制
                'fileId': 'fileId' //input type=file 的Id
            },
            init: function(opt) {
                $.extend(this.defaultOpt, opt);
                document.getElementById(this.defaultOpt.fileId).onchange = this.fileHandler;
                var canvas = document.getElementById('_canvas');
                if (canvas == undefined) {
                    $('body').append($('<canvas id="_canvas" style="display: none;"></canvas>'));
                };
                //返回图片压缩对象
                return compress;
            },
            fileHandler: function(e) {
                var me = compress;
                me.Files = $(this)[0].files;
                for (var i = 0; i < $(this)[0].files.length; i++) {
                    me.bllService($(this)[0].files[i], me.callBack);
                }
            },
            //业务逻辑
            bllService: function(file, callback) {
                var me = compress;
                //if (me.defaultOpt.limtSize != undefined) {
                //    if (file.size / (1024 * 1024) > me.defaultOpt.limtSize) {
                //        alert("图片" + file.name + "超出大小限制" + me.defaultOpt.limtSize + "M，请更换图片");
                //        return;
                //    }
                //};
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function(e) {
                    var base64Img = e.target.result;
                    var image = new Image();
                    image.src = base64Img;
                    //if (me.defaultOpt.maxNum != undefined && isNaN(me.defaultOpt.maxNum)) {
                    //    alert("上传图片超出最大限定值" + me.defaultOpt.maxNum);
                    //    return;
                    //};
                    //if (!(image.width > 600 || image.height > 600)) {
                    //    alert("图片" + file.name + "单边尺寸不符合600px的最低尺寸要求，无法进行上传，请更换图片");
                    //    return;
                    //};
                    ////图片的宽高比率
                    //var originalRate = image.height / image.width;
                    //if (me.defaultOpt.minRate != undefined && originalRate < me.defaultOpt.minRate) {
                    //    alert("图片小于最小比率值：" + me.defaultOpt.minRate);
                    //    return;
                    //};
                    //if (me.defaultOpt.minRate != undefined && originalRate > me.defaultOpt.maxRate) {
                    //    alert("图片大于最大比率值：" + me.defaultOpt.maxRate);
                    //    return;
                    //}
                    //压缩图片
                    if (me.defaultOpt.scale != undefined && isNaN(me.defaultOpt.scale)) {
                        var canvas = document.getElementById('_canvas');
                        canvas.width = image.width;
                        canvas.height = image.height;
                        var context = canvas.getContext('2d');
                        context.drawImage(image, 0, 0);
                        base64Img = canvas.toDataURL(file.type, me.defaultOpt.scale);
                    };
                    if (callback) {
                        callback(file, base64Img);
                    }
                };
            },
            //将base64位的数据添加到数组中
            callBack: function(file, base64String) {
                var me = compress;
                me.result.push(file.name + "|" + base64String);
            },
            result: []
        };

        compress.init(opt);

        return compress;
    }
});
