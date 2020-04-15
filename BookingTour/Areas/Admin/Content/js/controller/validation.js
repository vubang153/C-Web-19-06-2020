
/*$.validator.setDefaults({
    submitHandler: function () {
        alert("submitted!");
    }
});*/

$().ready(function () {
    $("#FormAddNewUser").validate({
        rules: {
            name: "required",
            username: {
                required: true,
                minlength: 8
            },
            password: {
                required: true,
                minlength: 8
            },
            email: {
                required: true,
                email: true
            },
            address: {
                required: true,
            },
            districtID: {
                required: true
            },
            provinceID: {
                required: true
            },
            DOB: {
                required: true,
                date: true
            }
        },
        messages: {
            name: "* Mời nhập tên",
            username: {
                required: "* Tên đăng nhập là bắt buộc",
                minlength: "* Tên đăng nhập phải dài hơn 8 kí tự"
            },
            password: {
                required: "* Mật khẩu là bắt buộc",
                minlength: "* Mật khẩu phải dài hơn 8 kí tự"
            },
            email: {
                required: "* Email là bắt buộc",
            },
            address: {
                required: "* Mời nhập địa chỉ"
            },
            districtID: {
                required: " * Mục này là bắt buộc"
            },
            provinceID: {
                required: "* Mục này là bắt buộc"
            },
            DOB: {
                required: " * Mục này là bắt buộc",
                date: "* Mời nhập đúng định đạng ngày tháng"
            }
        }
    });

});
