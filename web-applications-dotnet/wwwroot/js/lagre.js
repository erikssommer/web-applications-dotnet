function validerOgLagreKunde() {
    const fornavnOK = validerFornavn($("#fornavn").val());
    const etternavnOK = validerEtternavn($("#etternavn").val());
    const adresseOK = validerAdresse($("#adresse").val());
    const postnrOK = validerPostnr($("#postnr").val());
    const poststedOK = validerPoststed($("#poststed").val());
    if (fornavnOK && etternavnOK && adresseOK && postnrOK && poststedOK) {
        lagreKunde();
    }
}

function lagreKunde() {
    const customer = {
        firstName: $("#fornavn").val(),
        lastName: $("#etternavn").val(),
        address: $("#adresse").val(),
        postnr: $("#postnr").val(),
        postOffice: $("#poststed").val()
    }

    $.post("Customer/Save", customer, () => {
        window.location.href = 'index.html';
    }).fail(feil => {
        if (feil.status === 401){
            window.location.href = 'login.html';
        }else{
            $("#fail").html("Feil på server")
        }
    });
}