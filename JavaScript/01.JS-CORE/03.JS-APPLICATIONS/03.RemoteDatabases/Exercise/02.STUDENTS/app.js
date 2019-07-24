const urls = {
    'base' :'https://baas.kinvey.com/appdata/kid_rJ96dslzH/students',
    'update/delete' : 'https://baas.kinvey.com/appdata/kid_rJ96dslzH/students/'
}

const elements = {
    tbody : document.querySelector('tbody'),
    InputId : document.getElementById('id'),
    inputFirstName : document.getElementById('firstName'),
    inputLastName : document.getElementById('lastName'),
    inputFacultyNumber : document.getElementById('facultyNumber'),
    inputGrade : document.getElementById('grade'),
    inputFields : document.querySelectorAll('input'),
    btnSubmit : document.querySelector('form button'),
    btnEditDone : document.querySelector('.editBtn'),
    btnEditCancel : document.querySelector('.cancelBtn'),
    btnDelete : document.querySelector('.deleteBtn'),
    formTitle : document.querySelector('form h3')
}


const user = 'guest';
const password = 'guest';
const base_64 = btoa(`${user}:${password}`);
const headers = {
    'Authorization' : `Basic ${base_64}`,
    'Content-type' : 'application/json'
}

// Add Event Listeners
elements.btnSubmit.addEventListener('click', event => {
    event.preventDefault();
    createStudent();
});

elements.btnEditCancel.addEventListener('click', event => {
    event.preventDefault();
    editCancel();
});

elements.btnEditDone.addEventListener('click', event => {
    event.preventDefault();
    editDone();
});

elements.btnDelete.addEventListener('click', event => {
    event.preventDefault();
    deleteStudent();
});

elements.tbody.addEventListener('click', editStudent);

// Load Students
function loadStudents(){
    elements.tbody.innerHTML = '';

    fetch(urls.base, {
        method : 'GET',
        headers : headers
    })
    .then(requestErrorHandler)
    .then(response => response.json())
    .then(data => {
        for (const student of data.sort((a,b) => a.ID - b.ID)) {
            elements.tbody.append(tableRowFormater(student));
        }
    })
    .catch(error => alert(error.message));

    clearInputFields();
}

loadStudents();

//Create Student
function createStudent(){
    const studentData = {
        ID : elements.InputId.value,
        FirstName : elements.inputFirstName.value,
        LastName : elements.inputLastName.value,
        FacultyNumber : elements.inputFacultyNumber.value,
        Grade : elements.inputGrade.value
    }

    try {
        dataErrorHandler();

        fetch (urls.base, {
            method : 'POST',
            headers : headers,
            body : JSON.stringify(studentData)
        })
        .then(requestErrorHandler)
        .then(loadStudents)
        .catch(error => alert(error.message));
    } catch (error) {
        alert(error.message);
    }
    
}

//Edit Student
let currentValues = {};
function editStudent(e){
    let currentRow = e.target.parentNode;
    formsSwitch();
    loadEditData(currentRow);
    elements.btnEditDone.value = currentRow.id;
    elements.btnDelete.value = currentRow.id;
    currentValues.ID = currentRow.getAttribute('table-id');
    currentValues.FacultyNumber = currentRow.getAttribute('f-number');
}

function editDone(){
    const updateUrl = urls["update/delete"] + elements.btnEditDone.value;

    const studentData = {
        ID : elements.InputId.value,
        FirstName : elements.inputFirstName.value,
        LastName : elements.inputLastName.value,
        FacultyNumber : elements.inputFacultyNumber.value,
        Grade : elements.inputGrade.value
    }

    try {
        dataErrorHandler();

        if(currentValues.ID !== studentData.ID){
            idErrorHandler()
        }

        if(currentValues.FacultyNumber !== studentData.FacultyNumber){
            facultyNumberErrorHandler();
        }

        fetch(updateUrl, {
            method : 'PUT',
            headers : headers,
            body : JSON.stringify(studentData)
        })
        .then(requestErrorHandler)
        .then(loadStudents)
        .then(formsSwitch)
        .catch(error => alert(error.message));
    } catch (error) {
        alert(error.message);
    }  
}

function editCancel(){
    formsSwitch();
    clearInputFields();
}

function deleteStudent(){
    const deleteUrl = urls["update/delete"] + elements.btnDelete.value;

    fetch(deleteUrl , {
        method : 'DELETE',
        headers : headers
    })
    .then(requestErrorHandler)
    .then(loadStudents)
    .then(formsSwitch)
    .catch(error => alert(error.message));
}

function tableRowFormater(student){
    let tr = document.createElement('tr');
    let tdID = document.createElement('td');
    let tdFirstName = document.createElement('td');
    let tdLastName = document.createElement('td');
    let tdFacultyNumber = document.createElement('td');
    let tdGrade = document.createElement('td');

    tdID.textContent = student.ID
    tdID.setAttribute('class', 'ID');
    tdFirstName.textContent = student.FirstName;
    tdLastName.textContent = student.LastName;
    tdFacultyNumber.textContent = student.FacultyNumber;
    tdFacultyNumber.setAttribute('class', 'fNumber');
    tdGrade.textContent = Number(student.Grade).toFixed(2);
    
    tr.appendChild(tdID);
    tr.appendChild(tdFirstName);
    tr.appendChild(tdLastName);
    tr.appendChild(tdFacultyNumber);
    tr.appendChild(tdGrade);
    tr.setAttribute('id', student._id);
    tr.setAttribute('table-id', student.ID);
    tr.setAttribute('f-number', student.FacultyNumber);

    return tr;
}

function loadEditData(tableRow){
    elements.InputId.value = Number(tableRow.children[0].textContent);
    elements.inputFirstName.value = tableRow.children[1].textContent;
    elements.inputLastName.value = tableRow.children[2].textContent;
    elements.inputFacultyNumber.value = tableRow.children[3].textContent;
    elements.inputGrade.value = Number(tableRow.children[4].textContent);
}

function formsSwitch(){
    if(elements.formTitle.textContent === 'REGISTRATION FORM'){
        elements.formTitle.textContent = 'EDIT';
        elements.btnSubmit.style.display = 'none'
        elements.btnEditDone.style.display = 'inline-block';
        elements.btnEditCancel.style.display = 'inline-block';
        elements.btnDelete.style.display = 'inline-block';
    } else {
        elements.formTitle.textContent = 'REGISTRATION FORM';
        elements.btnSubmit.style.display = 'block';
        elements.btnEditDone.style.display = 'none';
        elements.btnEditCancel.style.display = 'none';
        elements.btnDelete.style.display = 'none';
    }
}

function clearInputFields(){
    elements.InputId.value = '';
    elements.inputFirstName.value = '';
    elements.inputLastName.value = '';
    elements.inputFacultyNumber.value = '';
    elements.inputGrade.value = '';
}

function requestErrorHandler(response){
    if(response.status >= 400){
        throw new Error (`Something went wrong! Response status: ${response.statusText}`);
    }

    return response;
}

function dataErrorHandler(){
    for (const inputField of Array.from(elements.inputFields)) {
        if(!inputField.value){
            throw new Error (`Input fields must not be empty`); 
        }
    }
}

function idErrorHandler(){
    const trs = document.getElementsByTagName('tr');

    for (const tr of trs) {
        if(tr.getAttribute('table-id') == elements.InputId.value){
            throw new Error('This ID has already been taken!');
        }
    }
}

function facultyNumberErrorHandler(){
    const trs = document.getElementsByTagName('tr');

    for (const tr of trs) {
        if(tr.getAttribute('f-number') == elements.inputFacultyNumber.value){
            throw new Error('This Faculty Number has already been taken!');
        }
    }
}