var alertBox = {
    options: {
        'backdrop': 'static',
        'keyboard': true,
        'show': true,
        'focus': false
    },
    openAlertBox: function () {
        $("#alert-box-content").text("Bạn muốn huỷ lịch tour này ?");
        $("#alert-box").modal(this.options);
        $("#alert-box").modal("show");
    },
    closeAlertBox: function () {
        $("#alert-box").modal('close');
    },
    acceptAlertBox: function () {
        $("#btnAlertBoxAccept").on("click", function () {
            $("#alert-box").modal("hide");
            $("#loginForm").modal('show');
        })
    },
};
