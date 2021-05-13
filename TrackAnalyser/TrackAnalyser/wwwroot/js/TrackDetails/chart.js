//getting from page BAR/PIE
var barContext = document.getElementById('barChart').getContext('2d');
var pieContext = document.getElementById("pieChart").getContext('2d');

//handling data BAR/PIE
var barRawData = document.getElementById('barChartData').innerHTML;
var barDataObj = JSON.parse(barRawData);

var pieRawData = document.getElementById('pieChartData').innerHTML;
var pieDataObj = JSON.parse(pieRawData);


//########## BAR CHART ###########

//preparing arrays for bar chart
var number = barDataObj.BarDateCounts.Count;
var barLabels = new Array(number);
var barLabelsData = new Array(number);
var barBackgroundColor = new Array(number);

//loop for bar chart
barDataObj.BarDateCounts.forEach(function (element, i) {
    barLabels[i] = element.Date;
    barLabelsData[i] = element.Count;

    if (i % 2 == 0) 
        barBackgroundColor[i] = "rgb(240,128,128)";
      
    else
        barBackgroundColor[i] = "rgb(205,92,92)";
});
//main data for bar chart
var barData = {
    labels: barLabels,
    datasets: [{
        label: 'Last Played',
        data: barLabelsData,
        backgroundColor: barBackgroundColor,
    }]
};
//options for bar chart
var barOptions = {
    scales: {
        y: {
            beginAtZero: true
        }
    }
}
//bar chart
var barChart = new Chart(barContext, {
    type: 'bar',
    data: barData,
    options: barOptions
});

//########## PIE CHART ###########

//preparing arrays for pie chart
var number = pieDataObj.PieNameCounts.Count;
var pieLabels = new Array(number);
var pieLabelsData = new Array(number);
var pieBackgroundColor = new Array(number);
//loop for pie chart
pieDataObj.PieNameCounts.forEach(function (element, i) {
    pieLabels[i] = element.Name;
    pieLabelsData[i] = element.Count;
    pieBackgroundColor[i] = "rgb(240,128,128)";

});
//main data for pie chart
var pieData = {
    labels: pieLabels,
    datasets: [
        {
            fill: true,
            backgroundColor: pieBackgroundColor,
            data: pieLabelsData
        }
    ]
};
//options for pie chart
var pieOptions = {
    title: {
        display: true,
        position: 'top'
    },
    rotation: -0.7 * Math.PI
};
//pie chart
var pieChart = new Chart(pieContext, {
    type: 'pie',
    data: pieData,
    options: pieOptions
});
