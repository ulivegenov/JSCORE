function solve() {
    let trucks = [];
    let tires = [];
    let legends = Array.from(document.getElementsByTagName('legend'));
    let trucksLegend = legends[legends.length - 1].parentNode.children[1];
    let tiresLegend = legends[legends.length - 2].parentNode.children[1];

    let buttons = document.getElementsByTagName('button');
    Array.from(buttons).forEach(el => {
        el.addEventListener('click', action)
    });

    function action(e){
        let currentButton = e.target.innerHTML;

        switch(currentButton){
            case 'Add new truck' : addNewTruck(); 
                break;
            case 'Add new tires' : addNewTires();
                break;
            case 'Go to work' : goToWork();
                break;
            case 'End of the shift' : report();
                break;
        }
    }

    function addNewTruck(){
        let plateNumber = document.getElementById('newTruckPlateNumber').value;
        let tires = document.getElementById('newTruckTiresCondition').value.split(' ').map(Number);
        let newTruck = {
            plateNumber,
            tires,
            distanceTraveld : 0
        };

        trucks.push(newTruck);

        let divElement = document.createElement('div');
        divElement.setAttribute('class', 'truck');
        divElement.innerHTML = newTruck.plateNumber;

        trucksLegend.appendChild(divElement);

        document.getElementById('newTruckPlateNumber').value = '';
        document.getElementById('newTruckTiresCondition').value = '';
    }

    function addNewTires(){
        let newTires = document.getElementById('newTiresCondition').value.split(' ').map(Number);
        tires.push(newTires);

        let divElement = document.createElement('div');
        divElement.setAttribute('class', 'tireSet');
        divElement.innerHTML = newTires.join(' ');

        tiresLegend.appendChild(divElement);

        document.getElementById('newTiresCondition').value = '';
    }

    function goToWork(){
        let workPlateNumber = document.getElementById('workPlateNumber').value;
        let distanceToTravel = Number(document.getElementById('distance').value);

        trucks.forEach(e => {
            if(e.plateNumber === workPlateNumber){
                if(tiresConditionChek(e.tires, distanceToTravel)){
                    travel(e, distanceToTravel);
                } else{
                    let backUpTires = tires.shift();
                    tiresLegend.removeChild(tiresLegend.children[0]);
                    for(let i = 0; i < backUpTires.length; i++){
                        e.tires[i] = backUpTires[i];
                    }

                    if(tiresConditionChek(e.tires, distanceToTravel)){
                        travel(e, distanceToTravel);
                    }
                    
                }
            }
        });

        document.getElementById('workPlateNumber').value = '';
        document.getElementById('distance').value = '';
    }

    function report(){
        let output = '';
        let reportTextArea = document.getElementsByTagName('textarea')[0];

        for (let truck of trucks) {
            output += `Truck ${truck.plateNumber} has traveled ${truck.distanceTraveld}.\n`
        }

        output += `You have ${tires.length} sets of tires left.\n`

        reportTextArea.value = output;
    }

    function tiresConditionChek(tires, distance){
        let isTiresQualityEnough = true;
        let decrement = distance/1000;
        
        tires.forEach(e => {
            if(e < decrement){
                return isTiresQualityEnough = false;
            }
        });

        return isTiresQualityEnough;
    }

    function travel(truck, distanceToTravel){
        let decrement = distanceToTravel/1000;
        for (let i = 0; i < truck.tires.length; i++) {
            truck.tires[i] -= decrement;   
        }
        truck.distanceTraveld += distanceToTravel;
    }
}