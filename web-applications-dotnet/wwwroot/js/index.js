$(function(){
    hentAlleKunder();
});

function hentAlleKunder() {
    $.get("Customer/GetAll", function (kunder) {
        formaterKunder(kunder);
    });
}

function formaterKunder(kunder) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th><th>Adresse</th><th></th><th></th>" +
        "</tr>";
    for (let kunde of kunder) {
        ut += "<tr>" + 
            "<td>" + kunde.name + "</td>" +
            "<td>" + kunde.address + "</td>" +
            "<td> <a class='btn btn-primary' href='endre.html?id="+kunde.id+"'>Endre</a></td>"+
            "<td> <button class='btn btn-danger' onclick='slettKunde("+kunde.id+")'>Slett</button></td>"+
            "</tr>";
    }
    ut += "</table>";
    $("#kundene").html(ut);
}

function slettKunde(id) {
    const url = "Customer/Delete?id="+id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }

    });
};