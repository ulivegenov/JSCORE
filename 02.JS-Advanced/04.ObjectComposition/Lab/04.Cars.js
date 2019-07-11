function solve(input){
    let carList = (function (){
        let cars = [];

        function create(name){
            let car = {
                name : name
            }

            cars.push({name});
        }

        function inherits(nameOne, nameTwo){
            let carOne = {
                name : nameOne
            };
            let carTwo = cars.find(c => c.name === nameTwo);
            Object.setPrototypeOf(carOne, carTwo);
            cars.push(carOne);
        }

        function set(name, key, value){
            let car = cars.find(c => c.name === name);
            car[key] = value;
            cars = cars.filter(c => c.name !== name);
            cars.push(car);
        }

        function print(name){
            let car = cars.find(c => c.name === name);
            let output = [];
            for (const key in car) {
                output.push(`${key}:${car[key]}`);
            }
            output.shift();
            console.log(output.join(', '));
        }

        return{
            create,
            inherits,
            set,
            print
        }
    })();
    
    for (const element of input) {
        let data = element.split(' ');

        if(data[0] === 'create'){
            if(data.length === 2){
                carList.create(data[1]);
            } else{
                carList.inherits(data[1], data[3]);
            }
        } else if(data[0] === 'set'){
            carList.set(data[1], data[2], data[3]);
        } else if(data[0] === 'print'){
            carList.print(data[1]);
        }
    }
}

solve(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
);