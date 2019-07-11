function solve(input){
    let map = new Map();

    for (let line of input) {
        let data = line.split(/\s+<->\s+/);
        let cityName = data[0];
        let population = Number(data[1]);

        if(!map.has(cityName)){
            map.set(cityName, 0);
        }

        map.set(cityName, map.get(cityName) + population);
    }

    for (let city of map) {
        console.log(`${city[0]} : ${city[1]}`);
    }
}