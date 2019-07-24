function solve() {
    
    let playerOneCards = document.querySelectorAll('#player1Div img');
    let playerTwoCards = document.querySelectorAll('#player2Div img');

    for (let i = 0; i < playerOneCards.length; i++){
        playerOneCards[i].addEventListener('click', clickEvent);
        playerTwoCards[i].addEventListener('click', clickEvent);
    }

    function clickEvent(element){
        let currentCard = element.target;
        currentCard.src = './images/whiteCard.jpg';
        currentCard.removeEventListener('click', clickEvent);

        let parent = currentCard.parentNode;

        let spans = document.querySelectorAll('#result span');
        let playerOneCardValue = spans[0];
        let playerTwoCardValue = spans[2];
        if(parent.id === 'player1Div'){
            playerOneCardValue.textContent = currentCard.name;
        } else{
            playerTwoCardValue.textContent = currentCard.name;
        }

        if (playerOneCardValue.textContent && playerTwoCardValue.textContent){

            let winner;
            let looser;

            if (Number(playerOneCardValue.textContent) > Number(playerTwoCardValue.textContent)){
                winner = document.querySelector(`#player1Div img[name = '${playerOneCardValue.textContent}']`);
                looser = document.querySelector(`#player2Div img[name = '${playerTwoCardValue.textContent}']`);
            } else{
                winner = document.querySelector(`#player2Div img[name = '${playerTwoCardValue.textContent}']`);
                looser = document.querySelector(`#player1Div img[name = '${playerOneCardValue.textContent}']`); 
            }

            winner.style.border = '2px solid green';
            looser.style.border = '2px solid darkred';

            document.querySelector('#history').textContent += `[${playerOneCardValue.textContent} vs ${playerTwoCardValue.textContent}] `;

                playerOneCardValue.textContent = '';
                playerTwoCardValue.textContent = '';
        }
    }
}