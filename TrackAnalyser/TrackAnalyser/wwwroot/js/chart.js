/*********** Global ***********/
//Chart.defaults.global.defaultFontColor = 'black';
//Chart.defaults.global.defaultFontSize = 16;

/*********** Context ***********/
var barContext = document.getElementById('barChart').getContext('2d');
var pieContext = document.getElementById("pieChart").getContext('2d');

/*********** Data ***********/
var barData = {
    labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
    datasets: [{
        label: '# of Votes',
        data: [12, 19, 3, 5, 2, 3],
        backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
        ],
        borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
        ],
        borderWidth: 1
    }]
};
var pieData = {
    labels: ["She returns it ", "She keeps it"],
    datasets: [
        {
            fill: true,
            backgroundColor: [
                'black',
                'white'],
            data: [5, 95],
            borderColor: ['black', 'black'],
            borderWidth: [2, 2]
        }
    ]
};

/*********** Option ***********/
var barOptions = {
    scales: {
        y: {
            beginAtZero: true
        }
    }
}
var pieOptions = {
    title: {
        display: true,
        text: 'What happens when you lend your favorite t-shirt to a girl ?',
        position: 'top'
    },
    rotation: -0.7 * Math.PI
};

/*********** Chart ***********/
var barChart = new Chart(barContext, {
    type: 'bar',
    data: barData,
    options: barOptions
});
var pieChart = new Chart(pieContext, {
    type: 'pie',
    data: pieData,
    options: pieOptions
});
