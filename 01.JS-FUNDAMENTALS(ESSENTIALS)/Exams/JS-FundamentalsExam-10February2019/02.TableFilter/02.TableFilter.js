function solve(matrix, commandInput){
    const commandData = commandInput.split(' ');
    const command = commandData[0];
    const colName = commandData[1];
    let colValue = '';
    if(commandData.length === 3){
        colValue = commandData[2];
    } 

    switch(command){
        case 'hide' : hide(colName);
            break;
        case 'sort' : sort(colName);
            break;
        case 'filter' : filter(colName, colValue);
            break;
    }

    function hide(colName){
        let indexTohide = matrix[0].indexOf(colName);
        let result = []

        for (let row = 0; row < matrix.length; row++) {
            let currentRow = [];

            for (let col = 0; col < matrix[row].length; col++) {
                
                if(col !== indexTohide){
                    currentRow.push(matrix[row][col]);   
                }
            }
            result.push(currentRow.join(' | '));
        }

        console.log(result.join('\n'));
    }

    function sort(colName){
        const sortColIndex = matrix[0].indexOf(colName);
        partToSort = matrix.slice(1);
        partToSort.sort(sortFunction);

        let result = [];
        result.push(matrix[0].join(' | '));
        for (let i = 0; i < partToSort.length; i++) {
            result.push(partToSort[i].join(' | '));
        }

        console.log(result.join('\n'));

        function sortFunction(a, b) {
            if (a[sortColIndex] === b[sortColIndex]) {
                return 0;
            }
            else {
                return (a[sortColIndex] < b[sortColIndex]) ? -1 : 1;
            }
        }
        
       
    }

    function filter(colName, colValue){
        let result = [matrix[0].join(' | ')];
        let rowToPrint = '';
        let indexOfColValue = matrix[0].indexOf(colName);

        for (let row = 0; row < matrix.length; row++) {
            if(matrix[row][indexOfColValue] === colValue){
                rowToPrint = matrix[row].join(' | ');
                result.push(rowToPrint);
            } 
        }

        console.log(result.join('\n'));
    }
}

solve([['name', 'age', 'grade'],
['Peter', '25', '5.00'],
['George', '34', '6.00'],
['Marry', '28', '5.49']],
 'hide name');

console.log('--------------');

solve([['name', 'age', 'grade'],
       ['Peter', '25', '5.00'],
       ['George', '34', '6.00'],
       ['Marry', '28', '5.49']],
        'sort grade');

console.log('--------------');  

solve([['firstName', 'age', 'grade', 'course'],
       ['Peter', '25', '5.00', 'JS-Core'],
       ['George', '34', '6.00', 'Tech'],
       ['Marry', '28', '5.49', 'Ruby']],
        'filter firstName George');