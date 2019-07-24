
let stopNameElement = document.getElementById('stopName');
let busesListElement = document.getElementById('buses');
 
let handleError = function (response) {
    if (!response.ok) {
        stopNameElement.textContent = "Error";
        busesListElement.innerHTML = "";
    }
    return response;
}
 
function getInfo() {
    let stopId = document.getElementById('stopId').value;
    let url = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;
    console.log(url)

    fetch(url)
        .then(handleError)
        .then((response) => response.json())
        .then((data) => {
            if(!data.hasOwnProperty('error')){
                busesListElement.innerHTML = '';
                let stopName = data.name;
                let stopBuses = data.buses;
 
                stopNameElement.textContent = stopName;
                
                for (const bus in stopBuses) {
                    let liElement = document.createElement('li');
                    liElement.textContent = `Bus ${bus} arrives in ${stopBuses[bus]}`;
                    busesListElement.appendChild(liElement);
                }
            }
            
        })
        .catch(error => {
            console.log('error');
        });
        document.getElementById('stopId').value = '';
}