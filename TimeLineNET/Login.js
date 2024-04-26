var LoginModel = {
    'playerName': '',
    'playerPass': ''
};

var LoginWorker = new Worker('LoginWorker.js');

/*
function LoginResult(result) {        
    WorldModel['playerToken'] = result.substring(1, result.length - 1);
    addTimeLine('LoginResult:' + WorldModel['playerToken']);
}*/

function LoginResult(result) {
    var loginToken = result.substring(1, result.length - 1);
    addTimeLine('LoginResult:' + loginToken);
    if (loginToken != "") {
        setTimeout(function () { startGame(loginToken); }, 2000)
    }
}

function doLogin() {
    LoginModel['playerName'] = document.getElementById("PlayerName").value;
    LoginModel['playerPass'] = document.getElementById("PlayerPass").value;

    LoginWorker.postMessage(JSON.stringify(LoginModel));

    //Clean memory
    LoginModel['playerName'] = "something";
    LoginModel['playerPass'] = "strangeBehave";
}

function LoginSetup() {
    LoginWorker.onmessage = function (event) {
        LoginResult(event.data);
    };
}
