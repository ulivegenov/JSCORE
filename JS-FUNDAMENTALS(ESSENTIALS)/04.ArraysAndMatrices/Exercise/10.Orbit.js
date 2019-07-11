function solve(input){
    const startValue = 1;
    let matrixRows = Number(input[0]);
    let matrixCols = Number(input[1]);
    let startPosRow = Number(input[2]);
    let startPosCol = Number(input[3]);

    let matrix = [];

    for(let currentRow = 0; currentRow < matrixRows; currentRow++){
        matrix.push([]);
        for(let currentCol = 0; currentCol < matrixCols; currentCol++){
            let currentRowDiff = Math.abs(startPosRow - currentRow);
            let currentColDiff = Math.abs(startPosCol - currentCol);
            let currentDiff = 0;
            
            if(currentRowDiff >= currentColDiff){
                currentDiff = currentRowDiff;
            } else{
                currentDiff = currentColDiff;
            }

            let currentValue = currentDiff + startValue;

            matrix[currentRow].push(currentValue);
        }
    }


    for(let currentRow = 0; currentRow < matrixRows; currentRow++){
        console.log(matrix[currentRow].join(' ')); 
    }
}

solve([4, 4, 1, 0]);