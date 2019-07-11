function solve() {

    let convertTo = document.querySelector('#container #selectMenuTo');
    let option = document.createElement('option');
    option.text = 'Hexadecimal';
    option.value = 'hexadecimal';
    convertTo.appendChild(option);
    let options = document.querySelectorAll('#container #selectMenuTo option');
    options[0].setAttribute('value', 2);
    options[0].textContent = 'Binary';

    let button = document.querySelector('#container button');

    button.addEventListener('click', convertIt);

    function convertIt(e){

        //let menu = e.target.parentNode;
        let optionValue = document.getElementById('selectMenuTo').value;
        
        let inputNum = Number(document.querySelector('#container #input').value);
        let outputNum = '';
        let output = document.getElementById('result');

        if(Number(optionValue) === 2){
            outputNum = inputNum.toString(2);
        } else{
            outputNum = inputNum.toString(16).toUpperCase();
        }

        output.value = outputNum;
    }
}