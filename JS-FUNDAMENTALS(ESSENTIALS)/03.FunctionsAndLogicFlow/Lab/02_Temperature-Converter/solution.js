function solve() {
  
  let inputDegrees = Number(document.getElementById('num1').value);
  let degreeType = String(document.getElementById('type').value);
  let convertedTemperature = 0;
  let corectType = false;
  let result = '';

  convert(inputDegrees, degreeType);
  print();
  document.getElementById('result').innerHTML = result;

  function convert(inputDegrees, degreeType){

    if(degreeType.toLowerCase() === 'celsius'){
      convertedTemperature = ((inputDegrees * 9) / 5) + 32;
      corectType = true;
    } else if(degreeType.toLowerCase() === 'fahrenheit'){
      convertedTemperature = (((inputDegrees - 32) * 5) / 9);
      corectType = true;
    }
  }

  function print(){
    if(corectType){
      result = Math.round(convertedTemperature);
    }
    else{
      result = 'Error!';
    }
  }
}