function greatestCD() {
    
    let inputFields = document.querySelectorAll('#exercise form div input[type="text"]');
    let numOne = Number(inputFields[0].value);
    let numTwo = Number(inputFields[1].value);

    let result = greatestDivisor(numOne, numTwo);
    let output = document.querySelector('#exercise div span');
    output.innerHTML = result;

    function greatestDivisor(num1, num2){
        let smallerNum = Math.min(Number(num1), Number(num2));
        let bigerNum = Math.max(Number(num1), Number(num2));

        if(smallerNum === 0){
            return bigerNum;
        } else{
            for(let i = smallerNum; i > 0; i--){
                if((Number(num1) % i === 0) && (Number(num2) % i === 0) ){
                    return i;
                }
            }
        }
    }
}