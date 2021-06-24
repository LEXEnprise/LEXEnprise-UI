export function AddLawyerToRow(elem, fullname, emailAddress) {
    let row = document.createElement("tr");

    let cell1 = document.createElement("td");
    let cell2 = document.createElement("td");

    cell1.innerText = fullname;
    cell2.innerText = emailAddress;

    row.append(cell1);
    row.append(cell2);
    elem.append(row);
} 