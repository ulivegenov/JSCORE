function spaceshipCrafting() {
	let titaniumCore = Number(document.getElementById('titaniumCoreFound').value);
	let aluminiumCore = Number(document.getElementById('aluminiumCoreFound').value);
	let magnesiumCore = Number(document.getElementById('magnesiumCoreFound').value);
	let carbonCore = Number(document.getElementById('carbonCoreFound').value);
	let lossesPercent = Number(document.getElementById('lossesPercent').value);

	lossesPercent = lossesPercent/4/100;
    // Losses
	titaniumCore = Math.round(titaniumCore - titaniumCore*lossesPercent);
	aluminiumCore = Math.round(aluminiumCore - aluminiumCore*lossesPercent);
	magnesiumCore = Math.round(magnesiumCore - magnesiumCore*lossesPercent);
	carbonCore = Math.round(carbonCore - carbonCore*lossesPercent);
  
	// Convert to Bars
	let titaniumBars = Math.round(titaniumCore/25);
	let aluminiumBars = Math.round(aluminiumCore/50);
	let magnesiumBars = Math.round(magnesiumCore/75);
	let carbonBars = Math.round(carbonCore/100);

	// Build Ships

	let theUndefinedShipsCount = 0;
	let nullMasterShipsCount = 0;
	let jsonCrewShipsCount = 0;
	let falseFeetShipsCount = 0;

		while((titaniumBars >= 2) && (aluminiumBars >= 2) && (magnesiumBars >= 3) && (carbonBars >= 1)){
			if((titaniumBars >= 7) && (aluminiumBars >= 9) && (magnesiumBars >= 7) && (carbonBars >= 7)){
				titaniumBars -= 7;
				aluminiumBars -= 9;
				magnesiumBars -= 7;
				carbonBars -= 7;
	
				theUndefinedShipsCount++;
			} 

			if((titaniumBars >= 5) && (aluminiumBars >= 7) && (magnesiumBars >= 7) && (carbonBars >= 5)){
				titaniumBars -= 5;
				aluminiumBars -= 7;
				magnesiumBars -= 7;
				carbonBars -= 5;
	
				nullMasterShipsCount++;
			}
			
			if((titaniumBars >= 3) && (aluminiumBars >= 5) && (magnesiumBars >= 5) && (carbonBars >= 2)){
				titaniumBars -= 3;
				aluminiumBars -= 5;
				magnesiumBars -= 5;
				carbonBars -= 2;
	
				jsonCrewShipsCount++;
			} 

			if((titaniumBars >= 2) && (aluminiumBars >= 2) && (magnesiumBars >= 3) && (carbonBars >= 1)) {
				titaniumBars -= 2;
				aluminiumBars -= 2;
				magnesiumBars -= 3;
				carbonBars -= 1;
	
				falseFeetShipsCount++;
			}
		}

	// Format result
	let shipReport = [];
	if(theUndefinedShipsCount > 0){
		shipReport.push(`${theUndefinedShipsCount} THE-UNDEFINED-SHIP`);
	}
	if(nullMasterShipsCount > 0){
		shipReport.push(`${nullMasterShipsCount} NULL-MASTER`)
	}
	if(jsonCrewShipsCount > 0){
		shipReport.push(`${jsonCrewShipsCount} JSON-CREW`);
	}
	if(falseFeetShipsCount > 0){
		shipReport.push(`${falseFeetShipsCount} FALSE-FLEET`);
	}
	
	let materialsReport = `${titaniumBars} titanium bars, ${aluminiumBars} aluminum bars, ${magnesiumBars} magnesium bars, ${carbonBars} carbon bars`;

	// DOM Attach
	let availableBars = document.getElementById('availableBars').children[1];
	let buildShips = document.getElementById('builtSpaceships').children[1];

	availableBars.textContent = materialsReport;
	console.log(availableBars.textContent);
	buildShips.textContent = shipReport.join(', ');
}