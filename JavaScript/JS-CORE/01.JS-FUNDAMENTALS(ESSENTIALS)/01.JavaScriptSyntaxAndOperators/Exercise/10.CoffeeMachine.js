function solve(input){

    let startPrices = {"coffeeCaffeine" : 0.8, "coffeeDecaf" : 0.90, "tea" : 0.80};
    let income = 0;

    let output = "";
    for(let i = 0; i < input.length; i++){

        let tottalPrice = 0;
        let currentOrder = input[i];
        let orderArgs = currentOrder.split(", ");
        let insertMoney = orderArgs[0];
        let kindOfDrink = orderArgs[1];

        if(kindOfDrink === "coffee"){
            let kindOfCoffee = orderArgs[2];
            if(kindOfCoffee === "caffeine"){
                tottalPrice = startPrices.coffeeCaffeine;
            }
            else{
                tottalPrice = startPrices.coffeeDecaf;
            }
            if(orderArgs.length > 3){
                if(orderArgs[3] === "milk"){
                    tottalPrice += 0.1; 
                }
                else if (Number(orderArgs[3]) !== 0){
                    tottalPrice += 0.1;
                }
            }
            if(orderArgs.length > 4){
                if (Number(orderArgs[4]) !== 0){
                    tottalPrice += 0.1;
                }
            }
        }
        else{
            tottalPrice = startPrices.tea

            if(orderArgs.length > 2){
                if(orderArgs[2] === "milk"){
                    tottalPrice += 0.1;
                }
                else if(Number(orderArgs[2]) !== 0){
                    tottalPrice += 0.1;
                }
            }
            if(orderArgs.length > 3){
                if(Number(orderArgs[3]) !== 0){
                    tottalPrice +=0.1;
                }
            }
        }

        if(tottalPrice <= insertMoney){
            output =`You ordered ${kindOfDrink}. Price: $${tottalPrice.toFixed(2)} Change: $${(insertMoney - tottalPrice).toFixed(2)}`;
            income += tottalPrice;
        }
        else{
            output = `Not enough money for ${kindOfDrink}. Need $${(tottalPrice - insertMoney).toFixed(2)} more.`;
        }
        
        console.log(output);
    }

    console.log(`Income Report: $${income.toFixed(2)}`);
}

solve(['8.00, coffee, decaf, 4',
'1.00, tea, 2']);