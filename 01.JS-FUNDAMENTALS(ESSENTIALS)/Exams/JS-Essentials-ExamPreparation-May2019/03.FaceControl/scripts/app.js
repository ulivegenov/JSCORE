function getData () {
	let input = JSON.parse(document.querySelector('#input textarea').value);
	let sortingCriteriaData = input.pop();
	
	let lists = {
		peopleIn : [],
		peopleOut : [],
		blacklist : []
	}
	
	let paragraphs = {
		peopleIn : document.querySelector('#peopleIn p'),
		peopleOut : document.querySelector('#peopleOut p'),
		blacklist : document.querySelector('#blacklist p')
	}

	for(let currentPerson of input){
		switch(currentPerson.action){
			case 'peopleIn' :
				peopleIn(currentPerson);
				break;
			case 'peopleOut' :
				peopleOut(currentPerson);
				break;
			case 'blacklist' :
				blacklist(currentPerson);
				break;
		}
	}

	function peopleIn(person){
		let personToPush = personToPushBuilder(person);
		let personBlacklist = lists.blacklist
							  .find(p => p.firstName === person.firstName && p.lastName === person.lastName);

		if(!personBlacklist){
			lists.peopleIn.push(personToPush);
			display();
		}
	}

	function peopleOut(person){
		let personToPush = personToPushBuilder(person)
		let personIn = lists.peopleIn
					   .find(p => p.firstName === person.firstName && p.lastName === person.lastName);
		
		if(personIn){
			let index = lists.peopleIn.indexOf(personIn);
			lists.peopleIn.splice(index, 1);
			lists.peopleOut.push(personToPush);
			display();
		}
	}

	function blacklist(person){
		let personToPush = personToPushBuilder(person)
		let personIn = lists.peopleIn
					   .find(p => p.firstName === person.firstName && p.lastName === person.lastName);

		if(personIn){
			let index = lists.peopleIn.indexOf(personIn);
			lists.peopleIn.splice(index, 1);
			lists.peopleOut.push(personToPush);
		}

		lists.blacklist.push(personToPush);
		display();
	}

	function display(){
	
		paragraphs.peopleIn.textContent = lists.peopleIn.map(p => JSON.stringify(p)).join(' ');
		paragraphs.peopleOut.textContent = lists.peopleOut.map(p => JSON.stringify(p)).join(' ');
		paragraphs.blacklist.textContent = lists.blacklist.map(p => JSON.stringify(p)).join(' ');
		
		if(sortingCriteriaData.criteria !== '' && sortingCriteriaData.action !== ''){
			paragraphs[sortingCriteriaData.action].textContent = lists[sortingCriteriaData.action]
											.sort((a, b) => a[sortingCriteriaData.criteria].localeCompare(b[sortingCriteriaData.criteria]))
											.map(p => JSON.stringify(p))
											.join(' ');
		}
	}

	function personToPushBuilder(person){
		let personToPush = {};
		personToPush.firstName = person.firstName;
		personToPush.lastName = person.lastName;

		return personToPush;
	}
}