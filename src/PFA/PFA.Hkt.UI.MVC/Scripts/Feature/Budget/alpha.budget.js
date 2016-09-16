app.controller('BudgetCtrl', BudgetCtrl);
BudgetCtrl.$inject = ['$scope', '$http', '$window', '$q'];

function BudgetCtrl($scope, $http, $window, $q) {
    $scope.response = window.response;
    $scope.resources = window.resources;
    $scope.helpers = iAlphaUtility.helpers;
    $scope.finalAmmount = 0;
    $scope.expense = 0
    $scope.income = 0;


    $scope.init = function () {


        $q.all([
            $http.get(window.ROOT + "Budget/GetAllBudget"),
            $http.get(window.ROOT + "Setting/GetAllCategory")
        ]).then(function (results) {
            $scope.budgets = results[0].data;
            $scope.categories = results[1].data;
        }).finally(function () {
            $scope.calculateAmmount();
        });
    };

    $scope.calculateAmmount = function () {

        for (var i = 0; i < $scope.budgets.length; i++) {

            if ($scope.budgets[i].Type == "Expense") {
                $scope.expense += $scope.budgets[i].Amount;
            } else
                $scope.income += $scope.budgets[i].Amount;
        }
        $scope.finalAmmount = $scope.income - $scope.expense;
    }

}
