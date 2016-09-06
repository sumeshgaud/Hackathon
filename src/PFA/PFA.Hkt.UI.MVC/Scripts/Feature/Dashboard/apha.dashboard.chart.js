
$(document).ready(function () {

    var budgetData = [{ "label": "Income", "value": "700" }, { "label": "Expense", "value": "400" }];
    var expenseData = [{ "label": "Income", "value": "700" }, { "label": "Expense", "value": "400" }];

    var expenseChart = new AlphaChart(
        {
            id: 'chart_expense',
            container: 'expense_chart_container',
            type: 'Pie2D',
            data: expenseData,
            totalItemCount: 2,
            caption: "Monthly income expense details",
            subCaption: "Alpha charts -- coming soon"
        });

    var budgetChart = new AlphaChart(
       {
           id: 'chart_budget',
           container: 'budget_chart_container',
           type: 'Pie2D',
           data: budgetData,
           totalItemCount: 2,
           caption: "Monthly budget management",
           subCaption: "Alpha charts -- coming soon"
       });

    expenseChart.render();
    budgetChart.render();

    $(".chart-type").click(function () {

        var type = ($(this).data('chartType'));

        $('.chart-type').removeClass('selected');
        $(this).addClass('selected');

        expenseChart.config.type = type;
        budgetChart.config.type = type;

        expenseChart.render();
        budgetChart.render();
    });


});