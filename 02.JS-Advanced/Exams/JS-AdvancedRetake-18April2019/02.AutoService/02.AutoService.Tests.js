const AutoService = require('./02. Auto Service_Ресурси').AutoService;
const expect = require('chai').expect;

describe('AutoService class tests', () => {
    let autoService;

    beforeEach(() => {
        autoService = new AutoService(3);
    });

    describe('Constructor tests', () => {
        it('Should set garage capacity to the given initialize value', () => {
            expect(autoService.garageCapacity).to.equal(3);
        });
        it('Should set "workInProgress" property as an empty array', () => {
            expect(autoService.workInProgress).to.deep.equal([]);
        });
        it('Should set "backlogWork" property as an empty array', () => {
            expect(autoService.backlogWork).to.deep.equal([]);
        });
    });

    describe('Getter availableSpace tests', () => {
        it('Should return the available space for cars with empty garage', () => {
            expect(autoService.availableSpace).to.equal(3);
        });
        it('Should return available space if there are some cars', () => {
            autoService.workInProgress.push('car');

            expect(autoService.availableSpace).to.equal(2);
        });
    });

    describe('signUpForReview method tests', () => {
        it('Should push current client in "workInProgress array" if there is available space', () =>{
            autoService.signUpForReview('Pesho', 'CA 1132', 'Oil change');

            expect(autoService.workInProgress.length).to.equal(1);
        });
        it('Should push current client in "backlogWork array" if there is not available space', () => {
            autoService.signUpForReview('Pesho', 'CA 1132 KH', 'Oil change');
            autoService.signUpForReview('Milka', 'CA 1332 AB', 'Oil change');
            autoService.signUpForReview('Kolyo', 'CA 2132 BB', 'Oil change');
            autoService.signUpForReview('Velyo', 'CB 1132 TC', 'Oil change');

            expect(autoService.backlogWork.length).to.equal(1);
        });
    });

    describe('carInfo method tests', () => {
        it('Should return message if there is no such owner in the garage', () => {
            autoService.signUpForReview('Pesho', 'CA 1132 KH', 'Oil change');

            expect(autoService.carInfo('CA 1132 KH', 'Misho')).to.equal('There is no car with platenumber CA 1132 KH and owner Misho.')
        });
        it('Should return message if there is no such plate number in the garage', () => {
            autoService.signUpForReview('Pesho', 'CA 1132 KH', 'Oil change');
            
            expect(autoService.carInfo('CA 1132 KC', 'Pesho')).to.equal('There is no car with platenumber CA 1132 KC and owner Pesho.')
        });
        it('Should return info if there is such client in the "workInProgress array"', () => {
            autoService.signUpForReview('Pesho', 'CA 1132 KH', 'Oil change');
            let result = {
                plateNumber : 'CA 1132 KH',
                clientName : 'Pesho',
                carInfo : 'Oil change'
            }
            
            expect(autoService.carInfo('CA 1132 KH', 'Pesho')).to.deep.equal(result);
        });
        it('Should return info if there is such client in the "backlogWork array"', () => {
            autoService.signUpForReview('Milka', 'CA 1332 AB', 'Oil change');
            autoService.signUpForReview('Kolyo', 'CA 2132 BB', 'Oil change');
            autoService.signUpForReview('Velyo', 'CB 1132 TC', 'Oil change');
            autoService.signUpForReview('Pesho', 'CA 1132 KH', 'Oil change');
            let result = {
                plateNumber : 'CA 1132 KH',
                clientName : 'Pesho',
                carInfo : 'Oil change'
            }
            
            expect(autoService.carInfo('CA 1132 KH', 'Pesho')).to.deep.equal(result);
        });
    });

    describe('repairCar method tests', () => {
        it('Should return message if there are no clients', () => {
            expect(autoService.repairCar()).to.equal('No clients, we are just chilling...');
        });
        it('Should return message if there is nohing to repaired', () => {
            autoService.signUpForReview('Peter', 'CA1234CA', {'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'FFFKKL34'});

            expect(autoService.repairCar()).to.equal('Your car was fine, nothing was repaired.');
        });
        it('Should return message with repaired parts', () => {
            autoService.signUpForReview('Peter', 'CA1234CA', {'engine': 'MFRGG23', 'transmission': 'broken', 'doors': 'broken'});

            expect(autoService.repairCar()).to.equal('Your transmission and doors were repaired.');
        });
    });
});