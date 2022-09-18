$(document).ready(function () {
    $("#totalMeals").prop('disabled', true);
    GetMealCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
        "ajax": {
            "url": "/Meal/AllMemberMeals",
            "dataSrc": ''
        },
        columnDefs: [
            {
                targets: 0,
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD')
            },
        ],
        "columns": [

            { "data": "date", "width": "15%"},
            { "data": "memberName", "width": "15%" },
            { "data": "memberId", "width": "15%" },
            { "data": "lunch", "width": "15%" },
            { "data": "guestLunch", "width": "15%" },
            { "data": "dinner", "width": "15%" },
            { "data": "guestDinner", "width": "15%" },
            {
                "data": "mealId", "width": "5%",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a style="color:black" onclick=UpdateMeal("/Meal/UpdateMealById/${data}") >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a style="color:black" id="btnDelete" onclick=DeleteMeal("/Meal/MealRemove/${data}")>
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

function UpdateMeal(data) {
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
                }

            });
            PopulateEditData(data);
        }
    });
}

function DeleteMeal(data) {

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
        width: 250,
        height: 280,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });
    setTimeout(function () {
        makeDropdownforName();
        $('#ddlNameList').val(data.memberId);
        $('#inputFieldForMealId').val(data.mealId);
        $('#inputFieldForLunch').val(data.lunch);
        $('#inputFieldForGuestLunch').val(data.guestLunch);
        $('#inputFieldForDinner').val(data.dinner);
        $('#inputFieldForGuestDinner').val(data.guestDinner);
        var dt_to = moment(data.date).format("YYYY-MM-DD");
        $('#inputFieldForDate').val(dt_to);
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

function SaveMealDetail() {

    var data = getData();
    console.warn(data);
    $.ajax({
        url: '/Meal/AddMealDetails',
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

    //Get Meal Id
    obj.MealId = $('#inputFieldForMealId').val();
    //Get Member Id
    var memberId = $('#ddlNameList option:selected').val();
    obj.MemberId = memberId;
    //Lunch Value Get
    var lunch = $('#inputFieldForLunch').val();
    if (lunch == null || lunch == "") {
        obj.lunch = 0;
    }
    else {
        obj.Lunch = lunch;
    }
    //Guest Lunch Value Get
    var guestLunch = $('#inputFieldForGuestLunch').val();
    if (lunch == null || lunch == "") {
        obj.GuestLunch = 0;
    }
    else {
        obj.GuestLunch = guestLunch;
    }
    //Dinner Value Get
    var dinner = $('#inputFieldForDinner').val();
    if (dinner == null || dinner == "") {
        obj.Dinner = 0;
    }
    else {
        obj.Dinner = dinner;
    }
    //Guest Dinner Value Get
    var guestDinner = $('#inputFieldForGuestDinner').val();
    if (guestDinner == null || guestDinner == "") {
        obj.GuestDinner = 0;
    }
    else {
        obj.GuestDinner = guestDinner;
    }
    obj.Status = 1;
    obj.Date = $('#inputFieldForDate').val();

    return obj;
}

function closePopup() {
    $('#ddlNameList').empty();
    $("#popupDiv").dialog('close');
}

function GetMealCalculation() {
    $.ajax({
        url: "/Meal/MealCalculation",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#totalMeals').val(data);
        }
    });

}
