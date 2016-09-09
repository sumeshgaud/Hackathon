app.controller('BudgetCtrl', BudgetCtrl);
BudgetCtrl.$inject = ['$scope', '$http', '$window', '$q'];

function BudgetCtrl($scope, $http, $window, $q) {
    $scope.response = window.response;
    $scope.resources = window.resources;
    $scope.helpers = iAlphaUtility.helpers;


    $scope.init = function () {


        $q.all([
            $http.get(window.ROOT + "Budget/GetAllBudget"),
            $http.get(window.ROOT + "Setting/GetAllCategory")
        ]).then(function (results) {
            $scope.budgets = results[0].data;
            $scope.categories = results[1].data;
        }).finally(function () {

        });
    };
}
