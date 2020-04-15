var loginModel = {
    init: function () {

    },
    addSession: function (username) {
        $.ajax({
            url: "/User/AddSession",
            data: {
                username: username,
            },
            dataType: "json",
            type: "POST",
            success: function (res) {
                location.reload();
            }
        });
    },
    authenication: function () {
        var txtUsername = $("#username").val();
        var txtPassword = $("#password").val();
        var rememberMe = ($("#rememberMe:checked").length > 0) ? true : false;

        $.ajax({
            url: "/User/Login",
            data: {
                username: txtUsername,
                password: txtPassword,
                rememberMe: rememberMe
            },
            dataType: "json",
            type: "POST",
            success: function (res) {
                var result = res.result;
                var error_string;
                if (result != 1) {
                    if (result == -1) {
                        error_string = "Sai tài khoản hoặc mật khẩu";
                    }
                    if (result == -2) {
                        error_string = "Tài khoản đã bị khoá";
                    }
                    if (result == -3) {
                        error_string = "Tài khoản chưa được kích hoạt"
                    }
                    if (result == -5) {
                        error_string = "Tài khoản không tồn tại";
                    }
                    $("#password").after("<label class='error'>* " + error_string + "</label>");
                }
                else {
                    loginModel.addSession(txtUsername);
                }
            }
        });
    }
}