function attachEvents() {
    let baseUrl = 'https://fisher-game.firebaseio.com/catches.json';
    let catchesElement = document.getElementById('catches');
    let catchModel = catchesElement.children[0].cloneNode(true);
    catchesElement.removeChild(catchesElement.children[0]);
    let btnLoad = document.querySelector('.load');
    let btnAdd = document.querySelector('.add');
    

    btnLoad.addEventListener('click', loadCatches);
    btnAdd.addEventListener('click', addCatch);

    function loadCatches(){
        

        fetch(baseUrl)
        .then(response => response.json())
        .then((data) => {
            catchesElement.innerHTML = '';
            let keys = Object.keys(data);
            
            for (const key of keys) {
                let currentModel = catchModel.cloneNode(true);
                currentModel.setAttribute('data-id', key)
                currentModel.children[1].setAttribute('value', data[key].angler);
                currentModel.children[4].setAttribute('value', data[key].weight);
                currentModel.children[7].setAttribute('value', data[key].species);
                currentModel.children[10].setAttribute('value', data[key].location);
                currentModel.children[13].setAttribute('value', data[key].bait);
                currentModel.children[16].setAttribute('value', data[key].captureTime);
                let btnUpdate = currentModel.children[18];
                let btnDelete = currentModel.children[19];

                btnUpdate.addEventListener('click', () => updateCatch(key, currentModel));
                btnDelete.addEventListener('click', () => deleteCatch(key));

                catchesElement.appendChild(currentModel);
            }
        });
    }
    
    function addCatch(){
        const [...info] = document.querySelectorAll('#addForm input');
        
        let angler = info[0].value;
        let weight = info[1].value;
        let species = info[2].value;
        let location = info[3].value;
        let bait = info[4].value;
        let captureTime = info[5].value;
        
        for (const currentInput of info) {
            currentInput.value = '';
        }

        fetch(baseUrl, 
        {
            headers : {'Content-Type' : 'application/json'},
            method : 'POST',
            body : JSON.stringify({
                angler,
                bait,
                captureTime,
                location,
                species,
                weight
            })
        })
        .then(response => response.json())
        .then((data) => {
            loadCatches();
        })
    }

    function updateCatch(key, currentModel){
        let updateUrl = `https://fisher-game.firebaseio.com/catches/${key}.json`;

        let angler = currentModel.children[1].value;
        let weight = currentModel.children[4].value;
        let species = currentModel.children[7].value;
        let location = currentModel.children[10].value;
        let bait = currentModel.children[13].value;
        let captureTime = currentModel.children[16].value;

        fetch(updateUrl, 
        {
            method : 'PUT',
            headers : {'Content-Type' : 'application/json'},
            body : JSON.stringify({
                angler,
                bait,
                captureTime,
                location,
                species,
                weight
            })
        })
        .then(response => response.json())
        .then((data) => {
            loadCatches();
        });
    }

    function deleteCatch(key){
        let deleteUrl = `https://fisher-game.firebaseio.com/catches/${key}.json`;

        fetch(deleteUrl, 
        {
            method : 'DELETE'
        })
        .then(response => response.json())
        .then((data) => {
            loadCatches();
        });
    }
}

attachEvents();

