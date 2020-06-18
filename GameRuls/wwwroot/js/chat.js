"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
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

function Message(button) {
    var user = document.getElementById("userInput").value;
    //var message = document.getElementById("messageInput").value;
    var room = document.getElementById("room").value;
    connection.invoke("SendMessage", user, button.name, room, false).catch(function (err) {
        return console.error(err.toString());
    });
};

function Registration () {
    var room = document.getElementById("room").value;
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message, room, true).catch(function (err) {
        return console.error(err.toString());
    });
};