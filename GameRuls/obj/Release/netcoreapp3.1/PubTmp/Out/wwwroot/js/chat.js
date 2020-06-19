"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg =  msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    //document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

function Message(coordinators) {
    connection.invoke("SendMessage", coordinators, $('#room').text(), false).catch(function (err) {
        return console.error(err.toString());
    });
};

function RegistrationGame() {
    connection.invoke("SendMessage", 'Join the game', $('#room').text(), true).catch(function (err) {
        return console.error(err.toString());
    });

};
