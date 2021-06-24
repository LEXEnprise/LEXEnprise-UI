export function AddContactToRow(elem, contactPerson, address1, address2, email,
    phone, mobile, position, remarks, isNew) {
    let row = document.createElement("tr");

    let cell1 = document.createElement("td");
    let cell2 = document.createElement("td");
    let cell3 = document.createElement("td");
    let cell4 = document.createElement("td");
    let cell5 = document.createElement("td");
    let cell6 = document.createElement("td");
    let cell7 = document.createElement("td");
    let cell8 = document.createElement("td");
    let cell9 = document.createElement("td");

    cell1.innerText = contactPerson;
    cell2.innerText = address1;
    cell3.innerText = address2;
    cell4.innerText = email;
    cell5.innerText = phone;
    cell6.innerText = mobile;
    cell7.innerText = position;
    cell8.innerText = remarks;
    cell9.innerText = isNew;

    row.append(cell1);
    row.append(cell2);
    row.append(cell3);
    row.append(cell4);
    row.append(cell5);
    row.append(cell6);
    row.append(cell7);
    row.append(cell8);
    row.append(cell9);

    elem.append(row);
} 