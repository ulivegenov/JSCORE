function solve() {
  let input = JSON.parse(document.getElementById('arr').value);
  let result = document.getElementById('result');

  let specialSymbols = {'!':'1',
                        '%':'2',
                        '#':'3',
                        '$':'4'};
  let keyword = input[0];
  let encodedMessage = [];

  for(let i = 1; i < input.length; i++){
    encodedMessage.push(input[i]);
  }

  let regexPattern = new RegExp(`(\\s|^)(?:${keyword}\\s+)([A-Z!#$%]{8,})(\\.|,|\\s|$)`, 'gi');
  let resultMessage = [];

  for(let i = 0; i < encodedMessage.length; i++){
    let matches;
    let currentLine = encodedMessage[i];

    while(matches = regexPattern.exec(encodedMessage[i])){
      
      if(matches[2].toUpperCase() === matches[2]){
        let decodedMessage = '';

        for(let j = 0; j < matches[2].length; j++){
          if(matches[2][j] === '!'){
            decodedMessage += specialSymbols['!'];
            } else if(matches[2][j] === '%'){
              decodedMessage += specialSymbols['%'];
            } else if(matches[2][j] === '#'){
              decodedMessage += specialSymbols['#'];
            } else if(matches[2][j] === '$'){
              decodedMessage += specialSymbols['$'];
            } else{
              decodedMessage += matches[2][j].toLowerCase();
            }
        }
 
        currentLine = currentLine.replace(matches[2], decodedMessage);
      }
    } 
    resultMessage.push(currentLine);
  }

  for(let i = 0; i < resultMessage.length; i++){
    let p = document.createElement('p');
    p.innerHTML = resultMessage[i];
    result.appendChild(p);
  }
}