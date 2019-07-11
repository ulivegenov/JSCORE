function solve(input){
    let data = JSON.parse(input);

    let propertyNames = Object.getOwnPropertyNames(data[0]);
    let secondElement = '  <tr>';
    for(let i = 0; i < propertyNames.length; i++){
        secondElement += `<th>${propertyNames[i]}</th>`;
    }
    secondElement += '</tr>';

    let result = ['<table>',`${secondElement}`];

    for(let i = 0; i < data.length; i++){
        let currentRow = '  <tr>';

        for(let j = 0; j < propertyNames.length; j++){
            currentRow += `<td>${escapeHTML(data[i][`${propertyNames[j]}`])}</td>`;
        }
        
        currentRow += '</tr>';
        result.push(currentRow);
    }

    result.push('</table>');
    result = result.join('\n');
    console.log(result);

    function escapeHTML(unsafe) {
        let pattern = /[&<"'>]/g;

        if(pattern.exec(unsafe)){
            return unsafe.replace(pattern, function(m) {
                switch (m) {
                  case '&':
                    return '&amp;';
                  case '<':
                    return '&lt;';
                  case '"':
                    return '&quot;';
                  case '>': 
                    return '&gt;';
                  default:
                    return '&#39;';
                }
            });
        } else{
            return unsafe;
        }  
    };
}

solve('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]');