function attachEvents() {
	$('#items li').on('click', slectTown);
	$('#showTownsButton').on('click', showTowns);

	function slectTown(){
		if($(this).attr('data-selected')){
			$(this).removeAttr('data-selected');
			$(this).css('background', '');
		} else{
			$(this).attr('data-selected','true');
			$(this).css('background','#DDD');
		}
	}

	function showTowns(){
		let selectedTowns = $('#items li[data-selected]')
							.toArray()
							.map(e => e.textContent)
							.join(', ');
		
		$('#selectedTowns').text(`${selectedTowns}`);
	}
}