var common = {
    init: function () {
        common.selectState();
    },
    selectState: function () {
        var stateId = $("select[name='bookingState']");
        console.log(stateId);
    }
}
common.init();