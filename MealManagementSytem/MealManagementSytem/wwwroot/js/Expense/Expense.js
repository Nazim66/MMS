$(document).ready(function () {
    $("#totalExpenses").prop('disabled', true);
    GetDepositCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
        "ajax": {
            "url": "Expense/ExpensesByAll",
            "dataSrc": ''
        },
        columnDefs: [
            {
                targets: 0,
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD'),
            },
           
        ],
        "columns": [

            { "data": "date", "width": "25%" },
            { "data": "memberId", "width": "25%"},
            { "data": "memberName", "width": "25%"},
            { "data": "amount", "width": "25%" },
            { "data": "bazarDetail", "width": "25%" }

        ],
        dom: 'lfrtBip',
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
        height: 550,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });

    setTimeout(function () {
        var select = $("#ddlNameList");
        $.ajax({
            url: "Expense/GetExpensesMemberName",
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

function SaveExpensesAmount() {

    var data = getData();

    $.ajax({
        url: '/Expense/AddExpensesAmount',
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

    var amount = $('#inputFieldForExpenseAmount').val();
    obj.Amount = amount;

    var date = $('#inputFieldForExpenseDate').val();
    obj.Date = date;

    var bazarDetail = $('#inputFieldForExpenseDetails').val();
    obj.BazarDetail = bazarDetail;


    return obj;
}

function closePopup() {
    $('#ddlNameList').empty();
    $("#popupDiv").dialog('close');
}

function GetDepositCalculation() {

    $.ajax({
        url: "/Expense/ExpenseCalculation",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#totalExpenses').val(data);
        }
    });

}