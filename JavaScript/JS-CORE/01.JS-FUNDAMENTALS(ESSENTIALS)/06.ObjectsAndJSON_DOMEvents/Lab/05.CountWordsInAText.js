function solve([input]){
    let spliter = /\W+/;
    let data = input.split(spliter).filter(x => x != "");
    
    let words = {};

    for(let i = 0; i < data.length; i++){
        if(!words.hasOwnProperty(data[i])){
            words[`${data[i]}`] = 0;
        }
        words[`${data[i]}`] ++;
    }

    console.log(JSON.stringify(words));
}
