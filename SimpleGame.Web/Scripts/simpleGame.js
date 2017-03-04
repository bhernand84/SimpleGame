$(function () {
    var hub = $.connection.gameHub;

    $.connection.hub.logging = true;
    //$.connection.hub.url = 'http://simplegameweb.azurewebsites.net/signalr';
    hub.client.update = function (game) {
        //logic for getting a new game goes here

    };
    $.connection.hub.start({ withCredentials: false });
})

function button1Clicked(event) {
    console.log('button 1 clicked');
    console.log(event);
}

function button2Clicked(event) {
    console.log('button 2 clicked');
    console.log(event);
}