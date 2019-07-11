class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    getRats(){
        return this.unitedRats;
    }

    unite(otherRat){
        if(otherRat.constructor === Rat){
            this.unitedRats.push(otherRat);
        }
    }

    toString(){
        let outputRats = () => {
            let result = '';
            for (const rat of this.unitedRats) {
                result += '#';
                result += rat.name;
                result += '\n';
            }

            return result.trim();
        }
        return `${this.name}\n${outputRats()}`;
    }
}

let test = new Rat("Pesho");
console.log(test.toString()); //Pesho
console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());
//[ Rat { name: 'Gosho', unitedRats: [] },
//  Rat { name: 'Sasho', unitedRats: [] } ]

console.log(test.toString());
// Pesho
// ##Gosho
// ##Sasho
