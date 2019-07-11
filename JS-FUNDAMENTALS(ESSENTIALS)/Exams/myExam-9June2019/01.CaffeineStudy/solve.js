function solve(duration){
    let coffeeQuantity = 150;
    let colaQuantity = 250;
    let teaQuantity = 350;
    let enegryDrinksQuantity = 500;
    let caffeineQuantity = 0;

    for (let i = 1; i <= duration; i++) {
          caffeineQuantity += coffeeQuantity*3/100*40;
          caffeineQuantity += colaQuantity*2/100*8;
          caffeineQuantity += teaQuantity*3/100*20;

          if(i % 5 === 0){
              caffeineQuantity += enegryDrinksQuantity*3/100*30;
          }

          if(i % 9 === 0){
              caffeineQuantity += colaQuantity*4/100*8;
              caffeineQuantity += enegryDrinksQuantity*2/100*30;
          }
    }

    console.log(`${caffeineQuantity} milligrams of caffeine were consumed`)
}

solve(5);
console.log('---------------');
solve(8);