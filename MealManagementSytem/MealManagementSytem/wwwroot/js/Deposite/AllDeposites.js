$(document).ready(function () {
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "ajax": {
            "url": "Deposite/IndividualDeposites",
            "dataSrc": ''
        },
        columnDefs: [
            {
                targets: 0,
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD'),
            },
            {
                target: 2,
                visible: false,
            },
        ],
        "columns": [

            { "data": "date", "width": "25%" },
            { "data": "memberId", "width": "25%", "visible": false },
            { "data": "amount", "width": "25%" }

        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});