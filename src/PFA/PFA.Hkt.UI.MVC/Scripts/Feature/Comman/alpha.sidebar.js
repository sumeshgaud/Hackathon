app.controller("sideBarCtrl", ['$scope', '$http', '$window', '$q', 'constants', function ($scope, $http, $window, $q, constants) {
    //Required angular scope model declaration.
    $scope.helpers = iAlphaUtility.helpers;
    $scope.init = function () {
        //$q.all([
        //       $http.get(window.ROOT + "Account/GetAllAccounts")                
        //]).then(function (results) {
        //    $scope.accounts = jQuery.parseJSON(results[0].data.data);            
        //}).finally(function () {
        //   
        //});

        $scope.accounts = [{ Id: 1, Name: "City bank", Description: "Details description", type: 1, Amount: 15645 },
                           { Id: 1, Name: "SBI bank", Description: "Details description", type: 1, Amount: 12545 },
                           { Id: 1, Name: "City bank", Description: "Credit card description", type: 3, Amount: -445 },
                           { Id: 1, Name: "SBI bank", Description: "Credit description", type: 3, Amount: -655 }]
    };

    $scope.setupControls = function () {

    };

    $scope.getTotal = function (type) {
        var total = 0;
        for (var i = 0; i < $scope.accounts.length; i++) {
            if ($scope.accounts[i].type == type) {
                total += $scope.accounts[i].Amount;
            }
        }
        return total;

    }
}
]);

