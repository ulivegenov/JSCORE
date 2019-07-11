const isSymmetric = require('./05.CheckForSymmetry');
const expect = require('chai').expect;

//Takes an array as argument
//Returns false for any input that isn’t of the correct type
//Returns true if the input array is symmetric (first half is the same as the second half mirrored)
//Otherwise, returns false

//Tests
describe('isSymmetric', function(){
    it('should returns false if we pass a string as input', function(){
        expect(isSymmetric('string')).to.false;
    });
    it('should returns false if we pass a number as input', function(){
        expect(isSymmetric(2)).to.false;
    });
    it('should returns false if we pass an object as input', function(){
        expect(isSymmetric({})).to.false;
    });
    it('should returns true if the input array is symmetric', function(){
        expect(isSymmetric([1,2,3,3,2,1])).to.true;
    });
    it('should returns true if the input array is symmetric', function(){
        expect(isSymmetric([-1,2,3,3,2,-1])).to.true;
    });
    it('should returns true if the input array is empty', function(){
        expect(isSymmetric([])).to.true;
    });
    it('should returns true if the input array with one element', function(){
        expect(isSymmetric([3])).to.true;
    });
    it('should returns false if the input array is symmetric', function(){
        expect(isSymmetric([1,2,3,3,2,2])).to.false;
    });
    it('should returns false if the input array is symmetric', function(){
        expect(isSymmetric([1,2])).to.false;
    });
    it('should returns true if input is [5,"hi",{a:5},new Date(),{a:5},"hi",5]', function(){
        expect(isSymmetric([[5,'hi',{a:5},new Date(),{a:5},'hi',5]])).to.true;
    })
});
