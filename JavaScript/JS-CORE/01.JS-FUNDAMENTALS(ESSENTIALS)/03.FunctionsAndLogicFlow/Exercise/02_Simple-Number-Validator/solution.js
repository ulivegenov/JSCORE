function validate() {

    let button = document.querySelector("#exercise fieldset div button");
    button.addEventListener('click', checkIt);
    
    function checkIt(){
        
        let input = document.querySelector("#exercise fieldset div input");
        let output = document.querySelector("#response");

        output.innerHTML = numValidator(input.value);
    }

    function numValidator(inputNum){

        let outputMessage = '';
        let reminderValidation = false;
        let lengthValidation = false;

        if(Number(inputNum.length) === 10){
            lengthValidation = true;
        }

        if(lengthValidation){

            let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
            let productSum = 0;

            for(let i = 0; i < weights.length; i++){
                productSum += Number(inputNum[i])*Number(weights[i]);
            }

            let reminder = productSum % 11; 

            if(reminder === 10){
                reminder = 0;
            }

            let lastDigit = Number(inputNum[inputNum.length-1]);

            if(reminder === lastDigit){
                reminderValidation = true;
            }

            if(reminderValidation){
                outputMessage = 'This number is Valid!';
            } else{
                outputMessage = 'This number is NOT Valid!';
            }

        } else{
            outputMessage = 'This number is NOT Valid!';
        }
        
        return outputMessage;
    }
}