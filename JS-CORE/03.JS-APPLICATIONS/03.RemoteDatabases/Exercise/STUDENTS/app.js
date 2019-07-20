const url ='https://baas.kinvey.com/appdata/kid_rJ96dslzH/students';

const elements = {
    tbody : document.querySelector('tbody')
}

const user = 'guest';
const password = 'guest';
const base_64 = btoa(`${user}:${password}`);
const headers = {
    'Authorization' : `Basic ${base_64}`,
    'Content-type' : 'application/json'
}

fetch(url, {
    method : 'GET',
    headers : headers
})
.then(errorHandler)
.then(response => response.json())
.then(data => {
    for (const student of data.sort((a,b) => a.ID - b.ID)) {
        elements.tbody.append(tableRowFormater(student));
    }
})


function tableRowFormater(student){
    let tr = document.createElement('tr');
    let tdID = document.createElement('td');
    let tdFirstName = document.createElement('td');
    let tdLastName = document.createElement('td');
    let tdFacultyNumber = document.createElement('td');
    let tdGrade = document.createElement('td');

    tdID.textContent = student.ID
    tdFirstName.textContent = student.FirstName;
    tdLastName.textContent = student.LastName;
    tdFacultyNumber.textContent = student.FacultyNumber;
    tdGrade.textContent = student.Grade.toFixed(2);
    
    tr.appendChild(tdID);
    tr.appendChild(tdFirstName);
    tr.appendChild(tdLastName);
    tr.appendChild(tdFacultyNumber);
    tr.appendChild(tdGrade);

    return tr;
}

function errorHandler(response){
    if(response.status >= 400){
        throw new Error (`Something went wrong! Response status: ${response.status}`);
    }

    return response;
}