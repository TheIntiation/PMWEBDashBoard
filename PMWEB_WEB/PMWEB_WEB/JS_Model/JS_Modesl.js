function Workflow_GetInboxByUser(Workflow_GetInboxByUser) {

    var self = this;

    self.DocumentId = ko.observable(Workflow_GetInboxByUser.DocumentId);
    self.ObjectTypeId = ko.observable(Workflow_GetInboxByUser.ObjectTypeId);
    self.RecordId = ko.observable(Workflow_GetInboxByUser.RecordId);
    self.RecordTypeId = ko.observable(Workflow_GetInboxByUser.RecordTypeId);
    self.RecordType = ko.observable(Workflow_GetInboxByUser.RecordType);
    self.EntityId = ko.observable(Workflow_GetInboxByUser.EntityId);
    self.Project = ko.observable(Workflow_GetInboxByUser.Project);
    self.PropertyName = ko.observable(Workflow_GetInboxByUser.PropertyName);
    self.Entity = ko.observable(Workflow_GetInboxByUser.Entity);
    self.Description = ko.observable(Workflow_GetInboxByUser.Description);
    self.StatusId = ko.observable(Workflow_GetInboxByUser.StatusId);
    self.StepNumber = ko.observable(Workflow_GetInboxByUser.StepNumber);
    self.NumberOfSteps = ko.observable(Workflow_GetInboxByUser.NumberOfSteps);
    self.MainPage = ko.observable(Workflow_GetInboxByUser.MainPage);
    self.ModuleId = ko.observable(Workflow_GetInboxByUser.ModuleId);
    self.PageId = ko.observable(Workflow_GetInboxByUser.PageId);
    self.CurrentStepNumber = ko.observable(Workflow_GetInboxByUser.CurrentStepNumber);
    self.DueDate = ko.observable(Workflow_GetInboxByUser.DueDate);
    self.correspondencedetails = ko.observable(Workflow_GetInboxByUser.correspondencedetails);
    self.ProjectNumber = ko.observable(Workflow_GetInboxByUser.ProjectNumber);
    self.RecordNumber = ko.observable(Workflow_GetInboxByUser.RecordNumber);
    self.DocumentDate = ko.observable(Workflow_GetInboxByUser.DocumentDate);
    self.FromContact = ko.observable(Workflow_GetInboxByUser.FromContact);
    self.ToContact = ko.observable(Workflow_GetInboxByUser.ToContact);
    self.FromCompany = ko.observable(Workflow_GetInboxByUser.FromCompany);
    self.ToCompany = ko.observable(Workflow_GetInboxByUser.ToCompany);
    self.TotalPendingWorkFlow = ko.observable(Workflow_GetInboxByUser.TotalPendingWorkFlow);

}

function PieChartDTO(PieChartDTO) {
    var self = this;
    self.name = PieChartDTO.SystemName;
    self.data = PieChartDTO.PercentageWithTotal;

}


function DocumentsInDelayDTO(PieChartDTO) {
    var self = this;
    self.totaldelay = PieChartDTO.totaldelay;
    self.Entity = PieChartDTO.Entity;
    self.RecordType = PieChartDTO.RecordType;

}


