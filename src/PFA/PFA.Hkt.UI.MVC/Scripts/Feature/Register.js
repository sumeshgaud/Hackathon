app.controller('RegisterCtrl', RegisterCtrl);
RegisterCtrl.$inject = ['$scope', '$http', '$window', '$q'];

function RegisterCtrl($scope, $http, $window, $q) {
    $scope.response = window.response;
    $scope.resources = window.resources;
    $scope.helpers = iAlphaUtility.helpers;
    $scope.registrationDetails = {};

    $scope.init = function () {


        $q.all([
            $http.get(window.ROOT + "Account/GetAllCurrencyList")            
        ]).then(function (results) {
            $scope.currencies = results[0].data;            
        }).finally(function () {
            
        });


        $scope.userNameAlreadyExists = false;
        $scope.emailIdAlreadyExists == false;

        $(".form-control").keyup(function () {
            $("#div-page-status").slideUp('slow');
        });

        $(".form-control").change(function () {
            $("#div-page-status").slideUp('slow');
        });

        $scope.validator = $("#frmRegister").kendoValidator({
            rules: {
                comparePasswords: function (input) {
                    var ret = true;
                    if (input.is("[name=txtConfirmPassword]")) {
                        ret = input.val() === $("#txtPassword").val();
                    }
                    return ret;
                },
                validateConfirmPassword: function (input) {
                    var ret = true;
                    if (input.is("[name=txtConfirmPassword]")) {
                        ret = (input.val() != $('#txtUsername').val()) &&
                        ($("#txtConfirmPassword").val().match(/^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]{8,20})$/) != null);
                    }
                    return ret;
                },
                validatePassword: function (input) {
                    var ret = true;
                    if (input.is("[name=txtPassword]")) {
                        ret = (input.val() != $('#txtUsername').val()) &&
                        ($("#txtPassword").val().match(/^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]{8,20})$/) != null);
                    }
                    return ret;
                },
                validateMailID: function (input) {
                    var ret = true;
                    if (input.is("[name=txtEmailAddress]")) {
                        if (!input.val().match(/^[_A-Za-z0-9-]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$/)) {
                            ret = false;
                        }
                    }
                    return ret;
                },                
                
                verifyUserName: function (input) {
                    var ret = true;
                    if (input.is("[name=txtUsername]")
                        && ($scope.userNameAlreadyExists == undefined
                            || $scope.userNameAlreadyExists == true)
                        && input.valueOf() != "") {
                        ret = false;
                    }
                    return ret;
                },                
                VerifyCheckTermsAndConditions: function (input) {
                    var ret = true;
                    if (input.is("[name=chkAgree]")) {
                        if (!($("#chkAgree").is(":checked"))) {
                            ret = false;

                        }
                    };
                    return ret;
                }
            },
            messages: {
                comparePasswords: "Passwords do not match",
                validatePassword: "Password does not meet the security requirements. Please try again",
                validateConfirmPassword: "Password does not meet the security requirements. Please try again",
                validateMailID: "Email format is not valid",
                
                verifyUserName: "Username already exists"
            }
        }).data("kendoValidator");
        
    };

    $scope.validateSubmit = function () {
        if ($scope.validator.validate() == true) {

            $http({
                method: "POST",
                url: window.ROOT + "Account/submitRegistration",
                processData: false,
                contentType: false,
                data: {
                    registrationViewModel: $scope.registrationDetails
                }
            }).success(function (callback) {
                if (callback.success) {
                    $scope.location = window.ROOT + "Account/Login";
                } else {
                    $scope.helpers.pageStatus.showFailureMessage(callback.message);                   
                }
            });
        }
    };

    $scope.validateAvailableUsernameEmailAndAccessCode = function (fieldName) {

        if ($("#" + fieldName).val() != '') {
            var userName = $scope.registrationDetails.Username;
            var email = $scope.registrationDetails.Email;
            var accessCode = $scope.registrationDetails.AccessCode;
            var userTypeId = $scope.registrationDetails.UserType;

            $http({
                method: "GET",
                url: window.ROOT + "Account/ValidateExistenceOfUserNameAndEmail",
                params: { userGuid: "", userName: userName, email: email, accessCode: accessCode, userTypeId: userTypeId }
            }).success(function (callback) {
                if (callback.success) {
                    $scope.accessCodeAlreadyExists = callback.data["AccessCodeExists"];
                    $scope.emailIdAlreadyExists = callback.data["EmailExists"];
                    $scope.userNameAlreadyExists = callback.data["UserNameExists"];

                    $scope.validator.validateInput($("input[name=" + fieldName + "]"));
                } else {
                    $scope.helpers.pageStatus.showFailureMessage("Something went wrong!");
                }
            });
        }
    };

    $scope.resetInputControls = function () {
        if ($scope.registrationDetails.UserType != "" && $scope.registrationDetails.UserType != undefined) {
            $scope.isDisabled = false;
            $scope.disableCaptcha = false;
        } else {
            $scope.isDisabled = true;
            $scope.disableCaptcha = true;
        }
        var userType = $scope.registrationDetails.UserType;
        var accessCode = $scope.registrationDetails.AccessCode;
        var email = $scope.registrationDetails.Email;
        $scope.registrationDetails = {};
        $scope.registrationDetails.UserType = userType;
        $scope.registrationDetails.AccessCode = accessCode;
        $scope.registrationDetails.Email = email ? email : $scope.initial;
        $("span.k-tooltip-validation").hide();
        $(".form-control").removeClass("k-invalid");
    };

    $scope.validatePasswordFields = function () {
        if ($scope.registrationDetails.ConfirmPassword != undefined && $scope.registrationDetails.ConfirmPassword != "") {
            $scope.validator.validateInput($("input[name=txtConfirmPassword]"));
        }
    }

    $scope.clear = function () {
        if (_.isEmpty($('#ddlUserType'))) {
            var model = angular.copy($scope.registrationDetails);
            //var accessCode = $scope.registrationDetails.AccessCode;
            //var email = $scope.registrationDetails.Email;
            //var userType = $scope.registrationDetails.UserType;

            $scope.registrationDetails = {};
            $scope.registrationDetails.UserType = model.UserType;
            $scope.registrationDetails.AccessCode = model.AccessCode;
            $scope.registrationDetails.Email = model.Email ? model.Email : $scope.initial;
            $("span.k-tooltip-validation").hide();
            $(".form-control").removeClass("k-invalid");
        } else {
            $scope.registrationDetails.UserType = $scope.initial;
            $scope.resetInputControls();
        }
        $('html, body').animate({ scrollTop: $('body').position().top }, 'slow');
    }

    $scope.cancel = function () {
        $window.location = window.ROOT + "Account/Login";
    };

    angular.element(document).ready(function () {
        //$scope.registrationDetails = {};       
        var getSelected = getCookie("selectedLogin");

        switch (getSelected) {
            case "Admin":
                $scope.registrationDetails.UserType = 1955;
                break;
            case "Employer":
                $scope.registrationDetails.UserType = 1953;
                break;
            case "Employee":
                $scope.registrationDetails.UserType = 1954;
                break;
            default:
                $scope.registrationDetails.UserType = 1953;
                break;
        }
        $scope.resetInputControls();
    });

    function getCookie(key) {
        return localStorage[key];
    }
};