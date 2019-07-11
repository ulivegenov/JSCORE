function solve() {
    let input = document.getElementById('string').value;
    let resultElement = document.getElementById('result');

    let info = {'name' : '',
                'fromAirport' : '',
                'toAirport' : '',
                'flightNumber' : '',
                'company' : ''};

    let text = input.split(',');
    let textInfo = text[0];
    let outputCommand = text[1].trim();

    namePattern = new RegExp('(\\s([A-Z][A-Za-z]*)?(-[A-Z][A-Za-z]*\.)?-([A-Z][A-Za-z]*)?\\s)', 'g');
    airportPattern = new RegExp('\\s([A-Z]{3}\/[A-Z]{3})\\s', 'g');
    flightNumberPattern = new RegExp('\\s([A-Z]{1,3}[\\d]{1,5})\\s', 'g');
    companyPattern = new RegExp('-\\s([A-Z][a-z]*\\*[A-Z][a-z]*)\\s', 'g');

    let regex = namePattern.exec(textInfo);
    if(regex !== null){
        info['name'] = regex[1].replace(/-/g,' ').trim();
    }
    
    regex = airportPattern.exec(textInfo);
    if(regex !== null){
        let airports = regex[1].split('/');
        info['fromAirport'] = airports[0];
        info['toAirport'] = airports[1];
    }

    regex = flightNumberPattern.exec(textInfo);
    if(regex !== null){
        info['flightNumber'] = regex[1];
    }

    regex = companyPattern.exec(textInfo);
    if(regex !== null){
        info['company'] = regex[1].replace('*',' ');
    }
    
    resultElement.innerHTML = print(info, outputCommand);

    function print(info, outputCommand){
        let result = '';
        if(outputCommand === 'name'){
            result = `Mr/Ms, ${info['name']}, have a nice flight!`;
        } else if(outputCommand === 'flight'){
            result = `Your flight number ${info['flightNumber']} is from ${info['fromAirport']} to ${info['toAirport']}.`;
        } else if(outputCommand === 'company'){
            result = `Have a nice flight with ${info['company']}.`;
        } else if(outputCommand === 'all'){
            result = `Mr/Ms, ${info['name']}, your flight number ${info['flightNumber']} is from ${info['fromAirport']} to ${info['toAirport']}. Have a nice flight with ${info['company']}.`;
        }
        return result;
    }
}