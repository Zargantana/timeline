onmessage = function (e) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState === 4) {
            if (xhttp.status === 200) {
                postMessage(this.responseText);
            }
            else {
                postMessage('Non OK response: [' + xhttp.status + ']');
            }
        }
    };
    xhttp.open("POST", "api/Login", false);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.send(e.data);
};

