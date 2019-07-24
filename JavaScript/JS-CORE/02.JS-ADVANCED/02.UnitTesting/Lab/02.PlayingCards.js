function makeCard(face, suit){
    let cardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    let cardSuits = {
        'S' : '\u2660',
        'H' : '\u2665',
        'D' : '\u2666',
        'C' : '\u2663' 
    };

    if(!cardFaces.includes(face)){
        throw new Error('Invalid face!');
    }

    if(!cardSuits.hasOwnProperty(suit)){
        throw new Error('Invalid suit!');
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

console.log('' + makeCard('A', 'S'));   //A♠
console.log('' + makeCard('10', 'H'));  //10♥
console.log('' + makeCard('1', 'C'));	//Error
