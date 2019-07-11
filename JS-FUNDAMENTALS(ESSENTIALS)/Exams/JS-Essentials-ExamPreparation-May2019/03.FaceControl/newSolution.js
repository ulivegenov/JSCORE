function getData(){
    let lists = {
        peopleIn : [],
        blacklist : [],
        peopleOut : []
    };
    
    let paragraphs = {
        peopleIn : document.getElementById('peopleIn').children[1],
        blacklist : document.getElementById('blacklist').children[1],
        peopleOut : document.getElementById('peopleOut').children[1]
    }
    
    let input = JSON.parse(document.getElementById('input').children[0].value);
    let sorting = input.pop();

    input.forEach(person => {
        if(person.action === 'peopleIn'){
            peopleIn(person);
        } else if(person.action === 'blacklist'){
            blacklist(person);
        } else if (person.action === 'peopleOut'){
            peopleOut(person);
        }
    });

    if(sorting.criteria !== '' && sorting.action !== ''){
        lists[sorting.action].sort((a, b) => a[sorting.criteria].localeCompare(b[sorting.criteria]));
    }

    paragraphs.peopleIn.textContent = lists.peopleIn.map(person => JSON.stringify(person)).join(' ');
    paragraphs.blacklist.textContent = lists.blacklist.map(person => JSON.stringify(person)).join(' ');
    paragraphs.peopleOut.textContent = lists.peopleOut.map(person => JSON.stringify(person)).join(' ');

    function peopleIn(person){
        let blacklistPerson = lists.blacklist
                            .find(p => p.firstName === person.firstName && p.lastName === person.lastName);

        if(!blacklistPerson){
            lists.peopleIn.push(personToPushBuilder(person));
        }
    }

    function blacklist(person){
        let peopleInPerson = lists.peopleIn
                                  .find(p => p.firstName === person.firstName && p.lastName === person.lastName);
        
        if(peopleInPerson){
            lists.peopleIn.splice(lists.peopleIn.indexOf(peopleInPerson), 1);
            lists.peopleOut.push(personToPushBuilder(person));
        }

        lists.blacklist.push(personToPushBuilder(person));
    }

    function peopleOut(person){
        let peopleInPerson = lists.peopleIn
                                  .find(p => p.firstName === person.firstName && p.lastName === person.lastName);
        if(peopleInPerson){
            lists.peopleIn.splice(lists.peopleIn.indexOf(peopleInPerson), 1);
            lists.peopleOut.push(personToPushBuilder(person));
        }

        
    }

    function personToPushBuilder(person){
        let personToPush = {};
        personToPush.firstName = person.firstName;
        personToPush.lastName = person.lastName;

        return personToPush;
    }
}