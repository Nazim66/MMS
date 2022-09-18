$(document).ready(function () {
    $('#tblData').DataTable({
        "paging": true,
        "deferRender": true,
        "order": [[0, 'desc']],
        "responsive": true,
        "ajax": {
            "url": "Member/AllMember",
            "dataSrc": ''
        },

        columnDefs: [
            {
                target: 3,
                visible: false,
            },
        ],
        "columns": [

            { "data": "memberId", "width": "25%" },
            { "data": "memberName", "width": "25%" },
            { "data": "memberType", "width": "25%" },
            { "data": "memberPass", "width": "25%", "visible": false },
            {
                "data": "memberId", "width": "5%",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a style="color:black" onclick=UpdateMember("/Member/UpdateMemberById/${data}") >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a style="color:black" id="btnDelete" onclick=DeleteMember("/Member/MemberRemove/${data}")>
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


function UpdateMember(data) {

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


function DeleteMember(data) {

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
        $('#inputFieldForMId').val(data.memberId);
        $('#inputFieldForMName').val(data.memberName);
        $('#inputFieldForMType').val(data.memberType);
        $('#inputFieldForMPass').val(data.memberPass);
    },20)



}

function showPopup() {
    $("#popupDiv").dialog({
        width: 320,
        height: 400,
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
            toastr.success(result);
            closePopup();
            $('#tblData').DataTable().ajax.reload();
        },
        error: function () {
            alert('Error Occured!!!!!');
        }
    });

}

function getData() {

    obj = new Object();

    var memberId = $('#inputFieldForMId').val();
    obj.MemberId = memberId;

    var memberName = $('#inputFieldForMName').val();
    obj.MemberName = memberName;

    var memberType =  $('#inputFieldForMType option:selected').val();
    obj.MemberType = memberType;

    var memberPass = $('#inputFieldForMPass').val();
    obj.MemberPass = memberPass;

    return obj;
}

function closePopup() {
    $("#popupDiv").dialog('close');
}

function clearField() {
    $('#inputFieldForMName').val("");
    $('#inputFieldForMPass').val("");
}

