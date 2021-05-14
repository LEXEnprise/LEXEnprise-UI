export function displaySpinner(id) {
    var element = document.getElementById(id);

    if (element != null)
        element.style.display = "block";
}

export function hideSpinner(id) {
    var element = document.getElementById(id);

    if (element != null)
        element.style.display = "none";
}