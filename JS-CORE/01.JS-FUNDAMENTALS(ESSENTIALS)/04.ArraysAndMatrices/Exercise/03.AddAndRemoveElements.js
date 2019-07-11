function solve(input){
    let result = [];
    let currentElement = 1;

    for(let i = 0; i < input.length; i++){
        if(input[i] === 'add'){
            result.push(currentElement);
            currentElement++;
        } else{
            if(result.length !== 0){
                result.pop();
            }
            currentElement++;
        }
    }

    if(result.length === 0){
        console.log('Empty');
    } else{
        for(let element of result){
            console.log(element);
        }
    }
}
