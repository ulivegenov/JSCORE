const FilmStudio = require('./filmStudio').FilmStudio;
const expect = require('chai').expect;


describe('FilmStudio class tests', () => {
    let filmStudio;

    beforeEach(() => {
        filmStudio = new FilmStudio('JS-CORE');
    });

    describe('Constructor Tests', () => {
        it('Should set name', () => {
            expect(filmStudio.name).to.be.equal('JS-CORE');
        });
        it('Should set a property "films" as an empty array', () => {
            expect(filmStudio.films).to.deep.equal([]);
        });
    });

    describe('makeMovie method tests', () => {
        it('Should throw an error message without argruments', () => {
            expect(() => filmStudio.makeMovie()).to.throw('Invalid arguments count');
        });
        it('Should throw an error message if the arguments are not right count', () => {
            expect(() => filmStudio.makeMovie('Avatar')).to.throw('Invalid arguments count');
        });
        it('Should throw an error message if argument are not from the right type', () => {
            expect(() => filmStudio.makeMovie(2, ['Boyko Krastanov'])).to.throw('Invalid arguments');
        });
        it('Should set filmName with right count of arguments from the right type', () => {
            let result = filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

            expect(result.filmName).to.equal('The Avengers');
        });
        it('Should set filmRoles with right count of arguments from the right type', () => {
            let result = filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

            expect(result.filmRoles).to.deep.equal([ { role: 'Iron-Man', actor: false },
                                                     { role: 'Thor', actor: false },
                                                     { role: 'Hulk', actor: false },
                                                     { role: 'Arrow guy', actor: false } ] );
        });
    });

    describe('casting method tests', () => {
        it('Should return message if there no films yet in this studio', () => {
            expect(filmStudio.casting('Pesho', 'Ovchar')).to.equal('There are no films yet in JS-CORE.');
        });
        it('Should return message if the given role is not exist in the films of this studio', () => {
            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            
            expect(filmStudio.casting('Pesho','Ovchar')).to.equal('Pesho, we cannot find a Ovchar role...')
        });
        it('Should return message if we hire the given actor for the given role', () => {
            filmStudio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            
            expect(filmStudio.casting('Pesho','Iron-Man')).to.equal('You got the job! Mr. Pesho you are next Iron-Man in the The Avengers. Congratz!')
        });
    });

    describe('lookForProducer method tests', () => {
        it('Should return an error message if the given film does not exists in this studio', () =>{
            expect(() => filmStudio.lookForProducer('Avatar')).to.throw('Avatar do not exist yet, but we need the money...');
        });
        it('Should print film name and cast if the given film exists in this studio', () => {
            filmStudio.makeMovie('The Avengers', ['Iron-Man','Thor']);
            filmStudio.casting('Pesho','Iron-Man');
            filmStudio.casting('Kolyo','Thor');

            let result = ['Film name: The Avengers', 'Cast:', 'Pesho as Iron-Man', 'Kolyo as Thor'];

            expect(filmStudio.lookForProducer('The Avengers')).to.equal(result.join('\n') + '\n');
        });
    });
});