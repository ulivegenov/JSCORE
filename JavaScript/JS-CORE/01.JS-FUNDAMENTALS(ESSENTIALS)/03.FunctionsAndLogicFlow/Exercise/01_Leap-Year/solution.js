function leapYear() {

    let button = document.querySelector('#exercise button');
    button.addEventListener('click', checkYear);

    function checkYear(){
        let inputYear = document.querySelector('#exercise input').value;
        let checkResult = document.querySelector('#year h2');
        let resultYear = document.querySelector('#year div');
        resultYear.textContent = inputYear;

        if ((inputYear % 4 == 0 && inputYear % 100 != 0) || inputYear % 400 == 0) {
            checkResult.textContent = 'Leap Year';
        } else {
            checkResult.textContent = 'Not Leap Year';
        }
        
        document.querySelector('#exercise input').value = '';
    }
}