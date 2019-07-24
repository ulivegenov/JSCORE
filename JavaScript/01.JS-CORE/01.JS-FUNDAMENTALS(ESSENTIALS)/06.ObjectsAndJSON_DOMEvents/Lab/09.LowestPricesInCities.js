function solve(input){
    let products = new Map();

    for (let line of input) {
        let data = line.split(' | ');
        let town = data[0];
        let product = data[1];
        let price = Number(data[2]);

        if(!products.has(product)){
            products.set(product, new Map());
        }

        products.get(product).set(town, price); 
    }

    for (let [product, insideMap] of products) {
        let lowestPrice = Number.POSITIVE_INFINITY;
        let townWithLowerPrice = ''
        for (let [town, price] of insideMap) {
            if(price < lowestPrice){
                lowestPrice = price;
                townWithLowerPrice = town;
            }
        }
        console.log(`${product} -> ${lowestPrice} (${townWithLowerPrice})`);
    }
}
