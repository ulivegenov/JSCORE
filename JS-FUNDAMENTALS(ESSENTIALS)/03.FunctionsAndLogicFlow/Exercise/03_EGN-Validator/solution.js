function validate() {
    
    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', getMyEGN);

    function getMyEGN(){
        let year = document.getElementById('year');
        let yearNum = yearValidate(year.value);
        let month = document.getElementById('month');
        let monthNum = getMonthNums(month.value);
        let date = document.getElementById('date');
        let dateNum = getDateNums(date.value);
        let genders = document.querySelectorAll('#exercise table tbody tr td input[name="gender"]');
        let gender = getSelectedGender(genders);
        let region = document.getElementById('region');
        let regionNum = regionNumConstruct(region.value);
        let genderNum = getGenderNum(gender);

        let numToCheck = yearNum + monthNum + dateNum + regionNum + genderNum;

        let egnNumber = numToCheck + numValidate(numToCheck);

        let egnResult = document.getElementById('egn');
        egnResult.innerHTML = `Your EGN is: ${egnNumber}`;

        year.value = '';
        month.selectedIndex = 0;
        date.value = '';
        genders.forEach((e) =>{
            e.checked = false;
        })
        region.value = '';
    }

    function numValidate(numToCheck){

        let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let productSum = 0;

        for(let i = 0; i < weights.length; i++){
            productSum += Number(numToCheck[i])*Number(weights[i]);
        }

        let reminder = productSum % 11; 

        if(Number(reminder) === 10){
            reminder = 0;
        }

        return reminder;
   
    }

    function regionNumConstruct(region){
        if(Number(region) >= 43 && Number(region) <= 999){
            if(Number(region) < 100){
                return `${region}`;
            } else{
                return `${String(region).substring(0,2)}`;
            }
        }
    }

    function getGenderNum(gender){
        if(String(gender) === 'Male'){
            return '2';
        } else{
            return '1';
        }
    }

    function getSelectedGender(genders){

        for(let i = 0; i < genders.length; i++){
            if(genders[i].checked){
                return genders[i].value;
            }
        }
    }

    function getDateNums(date){
        if(Number(date) < 10){
            return `0${date}`;
        } else{
            return `${date}`;
        }
    }

    function getMonthNums(monthName){

        let montNums = {'January': '01',
                        'February' : '02',
                        'March' : '03',
                        'April' : '04',
                        'May' : '05',
                        'June' : '06',
                        'July' : '07',
                        'August' : '08',
                        'September' : '09',
                        'October' : '10',
                        'November' : '11',
                        'December' : '12'
        };
        
        return montNums[String(monthName)];
    }
    
    function yearValidate(year){
        if(Number(year) >= 1900 && Number(year) <= 2100){
            return `${String(year).substring(2)}`;
        }
    }
}