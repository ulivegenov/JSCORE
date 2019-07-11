const rgbToHexColor = require('./06.RGBToHex');
const expect = require('chai').expect;

//Takes three integer numbers, representing the red, green and blue values of an RGB color, each within range [0…255]
//Returns the same color in hexadecimal format as a string (e.g. '#FF9EAA')
//Returns 'undefined' if any of the input parameters are of invalid type or not in the expected range

//Tests

describe('rgbToHexColor', function(){
    it('should return undefind if red is out of range', function(){
        let red = -1;
        let green = 67;
        let blue = 123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if red is out of range', function(){
        let red = 280;
        let green = 67;
        let blue = 123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if green is out of range', function(){
        let red = 238;
        let green = -67;
        let blue = 123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if green is out of range', function(){
        let red = 238;
        let green = 670;
        let blue = 123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if blue is out of range', function(){
        let red = 238;
        let green = 67;
        let blue = -123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if blue is out of range', function(){
        let red = 238;
        let green = 67;
        let blue = 1230;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if red is from invalid type', function(){
        let red = '238';
        let green = 67;
        let blue = 123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if green is from invalid type', function(){
        let red = 238;
        let green = [2];
        let blue = 123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return undefind if blue is from invalid type', function(){
        let red = 238;
        let green = 67;
        let blue = '123';

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal(undefined);
    });
    it('should return "#EE437B"', function(){
        let red = 238;
        let green = 67;
        let blue = 123;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal('#EE437B');
    });
    it('should return "#000000"', function(){
        let red = 0;
        let green = 0;
        let blue = 0;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal('#000000');
    });
    it('should return "#FFFFFF"', function(){
        let red = 255;
        let green = 255;
        let blue = 255;

        let result = rgbToHexColor(red, green, blue);

        expect(result).to.equal('#FFFFFF');
    });
});