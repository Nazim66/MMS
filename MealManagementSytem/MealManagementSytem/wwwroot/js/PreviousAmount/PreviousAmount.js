$(document).ready(function () {
    $("#totalPreAmount").prop('disabled', true);
    GetPreviousAmountCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
        "ajax": {
            "url": "PreviousAccount/PreviousAmountByAll",
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
            {
                "data": "previousAccountId", "width": "5%",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a style="color:black" onclick=UpdatePreviousAccount("/PreviousAccount/UpdatePreviousAccountById/${data}") >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a style="color:black" id="btnDelete" onclick=DeletePreviousAccount("/PreviousAccount/PreviousAccountRemove/${data}")>
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

function GetPreviousAmountCalculation() {

    $.ajax({
        url: "/PreviousAccount/PreviousAmountCalculation",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#totalPreAmount').val(data);
        }
    });

}
function UpdatePreviousAccount(data) {

    $.ajax({
        url: data,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $.ajax({
                url: data,
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    $('#tblData').DataTable().ajax.reload();
                }
            });
            PopulateEditData(data);
        }
    });
}


function DeletePreviousAccount(data) {

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


function PopulateEditData(data) {
    $("#popupDiv").dialog({
        width: 320,
        height: 400,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });
    setTimeout(function () {
        clearField();
        makeDropdownforName();
        $('#ddlNameList').val(data.memberId);
        $('#inputFieldForPreviousAccountId').val(data.previousAccountId);
        $('#inputFieldForPreviousAmount').val(data.amount);
    }, 20)

}


function clearField() {

    $('#inputFieldForPreviousAmount').val("");
    $('#ddlNameList').val(0);

}

var count = 0;
function showPopup() {

    $("#popupDiv").dialog({
        width: 320,
        height: 400,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });

    setTimeout(function () {
        clearField();
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

function SavePreviousAmount() {

    var data = getData();
    $.ajax({
        url: '/PreviousAccount/AddPreviousAmount',
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
            alert(result);
        }
    });

}

function getData() {
    obj = new Object();

    var previousAccountId = $('#inputFieldForPreviousAccountId').val();
    if (previousAccountId == "" || previousAccountId == null) {
        previousAccountId = 0;
    }
    obj.PreviousAccountId = previousAccountId;
    var memberId = $('#ddlNameList option:selected').val();
    obj.MemberId = memberId;
    var amount = $('#inputFieldForPreviousAmount').val();
    obj.Amount = amount;

    return obj;
}

function closePopup() {
    $('#ddlNameList').empty();
    $("#popupDiv").dialog('close');
}
