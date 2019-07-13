function solve(input){
    let listProcessor = (function(){
        let list = []; 

        return{
            add : (element) => { list.push(element) },
            remove : (element) => { list = list.filter(e => e !== element) },
            print : () => { console.log(list.join(',')) }
        }
    })();


    for (const currrentCommand of input) {
        let data = currrentCommand.split(' ');
        if(data.length === 2){
            let command = data[0];
            let element = data[1];

            if(command === 'add'){
                listProcessor.add(element);
            } else{
                listProcessor.remove(element);
            }
        } else{
            listProcessor.print();
        }   
    }
}

solve(['add pesho', 'add gosho', 'add pesho', 'remove pesho','print']);