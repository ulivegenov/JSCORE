function solution(params){
    return (function (){
        const container = {protein : 0, carbohydrate : 0, fat : 0, flavour : 0};
    
        const reciepes = {
            'apple' : {carbohydrate : 1, flavour : 2},
            'lemonade' : {carbohydrate : 10, flavour : 20},
            'burger' : {carbohydrate : 5, fat : 7, flavour : 3},
            'eggs' : {protein : 5, fat : 1, flavour : 1},
            'turkey' : {protein : 10, carbohydrate : 10, fat : 10, flavour : 10}
        }
    
        const prepareReciepe = (reciepeName, mealQuantity) => {
            const neededIngridients = Object.entries(reciepes[reciepeName]);
    
            //Validate Needed Ingridients.
            for (const [ing, qty] of neededIngridients) {
                const containerIngridientQuantity = container[ing];
                if(containerIngridientQuantity < qty*mealQuantity){
                    return `Error: not enough ${ing} in stock`;
                }
            }
            
            for (const [ing,qty] of neededIngridients) {
                container[ing] -= qty * mealQuantity;
            }
    
            return 'Success';
        }
    
        return input => {
            let [command, ...data] = input.split(' ');
            let ingridientOrRecipe = data[0];
            let quantity = Number(data[1]);
            let message = '';
    
            if(command === 'restock'){
                container[ingridientOrRecipe] += quantity;
                message ='Success';
            } else if(command === 'prepare'){
                message = prepareReciepe(ingridientOrRecipe, quantity);
            } else if(command === 'report'){
                message = Object.entries(container).map((kvp) => `${kvp[0]}=${kvp[1]}`).join(' ');
            }
            
            console.log(message);
            return message;
        } 
    })();
}
