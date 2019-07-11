function plasmaGiants(inputArray, cutSize){
    // 1.Cut inputArray into two pieces.
    firstPart = inputArray.slice(0, inputArray.length/2)
    secondPart = inputArray.slice(inputArray.length/2);
    

    // 2.Get sum of the products of the two pieces => Get Giants life.
    let firstGiantLife = 0;
    let secondGiantLife = 0;

    while(firstPart.length > 0 && secondPart.length > 0){
        firstGiantLife += firstPart.splice(0,cutSize).reduce((a, b) => a * b);
        secondGiantLife += secondPart.splice(0, cutSize).reduce((a, b) => a * b);
    }
    
    // 3.Fight
    let damagePerHit = Math.min(...inputArray);
    let deadLine = Math.max(...inputArray);
    let rounds = 1;

    if (damagePerHit !== 0) {
        while (firstGiantLife > deadLine && secondGiantLife > deadLine) {
          firstGiantLife -= damagePerHit;
          secondGiantLife -= damagePerHit;
          rounds++
        }
    }
    
    //4. Print
    if(firstGiantLife === secondGiantLife){
        console.log(`Its a draw ${firstGiantLife} - ${secondGiantLife}`);
    } else {
        let winner = '';
        let looser = '';
        if(firstGiantLife > secondGiantLife){
            winner = 'First';
            looser = 'Second';
        } else {
            winner = 'Second';
            looser = 'First';
        }
        let winnerPoints = Math.max(firstGiantLife, secondGiantLife);
        let looserPoints = Math.min(firstGiantLife, secondGiantLife);

        console.log(`${winner} Giant defeated ${looser} Giant with result ${winnerPoints} - ${looserPoints} in ${rounds} rounds`)
    }
}   

plasmaGiants([3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 2);
console.log('----------------------------------------------');
plasmaGiants([4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], 2);