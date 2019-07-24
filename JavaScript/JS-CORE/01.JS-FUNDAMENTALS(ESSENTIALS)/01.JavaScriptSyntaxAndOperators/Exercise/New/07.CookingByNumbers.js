function solve(inputArray){
    let num = Number(inputArray[0]);

    for (let i = 1; i < inputArray.length; i++) {
        num = manipulateNum(num, inputArray[i]);
        console.log(num);  
    }

    function manipulateNum(currentNum, operation){
        switch(operation){
            case 'chop' : return currentNum /= 2;
            case 'dice' : return currentNum = Math.sqrt(currentNum);
            case 'spice' : return ++currentNum;
            case 'bake' : return currentNum *= 3;
            case 'fillet' : return currentNum -= currentNum*0.2;
        }
    }
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
console.log('---');
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);