function solve() {
    let vipZonePrices = {
        'A' : 25,
        'B' : 15,
        'C' : 10
    }

    let teamZonePrices = {
        'A' : 10,
        'B' : 7,
        'C' : 5
    }

    let sectorNamesByNum = {
        '0' : 'A',
        '1' : 'B',
        '2' : 'C'
    }

    let totalPrice = 0;
    let totalFans = 0;

    let seats = document.getElementsByTagName('td');

    for (let i = 0; i < seats.length; i++) {
        seats[i].addEventListener('click', takeTicket);
    }

    let summaryButton = document.querySelector('#summary button');
    summaryButton.addEventListener('click', summary);

    function takeTicket(e){
        let currentTarget = e.currentTarget.children[0];
        let outPutArea = document.getElementById('output');

        if(currentTarget.hasAttribute('style')){
            let currentZone = currentTarget.parentNode.parentNode.parentNode.parentNode.parentNode.getAttribute('class');
            let sectors = currentTarget.parentElement.parentElement.children;
            let currentSectorNum;

            for (let i = 0; i < sectors.length; i++) {
                if(sectors[i].children[0].hasAttribute('style')){
                    currentSectorNum = i;
                }   
            }
        
            let currentSectorName = sectorNamesByNum[currentSectorNum.toString()];
                outPutArea.value += ` Seat ${currentTarget.textContent} in zone ${currentZone} sector ${currentSectorName} is unavailable.\n`;

        } else{
            currentTarget.style.backgroundColor = 'rgb(255,0,0)';
        
            let currentZone = currentTarget.parentNode.parentNode.parentNode.parentNode.parentNode.getAttribute('class');
            let sectors = currentTarget.parentElement.parentElement.children;
            let currentSectorNum;

            for (let i = 0; i < sectors.length; i++) {
                if(sectors[i].children[0].hasAttribute('style')){
                    currentSectorNum = i;
                }   
            }
        
            let currentSectorName = sectorNamesByNum[currentSectorNum.toString()];
            let currentPrice = 0;

            if(currentZone === 'VIP'){
                currentPrice = vipZonePrices[currentSectorName];
            } else{
                currentPrice = teamZonePrices[currentSectorName];
            }

            totalPrice += currentPrice;
            totalFans++;

            outPutArea.value += ` Seat ${currentTarget.textContent} in zone ${currentZone} sector ${currentSectorName} was taken.\n`;
        }
    }

    function summary(e){
        let currentElement = e.currentTarget.parentNode.children[1];
        currentElement.textContent = `${totalPrice} leva, ${totalFans} fans.`
    }
}