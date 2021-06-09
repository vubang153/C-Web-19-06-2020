var OrderController = {
    init: function () {
        this.cancelOrder();
    },
    cancelOrder: function () {
        $(".cancel-order").on("click", function (e) {
            e.preventDefault();
            var id = this.dataset.bind;
            alertBox.openAlertBox();
            $("#btnAlertBoxAccept").on("click", function () {
                $.ajax({
                    url: "/Booking/CancelOrder",
                    data: {
                        id: id
                    },
                    dataType: "json",
                    type: "POST",
                    async: false,
                    success: function (res) {
                        result = res.result;
                        console.log(result);
                    }
                });
                location.reload();
            })

        })
    }
}
OrderController.init();
