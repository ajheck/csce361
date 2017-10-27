
    // Global Options
    Chart.defaults.global.defaultFontSize = 12;
    Chart.defaults.global.defaultFontColor = '#777';

    var studPopChart = {
        labels:[],
        datasets:
        [
            {
                label:'Todays Usage',
                data: [],
                fillColor: "rgba(151,187,205,0.2)",
                strokeColor: "rgba(151,187,205,1)",
                pointColor: "rgba(151,187,205,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(151,187,205,1)",
            },
		    {
                label:'Typical Usage',
                data: [],
                fillColor: "rgba(220,220,220,0.2)",
                strokeColor: "rgba(220,220,220,1)",
                pointColor: "rgba(220,220,220,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(220,220,220,1)",
		    }
        ],
        options: {
            title: {
                display: true,
                text: 'Student Population in the SRC',
                fontSize: 25
            },
            multiTooltipTemplate: "<%= datasetLabel %>: <%= value %>",
            scales: {
                yAxes: [{
                    id: 'y-axis-1',
                    type: 'linear',
                    position: 'left',
                    ticks: {
                        beginAtZero: true,
                        stepSize: 5,
                        max: 100
                    }
                }]
            },
            layout: {
                padding: {
                    left: 50,
                    right: 0,
                    bottom: 0,
                    top: 0
                }
            },
            tooltips: {
                enabled: true
            }
        }
    };

    $.getJSON("/Home/GetData/", function (data) {

        studPopChart.datasets[0].data.push(0);
        studPopChart.datasets[1].data.push(0);

        $.each(data, function (i, item) {
            if (item.TodaysPopulation >= 0) {
                studPopChart.datasets[0].data.push(item.TodaysPopulation);
            }

            studPopChart.datasets[1].data.push(item.HistoricalPopulation);
        })

        studPopChart.labels.push("9:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM", "6:00 PM", "7:00 PM");
        var ctx = document.getElementById("myChart").getContext("2d");

        var myLineChart = new Chart(ctx,
            {
                type: 'line',
                data: studPopChart
            });
    });

