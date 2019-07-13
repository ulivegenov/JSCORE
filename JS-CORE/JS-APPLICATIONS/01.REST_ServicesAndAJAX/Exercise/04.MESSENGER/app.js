function attachEvents() {
    let url = 'https://rest-messanger.firebaseio.com/messanger.json';
    let messages = document.getElementById('messages');
    let btnSend = document.getElementById('submit');
    let btnRefresh = document.getElementById('refresh');

    btnSend.addEventListener('click', submit);
    btnRefresh.addEventListener('click', getMessages);


    function submit(){
        let author = document.getElementById('author').value;
        let content = document.getElementById('content').value;
        let post = { 
            author, 
            content 
        }; 

        fetch(url, {
            method : 'POST',
            headers : {
                'Content-type' : 'application/json'
            },
            body : JSON.stringify(post)
        })
        .then((response) => response.json());

        document.getElementById('author').value = '';
        document.getElementById('content').value = '';
    }
    
    function getMessages(){
        fetch(url)
        .then((response) => response.json())
        .then((data) => {
            let allMessages = Object.values(data).map(message => `${message.author}: ${message.content}`);
            messages.value = allMessages.join('\n');
        })
    }
}

attachEvents();