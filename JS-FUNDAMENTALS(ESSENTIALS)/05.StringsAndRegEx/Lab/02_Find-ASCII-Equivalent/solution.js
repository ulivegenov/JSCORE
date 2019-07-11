function solve() {
  let input = document.getElementById('str').value;
  let result = document.getElementById('result');

  findAsciiEquivalent(input);

  function findAsciiEquivalent(input){
    let splitInput = input.split(' ').filter(a => a !== '');

    let output = '';

    for(i = 0; i < splitInput.length; i++){
      if(Number(splitInput[i])){
        output += (String.fromCharCode(splitInput[i]));
      } else{
        let charToNum = [];

        for(let j = 0; j < splitInput[i].length; j++){
          charToNum.push(splitInput[i][j].charCodeAt(0));
        }

        let p = document.createElement('p');
        p.innerHTML = charToNum.join(' ');
        result.appendChild(p);
      }
    }

    let p = document.createElement('p');
    p.innerHTML = output;
    result.appendChild(p);
  }
}