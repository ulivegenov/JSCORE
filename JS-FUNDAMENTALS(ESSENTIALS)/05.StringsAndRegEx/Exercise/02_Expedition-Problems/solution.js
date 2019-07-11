function solve() {
  let keyword = document.getElementById('str').value;
  let brokenMessage = document.getElementById('text').value;
  let resultElement = document.getElementById('result');

  let cordinatePattern = /(north|east)[\s\S]*?(\d{2})[^,]*?,[^,]*?(\d{6})/gi;
  let messagePattern = new RegExp(`(?:${keyword})(.+?)(?:${keyword})`, 'g');

  let message = `Message: ${messagePattern.exec(brokenMessage)[1]}`;

  let match;

  let east = '';
  let north ='';

  while((match = cordinatePattern.exec(brokenMessage)) !== null){
    if(match[1].toUpperCase() === 'NORTH'){
      north = `${match[2]}.${match[3]} N`;
    } else if(match[1].toUpperCase() === 'EAST'){
      east = `${match[2]}.${match[3]} E`;
    }
  }

  let result = [];
  result.push(north);
  result.push(east);
  result.push(message);

  result.forEach(e => {
    let p = document.createElement('p');
    p.innerHTML = e;
    resultElement.appendChild(p);
  })  
}