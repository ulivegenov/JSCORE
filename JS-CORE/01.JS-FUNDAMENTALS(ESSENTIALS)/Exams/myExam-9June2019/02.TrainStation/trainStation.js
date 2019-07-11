function solve(capacity, passengers){
    let train = [];
    let passengersLeft = 0;

    for (let i = 0; i < passengers.length; i++) {
        passengers[i] += passengersLeft;

        if(passengers[i] <= capacity){
            train.push(passengers[i]);
            passengers[i] = 0;
            passengersLeft = 0;
        } else{
            train.push(capacity);
            passengersLeft = passengers[i] - capacity;
        }
    }

    console.log(`[ ${train.join(', ')} ]`);
    if(passengersLeft === 0){
        console.log('All passengers aboard');
    } else{
        console.log(`Could not fit ${passengersLeft} passengers`);
    }
}

solve(10, [9, 39, 1, 0, 0]);
console.log('-------------');
solve(6, [5, 15, 2]);