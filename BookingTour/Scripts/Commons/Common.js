var list_page = ["booking",
    "tour",
    "user/profile",
    "booking/checkout",
    "user/order"];
const domain_string_length = 24;
var common = {
    init: function () {
        common.hideMainBanner(".hero-wrap");
        common.blankOrder();
    },
    hideMainBanner: function (element) {
        var address = window.location.href.substring(domain_string_length);
        var controller_name = "";
        if (address.includes("?")) {
            controller_name = address.substring(0, address.indexOf("?"));
        }
        else {
            controller_name = address;
        }
        controller_name = controller_name.toLowerCase();
        for (var i = 0; i < list_page.length; i++) {
            if (controller_name == list_page[i]) {
                $(element).css("display", "none");
            }
        }
    },
    blankOrder: function () {
        var x = $(".tab-content").children();
        for (i = 0; i < x.length; i++) {
            if (x[i].children.length < 1) {
                var id = "#" + x[i].id;
                $(id).append("<p style='text-align: center;line-height: 250px'>Không có tour nào</p>")
            }
        }
    },
    setSelectedOption: function (dom) {
        var list_select = $(".booking-state").get();
        for (var i = 0; i < list_select.length; i++) {
            var dom = $("#" + list_select[i].id);
            var domValue = dom.data("bind");
            var list_option = dom.children();
            for (var j = 0; j < list_option.length; j++) {
                if (domValue == list_option[j].value) {
                    var x = dom.find("option[value='" + list_option[j].value + "']");
                    x.attr("selected", "true");
                    break;
                }
            }
        }
    },
    resetSelectedOption: function () {

    }

}
common.init();
