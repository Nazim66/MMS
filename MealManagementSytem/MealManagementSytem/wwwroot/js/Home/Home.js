$(document).ready(function () {
    $("#txtTodaysMeal").prop('disabled', true);
    GetMealCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
        "ajax": {
            "url": "/Home/TodaysMeal",
            "dataSrc": ''
        },
        columnDefs: [
            {
                targets: 0,
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD')
            },
        ],
        "columns": [
            { "data": "date", "width": "15%" },
            { "data": "memberName", "width": "15%" },
            { "data": "memberId", "width": "15%", "visible": false },
            { "data": "lunch", "width": "15%" },
            { "data": "guestLunch", "width": "15%" },
            { "data": "dinner", "width": "15%" },
            { "data": "guestDinner", "width": "15%" }
        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});


function GetMealCalculation() {
    $.ajax({
        url: "/Home/MealCalculationForTodays",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#txtTodaysMeal').val(data);
        }
    });

}