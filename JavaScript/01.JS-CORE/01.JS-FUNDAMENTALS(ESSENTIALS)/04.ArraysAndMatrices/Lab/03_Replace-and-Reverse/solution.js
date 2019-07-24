function solve() {
  let inputString = document.getElementById('arr').value;
  let inputArray = JSON.parse(inputString);
  let output = document.getElementById('result');

  for(let i = 0; i < inputArray.length; i++){
    inputArray[i] = reversingString(inputArray[i]);

    output.innerHTML += `${inputArray[i]} `;
  }

  output.innerHTML = output.innerHTML.trim();
  
  function reversingString(arr){
    let splitString = arr.split('');
    let reverseArray = splitString.reverse();
    reverseArray[0] = reverseArray[0].toUpperCase();
    let joinArray = reverseArray.join('');

    return joinArray;
  }
}