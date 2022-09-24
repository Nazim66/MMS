$(document).ready(function () {
    makeDropdownforName();
});

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


