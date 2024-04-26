onmessage = function (e) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState === 4) {
            if (xhttp.status === 200) {
                //addTimeLine('Answer received:4:'+ this.responseText);
                //receivedRender(this.responseText);
                //LogImageContent(this.responseText.substring(1, this.responseText.length - 1));
                //LogImageContent(this.responseText);
                postMessage(this.responseText);
                //addTimeLine('Answer received:4 end');
            }
            else {
                //addTimeLine('renderFrame response error: [' + xhttp.status + ']:' + xhttp.statusText + '.');
                //TODO: InNeedFroTrace
            }
        }
        //else addTimeLine('Answer received:' + xhttp.readyState);
    };
    xhttp.open("POST", "api/Information", false);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.send(e.data);
};

