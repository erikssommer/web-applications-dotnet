$(() => {
    hentAlleKunder();
});

const hentAlleKunder = () => {
    $.get("Customer/GetAll", kunder => formaterKunder(kunder));
}

const formaterKunder = kunder => {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th><th>Adresse</th><th></th><th></th>" +
        "</tr>";
    for (let kunde of kunder) {
        ut += "<tr>" +
            "<td>" + kunde.name + "</td>" +
            "<td>" + kunde.address + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#kundene").html(ut);
}