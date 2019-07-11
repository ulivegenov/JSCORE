function solve(input){
    input.sort((a,b) =>{
        if(a.length === b.length){
            a = a.toUpperCase();
            b = b.toUpperCase();
            return a > b; 
        } else{
            return a.length - b.length;
        }
    });

    for(let element of input){
        console.log(element);
    }
}

solve(['alpha', 
'beta', 
'gamma']);

