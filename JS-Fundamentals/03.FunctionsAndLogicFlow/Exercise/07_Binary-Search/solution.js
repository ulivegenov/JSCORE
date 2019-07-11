function binarySearch() {
    
    let inputFields = document.querySelectorAll('#exercise form div input[type="text"]');
    let stringArray = inputFields[0].value;
    let numToSearch = inputFields[1].value;

    let result = checkForNum(stringArray, numToSearch);

    let output = document.querySelector('#exercise div span');
    output.innerHTML = result;

    function checkForNum(string, num){
        let numbers = String(string).split(', ');
        let index = -1;

        for(let i = 0; i < numbers.length; i++){
            if(Number(numbers[i]) === Number(num)){
                index = i;
            }
        }

        if(index === -1){
            return `${num} is not in the array`;
        } else{
            return `Found ${num} at index ${index}`;
        }
    }
}