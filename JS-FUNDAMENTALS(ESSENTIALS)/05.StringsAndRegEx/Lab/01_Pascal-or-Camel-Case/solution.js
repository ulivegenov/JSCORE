function solve() {
  let firstString = String(document.getElementById('str1').value);
  let secondString = String(document.getElementById('str2').value);

  let result = 'Error!';

  words = firstString.toLowerCase().split(' ');

  if(secondString === 'Camel Case'){
    result = words[0];

    for(let i = 1; i < words.length; i++){
      let word = words[i].replace(words[i][0] ,words[i][0].toUpperCase());
      result += word;
    }
  } else if ( secondString === 'Pascal Case'){
    result = '';

    for(let i = 0; i < words.length; i++){
      let word = words[i].replace(words[i][0] ,words[i][0].toUpperCase());
      result += word;
    }
  }

  let resultElement = document.getElementById('result');
  resultElement.innerHTML = result;
}