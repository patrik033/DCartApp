
window.onload = function First() {
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
            type: "doughnut",
            dataPoints: dataPoints,
        }]
    });
    $.getJSON("/Admin/Charts", function (data) {
        event.preventDefault();
        $.each(data, function (key, value) {
            dataPoints.push({ label: value.label, y: parseInt(value.y) });
        });
        chart.render();
    });
}



function Doughnut() {

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
            type: "doughnut",
            dataPoints: dataPoints,
        }]
    });
    $.getJSON("/Admin/Charts", function (data) {
        event.preventDefault();
        $.each(data, function (key, value) {
            dataPoints.push({ label: value.label, y: parseInt(value.y) });
        });
        chart.render();
    });
}

function Line() {
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
            type: "line",
            dataPoints: dataPoints,
        }]
    });
    $.getJSON("/Admin/Charts", function (data) {
        event.preventDefault();
        $.each(data, function (key, value) {
            dataPoints.push({ label: value.label, y: parseInt(value.y) });
        });
        chart.render();
    });
}


function SplineArea() {
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
            type: "splineArea",
            dataPoints: dataPoints,
        }]
    });
    $.getJSON("/Admin/Charts", function (data) {
        event.preventDefault();
        $.each(data, function (key, value) {
            dataPoints.push({ label: value.label, y: parseInt(value.y) });
        });
        chart.render();
    });

}