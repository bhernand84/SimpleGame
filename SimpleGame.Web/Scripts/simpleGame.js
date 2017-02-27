$(function () {
    var hub = $.connection.gameHub;

    $.connection.hub.logging = true;
    $.connection.hub.url = 'http://simplegameweb.azurewebsites.net/signalr';
    hub.client.update = function (game) {
        console.log(game);
    };
    console.log(connection);
    $.connection.hub.start({ withCredentials: false });
})