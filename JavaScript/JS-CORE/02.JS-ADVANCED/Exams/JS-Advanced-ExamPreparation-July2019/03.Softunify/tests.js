const SoftUniFy = require('./03. Softunify').SoftUniFy;
const expect = require('chai').expect;

describe('Softunify Class Tests', () => {
    let softunify;

    beforeEach(() => {
        softunify = new SoftUniFy();
    })

    describe('Constructor test', () => {
        it('Should contain allSongs property', () => {
            expect(softunify).to.haveOwnProperty('allSongs');
        })

        it('allSongs property should initialized as an empty object', () => {
            expect(Object.keys(softunify.allSongs).length).to.equal(0);
        })
    })

    describe('downloadSong method tests', () => {
        it('Should adds the given information to the allSongs, per artist', () => {
           softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
           softunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
           softunify.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');

           expect(Object.keys(softunify.allSongs).length).to.equal(2);
        })

        it('Should adds the given information to the allSongs in the right format', () => {
            softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            softunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            softunify.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');
            let result = JSON.stringify({
                Eminem: 
                { rate: 0,
                  votes: 0,
                  songs: 
                   [ 'Venom - Knock, Knock let the devil in...',
                     'Phenomenal - IM PHENOMENAL...' ] },
               'Dub Fx': 
                { rate: 0,
                  votes: 0,
                  songs: [ 'Light Me On Fire - You can call me a liar.. ' ]
                }
            })
             
            expect(JSON.stringify(softunify.allSongs)).equal(result);
        })
    })
    describe('playSong method test', () => {
        it('Should return message if do not have at leas one downloaded song', () => {
            let result = "You have not downloaded a Vetrove song yet. Use SoftUniFy's function downloadSong() to change that!";

            expect(softunify.playSong('Vetrove')).to.equal(result);
        })

        it('Should return message if surched song is not downloaded', () => {
            softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            let result = "You have not downloaded a Vetrove song yet. Use SoftUniFy's function downloadSong() to change that!";

            expect(softunify.playSong('Vetrove')).to.equal(result);
        })

        it('Should return suched song if it is downloaded', () => {
            softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            let result = 'Eminem:\nVenom - Knock, Knock let the devil in...\n';

            expect(softunify.playSong('Venom')).to.equal(result);
        })
    })

    describe('songsList getter tests', () => {
        it('Should return message if we do not have at least one downloaded song', () => {
            let result = 'Your song list is empty';

            expect(softunify.songsList).to.equal(result);
        })

        it('Should return all downloaded song if there is', () => {
            softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            softunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            softunify.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');
            let songs = Object.values(softunify.allSongs)
            .map((v) => v['songs'])
            .reduce((acc, cur) => {
                return acc.concat(cur);
            }, []);
            let result = songs.join('\n');

            expect(softunify.songsList).to.equal(result);
        })
    })

    describe('rateArtist method tests', () => {
        it('Should return message if the given artist is not in the list', () => {
            let result = 'The Lily Ivanova is not on your artist list.';

            expect(softunify.rateArtist('Lily Ivanova')).to.equal(result);
        })

        it('Should return average rate of the given artist if there is', () => {
            softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            softunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');

            let artist = softunify.allSongs['Eminem'];
            let result;

            if (arguments.length === 2) {
                artist['rate'] += +arguments[1];
                artist['votes'] += 1;
            }

            let currentRate = (+(artist['rate'] / artist['votes']).toFixed(2));
            isNaN(currentRate) ? result = 0 : result = currentRate;

            expect(softunify.rateArtist('Eminem')).to.equal(result);
        })
    })
})
