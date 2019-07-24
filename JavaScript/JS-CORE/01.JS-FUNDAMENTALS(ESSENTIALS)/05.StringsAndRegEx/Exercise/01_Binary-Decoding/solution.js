function solve() {
  let input = document.getElementById('str').value;
  let resultElement = document.getElementById('result');

  let oneDigitSum = getOneDigitSum(input);
  let arrayOfStrings = getArrayOfStrings(input, oneDigitSum);
  let arrayOfDecimals = getArrayOfDecimals(arrayOfStrings);
  let resultString = getResultString(arrayOfDecimals);

  resultElement.textContent = `${resultString}`;

  function getOneDigitSum(inputString){

    let finalSum = inputString;

    while(finalSum.length > 1){
      let tempSum = finalSum
                            .split('')
                            .reduce((a,b) => +a + +b)
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
