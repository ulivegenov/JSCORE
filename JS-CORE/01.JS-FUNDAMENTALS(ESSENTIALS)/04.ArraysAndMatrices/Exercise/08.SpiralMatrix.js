function solve(rowCount, colCount){

    let matrix = [];

    for(let i = 0; i < rowCount; i++){
        matrix.push([]);
        for(let j = 0; j < colCount; j++){
            matrix[i].push(0);
        }
    }

    let row = 0;
    let col = 0;
    let element = 1;

    while(element <= rowCount*colCount){

        //horizontal right
        while(col < colCount && matrix[row][col] == 0){
            matrix[row][col] = element;
            element++;
            col++;
        }
    
        row++;
        col--;

        //vertical down
        while(row < rowCount && matrix[row][col] == 0){
            matrix[row][col] = element;
            element++;
            row++;
        }
    
        row--;
        col--;

        // horizontal left
        while(col >= 0 && matrix[row][col] == 0){
            matrix[row][col] = element;
            element++;
            col--;
        }
    
        row--;
        col++;

        // vertical up
        while(row >= 0 && matrix[row][col] == 0){
            matrix[row][col] = element;
            element++;
            row--;
        }

        row++;
        col++;
    }
    
    for(let row = 0; row < rowCount; row++){
        console.log(matrix[row].join(' '));
    }
}

