function solve(input){
    input.map(Number);
    let currentBigest = -Infinity;
    let result = [];

    for(let i = 0; i < input.length; i++){
        if(input[i] >= currentBigest){
            currentBigest = input[i];
            result.push(currentBigest);
        }
    }

    for(let element of result){
        console.log(element);
    }
}
