$(document).ready(function () {
    $("#overallExpenses").prop('disabled', true);
    $("#overallMeals").prop('disabled', true);
    $("#overallmealRates").prop('disabled', true);
    GetCalculation();

});


function makeReport() {
    html2canvas($('#tblData')[0], {
        onrendered: function (canvas) {
            var data = canvas.toDataURL();
            var docDefinition = {
                content: [{
                    image: data,
                    width: 500
                }]
            };
            pdfMake.createPdf(docDefinition).download("meal-calculation.pdf");
        }
    });
}

function GetCalculation() {

    $.ajax({
        url: "/OverallCalculation/OverallMealAndExpense",
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            $('#overallExpenses').val(data.overallExpenseCount);
            $('#overallMeals').val(data.overAllMealsCount);
            var exp = $('#overallExpenses').val();
            var meals = $('#overallMeals').val();
            var mealRate = (exp / meals).toFixed(2);
            $('#overallmealRates').val(mealRate);
        }
    });

}
