function argumentInfo(){

    let summary = {};

    for (let i = 0; i < arguments.length; i++) {
        let currentArgument = arguments[i];
        let currentType = typeof(currentArgument);
        console.log(`${currentType}: ${currentArgument}`);

        if(!summary[currentType]){
            summary[currentType] = 1;
        } else{
            summary[currentType]++;
        }
    }

    let sortedTypes = [];

    for (const currentType in summary) {
        sortedTypes.push([currentType, summary[currentType]]);
    }

    sortedTypes = sortedTypes.sort((a, b) => b[1] - a[1]);
    
    for (let kvp of sortedTypes) {
        console.log(`${kvp[0]} = ${kvp[1]}`);
    }
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); }, 23, 'd');
