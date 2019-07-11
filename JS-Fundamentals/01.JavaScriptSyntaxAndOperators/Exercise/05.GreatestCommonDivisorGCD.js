function solve(num1, num2){

    let min = Math.min(num1, num2);
    let max = Math.max(num1, num2);

    for(let i = min; i > 0; i--){
        if((max % i === 0) && (min % i === 0)){
            console.log(i);
            break;
        }
    }
}

solve(24, 16);