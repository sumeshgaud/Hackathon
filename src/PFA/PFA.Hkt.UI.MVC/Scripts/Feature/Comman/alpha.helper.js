//utility functions
var iAlphaUtility = iAlphaUtility || {};

iAlphaUtility.helpers = {
    pageStatus: {        
        showFailureMessage: function (message) {
            $('html, body').animate({ scrollTop: $('#div-page-status').position().top }, 'slow');
            $("#div-page-status .alert-success, #div-page-status .alert-danger #div-page-status .alert-warning").hide();
            this.clearAllMessages();
            $("#div-page-status .alert-danger .response-message").html(message);
            $("#div-page-status .alert-danger").show();
            $('#div-page-status').show();
            this.detachTimeout();
        },
        showSuccessMessage: function (message) {
            $('html, body').animate({ scrollTop: $('#div-page-status').position().top }, 'slow');
            $("#div-page-status .alert-success, #div-page-status .alert-danger #div-page-status .alert-warning").hide();
            this.clearAllMessages();
            $("#div-page-status .alert-success .response-message").html(message);
            $("#div-page-status .alert-success").show();
            $('#div-page-status').show();
            this.attachTimeout();
        },
        showWarningMessage: function (message) {
            $('html, body').animate({ scrollTop: $('#div-page-status').position().top }, 'slow');
            $("#div-page-status .alert-success, #div-page-status .alert-danger #div-page-status .alert-warning").hide();
            this.clearAllMessages();
            $("#div-page-status .alert-warning .response-message").html(message);
            $("#div-page-status .alert-warning").show();
            $('#div-page-status').show();
            this.detachTimeout();
        },
        clearAllMessages: function () {
            $("#div-page-status .alert").hide();
        },
        timeoutId: null,
        attachTimeout: function () {
            this.detachTimeout();
            var me = this;
            this.timeoutId = setTimeout(function () { me.clearAllMessages(); }, 10000);
        },
        detachTimeout: function () {
            if (this.timeoutId != null) {
                clearTimeout(this.timeoutId);
            }
        }
    },
    handlers: {
        checkNonNumericCharacters: function (event) {
            if (!((event.keyCode >= 48) && (event.keyCode <= 57))) {
                event.returnValue = false;
                return;
            }
            event.returnValue = true;
        },
        checkNumericAndSpecialCharacters: function () {
            if ((event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 32) || (event.keyCode >= 97 && event.keyCode <= 122)) {
                event.returnValue = true;
                return;
            }
            event.returnValue = false;
        },
        // Function to restrict user from entering non numberic characters        
        customizePaginaion: function (arg, dataSource, gridId, message) {
            // var colCount = arg.sender.columns.length;
            var colCount = $("#" + gridId).find('colgroup > col').length;
            if (dataSource.total() == 0) {
                arg.sender.tbody.append('<tr class="kendo-data-row"><td colspan="' + colCount + '" style="text-align:center"><b>No Records Found!</b></td></tr>');
                //arg.sender.tbody.append('<tr class="kendo-data-row"><td colspan="' + colCount + '" style="text-align:center"><b>No records found</b></td></tr>');
            }
            var gridContent = arg.sender.element.find('.k-grid-content');
            if (dataSource.totalPages() <= 1) {
                gridContent.css('height', gridContent.height() + arg.sender.pager.element.innerHeight());
                arg.sender.pager.element.hide();
            }

            else {
                arg.sender.pager.element.show();
                gridContent.css('height', gridContent.height() - arg.sender.pager.element.innerHeight());
            }

            var actualPageSize = dataSource.pageSize();
            var currentPageNumber = dataSource.page();
            var dataCount = dataSource.total();

            // #446
            if (dataCount > 0 && dataCount == ((currentPageNumber - 1) * actualPageSize)) {
                currentPageNumber = currentPageNumber - 1;
                dataSource.page(currentPageNumber)
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
        },
        refreshGrid: function (gridId, data) {
            $('#' + gridId).data('kendoGrid').dataSource.data(data);
            $('#' + gridId).data('kendoGrid').refresh();
        },
        destroyGrid: function (id) {
            var grid = $("#" + id);
            grid.empty();
            grid.html("");
            grid.next('div.k-pager-wrap').remove();
        },
        resetValidation: function () {
            $("span.k-tooltip-validation").hide();
            $(".form-control").removeClass("k-invalid");
        },

        resetDatePickers: function (elements) {
            _.forEach(elements, function (element) {
                $(element).kendoDatePicker().removeAttr("kendo-date-picker");
                $(element).kendoDatePicker({
                    format: "MM/dd/yyyy"
                }).attr("kendo-date-picker", "").val("");
            });
        }
    }
};
