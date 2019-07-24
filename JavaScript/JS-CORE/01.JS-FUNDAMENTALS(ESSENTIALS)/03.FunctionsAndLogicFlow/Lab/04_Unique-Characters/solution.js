function solve() {
  
  let string = document.getElementById('string').value;
  let uniqueCharacterString = '';

  findUniqueChrasString(string);
  document.getElementById('result').innerHTML = uniqueCharacterString;

  function isCharWhiteSpace(i){
    if(string[i] === ' '){
      uniqueCharacterString += string[i];
    }
  }

  function isCharUnique(i){
    if(uniqueCharacterString.indexOf(string[i]) === -1){
      uniqueCharacterString += string[i];
    }
  }

  function findUniqueChrasString(string){
    for(let i = 0; i < string.length; i++){
      isCharWhiteSpace(i);
      isCharUnique(i);
    }
  }
}