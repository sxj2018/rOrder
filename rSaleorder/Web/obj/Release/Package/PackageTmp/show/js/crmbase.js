Date.prototype.format = function (format) {
    /*
    * eg:format="YYYY-MM-dd hh:mm:ss";
    */
    var o = {
        "M+": this.getMonth() + 1,  //month
        "d+": this.getDate(),     //day
        "h+": this.getHours(),    //hour
        "m+": this.getMinutes(),  //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
};
FormatStringDate = function (strJsonDate) {
    ///	<summary>
    ///	格式化时间方法 用以格式化"/Date(1333900800000)/"字符串的时间 为 yyyy-MM-dd类型
    ///	</summary>
    if (strJsonDate != null && strJsonDate.length != 0) {
        var d = strJsonDate.replace("/Date(", "");
        d = parseInt(d.replace(")/", ""));
        return (new Date(d)).format("yyyy-MM-dd");
    }
    return "";
};
ExcuteStatus = function (iostatus) {
    var IoStatus = "";
    if (iostatus == null || iostatus == "" || iostatus == "0") {
        IoStatus = "未执行";
    } else if (iostatus=="1") {
        IoStatus = "执行中";
    } else if (iostatus == "2") {
        IoStatus = "执行完毕";
    } else if (iostatus == "3") {
        IoStatus = "已终止";
    }
    return "<span style='color:green;' >"+ IoStatus+"</span>";
};
FormatOrderStatus = function (iostatus) {
    var IoStatus = "";
    if (iostatus == null || iostatus == "" || iostatus == "0") {
        IoStatus = "未提交";
    } else if (iostatus == "1") {
        IoStatus = "待审核";
    } else if (iostatus == "2") {
        IoStatus = "审核通过";
        IoStatus= "<span style='color:green;' >" + IoStatus + "</span>";
    } 
    return IoStatus;
};
function getRows(tableid,table) {
    var checkStatus = table.checkStatus(tableid);
    return checkStatus.data;
}

function getparms(rscope) {
    var parms = {};
    $("input", rscope).each(function () {
        var issearinp = $(this).attr("searfield");
        if (issearinp) {
            var name = $(this).attr("name");
            if (name != null && name != "") {
                var inpval = $(this).val();
                parms[name] = inpval;
            }
        }
    });
    return parms;

}