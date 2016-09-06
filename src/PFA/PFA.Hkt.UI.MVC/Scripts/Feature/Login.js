app.controller("LoginCtrl", ['$scope', '$http', '$window', function ($scope, $http, $window) {

    $scope.response = window.response;

    $scope.init = function () {
        $('#userName').focus();
    };

    $scope.validateAndSubmit = function () {
        var validator = $("#loginForm").kendoValidator({
            rules: {
           },
            messages: {
            }
        }).data("kendoValidator");
        if (validator.validate()) {
            $('#ajaxLoader').show();
            $('#loginForm').submit();
        }
    };

    $scope.openRecoverPassword = function () {
        $window.location = window.ROOT + "Account/RecoverPassword";
    };

    $scope.hideMessage = function () {
        $("#div-login-status").hide();
    };
}]);