app.controller("investCtrl", ['$scope', '$http', '$window', '$q', 'customGridFactory', function ($scope, $http, $window, $q, customGridFactory) {
    //Required angular scope model declaration.
    $scope.helpers = iAlphaUtility.helpers;
    $scope.grid = {};
    $scope.calculator = {};
    
    $scope.initialInvestment;

    $scope.init = function () {

        $scope.setupControls();

    };

    $scope.setupControls = function () {
        $('.charting').slideUp('flow');
    };

    $scope.calculateSubmit = function () {
        var lowRiskPortfolioInterestAvg =
                (parseFloat($scope.calculator.LowInterestFrom) + parseFloat($scope.calculator.LowInterestTo)) / 2;
        var mediumRiskPortfolioInterestAvg =
                (parseFloat($scope.calculator.MedInterestFrom) + parseFloat($scope.calculator.MedInterestTo)) / 2;
        var highRiskPortfolioInterestAvg =
                (parseFloat($scope.calculator.HighInterestFrom) + parseFloat($scope.calculator.HighInterestTo)) / 2;

        var investmentRateOfInterest =
                ((parseFloat($scope.calculator.LowRiskPercentage)/100) * lowRiskPortfolioInterestAvg) +
                        ((parseFloat($scope.calculator.MedRiskPercentage)/100) * mediumRiskPortfolioInterestAvg) +
                        ((parseFloat($scope.calculator.HighRiskPercentage)/100) * highRiskPortfolioInterestAvg);

        $scope.initialInvestment = (parseFloat($scope.calculator.GoalAmount) / Math.pow((1 + (0.01 * investmentRateOfInterest)), (parseInt($scope.calculator.Year) + parseFloat($scope.calculator.Month / 12))));

        $('.charting').slideDown('slow');

        $scope.renderChart();
    };

    $scope.renderChart = function () {
      var budgetChart = new AlphaChart(
      {
          id: 'chart_budget',
          container: 'investment_chart_container',
          type: 'Column2D',
          data: [{ "label": new Date().getFullYear(), "value": $scope.initialInvestment },
              { "label": (new Date().getFullYear() + (parseInt($scope.calculator.Year) + parseFloat($scope.calculator.Month / 12))), "value": $scope.calculator.GoalAmount }],
          totalItemCount: 2,
          caption: "coming soon",
          subCaption: "Alpha charts -- coming soon"
      });      

      budgetChart.render();

    }

}
]);

