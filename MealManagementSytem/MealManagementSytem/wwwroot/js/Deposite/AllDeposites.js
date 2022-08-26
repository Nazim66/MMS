﻿$(document).ready(function () {
    $("#totalDeposits").prop('disabled', true);
    GetDepositCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "ajax": {
            "url": "/Deposite/DepositedByAll",
            "dataSrc": ''
        },
        columnDefs: [
            {
                targets: 0,
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD'),
            }
        ],
        "columns": [

            { "data": "date", "width": "15%" },
            { "data": "memberName", "width": "15%" },
            { "data": "memberId", "width": "15%"},
            { "data": "amount", "width": "15%" },
            { "data": "depositeId", "width": "15%" },
        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});


function GetDepositCalculation() {

    $.ajax({
        url: "/Deposite/DepositCalculation",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#totalDeposits').val(data);
        }
    });

}

