var LocalTime_hr;
var LocalTime_mn;
var LocalTime;

function testFunction(a, b) {
    var c = a + b;
    document.getElementById("scriptOutput").innerHTML = c;
    JL().info("Run pressed.");
}
function resetFunction() {
    document.getElementById("scriptOutput").innerHTML = "Here shows the sum of 4 and 5.";
}
function Time() {
    LocalTime_hr = document.getElementById("Hour").value;
    LocalTime_mn = document.getElementById("Minute").value;
    if (LocalTime_hr > 24 || LocalTime_hr < 0 || LocalTime_mn > 60 || LocalTime_mn < 0) {
        alert("Invalid time format!");
    } else {
        LocalTime_hr -= 5;
    }
    if (LocalTime_mn < 10) {
        LocalTime_mn = '0' + LocalTime_mn;
    }
    document.getElementById("Ottawa").innerHTML = LocalTime_hr + ':' + LocalTime_mn;
}