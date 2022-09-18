$(document).ready(function () {
    $("#totalIndividualDeposits").prop('disabled', true);
    GetIndividualDepositCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
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

            { "data": "date", "width": "5%" },
            { "data": "amount", "width": "5%" },
            { "data": "memberId", "width": "5%", "visible": false },

        ],
        dom: 'Bfrtip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});

var count = 0;
function showPopup() {

    $("#popupDiv").dialog({
        width: 400,
        height: 450,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });

    setTimeout(function()
    {
        var select = $("#ddlNameList");
        $.ajax({
            url: "Deposite/GetMemberName",
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var datavalue = data;
                var serverResponse = datavalue;
                contentType: "application/json";
                $.each(serverResponse, function (i, serverResponse) {
                    select.append("<option value='" + serverResponse.memberId + "'>" + serverResponse.memberName + "</option>")
                });
            }
        });
    }, 20)
}


function SaveDepositedAmount() {

    var data = getData();

    $.ajax({
        url: '/Deposite/AddDepositedAmount',
        data: { "prm": data },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (result) {
            alert('Successfully Added to the Database');
            closePopup();
            $('#tblData').DataTable().ajax.reload();
        },
        error: function () {
            alert('Failed to receive the Data');
        }
    });

}

function getData() {
    obj = new Object();

    var memberId = $('#ddlNameList option:selected').val();
    obj.MemberId = memberId;
    
    var amount = $('#inputFieldForAmount').val();
    obj.Amount = amount;
    
    var date = $('#inputFieldForDate').val();
    obj.Date = date;

    return obj;
}

function closePopup() {
    $('#ddlNameList').empty();
    $("#popupDiv").dialog('close');
}

function GetIndividualDepositCalculation() {

    $.ajax({
        url: "/Deposite/IndividualDepositCalculation",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#totalIndividualDeposits').val(data);
        }
    });

}


