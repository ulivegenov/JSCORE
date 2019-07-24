const PizzUni = require('./02. PizzUni_Ресурси').PizzUni;
const expect = require('chai').expect;

describe('PizzUni class tests', () => {
    let pizzUni;
    beforeEach(() => {
        pizzUni = new PizzUni();
    });

    describe('Constructor tests', () => {
        it('Shuld set "registeredUsers" as an empty array', () => {
            expect(pizzUni.registeredUsers).to.deep.equal([]);
        });
        it('Should set "availableProducts" as an object with properties "pizzas" and "drinks"', () =>{
            let result = {
                pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
                drinks: ['Coca-Cola', 'Fanta', 'Water']
            };

            expect(pizzUni.availableProducts).to.deep.equal(result);
        });
        it('Should set "orders" as an empty array', () => {
            expect(pizzUni.orders).to.deep.equal([]);
        });
    });

    describe('registerUser method tests', () => {
        it('Should throw error message if this email is already registered', () =>{
            pizzUni.registerUser('Pesho@abv.bg');

            expect(() => pizzUni.registerUser('Pesho@abv.bg')).to.throw(`This email address (Pesho@abv.bg) is already being used!`);
        });
        it('Should return a current registered user as an object with email and orderHistory', () => {
            let result = {
                email : 'Pesho@abv.bg',
                orderHistory : []
            }

            expect(pizzUni.registerUser('Pesho@abv.bg')).to.deep.equal(result);
        });
    });

    describe('makeAnOrder method tests', () => {
        it('Should throw error message if user is not registered', () => {
            expect(() => pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style', 'Coca-Cola')).to.throw('You must be registered to make orders!');
        });
        it('Should throw error message if ordered pizza is invalid', () => {
            pizzUni.registerUser('Pesho@abv.bg');

            expect(() => pizzUni.makeAnOrder('Pesho@abv.bg', 'Capri', 'Coca-Cola')).to.throw('You must order at least 1 Pizza to finish the order.');
        });
        it('Shuld push valid orders in the orderHistory of the user', () => {
            pizzUni.registerUser('Pesho@abv.bg');
            pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style', 'Coca-Cola')
            let index = pizzUni.registeredUsers.findIndex(e => e.email === 'Pesho@abv.bg');

            expect(pizzUni.registeredUsers[index].orderHistory.length).to.equal(1);
        });
        it('Shuld push a new object (with drink) with info in "orders" property if order is valid', () => {
            pizzUni.registerUser('Pesho@abv.bg');
            pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style', 'Coca-Cola');
            let result = {
                orderedPizza : 'Italian Style',
                orderedDrink : 'Coca-Cola',
                email : 'Pesho@abv.bg',
                status: 'pending'
            }

            expect(pizzUni.orders[0]).to.deep.equal(result);
        });
        it('Shuld push a new object (without drink) with info in "orders" property if order is valid', () => {
            pizzUni.registerUser('Pesho@abv.bg');
            pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style');
            let result = {
                orderedPizza : 'Italian Style',
                email : 'Pesho@abv.bg',
                status: 'pending'
            }

            expect(pizzUni.orders[0]).to.deep.equal(result);
        });
        it('Shuld push a new object (with invalid drink) with info in "orders" property if order is valid', () => {
            pizzUni.registerUser('Pesho@abv.bg');
            pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style', 'Voda');
            let result = {
                orderedPizza : 'Italian Style',
                email : 'Pesho@abv.bg',
                status: 'pending'
            }

            expect(pizzUni.orders[0]).to.deep.equal(result);
        });
        it('Should return the number of the order', () => {
            pizzUni.registerUser('Pesho@abv.bg');
            pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style', 'Voda');

            expect(pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style')).to.equal(1);
        });
    });

    describe('completeOrder method tests', () => {
        it('Shuold change status to first "pending" order to "complete"', () => {
            pizzUni.registerUser('Pesho@abv.bg');
            pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style', 'Voda');
            pizzUni.completeOrder();

            let result = {
            orderedPizza : 'Italian Style',
            email : 'Pesho@abv.bg',
            status: 'completed'
            }

            expect(pizzUni.orders[0]).to.deep.equal(result);
        });
    });

    describe('detailsAboutMyOrder method tests', () => {
        it('Should return the status of the given order if exist', () =>{
            pizzUni.registerUser('Pesho@abv.bg');
            pizzUni.makeAnOrder('Pesho@abv.bg', 'Italian Style', 'Voda');
            pizzUni.completeOrder();

            let result = {
            orderedPizza : 'Italian Style',
            email : 'Pesho@abv.bg',
            status: 'completed'
            }

            expect(pizzUni.detailsAboutMyOrder(0)).to.equal('Status of your order: completed');
        });
    });

    describe('doesTheUserExist method tests', () => {
        it('Shuld return an user registered to the given email as an object', () => {
            pizzUni.registerUser('Pesho@abv.bg');
            let result =  {
                email : 'Pesho@abv.bg',
                orderHistory : []
            }

            expect(pizzUni.doesTheUserExist('Pesho@abv.bg')).to.deep.equal(result);
        });
    });
});