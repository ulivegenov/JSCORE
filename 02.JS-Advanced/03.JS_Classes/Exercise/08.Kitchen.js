class Kitchen{
    constructor(budget){
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products){
        for (const currentLoad of products) {
            let data = currentLoad.split(' ');
            let productName = data[0];
            let productQuantity = Number(data[1]);
            let productPrice = Number(data[2]);

            if(this.budget - productPrice >= 0){
                if(!this.productsInStock.hasOwnProperty(productName)){
                    this.productsInStock[productName] = 0;
                }

                this.productsInStock[productName] += productQuantity;
                this.budget -= productPrice;
                this.actionsHistory.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else{
                this.actionsHistory.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }

        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, neededProducts, price){
        let currentMeal = {
            products : neededProducts,
            price : Number(price)
        }

        if(!this.menu.hasOwnProperty(meal)){
            this.menu[meal] = currentMeal;

            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        } else{
            return `The ${meal} is already in our menu, try something different.`;
        }
    }

    showTheMenu(){
        if(Object.keys(this.menu).length === 0){
            return "Our menu is not ready yet, please come later...";
        } else{
            let result = [];
            for (const meal in this.menu) {
                result.push(`${meal} - $ ${this.menu[meal].price}`);
            }

            return result.join('\n') + '\n';
        }
    }

    makeTheOrder(meal){
        if(!this.menu.hasOwnProperty(meal)){
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        } else{
            let stockHasAllProducts = true;

            for (const currentPrData of this.menu[meal].products) {
                let data = currentPrData.split(' ');
                let currentProductName = data[0];
                let currentProductQuantity = Number(data[1]);

                if(this.productsInStock.hasOwnProperty(currentProductName)){
                    if(this.productsInStock[currentProductName] < currentProductQuantity){
                        stockHasAllProducts = false;
                    }
                } else{
                    stockHasAllProducts = false;
                }
            }

            if(stockHasAllProducts){
                for (const currentPrData of this.menu[meal].products) {
                    let data = currentPrData.split(' ');
                    let currentProductName = data[0];
                    let currentProductQuantity = Number(data[1]);
    
                    this.productsInStock[currentProductName] -= currentProductQuantity;
                }

                this.budget += this.menu[meal].price;

                return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
            } else{
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }
    }
}

let kitchen = new Kitchen (1000);
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.showTheMenu());
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log('---------------------------------------');
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log('---------------------------------------');
console.log(kitchen.showTheMenu());
console.log('---------------------------------------');
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('kavarma'));
console.log(kitchen.makeTheOrder('Pizza'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));

