var ctx = document.getElementById('barChart').getContext('2d');
var barChart = new Chart(ctx, {
    type: 'bar',
    data: {
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
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

var canvas = document.getElementById("pieChart");
var ctx2 = canvas.getContext('2d');

// Global Options:
//Chart.defaults.global.defaultFontColor = 'black';
//Chart.defaults.global.defaultFontSize = 16;

var data = {
    labels: ["She returns it ", "She keeps it"],
    datasets: [
        {
            fill: true,
            backgroundColor: [
                'black',
                'white'],
            data: [5, 95],
            // Notice the borderColor 
            borderColor: ['black', 'black'],
            borderWidth: [2, 2]
        }
    ]
};

// Notice the rotation from the documentation.

var options = {
    title: {
        display: true,
        text: 'What happens when you lend your favorite t-shirt to a girl ?',
        position: 'top'
    },
    rotation: -0.7 * Math.PI
};


// Chart declaration:
var pieChart = new Chart(ctx2, {
    type: 'pie',
    data: data,
    options: options
});
