let mathEnforcer = require('./04.MathEnforcer');
let expect = require('chai').expect;


//addFive(num) - A function that accepts a single parameter:
    //If the parameter is not a number, the funtion should return undefined.
    //If the parameter is a number, add 5 to it, and return the result.

//subtractTen(num) - A function that accepts a single parameter:
    //If the parameter is not a number, the function should return  undefined.
    //If the parameter is a number, subtract 10 from it, and return the result.

//sum(num1, num2) - A function that should accepts two parameters:
    //If any of the 2 parameters is not a number, the function should return undefined.
    //If both parameters are numbers, the function should return their sum. 

//The methods should function correctly for positive, negative and floating point numbers.
//In case of floating point numbers the result should be considered correct if it is within 0.01 of the correct value. 

//Tests

describe('mathEnforcer', function(){
    it('should return undefined if we pass input different from a number for "addFive functionality"', function(){
        let input = '2';

        let result = mathEnforcer.addFive(input);

        expect(result).to.be.undefined;
    });

    it('should return undefined if we pass input different from a number for "subtractTen functionality"', function(){
        let input = '2';

        let result = mathEnforcer.subtractTen(input);

        expect(result).to.be.undefined;
    });

    it('should return undefined if we pass input different from numbers for "sum functionality"', function(){
        let firstParameter = '2';
        let secondParameter = '3';

        let result = mathEnforcer.sum(firstParameter, secondParameter);

        expect(result).to.be.undefined;
    });

    it('should return undefined if we pass input different from number as first parameter for "sum functionality"', function(){
        let firstParameter = '2';
        let secondParameter = 3;

        let result = mathEnforcer.sum(firstParameter, secondParameter);

        expect(result).to.be.undefined;
    });

    it('should return undefined if we pass input different from number as second parameter for "sum functionality"', function(){
        let firstParameter = 2.5;
        let secondParameter = '3';

        let result = mathEnforcer.sum(firstParameter, secondParameter);

        expect(result).to.be.undefined;
    });

    it('shuld add 5, to positive number input for "add functionality"', function(){
        let input = 10;

        let result = mathEnforcer.addFive(input);

        expect(result).to.be.equal(15);
    });

    it('shuld add 5, to negative number input for "add functionality"', function(){
        let input = -10;

        let result = mathEnforcer.addFive(input);

        expect(result).to.be.equal(-5);
    });

    it('shuld add 5, to positive floating point number input for "add functionality"', function(){
        let input = 1.355;

        let result = Number((mathEnforcer.addFive(input).toFixed(2)));

        expect(result).to.be.equal(6.36);
    });

    it('shuld add 5, to negative floating point number input for "add functionality"', function(){
        let input = -1.35;

        let result = mathEnforcer.addFive(input);

        expect(result).to.be.equal(3.65);
    });

    it('should subtract 10 from positive number for "subtractTen functionality"', function(){
        let input = 4.5;

        let result = mathEnforcer.subtractTen(input);

        expect(result).to.be.equal(-5.5);
    });

    it('should subtract 10 from negative number for "subtractTen functionality"', function(){
        let input = -10;

        let result = mathEnforcer.subtractTen(input);

        expect(result).to.be.equal(-20);
    });

    it('should subtract 10 from negative floating point number for "subtractTen functionality"', function(){
        let input = -10.544;

        let result = Number(mathEnforcer.subtractTen(input).toFixed(2));

        expect(result).to.be.equal(-20.54);
    });

    it('should return sum of two positive numbers for "sum functionality"', function(){
        let firstParameter = 2.5;
        let secondParameter = 3;

        let result = mathEnforcer.sum(firstParameter, secondParameter);

        expect(result).to.be.equal(5.5);
    });

    it('should return sum of one positive number and one negative number for "sum functionality"', function(){
        let firstParameter = 2.554;
        let secondParameter = -3;

        let result = Number(mathEnforcer.sum(firstParameter, secondParameter).toFixed(2));

        expect(result).to.be.equal(-0.45);
    });

    it('should return sum of two negative numbers for "sum functionality"', function(){
        let firstParameter = -2.554;
        let secondParameter = -3;

        let result = Number(mathEnforcer.sum(firstParameter, secondParameter).toFixed(2));

        expect(result).to.be.equal(-5.55);
    });

    it('should return sum of two floating point numbers for "sum functionality"', function(){
        let firstParameter = -2.554;
        let secondParameter = 3.666;

        let result = Number(mathEnforcer.sum(firstParameter, secondParameter).toFixed(2));

        expect(result).to.be.equal(1.11);
    });
})