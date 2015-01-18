function Tiny() {
    function testFunction(a, b) {
        var c = a + b;
        document.getElementById("scriptOutput").innerHTML = c;
        JL().info("Run pressed.");
    }
    function resetFunction() {
        document.getElementById("scriptOutput").innerHTML = "Here shows the sum of 4 and 5.";
    }
}