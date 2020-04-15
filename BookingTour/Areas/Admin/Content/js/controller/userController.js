var userModel = {
    init: function () {
        userModel.registerEvents();
        userModel.editUser();
        userModel.addDistrictToForm();
        userModel.datePicker();
    },
    datePicker: function () {
        $(".form-DOB").datepicker({
            dateFormat: "dd-mm-yy"
        });
    },
    addDistrictToForm: function () {
        var districtSelectedFormId;
        $(".districtSelectedForm").mouseenter(function () {
            districtSelectedFormId = this.id;
        });
        $('.districtSelectedForm').change(function () {
            var id = $("#" + districtSelectedFormId + " option:selected").val();
            userModel.getDistrictByProvinceID(id);
        });
    },
    getDistrictByProvinceID: function (s_id, provinceID = 0) {
        $.ajax({
            url: "/Admin/District/getDistrictByProvinceID",
            data: { id: s_id },
            dataType: "json",
            type: "POST",
            success: function (res) {
                var list_district = res.list_district;
                $(".provinceSelectedForm").children().not(':first').remove();
                for (var i = 0; i < list_district.length; i++) {
                    if (list_district[i].id == provinceID) {
                        $(".provinceSelectedForm").append("<option selected value=" + list_district[i].id + ">" + list_district[i].name + "</option>");
                    }
                    else {
                        $(".provinceSelectedForm").append("<option value=" + list_district[i].id + ">" + list_district[i].name + "</option>");
                    }
                }
            }
        });
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == 1) {
                        btn.text('Kích hoạt');
                    }
                    else {
                        btn.text('Khoá');
                    }
                }
            });
        });
    },
    setUser: function (user) {
        $("#username").val(user.username);
        $("#password").val(user.password);
        $("#address").val(user.address);
        $("#name").val(user.name);
        $("#address").val(user.address);
        $("#DOB").val(user.DOB);
        $("#id").val(user.id);
        /* $("#id").val(id);*/
        $("#email").val(user.email);
    },
    editUser: function () {
        $('.edit-button').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/getViewDetail",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    var user = response.user;
                    var date = new Date(parseInt(user.DOB.substr(6)));
                    user.DOB = userModel.formatDate(date);
                    userModel.setUser(user);
                    //
                    userModel.checkedGenderRadio(user);
                    // checked district select
                    
                    // checked province select
                    var arrOption = $("#edit-districtSelectedForm").children();
                    arrOption.removeAttr("selected");
                    userModel.checkedOptionByValue("#edit-districtSelectedForm", user.districtID);
                    userModel.getDistrictByProvinceID(user.districtID, user.provinceID);
                    /*userModel.checkedOptionByValue("#edit-provinceSelectedForm", user.provinceID);*/
                }
            });
        });

    },
    checkedGenderRadio: function (user) {
        if (user.gender == $("#male-gender").val()) {
            $("#male-gender").attr("checked", "");
        }
        else {
            $("#female-gender").attr("checked", "");
        }
    },
    formatDate: function (date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [year, month, day].join('/');
    },
    checkedOptionByValue: function (dom, value) {
        $(dom).find("option[value=" + value + "]").prop("selected", true);
    }
}
// Hàm convert date time to YYYYMMDD
userModel.init();
