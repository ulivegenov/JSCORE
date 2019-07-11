const createCalculator = require('./07.Add-Subtract');
const expect = require('chai').expect;

//Returns a module (object), containing the functions add, subtract and get as properties
//Keeps an internal sum which can’t be modified from the outside
//The functions add and subtract take a parameter that can be parsed as a number (either a number or a string containing a number) that is added or subtracted from the internal sum
//The function get returns the value of the internal sum

//Tests

describe('createCalculator', function(){
    it('should has proprety "add"', function(){
        let calculator = createCalculator();
        
        expect(calculator.hasOwnProperty('add')).to.equal(true);
    });
    it('should has proprety "subtract"', function(){
        let calculator = createCalculator();
        
        expect(calculator.hasOwnProperty('subtract')).to.equal(true);
    });
    it('should has proprety "get"', function(){
        let calculator = createCalculator();
        
        expect(calculator.hasOwnProperty('get')).to.equal(true);
    });
    it('internal sum must be a 15', function(){
        let calculator = createCalculator();

        calculator.add(3);
        calculator.add(17);
        calculator.subtract(5);

        expect(calculator.get()).to.equal(15);
    });
    it("internal sum can't be modified from outside", function(){
        let calculator = createCalculator();

        calculator.get(10);

        expect(calculator.get()).to.equal(0);
    });
    it('should return Nan if we add a string', function(){
        let calculator = createCalculator();

        calculator.add('str');

        expect(calculator.get()).to.be.NaN;
    });
    it('should return Nan if we subtract a string', function(){
        let calculator = createCalculator();

        calculator.subtract('str');

        expect(calculator.get()).to.be.NaN;
    });
    it('internal sum must be a 15.4', function(){
        let calculator = createCalculator();

        calculator.add(2.6);
        calculator.add(17.4);
        calculator.subtract(4.6);

        expect(calculator.get()).to.equal(15.4);
    });
    it('internal sum must be a -8', function(){
        let calculator = createCalculator();

        calculator.subtract(2);
        calculator.subtract(6);

        expect(calculator.get()).to.equal(-8);
    });
    it('should return 0', function(){
        let calculator = createCalculator();

        expect(calculator.get()).to.equal(0);
    });
    it("should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
        let calculator = createCalculator();

        calculator.add(10);
        calculator.subtract('7');
        calculator.add('-2');
        calculator.subtract(-1);
    
        expect(calculator.get()).to.be.equal(2);
    });
});