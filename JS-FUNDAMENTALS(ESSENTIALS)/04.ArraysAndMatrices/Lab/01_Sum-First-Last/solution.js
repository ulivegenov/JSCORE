function solve() {

  let inputString = document.getElementById('arr').value;
  let inputArray = JSON.parse(inputString).map(Number);

  let outputField = document.getElementById('result');

  for(let i = 0; i < inputArray.length; i++){
      let numOne = String(i);
      let numTwo = String(inputArray[i] * inputArray.length);
      let resultString = `${numOne}` + ' ' + '->' + ' ' + `${numTwo}`;
      let currentParagraph = document.createElement('p');
      currentParagraph.innerHTML = resultString;
      outputField.appendChild(currentParagraph);
  }
}