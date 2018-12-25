define([], function() {
    var timehelper = {};
    Date.prototype.format = function (fmt) {
        //author: meizz 
        var o =
         {
             "M+": this.getMonth() + 1, //月份 
             "d+": this.getDate(), //日 
             "h+": this.getHours(), //小時 
             "m+": this.getMinutes(), //分 
             "s+": this.getSeconds(), //秒 
             "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
             "S": this.getMilliseconds() //毫秒 
         };
        if (/(y+)/.test(fmt))
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt))
                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    }


    Date.prototype.addDays = function (d) {
        this.setDate(this.getDate() + d);
    };


    Date.prototype.addWeeks = function (w) {
        this.addDays(w * 7);
    };


    Date.prototype.addMonths = function (m) {
        var d = this.getDate();
        this.setMonth(this.getMonth() + m);

        if (this.getDate() < d)
            this.setDate(0);
    };
    timehelper.daysBetween = function (DateOne, DateTwo) {
        var OneMonth = DateOne.substring(5, DateOne.lastIndexOf('-'));
        var OneDay = DateOne.substring(DateOne.length, DateOne.lastIndexOf('-') + 1);
        var OneYear = DateOne.substring(0, DateOne.indexOf('-'));

        var TwoMonth = DateTwo.substring(5, DateTwo.lastIndexOf('-'));
        var TwoDay = DateTwo.substring(DateTwo.length, DateTwo.lastIndexOf('-') + 1);
        var TwoYear = DateTwo.substring(0, DateTwo.indexOf('-'));

        var cha = ((Date.parse(OneMonth + '/' + OneDay + '/' + OneYear) - Date.parse(TwoMonth + '/' + TwoDay + '/' + TwoYear)) / 86400000);
        return Math.abs(cha);
    }
    timehelper.parseDate = function (str) {
        if (str instanceof Date) {
            return str;
        }
        if (typeof str == 'string') {
            var results = str.match(/^ *(\d{4})(\d{2})(\d{2}) *$/);
            if (results && results.length > 3)
                return new Date(parseInt(results[1], 10), parseInt(results[2], 10) - 1, parseInt(results[3], 10));
            results = str.match(/^ *(\d{4})(\d{2})(\d{2})(\d{2})(\d{2})(\d{2}) *$/);
            if (results && results.length > 6)
                return new Date(parseInt(results[1], 10), parseInt(results[2], 10) - 1, parseInt(results[3], 10), parseInt(results[4], 10), parseInt(results[5], 10), parseInt(results[6], 10));
            results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) *$/);
            if (results && results.length > 3)
                return new Date(parseInt(results[1], 10), parseInt(results[2], 10) - 1, parseInt(results[3], 10));
            results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) +(\d{1,2}):(\d{1,2}) *$/);
            if (results && results.length > 5)
                return new Date(parseInt(results[1], 10), parseInt(results[2], 10) - 1, parseInt(results[3], 10), parseInt(results[4], 10), parseInt(results[5], 10));
            results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) +(\d{1,2}):(\d{1,2}):(\d{1,2}) *$/);
            if (results && results.length > 6)
                return new Date(parseInt(results[1], 10), parseInt(results[2], 10) - 1, parseInt(results[3], 10), parseInt(results[4], 10), parseInt(results[5], 10), parseInt(results[6], 10));
            results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) +(\d{1,2}):(\d{1,2}):(\d{1,2})\.(\d{1,9}) *$/);
            if (results && results.length > 7)
                return new Date(parseInt(results[1], 10), parseInt(results[2], 10) - 1, parseInt(results[3], 10), parseInt(results[4], 10), parseInt(results[5], 10), parseInt(results[6], 10), parseInt(results[7], 10));
        }
        return null;
    }
    timehelper.TimeDiffirence = function (startTime, endTime) {
        var diffDetail = {};

        try {
            var date1 = this.getObjectType(startTime) == "date" ? startTime : this.parseDate(startTime);
            var date2 = this.getObjectType(endTime) == "date" ? endTime : this.parseDate(endTime);
            //毫秒差
            diffDetail.msDiff = date2.getTime() - date1.getTime();
            //分鐘差
            diffDetail.minutesDiff = Math.floor(diffDetail.msDiff / (60 * 1000));
            //小時差
            diffDetail.hoursDiff = Math.floor(diffDetail.minutesDiff / 60);
            //天數差
            diffDetail.daysDiff = Math.floor(diffDetail.hoursDiff / 24);

        } catch (e) { }

        return diffDetail;
    }
    //判斷變量類型
    timehelper.getObjectType = function (o) {
        var _t;
        return ((_t = typeof (o)) == "object" ? Object.prototype.toString.call(o).slice(8, -1) : _t).toLowerCase();
    }
    timehelper.changeTimeInput = function (selector, selector2) {
        var timestr1 = selector.val();
        var timestr2 = selector2.val();
        if (timestr1 && timestr2 && (timehelper.parseDate(timestr1) > timehelper.parseDate(timestr2))) {
            selector.val(timestr2);
            selector2.val(timestr1);
        }
    }

    return timehelper;
})