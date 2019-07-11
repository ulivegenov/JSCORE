function solve() {

    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', extract);

    function extract(){
        let inputAreaText = document.getElementById('input').value;
        let outputArea = document.getElementById('output');

        let countOfcharPattern = /^[0-9]+/; 
        let charsToTake = countOfcharPattern.exec(inputAreaText)[0];
        let stringToSplit = inputAreaText.substr(charsToTake.length, Number(charsToTake));
        let splitChar = stringToSplit.slice(-1);
        let stringParts = stringToSplit.split(`${splitChar}`);
        let firstPart = stringParts[0];
        let removePattern = `[${firstPart}]+`;
        let regex = new RegExp(removePattern, 'g');
        let secondPart = stringParts[1];
        secondPart = secondPart.replace(removePattern, '');
        let result = secondPart.split(regex)
                               .join('')
                               .replace(/#/g, ' ')
                               .toString();

        outputArea.value = result;
    }
    
}