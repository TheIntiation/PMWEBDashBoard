function PaginationVM(pageSize, pageNumber, SearchFunction) {
    var self = this;
    self.TotalRecordsCount = ko.observable();
    //self.PageSize = ko.observable(pageSize);
    self.PageSize = ko.observable(10);
    self.PageSizeList = ko.observableArray([1, 5, 10, 15, 20, 25, 50, 100]);
    self.PageNumber = ko.observable(pageNumber);
    

    self.PageCountDisplay = ko.computed(function () {
          if (self.TotalRecordsCount() == 0)
        { return "No Records"; }
        else
        {  var endRecordNumber = (((self.PageSize() * self.PageNumber()) - self.PageSize()) + 1);
            if (endRecordNumber >= self.TotalRecordsCount()) endRecordNumber = self.TotalRecordsCount();
            var startNumber = (self.PageSize() * self.PageNumber());
            if (startNumber >= self.TotalRecordsCount()) startNumber = self.TotalRecordsCount();
            return self.TotalRecordsCount() + " من " + startNumber + "-" + endRecordNumber;
        }
    }, self);


    self.GetNextPage = function () {
        var newPageNumber = self.PageNumber() + 1;
        var allowedNumberOfPages = Math.ceil(self.TotalRecordsCount() / self.PageSize());
        if (newPageNumber <= allowedNumberOfPages) {
            self.PageNumber(self.PageNumber() + 1);
             SearchFunction();
         }
    }
    self.GetPreviousPage = function () {
        var newPageNumber = self.PageNumber() - 1;
        if (newPageNumber > 0) {
            self.PageNumber(self.PageNumber() - 1);
            SearchFunction();
        }
    }

    self.GetLastPage = function () {
        var allowedNumberOfPages = Math.ceil(self.TotalRecordsCount() / self.PageSize());
        if (self.PageNumber() != allowedNumberOfPages) {
            self.PageNumber(allowedNumberOfPages);
            SearchFunction();
        }
    }
    self.GetFirstPage = function () {
        var newPageNumber = self.PageNumber() - 1;
        if (self.PageNumber() !=1) {
            self.PageNumber(1);
            SearchFunction();
        }
    }
    self.PageSizeChange = function ()
    {
        self.PageNumber(1);
        SearchFunction();
    }
}