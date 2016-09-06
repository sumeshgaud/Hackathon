
app.factory('customGridFactory', ['$compile', function ($compile) {
    return function (prop, $scope) {
        this._tableId = prop.tableId;
        this._pagingMessageLabel = prop.pagingMessageLabel;
        this._dataSource = prop.dataSource || {};
        this._columns = prop.columns || [];
        this.totalRecords = 0;
        this._updateTotalRecords = prop.getSchedulesTotal;

        this.customizePagination = function (arg) {
            var self = this;
            var colCount = $("#" + this._tableId).find('colgroup > col').length;
            if (this._dataSource.total() == 0) {
                //arg.sender.tbody.append('<tr class="kendo-data-row"><td colspan="' + colCount + '" style="text-align:center"><b>No ' + this._pagingMessageLabel + ' Results Found!</b></td></tr>');
                arg.sender.tbody.append('<tr class="kendo-data-row"><td colspan="' + colCount + '" style="text-align:center"><b>No Records Found</b></td></tr>');
            }
            var gridContent = arg.sender.element.find('.k-grid-content');
            if (this._dataSource.totalPages() <= 1) {
                gridContent.css('height', gridContent.height() + arg.sender.pager.element.innerHeight());
                arg.sender.pager.element.hide();
            } else {
                arg.sender.pager.element.show();
                gridContent.css('height', gridContent.height() - arg.sender.pager.element.innerHeight());
            }

            var actualPageSize = this._dataSource.pageSize();
            var currentPageNumber = this._dataSource.page();
            var dataCount = this._dataSource.total();

            // #446
            if (dataCount > 0 && dataCount == ((currentPageNumber - 1) * actualPageSize)) {
                currentPageNumber = currentPageNumber - 1;
                arg.sender.dataSource.page(currentPageNumber)
            }
            //end
            // Set correct page number
            var totalPages = dataCount / actualPageSize;
            var remainder = dataCount % actualPageSize;
            if (remainder > 0) {
                totalPages = (dataCount - remainder) / actualPageSize + 1;
            }
            var pageMessage = "Page " + currentPageNumber + " of " + totalPages + "";
            arg.sender.pager.options.messages = {};
            arg.sender.pager.options.messages.display = pageMessage;
        };

        //default function for databound
        //If isPageable is false, apply scope and compile the Table id for event bootstrping, else bind data bound event for paging 
        this._dataBoundCallback = prop.dataBound != undefined ? prop.dataBound : ((!prop.isPageable && prop.isPageable != undefined) ? function (arg) { $scope.$apply(); $compile($("#" + prop.tableId).contents())($scope); } : function (arg) {
            var self = this;
            var cellTitle = [];
            var index = 0;
            arg.sender.thead.find('th').each(function () {
                if ($(this).attr("data-title") != undefined) {
                    cellTitle[index++] = $(this).attr("data-title");
                }
            });
            index = 0;
            arg.sender.tbody.find("tr").each(function () {
                if ($(this).attr("data-uid") != undefined) {
                    var indexCell = 0;
                    $(this).find("td").each(function () {
                        if (!$(this).hasClass('k-group-cell')) {
                            $(this).attr("data-title", cellTitle[indexCell++]);
                            if ($(this)[0].innerHTML == '')
                                $(this)[0].innerHTML = "&nbsp;"; //Added for Responsive layout
                        }
                    });
                }
            });
            var colCount = $("#" + prop.tableId).find('colgroup > col').length; //472 issue
            //  var colCount = arg.sender.columns.length;  
            if (arg.sender.dataSource.total() == 0) {
                arg.sender.tbody.append('<tr class="kendo-data-row"><td colspan="' + colCount + '" style="text-align:center"><b>No  Records Found!</b></td></tr>');
            }
            var gridContent = arg.sender.element.find('.k-grid-content');
            if (arg.sender.dataSource.totalPages() <= 1) {
                gridContent.css('height', gridContent.height() + arg.sender.pager.element.innerHeight());
                arg.sender.pager.element.hide();
            } else {
                arg.sender.pager.element.show();
                gridContent.css('height', gridContent.height() - arg.sender.pager.element.innerHeight());
            }

            var actualPageSize = arg.sender.dataSource.pageSize();
            var currentPageNumber = arg.sender.dataSource.page();
            var dataCount = arg.sender.dataSource.total();

            if (dataCount > 0 && dataCount == ((currentPageNumber - 1) * actualPageSize)) {
                currentPageNumber = currentPageNumber - 1;
                arg.sender.dataSource.page(currentPageNumber);

            }
            // Set correct page number
            var totalPages = dataCount / actualPageSize;
            var remainder = dataCount % actualPageSize;
            if (remainder > 0) {
                totalPages = (dataCount - remainder) / actualPageSize + 1;
            }
            var pageMessage = "Page " + currentPageNumber + " of " + totalPages + "";
            arg.sender.pager.options.messages = {};
            arg.sender.pager.options.messages.display = pageMessage;
            $scope.$apply();
            $compile($("#" + prop.tableId).contents())($scope);


        });

        this._changeCallback = prop.change || "";

        this._messages = {
            //display: "Page {0} - {1}", //{0} is the index of the first record on the page, {1} - index of the last record on the page, {2} is the total amount of records
            empty: "No items to display",
            page: "Page",
            of: "of {0}", //{0} is total amount of pages
            itemsPerPage: "",
            first: "First",
            previous: "Previous",
            next: "Next",
            last: "Last",
            refresh: ""
        };

        this._pageable = (!prop.isPageable && prop.isPageable != undefined) ? false : prop.pageable || {
            pageSize: 10,
            buttonCount: 5,
            previousNext: true,
            messages: this._messages
        };

        this._filterable = prop.filterable == false ? prop.filterable : {
            extra: false,
            operators: {
                string: {
                    contains: "Contains",
                    startswith: "Starts with",
                    eq: "Is equal to",
                    neq: "Is not equal to",
                    doesnotcontain: "Does not contain",
                    endswith: "Ends with"
                }
            }
        };
        this._resizable = prop.resizable || true;
        this._selectable = prop.selectable == undefined ? true : prop.selectable; // If default true, otherwise take value from passed values
        this._sortable = prop.sortable == false ? prop.sortable : { mode: "single", allowUnsort: true };
        this._scrollable = prop.scrollable || false;

        this._dataBinding = prop.dataBinding || "";
        this._save = prop.save || "";
        this._remove = prop.remove || "";

        this._editable = prop.editable || "";
        // filterMenuInit prevents negative numbers in number fields for grid filter
        this._filterMenuInit = function (e) {
            var numeric = e.container.find("[data-role=numerictextbox]").data("kendoNumericTextBox");
            if (numeric) {
                numeric.min(0);
            }
        }



        //Grid control
        $("#" + prop.tableId).kendoGrid({
            dataBound: this._dataBoundCallback,
            dataSource: this._dataSource,
            columns: this._columns,
            change: this._changeCallback,
            pageable: this._pageable,
            scrollable: this._scrollable,
            filterable: this._filterable,
            resizable: this._resizable,
            selectable: this._selectable,
            sortable: this._sortable,
            dataBinding: this._dataBinding,
            save: this._save,
            remove: this._remove,
            editable: this._editable,
            filterMenuInit: this._filterMenuInit
        });

        this.gridInstance = $("#" + prop.tableId).data("kendoGrid");
    };
}
]);
