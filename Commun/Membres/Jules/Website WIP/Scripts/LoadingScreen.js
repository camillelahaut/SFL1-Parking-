document.getElementById("body").style.display = "none";
window.addEventListener("load", showPage);

function showPage() {
    document.getElementById("loader").style.display = "none";
    document.getElementById("body").style.display = "block";
}