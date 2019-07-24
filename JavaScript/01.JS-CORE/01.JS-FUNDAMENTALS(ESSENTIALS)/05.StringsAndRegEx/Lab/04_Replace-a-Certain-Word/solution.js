function solve() {
  let inputArray = JSON.parse(document.getElementById('arr').value);
  let repalcingWord = String(document.getElementById('str').value);
  let result = document.getElementById('result');

  let firstStrinSplit = inputArray[0].split(' ').map(String);
  let wordToReplace = firstStrinSplit[2];
  let regex = new RegExp(wordToReplace, 'gi');

  console.log(wordToReplace);
  let output = [];

  for(let i = 0; i < inputArray.length; i++){
    inputArray[i] = inputArray[i].replace(regex, repalcingWord);
    let p = document.createElement('p');
    p.innerHTML = inputArray[i];
    result.appendChild(p);
  }
}