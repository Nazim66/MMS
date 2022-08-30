$(document).ready(function () {
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
        "ajax": {
            "url": "Member/AllMember",
            "dataSrc": ''
        },
        "columns": [

            { "data": "memberId", "width": "25%" },
            { "data": "memberName", "width": "25%" },
            { "data": "memberType", "width": "25%" },
            { "data": "memberPass", "width": "25%" }

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

function SaveMember() {

    var data = getData();

    $.ajax({
        url: '/Member/AddMember',
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

    var memberId = $('#inputFieldForMId').val();
    obj.MemberId = memberId;

    var memberName = $('#inputFieldForMName').val();
    obj.MemberName = memberName;

    var memberType = $('#inputFieldForMType').val();
    obj.MemberType = memberType;

    var memberPass = $('#inputFieldForMPass').val();
    obj.MemberPass = memberPass;

    return obj;
}

function closePopup() {
    $("#popupDiv").dialog('close');
}
