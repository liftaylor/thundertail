function Time() {
    /*
    var LocalTime_hr;
    var LocalTime_mn;
    var LocalTime;
    
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
    */

    var d = new Date();
    var offset = d.getTimezoneOffset() / 60 - 5;
    var Ottawa_hour = d.getHours() + offset;
    var local_hour = d.getHours();
    var minute = d.getMinutes();

    if (d.getMinutes() < 10) {
        minute = '0' + minute;
    }

    document.getElementById("Ottawa").innerHTML = Ottawa_hour + ':' + minute;
    document.getElementById("Local").innerHTML = local_hour + ':' + minute;

}
