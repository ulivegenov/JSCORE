let Warehouse = require('./09.Warehouse');
let expect = require('chai').expect;


//Tests

describe('Warehouse tests', function(){
    describe('Constructor tests', function(){
        it('Should initialize with valid input capacity of type number', function(){
            let warehouse = new Warehouse(3);

            expect(warehouse.hasOwnProperty('availableProducts')).to.be.true;
            expect(warehouse.capacity).to.be.equal(3);
        });

        it('Should trow error with wrong type of input capacity', function(){
            expect(() => new Warehouse('3')).to.throw('Invalid given warehouse space');
        });

        it('Should throw error with negative input capacity', function(){
            expect(() => new Warehouse(-4)).to.throw('Invalid given warehouse space');
        });

        it('Should throw error with zero input capacity', function(){
            expect(() => new Warehouse(0)).to.throw('Invalid given warehouse space');
        })
    });
    
    describe('addMethod tests', function(){
        it('Should add the given product if there is space', function(){
            let warehouse = new Warehouse(5);

            warehouse.addProduct('Food', 'Pizza', 1);

            let result = warehouse.availableProducts['Food'];

            expect(result).to.be.haveOwnProperty('Pizza');
            expect(result['Pizza']).to.be.equal(1);
        });
        
        it('Should sum quantity if product is added more than once', function(){
            let warehouse = new Warehouse(5);

            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food', 'Pizza', 3);

            let result =warehouse.availableProducts['Food']['Pizza'];

            expect(result).to.be.equal(4);
        });

        it('Should throw error if there is allready full', function(){
            let warehouse = new Warehouse(5);

            warehouse.addProduct('Food', 'Pizza', 5);
            let wrongFunc = () => warehouse.addProduct('Food', 'Pizza', 3);

            expect(wrongFunc).to.throw('There is not enough space or the warehouse is already full');
        });

        it('Should throw error if there is no enough place', function(){
            let warehouse = new Warehouse(5);

            warehouse.addProduct('Food', 'Pizza', 3);
            let wrongFunc = () => warehouse.addProduct('Food', 'Pizza', 3);

            expect(wrongFunc).to.throw('There is not enough space or the warehouse is already full');
        });

        it('should return object with the given type when adding product successfully', () => {
            let warehouse = new Warehouse(2)
            expect(warehouse.addProduct('Food', 'bread', 1)).to.be.an('Object');
            expect(warehouse.addProduct('Drink', 'water', 1)).to.be.an('Object');
            expect(warehouse.availableProducts.Food).to.haveOwnProperty('bread');
      });
    });

    describe('orderProducts method tests', function(){
        it('Should sort all product of type Food in descending oreder', function(){
            let warehouse = new Warehouse(10);

            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food','Tomato', 5);
            warehouse.addProduct('Food', 'Apple', 2);

            warehouse.orderProducts('Food');
            let expectedResult = 'Tomato Apple Pizza'

            expect(Object.keys(warehouse.availableProducts['Food']).join(' ')).to.be.equal(expectedResult);
        });

        it('Should sort all product of type Drink in descending oreder', function(){
            let warehouse = new Warehouse(10);

            warehouse.addProduct('Drink', 'Water', 1);
            warehouse.addProduct('Drink','Tea', 5);
            warehouse.addProduct('Drink', 'Cola', 2);

            warehouse.orderProducts('Drink');
            let expectedResult = 'Tea Cola Water';

            expect(Object.keys(warehouse.availableProducts['Drink']).join(' ')).to.be.equal(expectedResult);
        });

        it('Should sort all product of given type(witth more than one type) in descending oreder', function(){
            let warehouse = new Warehouse(100);

            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food','Tomato', 5);
            warehouse.addProduct('Food', 'Apple', 2);
            warehouse.addProduct('Drink', 'Water', 1);
            warehouse.addProduct('Drink','Tea', 5);
            warehouse.addProduct('Drink', 'Cola', 2);

            warehouse.orderProducts('Food');
            warehouse.orderProducts('Drink');
            let expectedResultOne = 'Tomato Apple Pizza';
            let expectedResultTwo = 'Tea Cola Water';

            expect(Object.keys(warehouse.availableProducts['Food']).join(' ')).to.be.equal(expectedResultOne);
            expect(Object.keys(warehouse.availableProducts['Drink']).join(' ')).to.be.equal(expectedResultTwo);
        });
    });

    describe('occupiedCapacity method tests', function(){
        it('Should return a number, which represents the already occupied place in the warehouse with one kind', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food','Tomato', 5);

            expect(warehouse.occupiedCapacity()).to.be.equal(6);
        });

        it('Should return a number, which represents the already occupied place in the warehouse with two kinds', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food', 'Tomato', 5);
            warehouse.addProduct('Drink', 'Water', 1);
            warehouse.addProduct('Drink', 'Cola', 5);

            expect(warehouse.occupiedCapacity()).to.be.equal(12);
        });
    });

    describe('revision method tests', function(){
        it('Should return a message for empty if there is no products in warehouse', function(){
            let warehouse = new Warehouse(1);

            expect(warehouse.revision()).to.be.equal('The warehouse is empty');
        });

        it('Should return a message with products in warehouse', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food', 'Tomato', 5);
            warehouse.addProduct('Drink', 'Water', 1);
            warehouse.addProduct('Drink', 'Cola', 5);

            let output = '';
            for (let type of Object.keys(warehouse.availableProducts)) {
                output += `Product type - [${type}]\n`;
                for (let product of Object.keys(warehouse.availableProducts[type])) {
                    output += `- ${product} ${warehouse.availableProducts[type][product]}\n`;
                }
            }

            expect(warehouse.revision()).to.be.equal(output.trim());
        });

        it('Should return a message with products from one type in warehouse', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food', 'Tomato', 5);

            let output = '';
            for (let type of Object.keys(warehouse.availableProducts)) {
                output += `Product type - [${type}]\n`;
                for (let product of Object.keys(warehouse.availableProducts[type])) {
                    output += `- ${product} ${warehouse.availableProducts[type][product]}\n`;
                }
            }

            expect(warehouse.revision()).to.be.equal(output.trim());
        });

        it('with trimed output', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            warehouse.addProduct(type, product, quantity);

            let result = warehouse.revision();


            expect(result.endsWith('\n'), `Result must be trimmed`).to.be.false;
        });
    });

    describe('scrapeAProduct method tests', function(){
        it('Should throw error if product do not exist', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Pizza', 1);
            warehouse.addProduct('Food', 'Tomato', 5);

            expect(() => warehouse.scrapeAProduct('Apple', 2)).to.throw('Apple do not exists');
        });

        it('Should reduce quantity of product', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Tomato', 5);
            warehouse.scrapeAProduct('Tomato', 2);

            expect(warehouse.availableProducts['Food']['Tomato']).to.be.equal(3);
        });

        it('Should reduce quantity of product to zero', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Tomato', 5);
            warehouse.scrapeAProduct('Tomato', 5);

            expect(warehouse.availableProducts['Food']['Tomato']).to.be.equal(0);
        });

        it('Should reset quantity of product', function(){
            let warehouse = new Warehouse(15);
            
            warehouse.addProduct('Food', 'Tomato', 5);
            warehouse.scrapeAProduct('Tomato', 6);

            expect(warehouse.availableProducts['Food']['Tomato']).to.be.equal(0);
        });
    });
});
