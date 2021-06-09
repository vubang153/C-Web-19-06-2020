var tourModel = {
    init: function () {
        tourModel.changeStatus();
    },
    changeStatus: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Tour/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == 1) {
                        btn.text('Mở');
                    }
                    else {
                        btn.text('Đóng');
                    }
                }
            });
        });
    },
};
tourModel.init();