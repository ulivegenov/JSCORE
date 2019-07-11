function getNext() {
    
    let inputField = document.querySelector('#exercise form input[type="text"]');
    let inputNum = Number(inputField.value);

    let sequence = getSequence(inputNum);

    let output = document.querySelector('#exercise div span');
    output.innerHTML = sequence;

    function getSequence(num){

        let result = `${String(num)} `;

        while(num != 1){
            if(num % 2 === 0){
                result += `${String(num/2)} `;
                num /=2;
            } else{
                result += `${String(3*num + 1)} `;
                num = 3*num + 1;
            }
        }

        return result;
    }
}