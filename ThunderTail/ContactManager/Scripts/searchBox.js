function searchBox() {
    //Get submit button
    var submitbutton = document.getElementById("box");
    //Add listener to submit button
    if (submitbutton.addEventListener) {
        submitbutton.addEventListener("click", function () {
            if (submitbutton.value == 'Search our website') {//Customize this text string to whatever you want
                submitbutton.value = '';
            }
        });
    }
}