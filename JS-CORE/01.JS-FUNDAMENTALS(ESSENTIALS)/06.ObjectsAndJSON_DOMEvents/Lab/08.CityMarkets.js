function solve(input){
    let cities = new Map();
   
    for (let line of input) {
        let data = line.split(/\s+->\s+/);
        let city = data[0];
        let product = data[1];
        let income = data[2].split(/\s+:\s+/).map(Number).reduce((a, b) => a*b);

        if(!cities.has(city)){
            cities.set(city, new Map())
        }

        if(!cities.get(city).has(product)){
            cities.get(city).set(product, 0);
        }

        cities.get(city).set(product, cities.get(city).get(product) + income);
    }

    for (let [city, product] of cities) {
        console.log(`Town - ${city}`);
        for (let [product, income] of cities.get(city)) {
            console.log(`$$$${product} : ${income}`);
        }
    }
}