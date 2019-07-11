function solve (input){

    let kindOfFlight = input[0];
    let townName = input[1];
    let time = input[2];
    let flightNumber = input[3];
    let gateNumber = input[4];

    let result = `${kindOfFlight}: Destination - ${townName}, Flight - ${flightNumber}, Time - ${time}, Gate - ${gateNumber}`;
 
    console.log(result);
}

solve(['Departures', 'London', '22:45', 'BR117', '42'])