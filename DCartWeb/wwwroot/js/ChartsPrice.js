window.onload = function Price() {
    var dataPoints = [];
    var chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,
        animationDuration: 500,
        exportEnabled: true,
        theme: "light1",

        title: {
            text: "Bought Products"
        },
        data: [{
            type: "column",
            dataPoints: dataPoints,
        }]
    });
    $.getJSON("/Admin/ChartsPrice", function (data) {
        event.preventDefault();
        $.each(data, function (key, value) {
            dataPoints.push({ label: value.label, y: parseInt(value.y) });
        });
        chart.render();
    });
}