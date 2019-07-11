function solve() {
   
   let inputField = document.querySelector('#exercise form input[type="text"]');
   let inputNum = Number(inputField.value);

   let factors = getFactors(inputNum);

   let output = document.querySelector('#exercise div span');
   output.innerHTML = factors;

   function getFactors(num){

      let result = '';

      for(let i = 0; i <= num; i++){
         if(num % i === 0){
            result += `${i} `;
         }
      }

      return result.trim();
   }
}