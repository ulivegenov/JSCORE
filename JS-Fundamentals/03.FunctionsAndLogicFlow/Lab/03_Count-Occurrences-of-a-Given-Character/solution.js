function solve() {
  let string = document.getElementById('string').value;
  let char = document.getElementById('character').value;
  let countOfOccurrences = 0;
  let result = '';

  findOccurrencesCount(string, char);
  checkEvenOrOddCount(string, char);
  document.getElementById('result').innerHTML = result;

  function findOccurrencesCount(string, char){
    for(let i = 0; i < string.length; i++){
      if(string[i] === char){
        countOfOccurrences++;
      }
    }
  }

  function checkEvenOrOddCount(string, char){
    if(countOfOccurrences % 2 === 0){
      result = `Count of ${char} is even.`;
    } else{
      result = `Count of ${char} is odd.`;
    }
  }
}