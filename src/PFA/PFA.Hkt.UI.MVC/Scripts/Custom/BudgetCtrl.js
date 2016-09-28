myApp.controller("budgetCtrl", function ($scope, $http) {
    debugger;
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        $scope.Budget = {};
        $scope.Budget.UserId = $scope.UserId;
        $scope.Budget.Type = $scope.Type;
        $scope.Budget.Month = $scope.Month;
        $scope.Budget.Year = $scope.Year;
        $scope.Budget.IsRecuring = $scope.IsRecuring;
        if (Action == "Submit")
        {
            $http({
                method: "post",
                url: "http://localhost:51080/Budget/Insert_Budget",
                datatype: "json",
                data: JSON.stringify($scope.Budget)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Budget.UserId = "";
                $scope.Budget.Type ="";
                $scope.Budget.Month = "";
                $scope.Budget.Year = "";
                $scope.Budget.IsRecuring = "";
            })
        }
        else {
            $scope.Budget.Id = document.getElementById("Id").value;
            $http({
                method: "post",
                url: "http://localhost:51080//Budget/Update_Budget",
                datatype: "json",
                data: JSON.stringify($scope.Budget)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Budget.UserId = "";
                $scope.Budget.Type = "";
                $scope.Budget.Month = "";
                $scope.Budget.Year = "";
                $scope.Budget.IsRecuring = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Budget";
            })
        }
    }

    $scope.GetAllData = function () {
        debugger;
        $http({
            method: "get",
            url: "http://localhost:51080/Budget/GetAllBudget"
        }).then(function(response){
            $scope.Budget = response.data;
        }, function () {
            alert("Error occur");
        })
    }

    $scope.DeleteBudget = function (Budgt) {
        $http({
            method: "post",
            url: "http://localhost:51080//Budget/Delete_Budget",
            datatype: "JSON",
            data: JSON.stringify(Budgt.Id)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    }

    $scope.UpdateBudget = function () {
        $scope.

    }

});