function solve(input){

    let inerString = "";

    for(let i = 0; i < input.length; i++){
        let nameOfFood = "";
        let calories = 0;
        if(i % 2 === 0){
            nameOfFood = input[i];
            inerString += nameOfFood;
            inerString += ": ";
        }
        else{
            calories = input[i];
            inerString += calories;

            if(i < input.length - 1){
                inerString += ", ";
            }
        }
    }

    let result = `{ ${inerString} }`;

    console.log(result);
}

solve(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);