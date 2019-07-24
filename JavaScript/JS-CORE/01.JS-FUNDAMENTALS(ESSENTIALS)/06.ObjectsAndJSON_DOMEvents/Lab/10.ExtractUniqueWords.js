function solve(input){
    let uniqueWords = new Set();

    for (let line of input) {
        let data = line.toLowerCase().split(/\W+/).filter(x => x !== '');
        
        for (let word of data) {
            uniqueWords.add(word)
        }
    }

    console.log(Array.from(uniqueWords.keys()).join(', '));
}