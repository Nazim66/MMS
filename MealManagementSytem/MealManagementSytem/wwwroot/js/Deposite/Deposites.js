$(document).ready(function () {
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "ajax": {
            "url": "Deposite/IndividualDeposites",
            "dataSrc": ''
        },
        columnDefs: [{
            targets: 0,
            render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD')
        }],
        "columns": [
           
            { "data": "date", "width": "15%" },
            { "data": "memberId", "width": "15%" },
            { "data": "amount", "width":"15%" }
            
        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});


function showPopup() {

    $("#popupDiv").dialog({
        width: 400,
        height: 450,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });
}

function closePopup() {
    $("#popupDiv").dialog('close');
}


