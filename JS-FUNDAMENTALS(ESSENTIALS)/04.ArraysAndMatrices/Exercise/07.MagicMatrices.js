function solve(matrix){
    let magicNum = 0;
    let isMagic = true;
    let firstArray = matrix[0];

    for(let i = 0; i < firstArray.length; i++){
        magicNum += firstArray[i];
    }

    for( let currentRow = 0; currentRow < matrix.length; currentRow++){
        let currentRowSum = 0;
        
        for(let currentCol = 0; currentCol < matrix[currentRow].length; currentCol++){
            currentRowSum += matrix[currentRow][currentCol];
            let currentColSum = 0;

            for(let row = 0; row < matrix.length; row++){
                currentColSum += matrix[row][currentCol];
            }

            if(currentColSum !== magicNum){
                isMagic = false;
                break;
            }
        }

        if(!isMagic){
            break;
        }

        if(currentRowSum !== magicNum){
            isMagic = false;
            break;
        }
    }

    console.log(isMagic);
}
