app.controller("tranCtrl", ['$scope', '$http', '$window', '$q', 'customGridFactory', function ($scope, $http, $window, $q, customGridFactory) {
	//Required angular scope model declaration.
	$scope.helpers = iAlphaUtility.helpers;
	$scope.grid = {};
	$scope.init = function () {
		$scope.transactionData = [{ Id: 1, Name: "Abc", Amount: 100, Expenses: 123 },
		{ Id: 2, Name: "Bbc", Amount: 200, Expenses: 1234 },
		{ Id: 13, Name: "Cbc", Amount: 300, Expenses: 1235 }]

		$scope.setupControls();
	};

	$scope.setupControls = function () {
		var prop = {
			tableId: "TransactionGrid",
			dataSource: {
				data: $scope.transactionData,
				sort: {
					field: "Name",
					dir: "asc"
				},
				schema: {
					model: {
						fields: {
							Id: { type: "int" },
							Name: { type: "string" },
							Amount: { type: "int" },
							Expenses: { type: "int" }				

						}
					}
				},
			},
			columns: [
				{ field: "Id", title: "ID" },
				{ field: "Name", title: "Transaction Name" },
				{ field: "Amount", title: "Amount"},
				{ field: "Expenses", title: "Expenses" }			

			],
			scrollable: false,
			filterable: {
				extra: false
			},
			resizable: true,
			selectable: true,
			sortable: {
				mode: "single",
				allowUnsort: true
			}
		}
		$scope.transactionGrid = new customGridFactory(prop, $scope);
	};

}
]);

