function solve(input){
    let [towns, profits] = [{}, {}];

    input.forEach(vehicle => {
        if(!towns.hasOwnProperty(vehicle.town)){
            towns[vehicle.town] = {};
            profits[vehicle.town] = {
                profit : 0,
                registered : 0
            }
        }

        if(!towns[vehicle.town].hasOwnProperty(vehicle.model)){
            towns[vehicle.town][vehicle.model] = {
                regNumbers : [],
                price : vehicle.price
            }
        }

        towns[vehicle.town][vehicle.model].regNumbers.push(vehicle.regNumber);
        profits[vehicle.town].profit += vehicle.price;
        profits[vehicle.town].registered++;
    });

    let [town, data] = Object.entries(profits).sort((a, b) =>
        b[1].profit - a[1].profit ||
        b[1].registered - a[1].registered ||
        a[0].localeCompare(b[0]))[0];

    

    let mostDrivenModel = Object.entries(towns[town]).sort(
        (a, b) =>
            b[1].regNumbers.length - a[1].regNumbers.length ||
            b[1].price - a[1].price ||
            a[0].localeCompare(b[0])
    )[0][0];

    console.log(`${town} is most profitable - ${data.profit} BGN`);
    console.log(`Most driven model: ${mostDrivenModel}`);

    Object.entries(towns)
          .filter(t => t[1].hasOwnProperty(mostDrivenModel))
          .sort((a, b) => a[0].localeCompare(b[0]))
          .forEach(t => {
              let regNumbers = t[1][mostDrivenModel].regNumbers
                               .sort((a, b) => a.localeCompare(b))
                               .join(', ');
            
            console.log(`${t[0]}: ${regNumbers}`);
           });
}

solve([ { model: 'BMW', regNumber: 'B1234SM', town: 'Varna', price: 2},
{ model: 'BMW', regNumber: 'C5959CZ', town: 'Sofia', price: 8},
{ model: 'Tesla', regNumber: 'NIKOLA', town: 'Burgas', price: 9},
{ model: 'BMW', regNumber: 'A3423SM', town: 'Varna', price: 3},
{ model: 'Lada', regNumber: 'SJSCA', town: 'Sofia', price: 3} ]
);