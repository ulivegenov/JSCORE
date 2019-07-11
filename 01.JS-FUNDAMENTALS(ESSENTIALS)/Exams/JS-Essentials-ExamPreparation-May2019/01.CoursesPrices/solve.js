function coursesPrices(fundamentalsStatus, advancedStatus, apllicationStatus, educationForm){
    let totalPrice = 0;
    let prices = {
        fundamentals : 170,
        advanced : 180,
        applications : 190
    }
    
    if(fundamentalsStatus){
        totalPrice += prices.fundamentals;
    }

    if(advancedStatus){
        if(fundamentalsStatus){
            totalPrice += prices.advanced*0.90;
        } else{
            totalPrice += prices.advanced;
        }
    }

    if(apllicationStatus){
        totalPrice += prices.applications;

        if(fundamentalsStatus && advancedStatus){
            totalPrice *= 0.94;
        }    
    }

    if(educationForm === 'online'){
        totalPrice *= 0.94;
    }

    console.log(Math.round(totalPrice));   
}

coursesPrices(true, false, false, "onsite");
console.log('------');
coursesPrices(true, false, false, "online");
console.log('------');
coursesPrices(true, true, false, "onsite");