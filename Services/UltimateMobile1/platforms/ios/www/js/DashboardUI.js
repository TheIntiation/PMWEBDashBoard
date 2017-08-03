function DashboardUI() {
    var self = this;
    var baseUrl = "http://localhost:6607/";
   // alert("sfsa");


    function getUrlVars() {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    }

    var UserID = getUrlVars()["UserID"];
    var UserName = getUrlVars()["UserName"];

   
    /***********Global DATA MODELS**********/

    function LoginDTO(LoginDTO) {
        var self = this;
        self.UserName = LoginDTO.UserName;
        self.Password = LoginDTO.Password;
    }

    function MenueDTO(MenueDTO) {
        var self = this;
        self.RecordTypeId = MenueDTO.RecordTypeId;
        self.RecordType = MenueDTO.RecordType;
        self.TotalPendingItems = MenueDTO.TotalPendingItems;
    }

    function ProjectDTO(ProjectDTO) {
        var self = this;
        self.Id = ProjectDTO.Id;
        self.ProjectName = ProjectDTO.ProjectName;
        self.ProjectNumber = ProjectDTO.ProjectNumber;
        self.ProgramId = ProjectDTO.ProgramId;
        self.IsActive = ProjectDTO.IsActive;
        self.IsInitiative = ProjectDTO.IsInitiative;
    }

    function DataTransferModel(DataTransferModel) {
        var self = this;
        self.IsSucess = DataTransferModel.IsSucess;
        self.Message = DataTransferModel.Message;
        self.DataValue = DataTransferModel.DataValue;
    }

   
    /***********Global DATA MODELS**********/
     
    
    /***********Global Variables**********/
    self.UserID = ko.observable(UserID);       ///Login UserID
    self.TotalWorkFlowPendingItems = ko.observable(0);
    self.UserName = ko.observable(UserName);     ///Login UserName
    self.UserFullName = ko.observable(0); ///Login UserFullName
    self.selectedProject = ko.observable(0);

    self.WorkUnderContract = ko.observable(0);
    self.WorkinProgress = ko.observable(0);
    self.UnstartedContracts = ko.observable(0);
    self.ContractChanges = ko.observable(0);
    self.ProjectedCost = ko.observable(0);


    self.ProjectsList = ko.observableArray([]);
    self.MenueList = ko.observableArray([]);

    /***********Global Variables**********/


    /***********Global Objects**********/
    var LoginDTO = new LoginDTO(new Object());
    /***********Global Objects**********/
    
  
    self.GetPortifolioSummryDashbaord = function () {
        var GetPortifolioSummryDashbaord_URL = baseUrl + "api/WorkFlow/GetPortifolioSummryDashbaord?programid=0";
        $.ajax({
            url: GetPortifolioSummryDashbaord_URL,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            success: function (data, textStatus, jqXHR) {
                if (data.IsSucess == true) {
                    ko.utils.arrayForEach(data.DataValue, function (record) {
                        self.WorkUnderContract('$' + record.WorkUnderContract);
                        self.WorkinProgress('$' + record.WorkinProgress);
                        self.UnstartedContracts('$' + record.UnstartedContracts);
                        self.ContractChanges('$' + record.ContractChanges);
                        self.ProjectedCost('$' + record.ProjectedCost);
                    });

                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });
    };


    self.GetMenueList = function () {
        var GetMenueList_URL = baseUrl + "api/WorkFlow/getWorkflowmenu?userId=" + self.UserName();
        var TotalWorkFlowPendingItems = parseInt(0);
        $.ajax({
            url: GetMenueList_URL,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            success: function (data, textStatus, jqXHR) {
             
                if (data.IsSucess == true) {
                    self.MenueList.removeAll();
                   
                    ko.utils.arrayForEach(data.DataValue, function (record) {
                        self.MenueList.push(new MenueDTO(record));
                        TotalWorkFlowPendingItems = TotalWorkFlowPendingItems + parseInt(record.TotalPendingItems);
                    });
                    self.TotalWorkFlowPendingItems(TotalWorkFlowPendingItems);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });
    };

    self.GetProjectsList = function () {
        var GetProjectsList_URL = baseUrl + "api/WorkFlow/GetALLUserProjects?UserId=" + self.UserID();
        $.ajax({
            url: GetProjectsList_URL,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            success: function (data, textStatus, jqXHR) {
                if (data.IsSucess == true) {
                    self.ProjectsList.removeAll();
                    ko.utils.arrayForEach(data.DataValue, function (record) {

                        self.ProjectsList.push(new ProjectDTO(record));
                    });
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });
    };

    self.TranslateGoogleAddressToDirections = function (GoogleAddress) {

        var geocoder = new google.maps.Geocoder();
        var address = GoogleAddress;
        
        geocoder.geocode({ 'address': address }, function (results, status) {

            if (status == google.maps.GeocoderStatus.OK) {
               // alert(address);

                var latitude = results[0].geometry.location.lat();
                var longitude = results[0].geometry.location.lng();
                //alert(latitude);

            }
        });

        //var GetGoogleAddressDirections_URL = "https://maps.googleapis.com/maps/api/geocode/json?address=" + GoogleAddress + "&key=AIzaSyB7XgD17kwbsbdgl92Q26_suKecVsbS37Y";
        //$.ajax({
        //    url: GetGoogleAddressDirections_URL,
        //    type: "GET",
        //    contentType: 'application/json; charset=utf-8',
        //    async: true,
        //    success: function (data, textStatus, jqXHR) {
        //        alert(data.results.geometry.bounds.northeast.lat);
        //    },
        //    error: function (jqXHR, textStatus, errorThrown) {
        //        // alert('Error: ' + errorThrown + "/" + textStatus);
        //    }
        //});
    }
    self.GenrateMap = function () {

        var GetPortifolioSummryDashbaord_URL = baseUrl + "api/WorkFlow/GetPortifolioSummryDashbaord?programid=-1";
        $.ajax({
            url: GetPortifolioSummryDashbaord_URL,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            success: function (data, textStatus, jqXHR) {
                if (data.IsSucess == true) {
                    ko.utils.arrayForEach(data.DataValue, function (record) {
                        self.TranslateGoogleAddressToDirections(record.GoogleAddress);
                    });

                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // alert('Error: ' + errorThrown + "/" + textStatus);
            }
        });

        var locations = [
          ['Bondi Beach', -33.890542, 151.274856, 0,34],
          ['Coogee Beach', -33.923036, 151.259052, 0,34],
          ['Cronulla Beach', -34.028249, 151.157507, 0,34],
          ['Manly Beach', -33.80010128657071, 151.28747820854187, 0,34],
          ['Maroubra Beach', -33.950198, 151.259302, 0,34]
        ];

        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 10,
            center: new google.maps.LatLng(-33.92, 151.25),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });

        var infowindow = new google.maps.InfoWindow();

        var marker, i;

        for (i = 0; i < locations.length; i++) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                map: map
            });

            google.maps.event.addListener(marker, 'click', (function (marker, i) {

               

                return function () {
                    //infowindow.setContent(locations[i][0]);
                    //infowindow.open(map, marker);
                    window.location = "sfsfs?asfd=" + locations[i][4];
                }
            })(marker, i));
        }
    }
    /***********Global Services**********/
       
    self.GetProjectsList();
    self.GetMenueList();
    self.GetPortifolioSummryDashbaord();
    self.GenrateMap();

}