const sum = require("./04.SumOfNumbers");
const expect = require("chai").expect;

describe('sum', function(){
    it('should return sum of the numbers in the given array', function(){
        expect(sum(['1','2','3'])).to.equal(6);
    });

    it('should return zero if we pass an empty array', function(){
        expect(sum([])).to.equal(0);
    });

    it('should return NaN if we pass a rong input', function(){
        expect(sum(['a', '1'])).to.NaN;
    });
});
