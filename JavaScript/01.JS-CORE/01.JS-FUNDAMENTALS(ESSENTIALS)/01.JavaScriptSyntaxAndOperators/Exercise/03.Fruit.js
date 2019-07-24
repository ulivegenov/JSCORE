function solve(name, weight, price){
    
    let fruitName = String(name);
    let fruitWeightInKilograms = Number(weight)/1000;
    let fruitPricePerKilogram = Number(price);
    let finalFruitPrice = fruitWeightInKilograms*fruitPricePerKilogram;

    console.log(`I need $${finalFruitPrice.toFixed(2)} to buy ${fruitWeightInKilograms.toFixed(2)} kilograms ${fruitName}.`);
}

solve('apple', 1563, 2.35);