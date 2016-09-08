app.controller("tranCtrl", ['$scope', '$http', '$window', '$q', 'customGridFactory', function ($scope, $http, $window, $q, customGridFactory) {
	//Required angular scope model declaration.
	$scope.helpers = iAlphaUtility.helpers;
	$scope.grid = {};

	$scope.init = function () {
		
	    $q.all([
            //$http.get(window.ROOT + "Account/GetAllAccounts")
            $http.get(window.ROOT + "Setting/GetAllCategory")
	    ]).then(function (results) {
	        ///$scope.accounts = results[0].data;
	        $scope.categories = results[0].data;

	        $scope.mappedCategories = $.map($scope.categories, function (item) {
	            return {
	                label: item.CategoryName, value: item.Id
	            };
	        });

	    }).finally(function () {
	    $scope.accounts = [{Id: 1, Name: 'City Bank'}, {Id: 2, Name: 'Credit Account'}, {Id:3, Name: 'HDFC Bank'}]

	        var accountData = $.map($scope.accounts, function (item) {
	            return {
	                label: item.Name, value: item.Id
	            };
	        });
	        $scope.SetMultiselectDropdown('ddlAccount', accountData, 'Select Account');
	    });
	    
		$scope.setupControls();
	};

	$scope.getAllTransaction = function () {
	    //$q.all([
            //$http.get(window.ROOT + "Account/GetAllAccounts")
            //$http.get(window.ROOT + "Transaction/GetAllTransaction")
	    //]).then(function (results) {
	        ///$scope.accounts = results[0].data;
	    $scope.transactions = [{ Id: "123", Date: new Date(), Description: "BCD", CategoryName: "ABC", CategoryId: "a0b5a5df-3200-43e6-8942-030d91e27253", Amount: 100 },
    { Id: "sdf", Date: new Date(), Description: "KFC1", CategoryName: "DRD", CategoryId: "f8685693-4e6b-46fb-8a24-9994516c3320", Amount: 100 },
    { Id: "sdfsdwre", Date: new Date(), Description: "KFC2", CategoryName: "ABC", CategoryId: "2a005613-3fab-4441-86fa-e1047eb328a4", Amount: 100 }];
	    //}).finally(function () {
	        if ($scope.transactionGrid == undefined) {
	            $scope.setupControls();
	        } else {
	            $scope.transactionGrid.gridInstance.dataSource.data($scope.transactions);
	            if ($scope.transactions.length > 0) {
	                $scope.transactionGrid.gridInstance.dataSource.page(1);
	            }
	            $scope.transactionGrid.refresh();
	        }
	    //});
	};

	$scope.reloadGrid = function () {

	};

	$scope.setupControls = function () {

	    $scope.transactions = [{ Id: "123", Date: new Date(), Description: "BCD", CategoryName: "ABC", CategoryId: "a0b5a5df-3200-43e6-8942-030d91e27253", Amount: 100 },
		{ Id: "sdf", Date: new Date(), Description: "KFC1", CategoryName: "DRD", CategoryId: "f8685693-4e6b-46fb-8a24-9994516c3320", Amount: 100 },
		{ Id: "sdfsdwre", Date: new Date(), Description: "KFC2", CategoryName: "ABC", CategoryId: "2a005613-3fab-4441-86fa-e1047eb328a4", Amount: 100 }]
		var prop = {
			tableId: "TransactionGrid",
			dataSource: {
				data: $scope.transactionData,
				sort: {
					field: "Date",
					dir: "asc"
				},
				schema: {
					model: {
						fields: {
						    Id: { type: "string" },
						    Date: { type: "date", editable: false },
						    Description: { type: "string" },
						    CategoryId: { type: "int" },
						    CategoryName: {type: "string"},
						    Amount: { type: "float", editable: false }

						}
					}
				},
			},
			columns: [
				
				{ field: "Date", title: "Date", format: "{0:MM/dd/yyyy}", template: "#= kendo.toString(kendo.parseDate(Date), 'MM/dd/yyyy') #" },
                { field: "Description", title: "Description" },
                { field: "CategoryId", title: "Category",template: "#= CategoryName #", editor : $scope.editCategoryControl },
				{ field: "Amount", title: "Amount" },                
                { command: [{ template: "<a class='glyphicon' ng-click='editTransaction($event)' href='' style='min-width:16px;' title='Delete'>Delete</a>" }], title: " ", width: "5%" }

			],
			scrollable: false,
			filterable: {
				extra: false
			},
			resizable: true,
			selectable: false,
			editable: true,
			save: $scope.updateTransaction,
			sortable: {
				mode: "single",
				allowUnsort: true
			}
		}
		$scope.transactionGrid = new customGridFactory(prop, $scope);

		$('.add-content').slideUp("slow");
	};

	$scope.editCategoryControl = function (container, options) {

	    $('<input required name="' + options.field + '"/>')
                        .appendTo(container)
                        .kendoDropDownList({
                            autoBind: false,
                            dataTextField: "label",
                            dataValueField: "value",
                            dataSource: $scope.mappedCategories
                        });
	};

	$scope.openTransactionForEdit = function (e) {
	    var $grid = e.sender;
	    var $cell = $grid.select();
	    var $row = $cell.closest('tr');

	    $grid.editRow($row);
	};

	$scope.editTransaction = function (e) {
	    $('#myModalTerms').modal('show');
	};

	$scope.addNewRowForEdit = function (e) {
	    var row = $('<tr><td><label class="form-control labelDisable">Walmart</label></td>' +
                                    '<td colspan="2">'+
                                        '<div class="drop-down"></div>'+
                                    '</td>'+
                                    '<td><input name="txtAccountName" type="text" class="form-control" id="txtAccountName1"></td>'+
                                    '<td><button class="btn btn-primary pull-left split-remove"><span class="glyphicon"></span> Remove</button></td></tr>');
	    $(row).appendTo('#split-table');

	    $scope.renderDropDown();

	    $(document).off('click', '.split-remove')
	    $(document).on('click', '.split-remove', function () {
	        $(this).parent('td').parent('tr').remove();
	    });
	};

	$scope.showSplit = function () {
	    $('.add-content').slideDown("slow");
	};

	$scope.SetMultiselectDropdown = function (ddlId, data, buttonValue) {
	    $('#' + ddlId).multiselect({
	        buttonWidth: "100%",
	        includeSelectAllOption: true,
	        enableFiltering: false,
	        enableCaseInsensitiveFiltering: false,
	        maxHeight: 150,
	        checkboxName: 'multiselect[]',
	        buttonText: function (options, select) {
	            if (options.length === 0) {
	                return buttonValue;
	            } else {
	                return options.length + ' selected';
	            }
	        }
	    }).multiselect("dataprovider", data).bind('change', function (values) {
	        if (values.target.selectedOptions.length == undefined || values.target.selectedOptions.length <= 0) {
	            $('span[data-for="' + ddlId + '"]').show();
	        }
	        else
	            $('span[data-for="' + ddlId + '"]').hide();
	    });

	};

	$scope.updateTransaction = function (e) {
	    console.log(e);

	    $http({
	        method: "POST",
	        url: window.ROOT + "Transaction/updateTransaction",
	        processData: false,
	        contentType: false,
	        data: {
	            transactionViewModel: e.model
	        }
	    }).success(function (callback) {
	        if (callback.success) {
	            
	        } else {
	            $scope.helpers.pageStatus.showFailureMessage(callback.message);
	        }
	    });
	}
}
]);

