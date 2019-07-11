function solve() {

  let numberToMultiplied = Number(document.getElementById('num1').value);
  let multiplier = Number(document.getElementById('num2').value);

  let result = document.getElementById('result');

  result.innerHTML = '';

  checkForWrongInput(numberToMultiplied, multiplier);
  prinTable(numberToMultiplied, multiplier);

  function checkForWrongInput(numberToMultiplied, multiplier){
    if(numberToMultiplied > multiplier){
      result.innerHTML = 'Try with other numbers.';
    }
  }

  function prinTable(numberToMultiplied, multiplier){
    for(let i = numberToMultiplied; i <= multiplier; i++){
      let paragraph = document.createElement('p');
    paragraph.innerHTML = `${i} * ${multiplier} = ${i*multiplier}`;
    result.appendChild(paragraph);
    }
    
  }
}