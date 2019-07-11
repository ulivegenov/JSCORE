let isOddOrEven = require('./02.EvenOrOdd');
let expect = require('chai').expect;

//Returning undefined.
//Returning "even".
//Returning "odd".

//Tests

describe('isOddOrEven', function(){
    it('should return undefined we pass a number', function(){
        let input = 2;

        let result = isOddOrEven(input);

        expect(result).to.be.undefined;
    });

    it('should return undefined we pass an array', function(){
        let input = [2];

        let result = isOddOrEven(input);

        expect(result).to.be.undefined;
    });

    it('should return undefined we pass an object', function(){
        let input = {pesho : 2};

        let result = isOddOrEven(input);

        expect(result).to.be.undefined;
    });

    it('should return even if we pass an empty string', function(){
        let input = '';

        let result = isOddOrEven(input);

        expect(result).to.equal('even');
    });

    it('should return even if we pass "Pepi"', function(){
        let input = 'Pepi';

        let result = isOddOrEven(input);

        expect(result).to.equal('even');
    });

    it('should return odd if we pass "Pesho"', function(){
        let input = 'Pesho';

        let result = isOddOrEven(input);

        expect(result).to.equal('odd');
    });
})