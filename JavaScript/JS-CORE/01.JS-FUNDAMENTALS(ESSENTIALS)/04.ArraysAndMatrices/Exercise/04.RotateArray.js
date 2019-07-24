function solve(input){
    let rotationCount = input[input.length - 1];
    input.pop();

    for(let i = 0; i < rotationCount % input.length; i++){
        let currentElement = input[input.length - 1];
        input.pop();
        input.unshift(currentElement);
    }

    let result = input.join(' ');
    console.log(result);
}
