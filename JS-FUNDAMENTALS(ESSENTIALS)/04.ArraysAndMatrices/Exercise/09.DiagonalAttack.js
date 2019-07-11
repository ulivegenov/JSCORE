function solve(matrixRows){
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    let matrix = matrixRows.map(row => row
                            .split(' ')
                            .map(Number));

    for(let row = 0; row < matrix.length; row++){
        leftDiagonalSum += Number(matrix[row][row]);
        rightDiagonalSum += Number(matrix[row][matrix[row].length - 1 - row]);
            
    }

    if(leftDiagonalSum === rightDiagonalSum){
        for(let row = 0; row < matrix.length; row++){
            for(let col = 0; col < matrix[row].length; col++){
                if((row != col) && ((matrix[row].length - 1 - row) != col)){
                    matrix[row][col] = leftDiagonalSum;
                }
            }
        }
    }

    for(let row = 0; row < matrix.length; row++){
        console.log(matrix[row].join(' '));
    }
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']);
