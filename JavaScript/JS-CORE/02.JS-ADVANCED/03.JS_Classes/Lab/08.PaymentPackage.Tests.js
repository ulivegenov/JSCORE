let PaymentPackage = require('./08.PaymentPackage');
let expect = require('chai').expect;


//Constructor tests
    //--Initialize with correct name and value
    //--Must throw error with incorect name type
    //--Must throw error with incorect name length(empty string)
    //--Must throw error with incorect value type
    //--Must throw error with negative value
//Set functionality tests
    //name
        //correct
        //--Must throw error with incorect name type
        //--Must throw error with incorect name length(empty string)
    //value
        //correct
        //--Must throw error with incorect value type
        //--Must throw error with negative value
    //VAT
        //correct
        //--Must throw error with incorect VAT type
        //--Must throw error with negative VAT
    //active
        //correct type
        //Must trow error with incorect type
//toString


//Tests

describe('PaymentPackage', function(){
    describe('check if functions are atached to prototype', function(){
        it('should atached functions', function(){
            expect(typeof PaymentPackage.prototype.toString === 'function').to.be.true;
        });
    });

    describe('Constructor tests', function(){
        it('should initialize with correct name and value', function(){
            let name = 'Technical Service';
            let value = 1000;
            let package = new PaymentPackage(name, value);
            let output = [
                `Package: ${package.name}` + (package.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${package.value}`,
                `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`];

            expect(package.toString()).to.be.equal(output.join('\n'));
        });

        it('Must throw error with incorrect name type', function(){
            let name = ['Technical Service'];
            let value = 1000;

            expect(() => new PaymentPackage(name, value)).to.throw(Error, 'Name must be a non-empty string');
        });

        it('Must throw error with incorrect name length (empty string)', function(){
            let name = '';
            let value = 1000;

            expect(() => new PaymentPackage(name, value)).to.throw(Error, 'Name must be a non-empty string');
        });

        it('Must throw error with negative value', function(){
            let name = 'Technical Service';
            let value = -1000;

            expect(() => new PaymentPackage(name, value)).to.throw(Error, 'Value must be a non-negative number');
        });

        it('Must throw error with incorrect value type', function(){
            let name = 'Technical Service';
            let value = '1000';

            expect(() => new PaymentPackage(name, value)).to.throw(Error, 'Value must be a non-negative number');
        });
    });

    describe('Set functionality tests', function(){
        describe('name set tests', function(){
            it('should set new name if it is correct type and length', function(){
                let name = 'Technical Service';
                let value = 1000;
                let package = new PaymentPackage(name, value);
                let newName = 'WC Service';

                package._name = newName;
                let output = [
                    `Package: ${package.name}` + (package.active === false ? ' (inactive)' : ''),
                    `- Value (excl. VAT): ${package.value}`,
                    `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`];
    
                expect(package.toString()).to.be.equal(output.join('\n'));
                expect(package.name).to.be.equal(newName);
            });

            it('Must throw error with incorrect name type', function(){
                let name = 'Technical Service';
                let value = 1000;
                let result = new PaymentPackage(name, value);
                let newName = ['WC Service'];

                expect(() => result._name = newName).to.throw(Error, 'Name must be a non-empty string');
            });

            it('Must throw error with incorect name length(empty string)', function(){
                let name = 'Technical Service';
                let value = 1000;
                let result = new PaymentPackage(name, value);
                let newName = '';

                expect(() => result._name = newName).to.throw(Error, 'Name must be a non-empty string');
            });
        });

        describe('value set tests', function(){
            it('should set a new value if it is corect type and it is positive', function(){
                let name = 'Technical Service';
                let value = 1000;
                let package = new PaymentPackage(name, value);
                let newValue = 1500;

                package._value = newValue;
                let output = [
                    `Package: ${package.name}` + (package.active === false ? ' (inactive)' : ''),
                    `- Value (excl. VAT): ${package.value}`,
                    `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`];
    
                expect(package.toString()).to.be.equal(output.join('\n'));
                expect(package.value).to.be.equal(newValue);
            });

            it('Must throw error with incorect value type', function(){
                let name = 'Technical Service';
                let value = 1000;
                let result = new PaymentPackage(name, value);
                let newValue = '1200';

                expect(() => result._value = newValue).to.throw(Error, 'Value must be a non-negative number');
            });

            it('Must throw error with negative value', function(){
                let name = 'Technical Service';
                let value = 1000;
                let result = new PaymentPackage(name, value);
                let newValue = -1200;

                expect(() => result._value = newValue).to.throw(Error, 'Value must be a non-negative number');
            });
        });

        describe('VAT set tests', function(){
            it('Should set new Vat if it is correct type and it is positive', function(){
                let package = new PaymentPackage('T', 1000);
                let newVat = 30;

                package._VAT = newVat;
                let output = [
                    `Package: ${package.name}` + (package.active === false ? ' (inactive)' : ''),
                    `- Value (excl. VAT): ${package.value}`,
                    `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`];
    
                expect(package.toString()).to.be.equal(output.join('\n'));
                expect(package.VAT).to.be.equal(newVat);
            });

            it('Must throw error with incorect VAT type', function(){
                let package = new PaymentPackage('T', 1000);
                let newVat = [30];

                expect(() => package._VAT = newVat).to.throw(Error, 'VAT must be a non-negative number');
            });

            it('Must throw error with negative VAT', function(){
                let package = new PaymentPackage('T', 1000);
                let newVat = -30;

                expect(() => package._VAT = newVat).to.throw(Error, 'VAT must be a non-negative number');
            });
        });

        describe('active set tests', function(){
            it('should set new "active" if it is correct type', function(){
                let package = new PaymentPackage('T', 1000);
                let newActive = false;

                package._active = newActive;
                let output = [
                    `Package: ${package.name}` + (package.active === false ? ' (inactive)' : ''),
                    `- Value (excl. VAT): ${package.value}`,
                    `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`];
    
                expect(package.toString()).to.be.equal(output.join('\n'));
                expect(package.active).to.be.equal(newActive);
            });

            it('should set new "active" if it is correct type', function(){
                let package = new PaymentPackage('T', 1000);
                let newActive = null;

                expect(() => package._active = newActive).to.throw(Error, 'Active status must be a boolean');
            });
        });
    });

    describe('toString() method test', function(){
        it('should return a correct format message', function(){
            let package = new PaymentPackage('Tech', 1000);
            let output = [
                `Package: ${package.name}` + (package.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${package.value}`,
                `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`];

        expect(package.toString()).to.be.equal(output.join('\n'));
        });
    });
});