function lagreKunde() {
    const customer = {
        firstName: $("#fornavn").val(),
        lastName: $("#etternavn").val(),
        address: $("#adresse").val(),
        postnr: $("#postnr").val(),
        postOffice: $("#poststed").val()
    }

    $.post("Customer/Save", customer, OK => {
        if (OK) {
            window.location.href = 'index.html';
        } else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}