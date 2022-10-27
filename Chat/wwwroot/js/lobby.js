console.log("before")

//Create connection
var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("/hubs/chat")
    .build();
console.log("after")
//methods that Hub uses to connect to client

connection.on("receiveGlobalMessage", (userName) => {
    var globalMessageContainer = document.getElementById('globalMessage');
    globalMessageContainer.innerText = `${userName} has joined to Lobby`;
})

//Method that Invoke Hub method
function InvokeSendGlobalMessage() {
    connection.send("SendGlobalMessage");
}

//Start connection
function fullfilled() {
    console.log("Connected")
    InvokeSendGlobalMessage();
}

function rejected() {
    console.log("Connection Failed");
}

connection
    .start()
    .then(fullfilled, rejected);
