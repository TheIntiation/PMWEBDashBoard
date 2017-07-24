// Initialize your app
var myApp = new Framework7({
    modalTitle: 'ULTIMATE APP',
    template7Pages: true,
    domCache: false,
    tapHold: true,
    swipePanelOnlyClose: true,
    swipeBackPage: false
});

var mySwiper = myApp.swiper('.swiper-container', {
    pagination: '.swiper-pagination'
});


var $$ = Dom7;

var RecordId=0;

var isAndroid = Framework7.prototype.device.android === true;
var isIos = Framework7.prototype.device.ios === true;

//var mainView = myApp.addView('.view-main', {
//    // Because we use fixed-through navbar we can enable dynamic navbar
//    dynamicNavbar: true,
//    template7Pages: true
//});

Template7.global = {
    isArabic: false,
    isEnglish: true
};

function CopyRights(){
    document.getElementById("op").innerHTML ="© All Rights Reserved to <span style=color:#6C3483;font-weight: bold;>Ultimate Solutions</span> " + new Date().getFullYear();   
}

$$("#Setting").on('click',function(){
    mainView.router.loadPage("Setting.html");
    $$(this).addClass('active');
    $$("#HomeTab").removeClass('active');
    $$("#Logout").removeClass('active');
});
$$("#HomeTab").on('click',function(){
   mainView.router.loadPage("main.html");
   $$(this).addClass('active');
   $$("#Setting").removeClass('active');
   $$("#Logout").removeClass('active');
});
$$("#Logout").on('click',function(){
    window.location.href = "index.html";
});
$$("#HelpDeskTab").on('click',function(){
    mainView.router.loadPage("helpdesk.html");
});
$$("#kpitab").on('click',function(){
    mainView.router.loadPage("main.html");
});
$$("#Workflow_correspondence").on('click', function () {
    mainView.router.loadPage("workflowDetails.html");
});

$$("#workflowkpi").on('click', function () {
    mainView.router.loadPage("WorkflowKPI.html");
});
//$$("#next").on('click', function () {
//    var username = $$("#txtUsername").val();
//    var password = $$("#txtPassword").val();
//    if (username == "" || username == null || username == undefined) {
//        document.getElementById("msg").innerHTML = "Please Enter User Name";
//        $('#txtUsername').focus().select();
//        return;
//    }
//    if (password == "" || password == null || password == undefined) {
//        document.getElementById("msg").innerHTML = "Please Enter Password";
//        $('#txtPassword').focus().select();
//        return;
//    }
//    //mainView.router.loadPage("WorkflowKPI.html")
//    var self = this;
//    self.Service_Login_Validate();
//    alert(self.userID());
//    window.location = "main.html";
//});
 
/**********************************Services****************************
1.Serv_Login_Validate

*/


var dynamicPageIndex = 0;
function createContentPage() {
	mainView.router.loadContent(
        '<!-- Top Navbar-->' +
        '<div class="navbar">' +
        '  <div class="navbar-inner">' +
        '    <div class="left"><a href="#" class="back link"><i class="icon icon-back"></i><span>Back</span></a></div>' +
        '    <div class="center sliding">Dynamic Page ' + (++dynamicPageIndex) + '</div>' +
        '  </div>' +
        '</div>' +
        '<div class="pages">' +
        '  <!-- Page, data-page contains page name-->' +
        '  <div data-page="dynamic-pages" class="page">' +
        '    <!-- Scrollable page content-->' +
        '    <div class="page-content">' +
        '      <div class="content-block">' +
        '        <div class="content-block-inner">' +
        '          <p>Here is a dynamic page created on ' + new Date() + ' !</p>' +
        '          <p>Go <a href="#" class="back">back</a> or go to <a href="services.html">Services</a>.</p>' +
        '        </div>' +
        '      </div>' +
        '    </div>' +
        '  </div>' +
        '</div>'
    );
	return;
}