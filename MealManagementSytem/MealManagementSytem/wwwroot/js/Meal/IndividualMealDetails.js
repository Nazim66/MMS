$(document).ready(function () {
    $("#totalIndividualMeals").prop('disabled', true);
    GetIndividualMealCalculation();
    $('#tblData').DataTable({
        "paging": true,
        "order": [[0, 'desc']],
        "deferRender": true,
        "ajax": {
            "url": "Meal/IndividualMealDetails",
            "dataSrc": ''
        },
        columnDefs: [{
            targets: 0,
            render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'YYYY/MM/DD')
        }],
        "columns": [
            { "data": "date", "width": "15%" },
            { "data": "lunch", "width": "15%" },
            { "data": "guestLunch", "width": "15%" },
            { "data": "dinner", "width": "15%" },
            { "data": "guestDinner", "width": "15%" }
        ],
        dom: 'lfrtBip',
        select: true,
        buttons: [
            'copy', 'excel', 'pdf', 'csv'
        ]
    });
});


function showPopup() {
    $('#inputFieldForDinner').hide();
    $('#inputFieldForLunch').hide();
    $('#lunchCheckBox').prop("checked", false);
    $('#dinnerCheckBox').prop("checked", false);
    $('#inputFieldForDinner').val("");
    $('#inputFieldForLunch').val("");
    $("#popupDiv").dialog({
        width: 250,
        height: 280,
        modal: true,
        dialogClass: 'dialogWithDropShadow'
    });
}

function generateFieldForLunch() {
    $("#inputFieldForLunch").show();
}


function generateFieldForDinner() {
    $("#inputFieldForDinner").show();
}

function SaveMealDetail() {
    
    var data = getData();
        $.ajax({
            url: '/Meal/AddMealDetails',
            data: { "prm": data},
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

    if ($('#lunchCheckBox').prop('checked') == true) {
        obj.Lunch = 1;
    }
    else {
        obj.Lunch = 0;
    }

    if ($('#dinnerCheckBox').prop('checked') == true) {
        obj.Dinner = 1;
    }
    else {
        obj.Dinner = 0;
    }

    var guestLunch = $('#inputFieldForLunch').val();
    if (guestLunch == null || guestLunch == "") {
        obj.GuestLunch = 0;
    }
    else {
        obj.GuestLunch = guestLunch;
    }

    var guestDinner = $('#inputFieldForDinner').val();
    if (guestDinner == null || guestDinner == "") {
        obj.GuestDinner = 0;
    }
    else {
        obj.GuestDinner = guestDinner;
    }

    obj.Status = 0;
    var today = new Date();
    var date = (today.getFullYear()) + "/" + (today.getMonth() + 1) + "/" + (today.getDate());
    obj.Date = date;
    return obj;
}

function closePopup() {
    $("#popupDiv").dialog('close');
}


function GetIndividualMealCalculation() {

    $.ajax({
        url: "/Meal/IndividualMealCalculation",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#totalIndividualMeals').val(data);
        }
    });

}



