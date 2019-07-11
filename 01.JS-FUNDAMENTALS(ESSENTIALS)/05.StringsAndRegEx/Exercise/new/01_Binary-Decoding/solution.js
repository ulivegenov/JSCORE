function solve() {
  let input = document.getElementById('input').value;
  let resultElement = document.getElementById('resultOutput');
  let oneDigitSum = getOneDigitSum(input);

  console.log(oneDigitSum);
  let arrayOfStrings = getArrayOfStrings(input, oneDigitSum);
  let arrayOfDecimals = getArrayOfDecimals(arrayOfStrings);
  let resultString = getResultString(arrayOfDecimals);
  resultElement.textContent = `${resultString}`;
  let boxes = document.getElementsByClassName('boxes')[0];
  boxes.style.display = 'flex';

  function getOneDigitSum(inputString){

    let finalSum = inputString;

    while(finalSum.length > 1){
      let tempSum = finalSum
                            .split('')
                            .reduce((a,b) => Number(a) + Number(b))
                            .toString();
      
      finalSum = tempSum;
    }

    return finalSum;
  }

  function getArrayOfStrings(inputString, oneDigitSum){

    let stringToSeparate = inputString.slice((oneDigitSum), (inputString.length - oneDigitSum));
    let arrayOfStrings = stringToSeparate.split(/(\d{8})/).filter(x => x);

    return arrayOfStrings;
  }

  function getArrayOfDecimals(stringArray){
    let arrayOfDecimals = [];

    for(let i = 0; i < stringArray.length; i++){
      let currentDecimalElement = parseInt(stringArray[i], 2);
      if(currentDecimalElement === 32 || (currentDecimalElement > 64 && currentDecimalElement < 91) 
                                      || (currentDecimalElement > 96 && currentDecimalElement < 122)){
        arrayOfDecimals.push(currentDecimalElement);
      }
      
    }

    return arrayOfDecimals;
  }

  function getResultString(arrayOfDecimals){
    let resultString = '';

    for(let i = 0; i < arrayOfDecimals.length; i++){
      resultString += String.fromCharCode(arrayOfDecimals[i]);
    }

    return resultString;
  }
}