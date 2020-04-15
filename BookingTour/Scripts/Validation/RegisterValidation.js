
$().ready(function () {
    var maxLengthInput = 20;
    var minLengthInput = 8;
    var emailMinLength = 12;
    var emailMaxLength = 50;
    var nameMinLength = 5;
    $("#registerForm").validate({
        rules: {
            username: {
                required: true,
                minlength: minLengthInput,
                maxlength: maxLengthInput
            },
            password: {
                required: true,
                minlength: minLengthInput,
                maxlength: maxLengthInput
            },
            rePassword: {
                equalTo: "#form-add-password",
                required: true,
            },
            name: {
                required: true,
                minlength: nameMinLength,
                maxlength: maxLengthInput
            },
            email: {
                required: true,
                email: true,
                minlength: emailMinLength,
                maxlength: emailMaxLength
            },
            DOB: {
                required: true,
            }
        },
        messages: {
            username: {
                required: "* Tên đăng nhập là bắt buộc",
                minlength: "* Tên đăng nhập phải dài hơn " + minLengthInput + " kí tự",
                maxlength: "* Tên đăng nhập không được quá " + maxLengthInput + " kí tự"
            },
            password: {
                required: "* Trường này là bắt buộc ",
                minlength: "* Mật khẩu phải dài hơn " + minLengthInput + " kí tự"
            },
            rePassword: {
                required: "* Trường này là bắt buộc",
                equalTo: " * Mật khẩu không khớp"
            },
            name: {
                required: "* Trường này là bắt buộc ",
                minlength: "* Tên phải dài hơn " + nameMinLength + " kí tự",
                maxlength: " Tên không được dài quá " + maxLengthInput + " kí tự"
            },
            email: {
                required: "* Trường này là bắt buộc",
                minlength: "* Email phải dài hơn " + emailMinLength + " kí tự",
                maxlength: "* Email không được quá " + maxLengthInput + " kí tự"
            },
            DOB: {
                required: "* Trường này là bắt buộc ",
            }
        }
    });

});
