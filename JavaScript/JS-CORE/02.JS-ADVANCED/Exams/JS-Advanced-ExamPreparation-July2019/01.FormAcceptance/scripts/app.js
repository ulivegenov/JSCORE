function acceptance() {
	//Get inputs.
	const [company, product, quantity, scrape] = document.querySelectorAll('#fields td input');
	const addButton = document.getElementById('acceptance');
	let warehouse = document.getElementById('warehouse');

	//Add eventListener to Add button(validate input).
	addButton.addEventListener('click', addProductToStore);

	function addProductToStore(){
		const validInput = ((company.value !== '') && (product.value !== '') && (!isNaN(quantity.value)) && (!isNaN(scrape.value)));

		if(validInput && (quantity.value - scrape.value > 0)){
			let divElement = document.createElement('div');
			let pElement = document.createElement('p');
			pElement.textContent = `[${company.value}] ${product.value} - ${quantity.value - scrape.value} pieces`;
			let outOfStockButton = document.createElement('button');
			outOfStockButton.setAttribute('type', 'button');
			outOfStockButton.textContent = 'Out of stock';
			divElement.appendChild(pElement);
			divElement.appendChild(outOfStockButton);

			
			warehouse.appendChild(divElement);
		}

		company.value = '';
		product.value = '';
		quantity.value = '';
		scrape.value = '';
	}

	//Add eventListener to Out of stock button(remove element).
	warehouse.addEventListener('click', remove);
	
	function remove(e){
		if(e.target.tagName.toLowerCase() === 'button'){
			warehouse.removeChild(e.target.parentNode);
		}
	}
}