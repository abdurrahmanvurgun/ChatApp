
$(document).ready(() => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7218/chathub")
        .withAutomaticReconnect([1000,1000,2000,3000,4000,5000,10000])
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

    $("#btnGonder").click(() => {
        let message = $("#exampleFormControlInput2").val();
        connection.invoke("SendMessageAsync", message).catch(error => console.log("Mesah gönderilirken hata oluştu. ${error}"));
    });

    connection.on("receiveMessage", message => {
        $("#contenttext").append(message);
    })

});
