function solve() {

	let answer = '';
	let rightAnswers = 0;
	let buttons = document.querySelectorAll('#exercise section button');
	let sections = document.querySelectorAll('#exercise section');
	let buttonOne = buttons[0].addEventListener('click', clikEventOne);
	let buttonTwo = buttons[1].addEventListener('click', clickEventTwo);
	let buttonTree = buttons[2].addEventListener('click', clickEventTree);

	function clikEventOne(){
		answer = document.querySelector('#exercise section input[name="softUniYear"]:checked').value;

		if(answer === '2013'){
			rightAnswers++;
		}

		sections[1].style.display = 'block';
	}

	function clickEventTwo(){
		answer = document.querySelector('#exercise section input[name="popularName"]:checked').value;

		if(answer === 'Pesho'){
			rightAnswers++;
		}
		
		sections[2].style.display = 'block';
		
	}

	function clickEventTree(){
		answer = document.querySelector('#exercise section input[name="softUniFounder"]:checked').value;
		if(answer === 'Nakov'){
			rightAnswers++;
		}

		let result = document.getElementById('result');

		if(rightAnswers === 3){
			result.textContent = 'You are recognized as top SoftUni fan!';
		} else{
			result.textContent = `You have ${rightAnswers} right answers`
		}
	}
}