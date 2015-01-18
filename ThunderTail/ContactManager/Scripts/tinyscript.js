    function testFunction(a, b, reset) {
        var c = a + b;
        if (reset == 1) {
            document.getElementById("scriptOutput").innerHTML = "Here shows the sum of 4 and 5.";
        }else{
            document.getElementById("scriptOutput").innerHTML = c;
        }
    }
    