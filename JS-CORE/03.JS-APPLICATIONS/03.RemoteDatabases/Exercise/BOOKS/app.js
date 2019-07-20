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
    btnSubmit : document.querySelector('form button')
}

const user = "guest";
const password = "guest";
const base_64 = btoa(`${user}:${password}`);
const headers = {
    'Authorization' : `Basic ${base_64}`,
    'Content-type' : 'application/json'
};

//Load All Books
elements.btnLoadBooks.addEventListener('click', loadBooks);

function loadBooks(){
    fetch(urls.base, {
        method : 'GET',
        headers : headers
    })
    .then(errorHandler)
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
}

//Create Book
elements.btnSubmit.addEventListener ('click', event => {
    event.preventDefault();
    createBook();
});

function createBook(){
    const bookData = {
        title : elements.inputTitle.value,
        author : elements.inputAuthor.value,
        isbn : elements.inputIsbn.value
    }

    clearInputFields();

    fetch(urls.base, {
        method : 'POST',
        headers : headers,
        body : JSON.stringify(bookData)
    })
    .then(errorHandler)
    .then(dataErrorHandler)
    .then(response => response.json())
    .then((data) => {
        loadBooks();
    })
    .catch(error => {
        alert(error.message);
    });
}



//Edit Book
function editBook(bookID){
    const updateUrl = urls["update/delete"] + bookID;

    const bookData = {
        title : elements.inputTitle.value,
        author : elements.inputAuthor.value,
        isbn : elements.inputIsbn.value
    }

    clearInputFields();

    fetch(updateUrl, {
        method : 'PUT',
        headers : headers,
        body : JSON.stringify(bookData)
    })
    .then(errorHandler)
    .then(dataErrorHandler)
    .then(response => response.json())
    .then(data => {
        loadBooks()
    })
    .catch(error => {
        alert(error);
    });
}

//Delete Book
function deleteBook(bookID){
    const deleteUrl = urls["update/delete"] + bookID;
    
    fetch(deleteUrl, {
        method : 'DELETE',
        headers : headers
    })
    .then(errorHandler)
    .then(response => response.json())
    .then(data => {
        loadBooks();
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

    return tr;
}

function errorHandler(response){
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