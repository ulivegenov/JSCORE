function solve(input) {
    
    let number = Number(input);

    for(let i = 1; i <= number; i++){
        if (i % 2 === 0){
            console.log(i);
        }
    }
}

solve(7);