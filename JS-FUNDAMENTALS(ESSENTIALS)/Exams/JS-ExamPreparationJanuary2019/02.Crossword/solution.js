function solve() {

   let filterButton = document.querySelector('#filter button');
   let sortButton = document.querySelector('#sort button');
   let rotateButton = document.querySelector('#rotate button');
   let getButton = document.querySelector('#get button');

   filterButton.addEventListener('click', filter);
   sortButton.addEventListener('click', sort);
   rotateButton.addEventListener('click', rotate);
   getButton.addEventListener('click', get);

   let outputText = '';

   function filter(){
      let input = getInput();
      let secondCommand = getSeconComand('filterSecondaryCmd');
      let resultString = '';

      switch(secondCommand){
         case 'uppercase':
            for (let char of input) {
               if(char === char.toUpperCase() && isNaN(char)){
                  resultString += char;
               }
            }
            break;
         case 'lowercase':
               for (let char of input) {
                  if(char === char.toLowerCase() && isNaN(char)){
                     resultString += char;
                  }
               }
            break;
         case 'nums':
               for (let char of input) {
                  if(!isNaN(char)){
                     resultString += char;
                  }
               }
            break;
      }

      let position = getPosition('filterPosition');
      outputText += resultString[position - 1];
      writeOutput();
   }

   function sort(){
      let input = getInput();
      let secondCommand = getSeconComand('sortSecondaryCmd');
      let temp = input.split('');

      switch(secondCommand){
         case 'A' :
            temp.sort()
            input = temp.join(''); 
            break;
         case 'Z' :
            temp.sort();
            temp.reverse();
            input = temp.join('');
            break; 
      }
      
      let position = getPosition('sortPosition');

      outputText += input[position-1];
      writeOutput();
   }

   function rotate(){
      let input = getInput();
      let secondaryCommand = Number(getPosition('rotateSecondaryCmd'));

      for (let i = 0; i < secondaryCommand; i++) {
         let temp = input.split('');
         let lastElement = temp.pop();
         temp.unshift(lastElement);
         input = temp.join('');
      }

      let position = getPosition('rotatePosition');

      outputText += input[position-1];
      writeOutput();
   }

   function get(){
      let input = getInput();
      let position = getPosition('getPosition');

      outputText += input[position-1];
      writeOutput();
   }

   function writeOutput(){
      let outputElement = document.getElementById('output').children[0];
      outputElement.textContent = outputText;
   }
   
   function getPosition(id){
      let position = document.getElementById(id).value;

      return position;
   }

   function getSeconComand(id){
      let e = document.getElementById(id);
      let secondCommand = e.options[e.selectedIndex].value;
      return secondCommand;
   }

   function getInput(){
      let input = document.getElementById('input').value;
      document.getElementById('input').value = '';
      
      return input;
   }
}