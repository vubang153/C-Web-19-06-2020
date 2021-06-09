var tourModel = {
    init: function () {
        this.checkAndBooking();
    },
    bookingTour: function () {
    },
    check: function () {
        var result = 2;
        $.ajax({
            url: "/Tour/SessionChecking",
            dataType: "json",
            type: "POST",
            async: false,
            success: function (res) {
                result = res.result;
            }
        });
        return result;
    },
    checkAndBooking: function () {
        $("#btnBookTour").on("click", function (e) {
            e.preventDefault();
            if (tourModel.check() == 1) {
                window.open(this.href);
            }
            else {
                alertBox.openAlertBox("Bạn cần đăng nhập trước khi đặt tour");
            }
        })
    },

};
tourModel.init();