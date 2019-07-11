function solve() {
    
    let button = document.querySelector('#exercise button');
    let inputs = document.querySelectorAll('#exercise input');
    let cardSuitInput = document.querySelector('#exercise select');
    let outputElement = document.querySelector('#exercise section');

    button.addEventListener('click', generateHand);

    function generateHand(){
        
        let fromCard = Number(getInputCardValue(inputs[0].value));
        let toCard = Number(getInputCardValue(inputs[1].value));
        
        
        for(let i = fromCard; i <= toCard; i++){
            let cardSuit = getCardSuit(cardSuitInput.value[0]);
            let card = createCard(i, cardSuit);
            outputElement.appendChild(card);
        }
    }

    function getInputCardValue(cardValue){
        switch(cardValue){
            case 'J': return 11;
            case 'Q': return 12;
            case 'K': return 13;
            case 'A': return 14;
            default: return Number(cardValue);
        }
    }

    function getCardSuit(inputSuit){
        switch(inputSuit){
            case 'H': return 'hearts';
            case 'S': return 'spades';
            case 'D': return 'diamond';
            case 'C': return 'clubs';
        }
    }

    function createCard(cardValue, cardSuit){
           
        let divElement = document.createElement('div');
        divElement.className = 'card';
        let p1CardElement = document.createElement('p');
        let p2CardElement = document.createElement('p');
        let p3CardElement = document.createElement('p');
            
        p1CardElement.innerHTML = `&${cardSuit};`;

        if(cardValue < 11){
            p2CardElement.textContent = `${cardValue}`;
        } else{
            switch(cardValue){
                case 11 : p2CardElement.textContent = 'J'; break;
                case 12 : p2CardElement.textContent = 'Q'; break;
                case 13 : p2CardElement.textContent = 'K'; break;
                case 14 : p2CardElement.textContent = 'A'; break;
            }
        }

        p3CardElement.innerHTML = `&${cardSuit};`;

        divElement.appendChild(p1CardElement);
        divElement.appendChild(p2CardElement);
        divElement.appendChild(p3CardElement);

        return divElement;
    }
}