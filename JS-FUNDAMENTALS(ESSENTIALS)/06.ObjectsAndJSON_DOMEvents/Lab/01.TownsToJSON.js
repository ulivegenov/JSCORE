function solve(input){
    let dataRows = JSON.parse(JSON.stringify(input));
    
    
    let result = [];

    for(let i = 1; i < dataRows.length; i++){
        let tokens = dataRows[i].split('| ');
       
        let resultRow = {
            'Town' : tokens[1].trim(),
            'Latitude' : Number(tokens[2].trim()),
            'Longitude' : Number(tokens[3].split(' |')[0])};

        result.push(resultRow);
    }

    result = JSON.stringify(result);
    console.log(result);
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);