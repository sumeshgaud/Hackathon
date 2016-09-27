myApp.controller("firstCtrl", function ($scope) {
    debugger;
    $scope.Name = "Vishal";
    $scope.LastName = "Srivastava";
    $scope.FullName = $scope.Name + $scope.LastName;
});

myApp.controller("parantCtrl", function ($scope) {
    $scope.Name = "Vishal";
    $scope.LastName = "Srivastava";
    $scope.FullName = $scope.Name + $scope.LastName;
});

myApp.controller("childCtrl1", function ($scope) {
    $scope.Name = "Vishal";
});

myApp.controller("childCtrl2", function ($scope) {
    $scope.LastName = "Srivastava";
});

