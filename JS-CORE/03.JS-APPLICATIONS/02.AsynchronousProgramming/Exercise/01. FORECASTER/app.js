function attachEvents() {
    let symbols = {
        'Sunny' : '&#x2600',
        'Partly sunny': '&#x26C5', 
        'Overcast' : '&#x2601',
        'Rain' : '&#x2614', 
        'Degrees':'&#176'
    }
    let locationsUrl = 'https://judgetests.firebaseio.com/locations.json';
    let forecastElement = document.getElementById('forecast');
    let currentConditionSection = document.getElementById('current');
    let upcomingConditionSection = document.getElementById('upcoming');
    let btnSubmit = document.getElementById('submit');

    btnSubmit.addEventListener('click', submit);

    function submit(){
        let location = document.getElementById('location').value;
        document.getElementById('location').value = '';

        fetch(locationsUrl)
        .then(respone => respone.json())
        .then((data) => {
            let code = data.filter(l => l.name === location).map(l => l.code);
            const todayUrl = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;
            const upcomingUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;

            function errorHandler(){
                if(code.length === 0){
                    throw new Error('Error');
                }
    
                return respone;
            }

            fetch(todayUrl)
            .then(errorHandler)
            .then(respone => respone.json())
            .then((data) =>{

                if(currentConditionSection.children.length === 2){
                    currentConditionSection.removeChild(currentConditionSection.children[1]);
                }
                const [forecast, name] = Object.values(data);

                let divElement = document.createElement('div');
                divElement.setAttribute('class', 'forecasts');

                let spanSymbolElement = document.createElement('span');
                spanSymbolElement.setAttribute('class', 'condition symbol');
                spanSymbolElement.innerHTML = symbols[forecast.condition];

                let spanConditionElement = document.createElement('span');
                spanConditionElement.setAttribute('class', 'condition');

                let spanNameElement = document.createElement('span');
                spanNameElement.setAttribute('class', 'forecast-data');
                spanNameElement.innerHTML = name;
                spanConditionElement.appendChild(spanNameElement);

                let spanDegreesElement = document.createElement('span');
                spanDegreesElement.setAttribute('class', 'condition');
                spanDegreesElement.innerHTML = `${forecast.low}${symbols.Degrees}/${forecast.high}${symbols.Degrees}`;
                spanConditionElement.appendChild(spanDegreesElement);

                let spanTemperatureElement = document.createElement('span');
                spanTemperatureElement.setAttribute('class', 'condition');
                spanTemperatureElement.innerHTML = forecast.condition;
                spanConditionElement.appendChild(spanTemperatureElement);

                divElement.appendChild(spanSymbolElement);
                divElement.appendChild(spanConditionElement);

                currentConditionSection.appendChild(divElement);
            })
            .catch(error => {
                if(currentConditionSection.children.length === 2){
                    currentConditionSection.removeChild(currentConditionSection.children[1]);
                }
                
                if(upcomingConditionSection.children.length === 2){
                    upcomingConditionSection.removeChild(upcomingConditionSection.children[1]);
                }
    
                let divToday = document.createElement('div');
                divToday.setAttribute('class', 'condition');
                divToday.innerHTML = 'Error';
                currentConditionSection.appendChild(divToday);
    
                let divUpcoming = document.createElement('div');
                divUpcoming.setAttribute('class', 'upcoming');
                divUpcoming.innerHTML = 'Error';
                upcomingConditionSection.appendChild(divUpcoming);
            });

            fetch(upcomingUrl)
            .then(errorHandler)
            .then(respone => respone.json())
            .then((data) => {

                if(upcomingConditionSection.children.length === 2){
                    upcomingConditionSection.removeChild(upcomingConditionSection.children[1]);
                }

                const [forecasts, name] = Object.values(data);
                console.log(forecasts);
                let divElement = document.createElement('div');
                divElement.setAttribute('class', 'forecast-info');
                

                for (const forecast of forecasts) {
                    let spanElement = document.createElement('span');
                    spanElement.setAttribute('class', 'upcoming');

                    let spanSymbol = document.createElement('span');
                    spanSymbol.setAttribute('class', 'symbol');
                    spanSymbol.innerHTML = symbols[forecast.condition];
                    spanElement.appendChild(spanSymbol);
                    
                    let spanDegrees = document.createElement('span');
                    spanDegrees.setAttribute('class', 'forecast-data');
                    spanDegrees.innerHTML = `${forecast.low}${symbols.Degrees}/${forecast.high}${symbols.Degrees}`;
                    spanElement.appendChild(spanDegrees);

                    let spanCondition = document.createElement('span');
                    spanCondition.setAttribute('class', 'forecast-data');
                    spanCondition.innerHTML = forecast.condition;
                    spanElement.appendChild(spanCondition);

                    divElement.appendChild(spanElement);
                }

                
                upcomingConditionSection.appendChild(divElement);
            });
        })

        forecastElement.style.display = 'block';
    }
}

attachEvents();