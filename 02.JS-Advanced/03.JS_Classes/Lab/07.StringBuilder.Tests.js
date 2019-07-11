let StringBuilder = require('./07.StringBuilder');
let expect = require('chai').expect;

//Initialize
    //--Can be instantiated with a passed in string argument or without anything
    //--Should throw Error with a passed in non-string argument
//Function append(string) 
    //-–converts the passed in string argument to an array and adds it to the end of the storage
    //--Should throw Error with a passed in non-string argument
//Function prepend(string) 
    //–-converts the passed in string argument to an array and adds it to the beginning of the storage
    //--Should throw Error with a passed in non-string argument
//Function insertAt(string, index) 
    //–-converts the passed in string argument to an array and adds it at the given index (there is no need to check if the index is in range)
    //--Should throw Error with a passed in non-string argument
//Function remove(startIndex, length) 
    //–-removes elements from the storage, starting at the given index (inclusive), 
        //length number of characters (there is no need to check if the index is in range)
    //--Should throw Error with a passed in non-string argument
//Function toString() – returns a string with all elements joined by an empty string
//All passed in arguments should be strings. If any of them are not, throws a type error with the following message: 
    //"Argument must be a string"


//Tests

describe('StringBuilder', function(){
    let sb;
    beforeEach(function(){
        sb = new StringBuilder();
    });

    describe('check if functions are atached to prototype', function(){
        it('should atached functions', function(){
            expect(typeof StringBuilder.prototype.append === 'function').to.be.true;
            expect(typeof StringBuilder.prototype.prepend === 'function').to.be.true;
            expect(typeof StringBuilder.prototype.insertAt === 'function').to.be.true;
            expect(typeof StringBuilder.prototype.remove === 'function').to.be.true;
            expect(typeof StringBuilder.prototype.toString === 'function').to.be.true;
        });
    });

    describe('constructor tests', function(){
        it('shuld initialize without params', function(){
            expect(sb.toString()).to.be.equal('');
        });
        
        it('should initialize with string as input', function(){
            let input = 'Test';

            sb = new StringBuilder(input);

            expect(sb.toString()).to.be.equal(input);
        });
        
        it('should throw error with non-string as input', function(){
            let input = [];

            let errorFunc = () =>{
                sb(input);
            }

            expect(errorFunc).to.throw(TypeError);
        });
    });

    describe('append functionality tests', function(){
        it('should add input string to the end', function(){
            let input1 = 'Hello';
            let input2 = ' World!';

            sb.append(input1);
            sb.append(input2);

            expect(sb.toString()).to.be.equal(`${input1}${input2}`);
        });

        it('should add one input string to the end', function(){
            let input1 = 'Hello';

            sb.append(input1);

            expect(sb.toString()).to.be.equal(`${input1}`);
        });

        it('should throw error if input for adding is non-string to the end', function(){
            let input1 = 6;

            let errorFunc = () => {
                sb.append(input1)
            }

            expect(errorFunc).to.throw(TypeError);
        });
    });

    describe('prepend functionality tests', function(){
        it('should add input string to begining', function(){
            let input1 = 'Hello';
            let input2 = ' World!';

            sb.prepend(input2);
            sb.prepend(input1);

            expect(sb.toString()).to.be.equal(`${input1}${input2}`);
        });

        it('should add one input string to begining', function(){
            let input1 = 'Hello';
            sb.append('World!');

            sb.prepend(input1);

            expect(sb.toString()).to.be.equal(`${input1}World!`);
        });

        it('should throw error if input for adding is non-string to the end', function(){
            let input1 = 6;

            let errorFunc = () => {
                sb.prepend(input1)
            }

            expect(errorFunc).to.throw(TypeError);
        });
    });

    describe('insertAt functionality tests', function(){
        it('should insert given string at index 0', function(){
            let input = 'T';
            let index = 0;
            sb.append('est');

            sb.insertAt(input, index);

            expect(sb.toString()).to.be.equal('Test');
        });

        it('should insert given string at index 2', function(){
            let input = 's';
            let index = 2;
            sb.append('Tet');

            sb.insertAt(input, index);

            expect(sb.toString()).to.be.equal('Test');
        });

        it('should insert given string as last index', function(){
            let input = 't';
            sb.append('Tes');
            let currentString = sb.toString();
            let index = currentString.length;

            
            sb.insertAt(input, index);

            expect(sb.toString()).to.be.equal('Test');
        });

        it('should throw error if we try to insert a non-string', function(){
            let input = 3;
            let index = 2;
            sb.append('Test');

            let errorFunc = () =>{
                sb.insertAt(input, index);
            }

            expect(errorFunc).to.throw(TypeError);
        });
    });

    describe('remove functionality tests', function(){
        it('should remove first two elements', function(){
            sb.append('Test');

            sb.remove(0,2);

            expect(sb.toString()).to.be.equal('st');
        });

        it('should remove second and third element', function(){
            sb.append('Test');

            sb.remove(1,2);

            expect(sb.toString()).to.be.equal('Tt');
        });

        it('should remove last element', function(){
            sb.append('Test');
            let currentString = sb.toString();
            let startIndex = currentString.length - 1;

            sb.remove(startIndex,1);

            expect(sb.toString()).to.be.equal('Tes');
        });

        it('should remove to the end', function(){
            sb.append('Test');

            sb.remove(1,3);

            expect(sb.toString()).to.be.equal('T');
        });
    });

    describe('toString functionality tests', function(){
        it('shuold return current string in StrinBuilder', function(){
            sb.append('Hi! ');
            sb.append('How are you doing?')

            expect(sb.toString()).to.be.equal('Hi! How are you doing?');
        });
    });
});