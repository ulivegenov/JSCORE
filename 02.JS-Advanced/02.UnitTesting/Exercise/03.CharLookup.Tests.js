let lookupChar = require('./03.CharLookup');
let expect = require('chai').expect;

//If the first parameter is not a string or the second parameter is not an integer - return undefined.
//If both parameters are of the correct type, but the value of the index is incorrect (bigger than or equal to the string length or a negative number) - return the text "Incorrect index". 
//If both parameters have correct types and values - return the character at the specified index in the string.

//Tests

describe('lookupChar', function(){
    it('should return undefined if we not pass a string as first parameter and number as second parameter', function(){
        let firstParameter = 2;
        let secondParameter = '2';

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.be.undefined;
    });

    it('should return undefined if we pass a floating point number as second parameter', function(){
        let firstParameter = 'Pesho';
        let secondParameter = 2.3;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.be.undefined;
    });

    it('should return undefined if we not pass a string as first parameter', function(){
        let firstParameter = 2;
        let secondParameter = 2;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.be.undefined;
    });

    it('should return "Incorrect index" if we pass an empry string as first parameter', function(){
        let firstParameter = '';
        let secondParameter = 0;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.be.equal("Incorrect index");
    });

    it('should return undefined if we not pass a number as second parameter', function(){
        let firstParameter = 'Pesho';
        let secondParameter = '2';

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.be.undefined;
    });

    it('should return "Incorrect index" if we pass a negative index', function(){
        let firstParameter = 'Pesho';
        let secondParameter = -1;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.equal('Incorrect index');
    });

    it('should return "Incorrect index" if we pass an index equal to the string length', function(){
        let firstParameter = 'Pesho';
        let secondParameter = 5;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.equal('Incorrect index');
    });

    it('should return "Incorrect index" if we pass an index biger than the string length', function(){
        let firstParameter = 'Pesho';
        let secondParameter = 8;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.equal('Incorrect index');
    });

    it('should return "s" if we pass "Pesho" and "2" respectively as first parameter and secon parameter', function(){
        let firstParameter = 'Pesho';
        let secondParameter = 2;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.equal('s');
    });

    it('should return "P" if we pass "Pesho" and "0" respectively as first parameter and secon parameter', function(){
        let firstParameter = 'Pesho';
        let secondParameter = 0;

        let result = lookupChar(firstParameter, secondParameter);

        expect(result).to.equal('P');
    });
})
