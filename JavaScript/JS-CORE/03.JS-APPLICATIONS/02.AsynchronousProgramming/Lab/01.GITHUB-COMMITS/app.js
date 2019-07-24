function loadCommits() {
    let username = document.getElementById('username').value;
    let repository = document.getElementById('repo').value;
    let url = `https://api.github.com/repos/${username}/${repository}/commits`;
    let commitsList = document.getElementById('commits');
    commitsList.innerHTML = '';

    function handleError(response){
        if(response.status >= 300){
            throw new Error(`Error: ${response.status} (${response.statusText})`);
        }

        return response;
    }

    fetch(url)
    .then(handleError)
    .then((response) => response.json())
    .then((data) => {
        let objects = Object.values(data);
        
        for (const obj of objects) {
            const commit = obj.commit;
            let listItem = document.createElement('li');
            listItem.textContent = `${commit.author.name}: ${commit.message}`;
            commitsList.appendChild(listItem);
        }
    })
    .catch((error) => {
        let listItem = document.createElement('li');
        listItem.textContent = error.message;
        commitsList.appendChild(listItem);
    });
}