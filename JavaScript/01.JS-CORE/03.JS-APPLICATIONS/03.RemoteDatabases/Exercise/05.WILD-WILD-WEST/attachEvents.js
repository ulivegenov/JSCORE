function attachEvents() {
    const credentials = {
        appKey : 'kid_BkjjlbLzH',
        appSecret : 'a9f0c55aaff04b52b4ef9fa6e13d3bbb',
        username : 'admin',
        password : 'admin'
    }

    const base_64 = btoa(`${credentials.username}:${credentials.password}`);

    const headers = {
        'Authorization' : `Basic ${base_64}`,
        'Content-type' : 'application/json'
    }

    const urls = {
        base : 'https://baas.kinvey.com/appdata/kid_BkjjlbLzH/players'
    }

    const elements = {
        players : document.getElementById('players'),
        btnAddPlayer : document.getElementById('addPlayer'),
        inputName : document.getElementById('addName'),
        btnSave : document.getElementById('save'),
        btnReload : document.getElementById('reload'),
        canvas : document.getElementById('canvas'),
        h3 : document.getElementsByTagName('h3')[0]
    }

    elements.btnAddPlayer.addEventListener('click', addPlayer);
    
    async function loadPlayers() {
        elements.players.innerHTML = '';

        let response = await fetch(urls.base, {
            method : 'GET',
            headers : headers
        })
        .then(requestErrorHandler)
        .then(response => response.json())
        .then(data => {
            for (const currentPlayer of data) {
                appendPlayerToDom(currentPlayer);
            }
        })
        .catch(error => alert(error.message));

    }

    loadPlayers();

    async function addPlayer(){
        try {
            inputDataErrorHandler();

            const player = {
                name : elements.inputName.value,
                money : 500,
                bullets : 6
            }
    
            elements.inputName.value = '';
    
            let response = await fetch(urls.base, {
                method : 'POST',
                headers : headers,
                body : JSON.stringify(player)
            })
            .then(requestErrorHandler)
            .then(loadPlayers)
            .catch(error => alert(error.message));
        } catch (error) {
            alert(error.message);
        }
    }

    function appendPlayerToDom(currentPlayer){
        const divElement = document.createElement("div");
        divElement.classList.add("player");
        divElement.setAttribute("id", currentPlayer._id);
        divElement.innerHTML = `<div class="name">Name: ${currentPlayer.name}</div>
                           <div class="money">Money: ${currentPlayer.money}</div>
                           <div class="bullets">Bullets: ${currentPlayer.bullets}</div>
                           <div class="buttons">
                               <div class="play-button">
                                  <button>Play</button>
                               </div>
                               <div class="delete-button">
                                  <button>Delete</button>
                               </div>
                           </div>`;
        const btnPlay = divElement.querySelector('.play-button');
        const deleteBtn = divElement.querySelector('.delete-button');
        btnPlay.addEventListener('click', () => {
            play(currentPlayer)
        }); 
        deleteBtn.addEventListener("click", () => {
             deletePlayer(currentPlayer._id)
        });
        elements.players.appendChild(divElement);
    }

    function play(currentPlayer){
        elements.canvas.style.display = 'block';
        elements.btnSave.style.display = 'inline-block';
        elements.btnReload.style.display = 'inline-block';
        elements.btnSave.addEventListener('click', () => save(currentPlayer));
        elements.btnReload.addEventListener('click', () => reload(currentPlayer));
        loadCanvas(currentPlayer);
    }

    async function save(currentPlayer){
        const putUrl = `${urls.base}/${currentPlayer._id}`;

        let response = await fetch(putUrl, {
            method : 'PUT',
            headers : headers,
            body : JSON.stringify(currentPlayer)
        })
        .then(requestErrorHandler)
        //.then(stopGame) //--> This function is optional. Just uncomment if you want a different view for Game Over!
        .then(elements.players.innerHTML = '')
        .then(loadPlayers)
        .catch(error => alert(error.message));

        clearInterval(elements.canvas.intervalId);
    }

    function reload(currentPlayer){
        currentPlayer.money -= 60;
        currentPlayer.bullets = 6;
    }

    async function deletePlayer(playerId){
        let deleteUrl = `${urls.base}/${playerId}`;

        let response = await fetch(deleteUrl, {
            method : 'DELETE',
            headers : headers
        })
        .then(requestErrorHandler)
        .then(loadPlayers)
        .catch(error => alert(error.message));
    }

    function stopGame(){
        elements.canvas.style.display = 'none';
        elements.btnSave.style.display = 'none';
        elements.btnReload.style.display = 'none';
        elements.h3.style.display = 'block';
    }

    function requestErrorHandler(response){
        if(response.status >= 400){
            throw new Error(`Something went wrong! Response status: ${response.status}. ${response.statusText}`);
        }

        return response;
    }

    function inputDataErrorHandler(){
        if(!elements.inputName.value){
            throw new Error('Name should be atleast one symbol long!');
        }
    }
}