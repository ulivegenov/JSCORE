function solve(input){
    let step = input[input.length - 1];
    input.pop();

    for(let i = 0; i < input.length; i++){
        if(i % step === 0){
            console.log(input[i]);
        }
    }
}
