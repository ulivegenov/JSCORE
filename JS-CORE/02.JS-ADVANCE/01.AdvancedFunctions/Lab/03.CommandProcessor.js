function commandProcessor(input){
    let myString ='';

    for(let i = 0; i < input.length; i++){
        let data  = input[i].split(' ');
        let command = data[0];

        switch(command){
            case 'append': myString += data[1];
            break;
            case 'removeStart': myString = myString.slice(Number(data[1]));
            break;
            case 'removeEnd': myString = myString.substring(0, myString.length - Number(data[1]));
            break;
            case 'print': console.log(myString);
            break;
        }
    }
}
