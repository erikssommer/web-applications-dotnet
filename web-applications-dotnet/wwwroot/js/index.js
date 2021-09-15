$(function () {
    hentAlleKunder();
});

function hentAlleKunder() {
    $.get("Customer/GetAll", function (customers) {
        formaterKunder(customers);
    }).fail(() => $("#feil").html("Feil på server"));
}

function formaterKunder(customers) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Fornavn</th><th>Etternavn</th><th>Adresse</th><th>Postnr</th><th>Poststed</th><th></th><th></th>" +
        "</tr>";
    for (let customer of customers) {
        ut += "<tr>" +
            "<td>" + customer.firstName + "</td>" +
            "<td>" + customer.lastName + "</td>" +
            "<td>" + customer.address + "</td>" +
            "<td>" + customer.postnr + "</td>" +
            "<td>" + customer.postOffice + "</td>" +
            "<td> <a class='btn btn-primary' href='endre.html?id=" + customer.id + "'>Endre</a></td>" +
            "<td> <button class='btn btn-danger' onclick='slettKunde(" + customer.id + ")'>Slett</button></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#kundene").html(ut);
}

function slettKunde(id) {

    $.get("Customer/Delete?id=" + id, () => {
        window.location.href = 'index.html';
    }).fail(() => $("#feil").html("Feil på server"));
}