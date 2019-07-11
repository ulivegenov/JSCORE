function bmi(name, age, weightKg, heightCm){

    function bmiCalc(weightKg, heightCm){
        let heightM = heightCm/100;

        return Math.round(weightKg/(heightM**2));
    }

    function getStatus(bmi){
        if(bmi < 18.5){
            return 'underweight';
        } else if(bmi < 25){
            return 'normal';
        } else if(bmi < 30){
            return 'overweight';
        } else{
            return 'obese';
        }
    }

    let patientCharts = {
        name : name,
        personalInfo : {
            age : age,
            weight : weightKg,
            height : heightCm
        },
        BMI : bmiCalc(weightKg, heightCm),
        status : ''
    };

    patientCharts.status = getStatus(patientCharts.BMI);

    if(patientCharts.status === 'obese'){
        patientCharts['recommendation'] = 'admission required';
    }

    return patientCharts; 
}

bmi('Honey Boo Boo', 29, 75, 182);