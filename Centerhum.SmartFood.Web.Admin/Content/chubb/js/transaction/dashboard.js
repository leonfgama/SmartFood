var currentDate;
var ChubbDashBoard = {
    Init: function () {
        ChubbDashBoard.InitMethods.GetDataChart(new Date().toLocaleDateString());
        ChubbDashBoard.InitMethods.GetDataChartPie(new Date().toLocaleDateString());
        ChubbDashBoard.InitMethods.LoadInfos(new Date().toLocaleDateString());
        ChubbDashBoard.InitMethods.DayChangeEvent();

    },
    InitMethods: {
        GetDataChart: function (date) {
            NProgress.start();
            var $urlChartProgress = $("#UrlChartProgress");
            var urlChartProgress = $urlChartProgress.val();
            var cod_tipo_operacao = $urlChartProgress.attr("data-cod-tipo-operacao");
            $.ajax({
                url: urlChartProgress,
                type: "GET",
                data: { date: date, cod_tipo_operacao: cod_tipo_operacao },
                success: function (response) {
                    if (response != []) {
                        ChubbDashBoard.Methods.MakeChartProgress(response);
                    }
                    else {
                        ChubbAPI.UIMethods.ShowMessage("Não foi possivel encontrar dados com essa data!", 3);
                    }
                    NProgress.done();
                }
            });
        },
        GetDataChartPie: function (date) {
            NProgress.start();
            var $urlChartProgress = $("#UrlChartProgressPie");
            var urlChartProgress = $urlChartProgress.val();
            var cod_tipo_operacao = $urlChartProgress.attr("data-cod-tipo-operacao");
            $.ajax({
                url: urlChartProgress,
                type: "GET",
                data: { date: date, cod_tipo_operacao: cod_tipo_operacao },
                success: function (response) {
                    if (response != "") {
                        ChubbDashBoard.Methods.MakeChartProgressPie(response);
                    }
                    NProgress.done();
                }
            });
        },
        LoadInfos: function (date) {
            var $urlGetDataInfos = $("#UrlInfos");
            var urlGetDataInfos = $urlGetDataInfos.val();
            var cod_tipo_operacao = $urlGetDataInfos.attr("data-cod-tipo-operacao");

            var dataGet = { date: date, cod_tipo_operacao: cod_tipo_operacao };
            $("#tblDocumentOperationInfos").load(urlGetDataInfos, dataGet, function () {
                
            });

        },
        DayChangeEvent: function () {
            $("#txtDay").change(function () {
                var $txtDate = $("#txtDay");
                if ($txtDate.val() == "") {
                    return;
                }

                ChubbDashBoard.InitMethods.GetDataChart($txtDate.val());
                ChubbDashBoard.InitMethods.GetDataChartPie($txtDate.val());
                ChubbDashBoard.InitMethods.LoadInfos($txtDate.val());
                //ChubbDashBoard.InitMethods.LoadInfos($txtDate.val());
            });
        }
    },
    Methods: {
        MakeChartProgress: function (obj) {
            var dataChart = [];            
            for (var i = 0; i < obj.ChartValue.length; i++) {
                dataChart.push({
                    data: obj.ChartValue[i].Value,
                    label: obj.ChartValue[i].Label
                });
            }

            var plot = $.plot("#progressChart",
		        dataChart,
		        $.extend(true, {}, Plugins.getFlotWidgetDefaults(), {
		            series: {
		                lines: { show: true },
		                points: { show: true },
		                grow: { active: true }
		            },
		            grid: {
		                hoverable: true,
		                clickable: true
		            },
		            yaxis: {
		                min: 0,
		                max: obj.Settings.XaxisSettings.Max
		            },
		            xaxis: {
		                min: 0,
		                max: 24
		            },
		            series: {
		                lines: {
		                    fill: true,
		                    lineWidth: 2.0
		                },
		                points: {
		                    show: true,
		                    radius: 4,
		                    lineWidth: 1.1
		                },
		                grow: { active: true, growings: [{
		                    stepMode: "maximum"
		                }]
		                }
		            },
		            tooltip: true,
		            tooltipOpts: {
		                content: '%s: %y'
		            }
		        })
	        );
        },
        MakeChartProgressPie: function (obj) {
            // Sample Data
            var dataChart = [];
            var series = Math.floor(Math.random() * 10) + 1;
            for (var i = 0; i < obj.length; i++) {
                dataChart[i] = { label: obj[i].nom_operacao, data: obj[i].num_qtde }
            }

           


            $.plot("#progressChartPie", dataChart, $.extend(true, {}, Plugins.getFlotDefaults(), {
                series: {
                    pie: {
                        show: true,
                        radius: 9/10,
                        label: {
                            show: false
                        }
                    }
                },
                grid: {
                    hoverable: true,
                    clickable: true
                },
                tooltip: true,
                tooltipOpts: {
                    content: '%p.0%, %s', // show percentages, rounding to 2 decimal places
                    shifts: {
                        x: 20,
                        y: 0
                    }
                }
            }));
        }
    }
}


// Initialize Bind!
$(document).ready(function (){
    ChubbDashBoard.Init();
});