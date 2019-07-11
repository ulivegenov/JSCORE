class Stringer{
    constructor(initialString, initialLength){
        this.innerString = initialString;
        this.innerLength = initialLength;
    }

    increase(value){
        this.innerLength += value;
    }

    decrease(value){
        if(this.innerLength - value < 0){
            this.innerLength = 0;
        } else{
            this.innerLength -= value;
        }
    }

    toString(){
        if(this.innerLength === 0){
            return '...';
        } else if(this.innerString.length <= this.innerLength){
            return this.innerString;
        } else{
            return `${this.innerString.slice(0, this.innerLength)}...`;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test
