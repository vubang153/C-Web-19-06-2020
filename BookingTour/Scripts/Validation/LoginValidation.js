
$().ready(function () {
    $("#formLogin").submit(function (e) {
        e.preventDefault();
    }).validate({
        rules: {
            username: {
                required: true,
                minlength: 8
            },
            password: {
                required: true,
                minlength: 8
            }
        },
        messages: {
            username: {
                required: "* Tên đăng nhập là bắt buộc",
                minlength: "* Tên đăng nhập phải dài hơn 8 kí tự"
            },
            password: {
                required: "* Mật khẩu là bắt buộc",
                minlength: "* Mật khẩu phải dài hơn 8 kí tự"
            }
        },
        submitHandler: function (form) { // <- pass 'form' argument in
            loginModel.authenication();
        }
    });

});
