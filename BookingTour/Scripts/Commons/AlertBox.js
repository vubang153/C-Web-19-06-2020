var alertBox = {
    init: function () {
        alertBox.acceptAlertBox();
    },
    options: {
        'backdrop': 'static',
        'keyboard': true,
        'show': true,
        'focus': false
    },
    resetButtons: function () {
        $("#btnAlertBoxAccept").css('display', 'inline-block');
    },
    openAlertBox: function (content, type = 1) {
        alertBox.resetButtons();
        if (type == 0) {
            $("#btnAlertBoxAccept").css('display', 'none');
        }
        $("#alert-box-content").text(content);
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
alertBox.init();
