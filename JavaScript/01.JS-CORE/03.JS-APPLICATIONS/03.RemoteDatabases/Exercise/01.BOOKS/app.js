const urls = {
    'base' : 'https://baas.kinvey.com/appdata/kid_SyBswvefH/books',
    'update/delete' : 'https://baas.kinvey.com/appdata/kid_SyBswvefH/books/'
}



const elements = {
    btnLoadBooks : document.getElementById('loadBooks'),
    tBody : document.querySelector('body table tbody'),
    inputTitle : document.getElementById('title'),
    inputAuthor : document.getElementById('author'),
    inputIsbn : document.getElementById('isbn'),
    btnSubmit : document.querySelector('form button'),
    btnEditDone : document.querySelector('form div .editBtn'),
    btnEditCancel : document.querySelector('form div .cancelBtn'),
    formTitle : document.querySelector('form h3'),
    form : document.querySelector('form')
}



const user = "guest";
const password = "guest";
const base_64 = btoa(`${user}:${password}`);
const headers = {
    'Authorization' : `Basic ${base_64}`,
    'Content-type' : 'application/json'
};


elements.btnLoadBooks.addEventListener('click', loadBooks);
elements.btnSubmit.addEventListener ('click', event => {
    event.preventDefault();
    createBook();
});

elements.btnEditDone.addEventListener('click' , event => {
    event.preventDefault();
    editDone();
});

elements.btnEditCancel.addEventListener('click', event => {
    event.preventDefault();
    editCancel();
})

//Load All Books
function loadBooks(){
    fetch(urls.base, {
        method : 'GET',
        headers : headers
    })
    .then(requestErrorHandler)
    .then(response => response.json())
    .then((data) => {
        elements.tBody.innerHTML = '';
        for (const book of data) {
            elements.tBody.appendChild(tableRowFormater(book));
        }
    })
    .catch(error => {
        alert(error.message);
    });

    clearInputFields();
}

//Create Book
function createBook(){
    const bookData = {
        title : elements.inputTitle.value,
        author : elements.inputAuthor.value,
        isbn : elements.inputIsbn.value
    }

    try {
        dataErrorHandler();

        fetch(urls.base, {
            method : 'POST',
            headers : headers,
            body : JSON.stringify(bookData)
        })
        .then(requestErrorHandler)
        .then(loadBooks)
        .catch(error => {
            alert(error.message);
        });
    } catch (error) {
        alert(error.message);
    }
    
}

//Edit Book
function editBook(bookID){
    formsSwitch(bookID);
    elements.btnEditDone.value = bookID;    
}

function editDone(){
    const updateUrl = urls["update/delete"] + elements.btnEditDone.value;

    const bookData = {
        title : elements.inputTitle.value,
        author : elements.inputAuthor.value,
        isbn : elements.inputIsbn.value
    }

    try {
        dataErrorHandler();
        
        fetch(updateUrl, {
            method : 'PUT',
            headers : headers,
            body : JSON.stringify(bookData)
        })
        .then(requestErrorHandler)
        .then(loadBooks)
        .then(formsSwitch)
        .catch(error => {
            alert(error);
        });
    } catch (error) {
        alert(error.message);
    }
}

function editCancel(){
    clearInputFields();
    formsSwitch();
}

//Delete Book
function deleteBook(bookID){
    const deleteUrl = urls["update/delete"] + bookID;
    
    fetch(deleteUrl, {
        method : 'DELETE',
        headers : headers
    })
    .then(requestErrorHandler)
    .then(response => {
        loadBooks();
        if(elements.formTitle.textContent === 'EDIT'){
            formsSwitch();
        }
    })
    .catch(error => {
        alert(error.message);
    });
}

function clearInputFields(){
    elements.inputTitle.value = '';
    elements.inputAuthor.value = '';
    elements.inputIsbn.value = '';
}

function tableRowFormater(book){
    let tr = document.createElement('tr');
    let tdTitle = document.createElement('td');
    let tdAuthor = document.createElement('td');
    let tdIsbn = document.createElement('td');
    let tdBtns = document.createElement('td');
    let btnEdit = document.createElement('button');
    let btnDelete = document.createElement('button');
    btnEdit.textContent = 'Edit';
    btnDelete.textContent = 'Delete';

    btnEdit.addEventListener('click', () => editBook(book._id));
    btnDelete.addEventListener('click', () => deleteBook(book._id));

    tdTitle.textContent = book.title;
    tdAuthor.textContent = book.author;
    tdIsbn.textContent = book.isbn;
    tdBtns.appendChild(btnEdit);
    tdBtns.appendChild(btnDelete);

    tr.appendChild(tdTitle);
    tr.appendChild(tdAuthor);
    tr.appendChild(tdIsbn);
    tr.appendChild(tdBtns);
    tr.setAttribute('id', book._id);

    return tr;
}



function formsSwitch(bookID) {
    if(bookID){
        elements.formTitle.textContent = 'EDIT';
        elements.btnSubmit.style.display = 'none';
        elements.btnEditDone.style.display = 'block';
        elements.btnEditCancel.style.display = 'block';
        loadEditData(bookID);
    } else{
        elements.formTitle.textContent = 'FORM';
        elements.btnSubmit.style.display = 'block';
        elements.btnEditDone.style.display = 'none';
        elements.btnEditCancel.style.display = 'none';
    }   
}

function loadEditData(bookId){
    const currentRow = document.getElementById(bookId);

    elements.inputTitle.value = currentRow.children[0].textContent;
    elements.inputAuthor.value = currentRow.children[1].textContent;
    elements.inputIsbn.value = currentRow.children[2].textContent;
}

function requestErrorHandler(response){
    if(response.status >= 400){
        throw new Error (`Something went wrong! Response status: ${response.status}`);
    }

    return response;
}

function dataErrorHandler(){
    if(!elements.inputTitle.value || !elements.inputAuthor.value || !elements.inputIsbn.value){
        throw new Error ('Input fields must not be empty');
    }
}