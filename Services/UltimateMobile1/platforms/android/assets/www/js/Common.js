myApp.onPageInit('main', function (page) {
    $$(".highcharts-credits").html('');
     $$(".navbar").css("display", "block");
     $$(".toolbar").css("display", "block");
    var mySwiper = myApp.swiper('.swiper-container', {
    pagination:'.swiper-pagination'
  });
    
    Highcharts.theme = {
        colors: ['#2b908f', '#90ee7e', '#f45b5b', '#7798BF', '#aaeeee', '#ff0066', '#eeaaee',
           '#55BF3B', '#DF5353', '#7798BF', '#aaeeee'],
        chart: {
            backgroundColor: {
                linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                stops: [
                   [0, '#2a2a2b'],
                   [1, '#3e3e40']
                ]
            },
            style: {
                fontFamily: '\'Unica One\', sans-serif'
            },
            plotBorderColor: '#606063'
        },
        title: {
            style: {
                color: '#E0E0E3',
                textTransform: 'uppercase',
                fontSize: '20px'
            }
        },
        subtitle: {
            style: {
                color: '#E0E0E3',
                textTransform: 'uppercase'
            }
        },
        xAxis: {
            gridLineColor: '#707073',
            labels: {
                style: {
                    color: '#E0E0E3'
                }
            },
            lineColor: '#707073',
            minorGridLineColor: '#505053',
            tickColor: '#707073',
            title: {
                style: {
                    color: '#A0A0A3'

                }
            }
        },
        yAxis: {
            gridLineColor: '#707073',
            labels: {
                style: {
                    color: '#E0E0E3'
                }
            },
            lineColor: '#707073',
            minorGridLineColor: '#505053',
            tickColor: '#707073',
            tickWidth: 1,
            title: {
                style: {
                    color: '#A0A0A3'
                }
            }
        },
        tooltip: {
            backgroundColor: 'rgba(0, 0, 0, 0.85)',
            style: {
                color: '#F0F0F0'
            }
        },
        plotOptions: {
            series: {
                dataLabels: {
                    color: '#B0B0B3'
                },
                marker: {
                    lineColor: '#333'
                }
            },
            boxplot: {
                fillColor: '#505053'
            },
            candlestick: {
                lineColor: 'white'
            },
            errorbar: {
                color: 'white'
            }
        },
        legend: {
            itemStyle: {
                color: '#E0E0E3'
            },
            itemHoverStyle: {
                color: '#FFF'
            },
            itemHiddenStyle: {
                color: '#606063'
            }
        },
        credits: {
            style: {
                color: '#666'
            }
        },
        labels: {
            style: {
                color: '#707073'
            }
        },

        drilldown: {
            activeAxisLabelStyle: {
                color: '#F0F0F3'
            },
            activeDataLabelStyle: {
                color: '#F0F0F3'
            }
        },

        navigation: {
            buttonOptions: {
                symbolStroke: '#DDDDDD',
                theme: {
                    fill: '#505053'
                }
            }
        },

        // scroll charts
        rangeSelector: {
            buttonTheme: {
                fill: '#505053',
                stroke: '#000000',
                style: {
                    color: '#CCC'
                },
                states: {
                    hover: {
                        fill: '#707073',
                        stroke: '#000000',
                        style: {
                            color: 'white'
                        }
                    },
                    select: {
                        fill: '#000003',
                        stroke: '#000000',
                        style: {
                            color: 'white'
                        }
                    }
                }
            },
            inputBoxBorderColor: '#505053',
            inputStyle: {
                backgroundColor: '#333',
                color: 'silver'
            },
            labelStyle: {
                color: 'silver'
            }
        },

        navigator: {
            handles: {
                backgroundColor: '#666',
                borderColor: '#AAA'
            },
            outlineColor: '#CCC',
            maskFill: 'rgba(255,255,255,0.1)',
            series: {
                color: '#7798BF',
                lineColor: '#A6C7ED'
            },
            xAxis: {
                gridLineColor: '#505053'
            }
        },

        scrollbar: {
            barBackgroundColor: '#808083',
            barBorderColor: '#808083',
            buttonArrowColor: '#CCC',
            buttonBackgroundColor: '#606063',
            buttonBorderColor: '#606063',
            rifleColor: '#FFF',
            trackBackgroundColor: '#404043',
            trackBorderColor: '#404043'
        },

        // special colors for some of the
        legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
        background2: '#505053',
        dataLabelsColor: '#B0B0B3',
        textColor: '#C0C0C0',
        contrastTextColor: '#F0F0F3',
        maskColor: 'rgba(255,255,255,0.3)'
    };

    // Apply the theme
    Highcharts.setOptions(Highcharts.theme);

    Highcharts.chart('container', {

        title: {
            text: 'Curve'
        },

        subtitle: {
            text: ''
        },

        yAxis: {
            title: {
                text: ''
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },

        plotOptions: {
            series: {
                pointStart: 30
            }
        },

        series: [{
            name: 'Cost',
            data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
        }, {
            name: 'Revenue',
            data: [24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434]
        }, {
            name: 'Actual Cost',
            data: [11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387]
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