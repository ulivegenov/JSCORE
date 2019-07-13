function printDeckOfCards(cardsInput){

    try{
        
        let result = [];

        for (const currentInput of cardsInput){
            let tokens = currentInput.split('');
            let suit = tokens.pop();
            let face = tokens.join('');
            let currentCard = makeCard(face, suit);
            result.push(currentCard);
        }
    
        console.log(result.join(' '));
        
    } catch (error) {
        console.log(error.message);
    }
    

    function makeCard(face, suit){
        let cardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    
        let cardSuits = {
            'S' : '\u2660',
            'H' : '\u2665',
            'D' : '\u2666',
            'C' : '\u2663' 
        };
    
        if((!cardFaces.includes(face) || (!cardSuits.hasOwnProperty(suit)))){
            throw Error(`Invalid card: ${face+suit}`);
        }
    
        let card = {
            face : face,
            suit : cardSuits[suit],
            toString : function(){
                return this.face + this.suit;
            }
        }
    
        return card.toString();
    } 
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);

