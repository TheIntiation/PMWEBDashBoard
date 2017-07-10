function getFormattedDate(myDate) {

    var month = myDate.getMonth() + 1;
    var monthText = month;

    if (month < 10)
        monthText = "0" + month;

    var day1 = parseInt(myDate.getDate());
    var dayText = day1;

    if (day1 < 10)
        dayText = '0' + day1;

    var formattedDate = myDate.getFullYear() + '-' + monthText + '-' + dayText;
    return formattedDate
}






ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize datepicker with some optional options
        var options = {
            autoclose: true,
            format: 'yyyy-mm-dd'
        }

        //var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        //when a user changes the date, update the view model
        ko.utils.registerEventHandler(element, "changeDate", function (event) {
            var value = valueAccessor();
            if (ko.isObservable(value)) {
                //value(event.date);
                var myDate = event.date;
                //  alert(event.date);
                var month = myDate.getMonth() + 1;
                var monthText = month;

                if (month < 10)
                    monthText = "0" + month;

                var day1 = parseInt(myDate.getDate());
                var dayText = day1;

                if (day1 < 10)
                    dayText = '0' + day1;

                value(myDate.getFullYear() + '-' + monthText + '-' + dayText);
            }
        });
    },
    update: function (element, valueAccessor) {
        var widget = $(element).data("datepicker");

        //when the view model is updated, update the widget
        if (widget) {
            widget.date = ko.utils.unwrapObservable(valueAccessor());
            if (widget.date != null || widget.date != undefined) {
                widget.setValue(widget.date);
            }
            else {
                var today = new Date();
                var curr_date = today.getDate();
                var curr_month = today.getMonth() + 1; //Months are zero based
                var curr_year = today.getFullYear();
                widget.setValue(curr_year + "-" + curr_month + "-" + curr_date);
            }
        }
    }
};




ko.bindingHandlers.datepicker2 = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize datepicker with some optional options
        var options = {
            autoclose: true,
            format: 'yyyy-mm-dd'
        }

        //var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        //when a user changes the date, update the view model
        ko.utils.registerEventHandler(element, "changeDate", function (event) {
            var value = valueAccessor();

            if (ko.isObservable(value)) {
                //value(event.date);
                var myDate = event.date;
                //  alert(event.date);
                var month = myDate.getMonth() + 1;
                var monthText = month;

                if (month < 10)
                    monthText = "0" + month;

                var day1 = parseInt(myDate.getDate());
                var dayText = day1;

                if (day1 < 10)
                    dayText = '0' + day1;

                value(myDate.getFullYear() + '-' + monthText + '-' + dayText);
            }
        });
    },
    update: function (element, valueAccessor) {
        var widget = $(element).data("datepicker");

        //when the view model is updated, update the widget
        if (widget) {

            widget.date = ko.utils.unwrapObservable(valueAccessor());

            if (widget.date)
                if (widget.date != null || widget.date != undefined) {
                    widget.setValue(widget.date);
                }

            //else {
            //    var today = new Date();
            //    var curr_date = today.getDate();
            //    var curr_month = today.getMonth() + 1; //Months are zero based
            //    var curr_year = today.getFullYear();
            //    widget.setValue(curr_year + "-" + curr_month + "-" + curr_date);
            //}
        }
    }
};








//Its events for Date Conversation from JSON to Date
ko.bindingHandlers.date = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        try {
            var jsonDate = ko.utils.unwrapObservable(valueAccessor());
            var value = parseJsonDateString(jsonDate);
            //var strDate = value.getMonth() + 1 + "-"
            //                + value.getDate() + "-"
            //                + value.getFullYear();

            var monthvalue = +value.getMonth() + 1 + "-"
            var strDate = value.getDate() + "-"
                            + monthvalue
                           + value.getFullYear();

            element.innerHTML = strDate;
            // alert(monthvalue);
        }
        catch (exc) {
        }
        $(element).change(function () {
            var value = valueAccessor();
            value(element.innerHTML);
        });
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var val = valueAccessor();
        val(element.innerHTML);
    }
};

var jsonDateRE = /^\/Date\((-?\d+)(\+|-)?(\d+)?\)\/$/;
var parseJsonDateString = function (value) {
    var arr = value && jsonDateRE.exec(value);
    if (arr) {
        return new Date(parseInt(arr[1]));
    }
    return value;
};


