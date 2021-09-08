function lagreKunde() {
    const kunde = {
        name: $("#navn").val(),
        address: $("#adresse").val()
    }
    const url = "Customer/Save";
    $.post(url, kunde, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}