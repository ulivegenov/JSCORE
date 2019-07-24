function attachEvents() {
    let baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
    let phonebookList = document.getElementById('phonebook');
    
    let btnLoad = document.getElementById('btnLoad');
    let btnCreate = document.getElementById('btnCreate');

    btnLoad.addEventListener('click', loadContacts);
    btnCreate.addEventListener('click', createContact);

    function loadContacts(){
        getInfo();
    }

    function createContact(){
        let person = document.getElementById('person').value;
        let phone = document.getElementById('phone').value;

        fetch(baseUrl, {
            method : 'POST',
            headers : {
                'Accept' : 'application/json',
                'Content-type' : 'application/json'
            },
            body : JSON.stringify({
                person,
                phone
            })
        })
        .then((response) => response.json())
        .then(response => {
            getInfo();
        });

        document.getElementById('person').value = '';
        document.getElementById('phone').value = '';
    }


    function getInfo(){
        fetch(baseUrl)
        .then((response) => response.json())
        .then((data) => {
            phonebookList.innerHTML = '';
            for (const key of Object.keys(data)) {
                let contact = data[key];
                let liElement = document.createElement('li');
                let btnDelete = document.createElement('button');
                btnDelete.textContent = 'Delete';
                btnDelete.setAttribute('class', 'btnDelete');
                btnDelete.addEventListener('click', () => deleteContact(key));

                liElement.textContent = `${contact.person}: ${contact.phone}`;
                liElement.appendChild(btnDelete);
                phonebookList.appendChild(liElement);
            }
        });
    }

    function deleteContact(key){
        let urlToDelete = `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`;
        
        fetch(urlToDelete, {
            method : 'DELETE'
        })
        .then((response) => response.json())
        .then(response => {
            getInfo()
        });
    }
}

attachEvents();