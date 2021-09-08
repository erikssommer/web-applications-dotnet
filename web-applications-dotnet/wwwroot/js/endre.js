$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet

    const id = window.location.search.substring(1);
    const url = "Customer/GetOne?" + id;
    $.get(url, function (kunde) {
        $("#id").val(kunde.id); // må ha med id inn skjemaet, hidden i html
        $("#navn").val(kunde.name);
        $("#adresse").val(kunde.address);
    }); 
});

function endreKunde() {
    const kunde = {
        id: $("#id").val(), // må ha med denne som ikke har blitt endret for å vite hvilken kunde som skal endres
        name: $("#navn").val(),
        address: $("#adresse").val()
    }
    
    $.post("Customer/Update", kunde, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}