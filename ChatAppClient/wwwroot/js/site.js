
$(document).ready(() => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7218/chathub")
        .withAutomaticReconnect([1000,1000,2000,3000])
        .build();

    async function start() {
        try {
            await connection.start();
        } catch (error) {
            setTimeout(() => start(), 2000);
        }
    }
    // connection.start();
    start();

const durum=$("#durum");
connection.onreconnecting(error=>{
durum.addClass("bg-success");
durum.fadeIn(2000,()=>{
    setTimeout(() => {
        durum.fadeOut(2000);
    }, 2000)
});
});

connection.onreconnected(connectionId=>{
    durum.addClass("bg-warning");
    durum.fadeIn(2000,()=>{
        setTimeout(() => {
            durum.fadeOut(2000);
        }, 2000)
    });
});

connection.onclose(connectionId=>{
    durum.addClass("bg-warning");
    durum.fadeIn(2000,()=>{
        setTimeout(() => {
            durum.fadeOut(2000);
        }, 2000)
    });
});
var userContent=$("#userContent");
var li="<li></li>";
li.addClass("p-2 border-bottom");
var a="<a></a>";
a.addClass("d-flex justify-content-between");

connection.on("userJoind",connectionId=>{

});
connection.on("userLeaved",connectionId=>{

});

    $("#btnGonder").click(() => {
        let message = $("#exampleFormControlInput2").val();
        connection.invoke("SendMessageAsync", message).catch(error => console.log("Mesaj gönderilirken hata oluştu. ${error}"));
    });

    connection.on("receiveMessage", message => {
        $("#contenttext").append(message);
    })


});
