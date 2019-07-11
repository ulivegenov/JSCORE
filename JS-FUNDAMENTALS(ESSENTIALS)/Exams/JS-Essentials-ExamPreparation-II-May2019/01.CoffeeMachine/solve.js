function cofeeMachine(input){
    let totalMoney = 0;

    for (let currentOrder of input) {
        let data = currentOrder.split(', ');
        let insertedCoins = Number(data.shift());
        let drinkType = data.shift();
        let price = 0.80;
        let sugarQuantity = data.pop();

        if(currentOrder.includes('decaf')){
            price += 0.10;
        }

        if(currentOrder.includes('milk')){
            price += Number((price*0.1).toFixed(1));
        }

        if(sugarQuantity > 0){
            price += 0.10;
        }

        

        if(insertedCoins >= price){
            totalMoney += price;
            console.log(`You ordered ${drinkType}. Price: ${price.toFixed(2)}$ Change: ${(insertedCoins - price).toFixed(2)}$`);
        } else{
            console.log(`Not enough money for ${drinkType}. Need ${(price - insertedCoins).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalMoney.toFixed(2)}$`);
}


cofeeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
'1.00, coffee, decaf, 0']);

console.log('-----------------------------------');

cofeeMachine(['8.00, coffee, decaf, 4',
'1.00, tea, 2']);