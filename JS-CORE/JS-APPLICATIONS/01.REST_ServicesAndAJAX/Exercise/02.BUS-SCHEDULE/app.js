function solve() {
    let infoElement = document.querySelector('.info');
    let btnDepart = document.getElementById('depart');
    let btnArrive = document.getElementById('arrive');
    let currentId = 'depot';
    let url = '';

    function depart() {
        getInfo();
        switchButtons(btnDepart, btnArrive);
    }

    function arrive() {
        getInfo();
        switchButtons(btnArrive, btnDepart);
    }

    return {
        depart,
        arrive
    };

    function getInfo(){
        url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;
        fetch(url)
            .then((respons) => respons.json())
            .then((data) => {
                const currentStopName = data.name;
                currentId = data.next;
                infoElement.textContent = currentStopName;
            });
    }

    function switchButtons(disable, enable){
        disable.setAttribute('disabled', 'disabled');
        enable.removeAttribute('disabled');
    }
}

let result = solve();