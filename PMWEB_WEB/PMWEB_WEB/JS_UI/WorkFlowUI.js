function WorkFlowUI(baseUrl, UserID, UserName, UserFullName) {

    var self = this;

    self.Workflow_GetInboxByUser_List = ko.observableArray([]);
    self.TotalPendingWorkFlow = ko.observable(0);

    self.GetPendingWorkFlowByUserID = function (UserName) {
        var GetPendingWorkFlowByUserID_API_URL = baseUrl + "api/WorkFlow/GetPendingWorkFlowByUserID?UserID=" + UserName;
        $.ajax({
            url: GetPendingWorkFlowByUserID_API_URL,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            success: function (data, textStatus, jqXHR) {
                if (data.IsSucess == true) {
                    //self.TotalPendingWorkFlow(data.DataValue);
                    self.Workflow_GetInboxByUser_List.removeAll();
                    var TotalPendingWorkFlow = 0;
                    ko.utils.arrayForEach(data.DataValue, function (record) {
                        TotalPendingWorkFlow = parseInt(TotalPendingWorkFlow) + parseInt(1);
                        self.Workflow_GetInboxByUser_List.push(new Workflow_GetInboxByUser(record));
                    });

                    self.TotalPendingWorkFlow(TotalPendingWorkFlow);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });
    };


    self.GetPendingWorkFlowByUserID(UserName);
}