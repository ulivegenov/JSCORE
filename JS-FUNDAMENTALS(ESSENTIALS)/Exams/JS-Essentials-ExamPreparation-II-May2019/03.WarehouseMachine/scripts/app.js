function coffeeStorage() {
    let input = JSON.parse(document.getElementsByTagName('textarea')[0].value);
    let coffeeStorage = {};
    
    for (let currentElement of input) {
        let data = currentElement.split(', ');
        let currentCommand = data.shift();
          
        switch(currentCommand){
            case 'IN':
                addCoffee(data);
                break;
            case 'OUT':
                removeCoffee(data);
                break;
            case 'REPORT':
                report();
                break;
            case 'INSPECTION':
                inspection();
                break;
        }
    }

    

    function addCoffee(coffeeData){
        let coffeeBrand = coffeeData.shift();
        let coffeeName = coffeeData.shift();
        let expireDate = coffeeData.shift();
        let quantity = Number(coffeeData.shift());
        
        if(!coffeeStorage.hasOwnProperty(coffeeBrand)){
            coffeeStorage[coffeeBrand] = {};
        }

        if(!coffeeStorage[coffeeBrand].hasOwnProperty(coffeeName)){
            coffeeStorage[coffeeBrand][coffeeName] = {
                expireDate,
                quantity
            }
        } else {
            let currentCoffee = coffeeStorage[coffeeBrand][coffeeName];

            if(currentCoffee.expireDate < expireDate){
                currentCoffee.expireDate = expireDate;
                currentCoffee.quantity = quantity
            } else if (currentCoffee[expireDate] === expireDate){
                currentCoffee.quantity += quantity;
            }
        }
    }

    function removeCoffee(coffeeData){
        let coffeeBrand = coffeeData.shift();
        let coffeeName = coffeeData.shift();
        let expireDate = coffeeData.shift();
        let quantity = Number(coffeeData.shift());

        if(coffeeStorage.hasOwnProperty(coffeeBrand)){
            if(coffeeStorage[coffeeBrand].hasOwnProperty(coffeeName)){
                if(coffeeStorage[coffeeBrand][coffeeName].expireDate > expireDate){
                    if(coffeeStorage[coffeeBrand][coffeeName].quantity > quantity){
                        coffeeStorage[coffeeBrand][coffeeName].quantity -= quantity;   
                    }
                }
            }
        }
    }

    function report(){
        let reportElement = document.getElementsByTagName('p')[0];

        Object.entries(coffeeStorage).map(([brand, name]) => {
            reportElement.innerHTML += `${brand}:`;

            Object.entries(name).map(([name, info]) =>{
                reportElement.innerHTML += ` ${name} - ${info.expireDate} - ${info.quantity}.`
            });

            reportElement.innerHTML += '<br>';
        });
    }

    function inspection(){
        let inspectionElement = document.getElementsByTagName('p')[1];

        Object.entries(coffeeStorage)
              .sort((a, b) => a[0].localeCompare(b[0]))
              .map(([brand, name]) => {
                    inspectionElement.innerHTML += `${brand}:`;

                    Object.entries(name).sort((a, b) => b[1].quantity - a[1].quantity)
                                        .map(([name, info]) => {
                                            inspectionElement.innerHTML += ` ${name} - ${info.expireDate} - ${info.quantity}.`
                                        });

                    inspectionElement.innerHTML += '<br>';
               });
    }
}