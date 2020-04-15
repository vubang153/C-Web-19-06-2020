$.fn.datepicker.defaults.format = "dd/mm/yyyy";
$(document).ready(function () {
    $('.checkin_date, .checkout_date').datepicker({
        'format': 'd/m/yyyy',
        'autoclose': true
    });
});