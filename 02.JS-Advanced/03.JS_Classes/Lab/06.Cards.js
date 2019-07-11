let result = (function(){
    let suits = {
        'SPADES': '♠',
        'HEARTS': '♥',
        'DIAMONDS': '♦',
        'CLUBS': '♣',
    };

    let validFaces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit){
            this.face = face;
            this.suit = suit;
        }

        get face(){
            return this._face;
        }

        set face(face){
            if(!validFaces.includes(face)){
                throw new Error("Invalid card face: " + face);
            }

            this._face = face;
        }

        get suit(){
            return this._suit;
        }

        set suit(suit){
            if(!Object.keys(suits).map(s => suits[s]).includes(suit)){
                throw new Error("Invalid card suit: " + suit);
            }

            this._suit = suit;
        }
    }

    return {
        Suits: suits,
        Card: Card
    }   
}());

let Card = result.Card;
let Suits = result.Suits;



try {
    let card = new Card('Q', Suits.CLUBS);
    console.log(card.face);
    console.log(card.suit);
    card.face = 'A';
    card.suit = Suits.DIAMONDS;
    console.log(card.face);
    console.log(card.suit);
    //let card2 = new Card('1', Suits.DIAMONDS);
    //let card3 = new Card("1",Suits.CLUBS);
    let card4 = new Card("2",Suits.Pesho);
    let card5 = new Card("3",'hearts');
    //console.log(card2.face);
} catch (error) {
    console.log(error.message);
}