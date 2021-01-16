$(document).ready(function () {
    $('#datepicker').datepicker({
        showOptions: { speed: 'fast' },
        changeMonth: false,
        changeYear: false,
        dateFormat: 'dd/mm/yy',
        gotoCurrent: true
    });
    $('#timepicker').timepicker();
});  