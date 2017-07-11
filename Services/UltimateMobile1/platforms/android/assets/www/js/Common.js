myApp.onPageInit('main', function (page) {
    $$(".highcharts-credits").html('');
     $$(".navbar").css("display", "block");
     $$(".toolbar").css("display", "block");
    var mySwiper = myApp.swiper('.swiper-container', {
    pagination:'.swiper-pagination'
  });
    
    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Work Flow in Process'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                  
                },  showInLegend:true
            }
        },
        series: [{
            name: 'Brands',
            colorByPoint: true,
            data: [{
                name: 'Total Outstanding',
                y: 56.0
        }, {
                name: 'Total Overdue',
                y: 44.0,
                sliced: true,
                selected: true
        }]
    }]
    });
    
    
    
    
    
    var chart = Highcharts.chart('container2', {

        title: {
            text: 'Cost Summary'
        },

        subtitle: {
            text: ''
        },

        xAxis: {
            categories: ['Buget', 'Cost', 'Variants', 'Cost to Date', 'Forcast', 'Forcast Variance']
        },

        series: [{
            type: 'column',
            colorByPoint: true,
            data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0],
            showInLegend: false
    }]

    });
    
    
     var chart = Highcharts.chart('container3', {

        title: {
            text: 'Gateways'
        },

        subtitle: {
            text: ''
        },

        xAxis: {
            categories: ['Gateway 0', 'Gateway 1', 'Gateway 2', 'Gateway 3', 'Gateway 4','Gateway 5']
        },

        series: [{
            type: 'column',
            colorByPoint: true,
            data: [99, 99, 90.4, 50, 70, 80.0],
            showInLegend: false
    }]

    });
    
});
myApp.onPageInit('Graphs2', function (page) {

    var mySwiper = myApp.swiper('.swiper-container', {
        speed: 400,
        spaceBetween: 100
    });

    var chart = Highcharts.chart('container2', {

        title: {
            text: 'Chart.update'
        },

        subtitle: {
            text: 'Plain'
        },

        xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun']
        },

        series: [{
            type: 'column',
            colorByPoint: true,
            data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4],
            showInLegend: false
    }]

    });





    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Browser market shares January, 2015 to May, 2015'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            name: 'Brands',
            colorByPoint: true,
            data: [{
                name: 'Microsoft Internet Explorer',
                y: 56.33
        }, {
                name: 'Chrome',
                y: 24.03,
                sliced: true,
                selected: true
        }, {
                name: 'Firefox',
                y: 10.38
        }, {
                name: 'Safari',
                y: 4.77
        }, {
                name: 'Opera',
                y: 0.91
        }, {
                name: 'Proprietary or Undetectable',
                y: 0.2
        }]
    }]
    });
    $$(".highcharts-point").on('click', function () {
        debugger;
        if ($$(this).attr("fill") == "#7cb5ec") {
            myApp.alert('internet expolreer');
        }
    })

});

myApp.onPageInit('Graphs', function (page) {



    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Browser market shares January, 2015 to May, 2015'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            name: 'Brands',
            colorByPoint: true,
            data: [{
                name: 'Microsoft Internet Explorer',
                y: 20.33
        }, {
                name: 'Chrome',
                y: 30.03,
                sliced: true,
                selected: true
        }, {
                name: 'Firefox',
                y: 30.38
        }, {
                name: 'Safari',
                y: 4.77
        }, {
                name: 'Opera',
                y: 0.91
        }, {
                name: 'Proprietary or Undetectable',
                y: 0.2
        }]
    }]
    });


});

myApp.onPageInit('iteminfo', function (page) {
    debugger;
    var obj;
    var data = localStorage.getItem("value");
    data = JSON.parse(data);
    data = data.DataValue;
    for (var i = 0; i < data.length; i++) {
        // var concat=+data[i].RecordTypeId;
        if (data[i].RecordId == RecordId) {
            obj = data[i];
        }
    }

    $$("#ent").html(obj.Entity);
    $$("#prjnum").html(obj.ProjectNumber);
    $$("#due").html(obj.DueDate);


});

myApp.onPageInit('Home', function (page) {
    $$(".navbar").css("display", "block");
    //$$(".toolbar").show();
    var mySearchbar = myApp.searchbar('.searchbar', {
        searchList: '.list-block-search',
        searchIn: '.item-title'
    });

    getitems();
    appenditems();

    $$("#items li").on('click', function () {
        // myApp.alert(this.id);
        RecordId = this.id;
        mainView.router.loadPage('iteminfo.html');
    })
});