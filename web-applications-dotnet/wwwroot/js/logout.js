function logOut() {
    $.get("Customer/LogOut", () => {
        window.location.href = 'login.html';
    });
}