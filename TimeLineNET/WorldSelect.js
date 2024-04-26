var WorldModel = {
    'playerToken': '',
    'worldName': ''
};

var WorldWorker = new Worker('WorldWorker.js');

function selectWorldResult(result) {
    //addTimeLine('selectWorldResult:' + result);
    if (result != "") {
        setTimeout(function () { startGame(WorldModel['playerToken']); }, 2000)
    }
}

function selectWorld() {
    WorldModel['worldName'] = document.getElementById("WorldName").value;
    WorldWorker.postMessage(JSON.stringify(WorldModel));
}

function WorldSelectSetup() {
    WorldWorker.onmessage = function (event) {
        selectWorldResult(event.data);
    };   
}
