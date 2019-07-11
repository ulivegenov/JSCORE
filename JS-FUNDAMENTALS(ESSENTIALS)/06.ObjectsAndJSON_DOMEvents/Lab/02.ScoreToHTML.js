function solve(input){
    let data = JSON.parse(input);

    let result = ['<table>','  <tr><th>name</th><th>score</th></tr>'];

    for(let i = 0; i < data.length; i++){
        let currentRow = `  <tr><td>${escapeHTML(data[i]['name'])}</td><td>${escapeHTML(data[i]['score'])}</td></tr>`;
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