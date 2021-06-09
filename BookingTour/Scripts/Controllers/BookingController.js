var bookingModel = {
    init: function () {
        bookingModel.checkRuleAndPayment();
        bookingModel.choosePayments();
        bookingModel.changeState();
    },
    check: function () {
        $.ajax({
            data: {
            },
            async: false,
            dataType: "json",
            method: "POST",
            url: "Booking/Checking",
            success: function (res) {
                console.log(res);
            }
        });
    },
    checkRuleAndPayment: function () {
        $("#payment_form").submit(function (e) {
            e.preventDefault();
            var payments = $("input[name='payment']:checked").val();
            var rule_accept = $("input[name='rule']:checked").val();
            var tourId = $("#tour_id").text();
            var result = -1;
            if (payments == undefined || rule_accept == undefined) {
                if (payments == undefined) {
                    alertBox.openAlertBox("Vui lòng chọn hình thức thanh toán", 0);
                }
                if (rule_accept == undefined) {
                    alertBox.openAlertBox("Bạn cần đồng ý với các điều khoản", 0);
                }
            }
            else {
                result = 1;
            }

            if ($("#cash_on_account").prop("checked") == 1) {
                if (bookingModel.getBlance() < 0) {
                    alertBox.openAlertBox("Số tiền hiện tại trong tài khoản không đủ xin vui lòng nạp thêm", 0);
                    result = -1;
                }
            }
            if (result == 1) {
                if (bookingModel.addTourToCart(tourId, payments) == 1) {
                    location.href = "Booking/Checkout";
                }
                else {
                    alertBox.openAlertBox("Có lỗi xảy ra vui lòng thử lại sau", 0);
                }
            }
        })
    },
    choosePayments: function () {
        if (bookingModel.getBlance() < 0) {
            $("input[name='payment']").click(function () {
                $("#blance_not_enough").toggleClass("d-none", bookingModel.checkBlance());
            });
        };
    },
    checkBlance: function () {
        var this_val = $("input[name='payment']:checked").val();
        var result = this_val == 1 ? false : true;
        return result;
    },
    getBlance: function () {
        return $("#blance_not_enough").attr("data-value");
    },
    addTourToCart: function (id, payments) {
        var result = 0;
        $.ajax({
            url: "/Booking/AddToCart",
            data: {
                id: id,
                payments: payments,
            },
            async: false,
            dataType: "json",
            type: "POST",
            success: function (res) {
                result = res.result;
            }
        });
        return result;
    },
    changeState: function () {
        $(".booking-state").on("change", function () {
            console.log("ec ec");
            var id = this.id;
            var dataBind = $("#" + id).data("bind");
            var value = this.value;
            if (dataBind != 4 && dataBind != 3) {
                if (value > dataBind) {
                    $.ajax({
                        url: "/Admin/Booking/ChangeState",
                        data: {
                            id: id,
                            value: value,
                        },
                        dataType: "json",
                        type: "POST",
                        async: false,
                        success: function (res) {
                            result = res.result;
                            console.log(result);
                            if (result) {
                                alert("Đổi trạng thái đơn hàng thành công");
                            }
                            else {
                                alert("Có lỗi xảy ra vui lòng thử lại");
                            }
                        }
                    });
                }
                else {
                    alert("Không thể đổi trạng thái");
                    location.reload();
                }
            }
            else {
                alert("Không thể đổi trạng thái");
                location.reload();



            }

        })
    }

}
bookingModel.init();
