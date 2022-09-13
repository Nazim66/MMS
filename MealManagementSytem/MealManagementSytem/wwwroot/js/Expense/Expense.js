$(document).ready(function () {
    $("#inputFieldForExpenseDate").datepicker();
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
            { "data": "bazarDetail", "width": "25%" },
            {
                "data": "expenseId", "width": "5%",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a style="color:black" onclick=UpdateExpense("/Expense/UpdateExpenseById/${data}") >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a style="color:black" id="btnDelete" onclick=DeleteExpense("/Expense/ExpenseRemove/${data}")>
                                    <i class="fa fa-trash"></i>
                                </a>
                           </div>`;

                }, "width": "20%"
            }

        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});


function UpdateExpense(data) {

    $.ajax({
        url: data,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            PopulateEditData(data);
        }
    });
}


function PopulateEditData(data) {

    $("#popupDiv").dialog({
        width: 400,
        height: 450,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });
    setTimeout(function () {
        clearField();
        console.warn(data);
        makeDropdownforName();
        $('#ddlNameList').val(data.memberId);
        $('#inputFieldForExpenseAmount').val(data.amount);
        var dt_to = $.datepicker.formatDate('mm-dd-yy', new Date());
        $('#inputFieldForExpenseDate').val(dt_to);
        $('#inputFieldForExpenseDetails').val(data.bazarDetail);
    }, 20)



}


function clearField() {

    $('#inputFieldForExpenseAmount').val("");
    $('#inputFieldForExpenseDate').val("");
    $('#inputFieldForExpenseDetails').val("");

}

function DeleteExpense(data) {

    swal({
        title: "are you sure, you want to delete",
        text: "once delete, you will never recover the data!",
        icon: "warning",
        buttons: true,
        dangermode: true
    }).then((willdelete) => {
        if (willdelete) {
            $.ajax({
                type: "delete",
                url: data,
                success: function (data) {
                    if (data) {
                        toastr.success(data);
                        $('#tbldata').datatable().ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

var count = 0;
function showPopup() {

    $("#popupDiv").dialog({
        width: 400,
        height: 550,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });

    setTimeout(function () {
        makeDropdownforName();
    }, 20)

}

function makeDropdownforName() {
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