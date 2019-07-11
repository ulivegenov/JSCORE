function solve() {
	
	let button = document.querySelector('#myNumbers button');
	button.addEventListener('click', getNums);

	function getNums(){

		let nums = String(document.querySelector('#myNumbers input').value);
		let numsArray = nums.split(' ');
		let allNumsInRange = true;
		let allNumsAreUnique = true;
		let prevNum ='';

		numsArray.forEach(element => {
			if(element < 1 || element > 49){
				allNumsInRange = false;
			}

			if(Number(element) === Number(prevNum)){
				allNumsAreUnique = false;
				prevNum = element;
			}

			prevNum = element;
		});

		if(numsArray.length === 6 && allNumsInRange && allNumsAreUnique){
			let allNums = document.getElementById('allNumbers');

			for(let i = 1; i <= 49; i++){
				let divElement = document.createElement('div');
				divElement.innerText = `${i}`;
				divElement.classList.add('numbers');
				allNums.appendChild(divElement);

				for(let j = 0; j < numsArray.length; j++){
					if(Number(divElement.innerText) === Number(numsArray[j])){
						divElement.style.backgroundColor = 'orange';
					}
				}
			}
		}

		document.querySelector('#myNumbers input').disabled = true;
		button.disabled = true;
	}
}