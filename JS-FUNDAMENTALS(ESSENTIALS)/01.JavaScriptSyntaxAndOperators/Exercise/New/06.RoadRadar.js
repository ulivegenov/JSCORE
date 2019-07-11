function solve(inputArray){
    let speedLimits = {
        'motorway' : 130,
        'interstate' : 90,
        'city' : 50,
        'residential' : 20
    }

    let currentSpeed = Number(inputArray[0]);
    let currentArea = inputArray[1];

    let speeding = currentSpeed - speedLimits[currentArea];

    if(speeding > 0){
        if(speeding <= 20){
            console.log('speeding');
        } else if( speeding <= 40){
            console.log('excessive speeding');
        } else{
            console.log('reckless driving');
        }
    }
}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);