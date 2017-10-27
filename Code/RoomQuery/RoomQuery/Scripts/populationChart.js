
    // Global Options
    Chart.defaults.global.defaultFontSize = 12;
    Chart.defaults.global.defaultFontColor = '#777';

    var studPopChart = {
        labels:[],
        datasets:
        [
            {
                label:'Student Population',
                data:[],
		        fill: false,
                backgroundColor:'red',
                borderWidth:3,
                borderColor:'#FF000',
                hoverBorderWidth:3,
                hoverBorderColor:'#000'
            },
		    {
                label:'Student Population',
                data:[],
		        fill: false,
                backgroundColor:'blue',
                borderWidth:3,
                borderColor:'#000FF',
                hoverBorderWidth:3,
                hoverBorderColor:'#000'
		    }
        ],
        options: {
            title: {
                display: true,
                text: 'Student Population in the SRC',
                fontSize: 25
            },
            legend: {
                display: true,
                position: 'right',
                labels: {
                    fontColor: '#000'
                }
            },
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

