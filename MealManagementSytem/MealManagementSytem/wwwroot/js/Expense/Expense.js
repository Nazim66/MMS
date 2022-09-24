var Type = "";
$(document).ready(function () {
    CheckUserType();
    $("#totalExpenses").prop('disabled', true);
    GetExpenseCalculation();
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

            { "data": "date", "width": "15%" },
            { "data": "memberId", "width": "15%" },
            { "data": "memberName", "width": "15%" },
            { "data": "amount", "width": "15%" },
            { "data": "bazarDetail", "width": "15%" },
            {
                "data": "expenseId", "width": "5%",
                "render": function (data) {
                    if ($('#inputFieldForUserType').val() == "Admin") {
                        return `
                            <div class="text-center">
                                <a style="color:black" onclick=UpdateExpense("/Expense/UpdateExpenseById/${data}") >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a style="color:black" id="btnDelete" onclick=DeleteExpense("/Expense/ExpenseRemove/${data}")>
                                    <i class="fa fa-trash"></i>
                                </a>
                           </div>`;

                    }
                    else {
                        return '';
                    }
                }, "width": "20%"
            }
        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
    setTimeout(function () {
        Type = $('#inputFieldForUserType').val();
        //console.warn(Type);
    },2000)
    
});

function CheckUserType() {
    $.ajax({
        url: '/Expense/CheckUserType',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#inputFieldForUserType').val(data);
        },
        error: function (data) {
            return dt;
        }
    });
}

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
        width: 280,
        height: 350,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });
    setTimeout(function () {
        clearField();
        makeDropdownforName();
        $('#ddlNameList').val(data.memberId);
        $('#inputFieldForExpenseId').val(data.expenseId);
        $('#inputFieldForExpenseAmount').val(data.amount);
        var dt_to = moment(data.date).format("YYYY-MM-DD");
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
        title: "Are you sure, you want to delete",
        text: "Once Delete, You will never recover the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: data,
                success: function (data) {
                    if (data) {
                        toastr.success(data);
                        $('#tblData').DataTable().ajax.reload();
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
        width: 280,
        height: 350,
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
            toastr.success(result);
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

    var expenseId = $('#inputFieldForExpenseId').val();
    if (expenseId == "" || expenseId == null) {
        expenseId = 0;
    }
    obj.ExpenseId = expenseId;

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

function GetExpenseCalculation() {

    $.ajax({
        url: "/Expense/ExpenseCalculation",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#totalExpenses').val(data);
        }
    });

}