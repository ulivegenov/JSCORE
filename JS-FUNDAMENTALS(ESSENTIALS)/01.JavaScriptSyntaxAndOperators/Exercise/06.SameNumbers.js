function solve (input){
    
    let number = String(input);
    let firstNum = Number(number[0]);
    let sum = firstNum;
    let sameNambers = true;

    for(let i = 1; i < number.length; i++){
        if(firstNum !== Number(number[i])){
            sameNambers = false;
        }
        sum = sum + Number(number[i]);
    }

    console.log(sameNambers);
    console.log(sum);
}

solve(2222222);