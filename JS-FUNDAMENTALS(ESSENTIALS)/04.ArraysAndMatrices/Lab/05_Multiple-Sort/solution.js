function solve() {
  let inputString = document.getElementById('arr').value;
  let inputArray = JSON.parse(inputString);
  let inputArrayNums = inputArray.map(Number);
  let output = document.getElementById('result');
  let divOne = document.createElement('div');
  let divTwo = document.createElement('div');

  divOne.innerHTML = inputArrayNums.sort((a, b) => a - b).join(', ');
  divTwo.innerHTML = inputArray.sort().join(', ');

  output.appendChild(divOne);
  output.appendChild(divTwo);
}