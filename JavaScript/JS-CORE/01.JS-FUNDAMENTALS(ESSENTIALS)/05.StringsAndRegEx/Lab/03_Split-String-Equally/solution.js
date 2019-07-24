function solve() {
  let input = String(document.getElementById('str').value);
  let partsLength = Number(document.getElementById('num').value);
  let output = '';

  let currentLength = input.length;

  while(currentLength % partsLength !== 0){
    currentLength++
  }

  let newLength = currentLength;
  
  let diff = newLength - input.length;
  input += input.substring(0, diff);
  
  if(input.length % partsLength === 0){
    let currentResult = [];

    for(let i = 0; i < input.length; i+=partsLength){
      let part = input.substring(i, i + partsLength);
      currentResult.push(part);
    }

    output = currentResult.join(' ');
  }

  let result = document.getElementById('result');
  result.innerHTML = output;
}