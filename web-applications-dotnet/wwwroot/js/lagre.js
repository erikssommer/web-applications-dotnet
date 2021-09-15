function lagreKunde() {
    const customer = {
        firstName: $("#fornavn").val(),
        lastName: $("#etternavn").val(),
        address: $("#adresse").val(),
        postnr: $("#postnr").val(),
        postOffice: $("#poststed").val()
    }

    $.post("Customer/Save", customer => {
        window.location.href = 'index.html';
    }).fail(() => $("#feil").html("Feil på server"));
}