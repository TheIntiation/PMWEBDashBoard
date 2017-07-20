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
    self.UserName = ko.observable(UserName);     ///Login UserName
    self.UserFullName = ko.observable(0); ///Login UserFullName
    self.selectedProject = ko.observable(0);

    self.ProjectsList = ko.observableArray([]);

    /***********Global Variables**********/


    /***********Global Objects**********/
    var LoginDTO = new LoginDTO(new Object());
    /***********Global Objects**********/


    
    //alert(self.UserID());
    //alert(self.UserName());

    /***********Global Services**********/

    // 1. Service_Login_Validate(userName,password) //
    // 2. GetProjectsList() //

  


  
    self.GetProjectsList = function () {
        var GetProjectsList_URL = baseUrl + "api/WorkFlow/GetProjectsList";
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
    /***********Global Services**********/
       
    self.GetProjectsList();


}