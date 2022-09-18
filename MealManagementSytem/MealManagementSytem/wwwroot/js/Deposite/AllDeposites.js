$(document).ready(function () {
    $("#totalDeposits").prop('disabled', true);
    GetDepositCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
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

            {
                "data": "depositeId", "width": "5%",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a style="color:black" onclick=UpdateDeposite("/Deposite/UpdateDepositeById/${data}") >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a style="color:black" id="btnDelete" onclick=DeleteDeposite("/Deposite/DepositeRemove/${data}")>
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


function UpdateDeposite(data) {

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

function DeleteDeposite(data) {

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
        $('#inputFieldForDepositeId').val(data.depositeId);
        $('#inputFieldForAmount').val(data.amount);
        var dt_to = moment(data.date).format("YYYY-MM-DD");
        $('#inputFieldForDate').val(dt_to);
    }, 20)

}

function clearField() {

    $('#inputFieldForAmount').val("");
    $('#inputFieldForDate').val("");
    $('#ddlNameList').val(0);

}

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
        url: "/Expense/GetExpensesMemberName",
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

function SaveDepositedAmount() {

    var data = getData();

    $.ajax({
        url: '/Deposite/AddDepositedAmount',
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

    var depositeId = $('#inputFieldForDepositeId').val();
    if (depositeId == "" || depositeId == null) {
        depositeId = 0;
    }
    obj.DepositeId = depositeId;

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

