function login() {

    const brukernavnOK = validerBrukernavn($("#brukernavn").val());
    const passordOK = validerPassord($("#passord").val());

    if (brukernavnOK && passordOK) {
        const customer = {
            username: $("#brukernavn").val(),
            password: $("#passord").val()
        }
        $.post("Customer/Login", customer, OK => {
            if (OK) {
                window.location.href = 'index.html';
            } else {
                $("#feil").html("Feil brukernavn eller passord");
            }
        }).fail(feil => {
            $("#feil").html("Feil på server - prøv igjen senere: " + feil.responseText + " : " + feil.status + " : " + feil.statusText);
        });
    }
}