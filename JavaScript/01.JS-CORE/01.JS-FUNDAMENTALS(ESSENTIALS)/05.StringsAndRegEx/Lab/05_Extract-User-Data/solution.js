function solve() {
  let input = JSON.parse(document.getElementById('arr').value);
  let result = document.getElementById('result');

  let pattern = /^([A-Z]{1}[a-z]* [A-Z]{1}[a-z]*) ((\+359 \d \d{3} \d{3})|(\+359-\d-\d{3}-\d{3})) ([a-z\d]+@[a-z]+\.[a-z]{2,3})/g;

  input.forEach(element => {
    let match = pattern.exec(element);

    if(match){
      let firstP = document.createElement('p');
      firstP.innerHTML = `Name: ${match[1]}`;
      result.appendChild(firstP);

      let secondP = document.createElement('p');
      secondP.innerHTML = `Phone Number: ${match[2]}`;
      result.appendChild(secondP);

      let thirdP = document.createElement('p');
      thirdP.innerHTML = `Email: ${match[5]}`;
      result.appendChild(thirdP);

      let fourthP = document.createElement('p');
      fourthP.innerHTML = '- - -';
      result.appendChild(fourthP);
    } else{
      let firstP = document.createElement('p');
      firstP.innerHTML = 'Invalid data';
      result.appendChild(firstP);

      let secondP = document.createElement('p');
      secondP.innerHTML = '- - -';
      result.appendChild(secondP);
    }
  });
}