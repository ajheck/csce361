// Global Options
Chart.defaults.global.defaultFontSize = 12;
Chart.defaults.global.defaultFontColor = '#777';

var numStudentsChart = {
	labels: [],
	datasets:
	[
		{
			label: 'Number of Uses Per Week',
			data: [],
			fillColor: "rgba(151,187,205,0.2)",
			strokeColor: "rgba(151,187,205,1)",
			pointColor: "rgba(151,187,205,1)",
			pointStrokeColor: "#fff",
			pointHighlightFill: "#fff",
			pointHighlightStroke: "rgba(151,187,205,1)",
			backgroundColor: 'red',
			fill: false,
			borderColor: "pink",
		}
	],

};

$.getJSON("/Professor/GetDataNumStudentUsage/", function (data) {


	$.each(data, function (i, item) {
			numStudentsChart.datasets[0].data.push(item.NumStudents);
	})

	numStudentsChart.labels.push("Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8", "Week 9", "Week 10", "Week 11", "Week 12", "Week 13", "Week 14", "Week 15", "Week 16");
	var ctx = document.getElementById("numStudentsWeek").getContext("2d");

	var myLineChart = new Chart(ctx,
		{
			type: 'line',
			data: numStudentsChart,

		});
});

