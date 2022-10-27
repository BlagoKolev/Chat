//Create connection
var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("/hubs/chat")
    .build();

//methods that Hub uses to connect to client

connection.on("receiveGlobalMessage", (userName) => {
    var globalMessageContainer = document.getElementById('globalMessage');
    globalMessageContainer.innerText = `${userName} has joined to Lobby`;
    
});

connection.on("updateConnectedUsers", (connectedUsers) => {
    var connectedUsersList = document.getElementById("online-users-list");
    connectedUsersList.innerHTML = "";
    connectedUsers.map(x => {
        var user = document.createElement("li");
        user.className = "user";
        user.innerText = x;
        connectedUsersList.appendChild(user);
    })
});

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
