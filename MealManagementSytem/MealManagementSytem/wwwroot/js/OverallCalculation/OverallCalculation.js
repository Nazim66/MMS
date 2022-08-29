$(document).ready(function () {
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
        "ajax": {
            "url": "/OverallCalculation/OverallCalculationByAll",
            "dataSrc": ''
        },
        columnDefs: [
            {
                targets: 0,
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD'),
            },

        ],
        "columns": [

        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});