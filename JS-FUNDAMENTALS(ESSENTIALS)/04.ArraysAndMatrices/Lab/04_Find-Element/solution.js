function solve() {
  let searchedElement = Number(document.getElementById('num').value);
  let inputString = document.getElementById('arr').value;
  let inputArray = JSON.parse(inputString);
  let output = document.getElementById('result');

  let tempArray = [];

  for(let i = 0; i < inputArray.length; i++){
    tempArray.push(`${inputArray[i].includes(searchedElement)} -> ${inputArray[i].indexOf(searchedElement)}`);
  }

  
  output.innerHTML = tempArray;
}