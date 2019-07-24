function solve() {
  let inputString = document.getElementById('arr').value;
  let inputArray = JSON.parse(inputString);

  let output = document.getElementById('result');
  let resultString = '';
  
  for(let i = 0; i < inputArray.length; i++){
    if(i % 2 === 0){
      resultString += `${inputArray[i]} x `;
    }
  }

  resultString = resultString.substring(0, resultString.length - 3);

  output.innerHTML = resultString;
}