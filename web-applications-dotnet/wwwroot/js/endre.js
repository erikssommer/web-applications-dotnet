$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet

    const id = window.location.search.substring(1);
    $.get("Customer/GetOne?" + id, customer => {
        $("#id").val(customer.id); // må ha med id inn skjemaet, hidden i html
        $("#fornavn").val(customer.firstName);
        $("#etternavn").val(customer.lastName);
        $("#adresse").val(customer.address);
        $("#postnr").val(customer.postnr);
        $("#poststed").val(customer.postOffice);
    }).fail(() => $("#feil").html("Feil på server"));
});

function endreKunde() {
    const customer = {
        id: $("#id").val(), // må ha med denne som ikke har blitt endret for å vite hvilken kunde som skal endres
        firstName: $("#fornavn").val(),
        lastName: $("#etternavn").val(),
        address: $("#adresse").val(),
        postnr: $("#postnr").val(),
        postOffice: $("#poststed").val()
    };
    $.post("Customer/Update", customer => {
        window.location.href = 'index.html';
    }).fail(() => $("#fail").html("Feil på server"));
}