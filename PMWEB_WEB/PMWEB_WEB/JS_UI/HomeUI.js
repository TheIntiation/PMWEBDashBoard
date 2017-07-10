function HomeUI(baseUrl, UserID, UserName, UserFullName) {

    var self = this;

    self.Workflow_GetInboxByUser_List = ko.observableArray([]);
    self.GetDocumentsInDelay_List = ko.observableArray([]);
    var DocumentsInDelayList = [];
    self.GetPendingDocuments_List = ko.observableArray([]);
    var PendingDocumentsList = [];
    self.TotalPendingWorkFlow = ko.observable(0);

    self.project_List = ko.observableArray([]);
    self.selectedProject = ko.observable();


    self.loadProject = function () {
        self.project_List.removeAll();
        self.project_List.push({ PName: 'Plot Q' });
        self.project_List.push({ PName: 'New HMC General' });
        self.project_List.push({ PName: 'Risk Mitigation' });
        self.project_List.push({ PName: 'New General Hospital ' });
        self.project_List.push({ PName: 'HMC Cardiac Phase' });
        self.project_List.push({ PName: 'New HMC General' });
        self.project_List.push({ PName: 'General Hospital in Al Sadd ' });
        self.project_List.push({ PName: 'HMC New phase development' });
    }
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
               // alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });
    };
    

    self.GetDocumentsInDelay = function (Project) {
        var GetDocumentsInDelay_API_URL = baseUrl + "api/WorkFlow/GetDocumentsInDelay?Project=" + Project;
        $.ajax({
            url: GetDocumentsInDelay_API_URL,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            success: function (data, textStatus, jqXHR) {
                if (data.IsSucess == true) {
                    self.GetDocumentsInDelay_List.removeAll();
                    ko.utils.arrayForEach(data.DataValue, function (record) {
                        self.GetDocumentsInDelay_List.push(new DocumentsInDelayDTO(record));
                    });
                    ko.utils.arrayForEach(self.GetDocumentsInDelay_List(), function (Item) {
                        var mydata = new PieChartDTO(new Object());
                        mydata.name = Item.RecordType;
                        mydata.data = Item.totaldelay;
                        DocumentsInDelayList.push(mydata);
                    });
                    self.DocumentsInDelayPie();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });
    }
    self.DocumentsInDelayPie = function () {
        var data = DocumentsInDelayList;
        $.each(data, function (i, point) {
            point.y = point.data;
        });
        var chart = new Highcharts.Chart({

            chart: {
                type: 'pie',
                renderTo: 'DocumentsInDelayList',
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'Browser market shares at a specific website, 2014'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            series: [{
                type: 'pie',
                name: 'Browser share',
                data: [
                    ['Firefox', 45.0],
                    ['IE', 26.8],
                    {
                        name: 'Chrome',
                        y: 12.8,
                        sliced: true,
                        selected: true
                    },
                    ['Safari', 8.5],
                    ['Opera', 6.2],
                    ['Others', 0.7]
                ]
            }]

            //series: [{
            //    data: data
            //}]

        });
    }



    self.GetPendingDocuments = function (Project) {
        var GetPendingDocuments_API_URL = baseUrl + "api/WorkFlow/GetPendingDocuments?Project=" + Project;
        $.ajax({
            url: GetPendingDocuments_API_URL,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            success: function (data, textStatus, jqXHR) {
                if (data.IsSucess == true) {
                    self.GetPendingDocuments_List.removeAll();
                    ko.utils.arrayForEach(data.DataValue, function (record) {
                        self.GetPendingDocuments_List.push(new DocumentsInDelayDTO(record));
                    });
                    ko.utils.arrayForEach(self.GetPendingDocuments_List(), function (Item) {
                        var mydata = new PieChartDTO(new Object());
                        mydata.name = Item.RecordType;
                        mydata.data = Item.totaldelay;
                        PendingDocumentsList.push(mydata);
                    });
                    self.PendingDocumentsPie();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
               // alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });
    }
    self.PendingDocumentsPie = function () {
        var data = PendingDocumentsList;
        $.each(data, function (i, point) {
            point.y = point.data;
        });
        var chart = new Highcharts.Chart({

            chart: {
                style: {
                    direction: 'rtl',
                },
                renderTo: 'PendingDocumentsPie',
                type: 'pie',
                alignTicks: true,
                animation: true,
                backgroundColor: '#ffffff',
                reflow: true,
                height: 250
            },

            title: {
                text: ''
            },

            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        distance: -40,
                        color: '#ffffff',
                        style: {
                            fontFamily: 'roboto',
                            fontSize: '12pt',
                            width: 80,
                           
                        },
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 1);
                        }
                    },
                    showInLegend: true
                }
            },


            legend: {
                rtl: true,
                useHTML: true,
                align: 'left',
                layout: 'vertical',
                verticalAlign: 'top',
                x: 40,
                y: 0,
                style: {
                    color: '#333333',
                    fontSize: '24px'
                }
            },

            tooltip: {
                pointFormat: '<b>{point.percentage:.1f}%</b>',
                style: {
                    color: '#333333',
                    fontSize: '24px'
                },
                useHTML: true
            },


            series: [{
                name: '',
                colorByPoint: true,
                data: [{
                    name: 'Correspondence',
                    y: 8
                }, {
                    name: 'RFI',
                    y: 4,
                    sliced: true,
                    selected: true
                }, {
                    name: 'Transmittals',
                    y: 6
                }]
            }]

        });
    }

    self.loadProject();
    self.PendingDocumentsPie();
    self.DocumentsInDelayPie();
    //self.GetPendingWorkFlowByUserID(UserName);
}