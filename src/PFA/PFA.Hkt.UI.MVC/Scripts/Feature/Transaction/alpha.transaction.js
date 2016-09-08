app.controller("tranCtrl", ['$scope', '$http', '$window', '$q', 'customGridFactory', function ($scope, $http, $window, $q, customGridFactory) {
	//Required angular scope model declaration.
	$scope.helpers = iAlphaUtility.helpers;
	$scope.grid = {};
	$scope.init = function () {
		$scope.transactionData = [{ TransactionId: 1, Date: new Date(), Description: "KFC", CategoryName: "ABC", CategoryId: 12 , Amount: 100 },
		{ TransactionId: 2, Date: new Date(), Description: "KFC1", CategoryName: "ABC12", CategoryId: 13, Amount: 100 },
		{ TransactionId: 3, Date: new Date(), Description: "KFC2", CategoryName: "ABC32", CategoryId: 11, Amount: 100 }]

		$scope.setupControls();
	};

	$scope.setupControls = function () {
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
						    TransactionId: { type: "int" },
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
                { command: [{ id: "edit", name: "edit", template: "<a class='k-grid-edit glyphicon glyphicon-pencil shw-td' href='' style='min-width:16px;' title='Edit'></a>" }], title: " " },
                { command: [{ template: "<a class='glyphicon' ng-click='editTransaction($event)' href='' style='min-width:16px;' title='Edit Detail'>Edit Detail</a>" }], title: " ", width: "5%" }

			],
			scrollable: false,
			filterable: {
				extra: false
			},
			resizable: true,
			selectable: false,
			editable: "inline",
			sortable: {
				mode: "single",
				allowUnsort: true
			}
		}
		$scope.transactionGrid = new customGridFactory(prop, $scope);

		$scope.renderDropDown();

		$('.add-content').slideUp("slow");
	};

	$scope.renderDropDown = function () {
	    $(".drop-down").not('[data-role=extdropdowntreeview]').kendoExtDropDownTreeView({
	        treeview: {
	            dataSource: new kendo.data.HierarchicalDataSource({
	                data: [
                        {
                            id: 11, text: "Furniture", items: [
                              { id: 12, text: "Tables & Chairs" },
                              { id: 13, text: "Sofas" },
                              { id: 14, text: "Occasional Furniture" }
                            ]
                        },
                        {
                            id: 15, text: "Decor", items: [
                              { id: 16, text: "Bed Linen" },
                              { id: 17, text: "Curtains & Blinds" },
                              { id: 18, text: "Carpets" }
                            ]
                        }
	                ]
	            })
	        }
	    }).data("kendoExtDropDownTreeView");	    
	};

	$scope.editCategoryControl = function (container, options) {

	    $("<div class='dropDownTreeView'/>").appendTo(container);

	    var treeview = $(".dropDownTreeView").kendoExtDropDownTreeView({
	        treeview: {
	            dataSource: new kendo.data.HierarchicalDataSource({
	                data: [
                        {
                            id: 11, text: "Furniture", items: [
                              { id: 12, text: "Tables & Chairs" },
                              { id: 13, text: "Sofas" },
                              { id: 14, text: "Occasional Furniture" }
                            ]
                        },
                        {
                            id: 15, text: "Decor", items: [
                              { id: 16, text: "Bed Linen" },
                              { id: 17, text: "Curtains & Blinds" },
                              { id: 18, text: "Carpets" }
                            ]
                        }
	                ]
	            })
	        }
	    }).data("kendoExtDropDownTreeView");

	    var selectedValue = treeview._treeview.findByUid(options.model.CategoryId);
	    treeview._treeview.select(selectedValue);
	    //treeview._treeview.trigger("select");
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

}
]);

