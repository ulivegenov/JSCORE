function encodeAndDecodeMessages() {
    let buttons = document.querySelectorAll('#container #main div button');
	let encodeButton = buttons[0];
	let decodeButton = buttons[1];

	let textareas = document.querySelectorAll('#container #main div textarea');
	let inputTextarea = textareas[0];
	let outputTextarea = textareas[1];

	encodeButton.addEventListener('click', encode);
	decodeButton.addEventListener('click', decode);

	function encode(){

		let messageToEncode = String(inputTextarea.value);
		let encodedMassage =''
		for(let i = 0; i < messageToEncode.length; i++){

			let currentSimbol = messageToEncode[i];
			let currentASCI = messageToEncode.charCodeAt(i);
			currentSimbol = String.fromCharCode(currentASCI + 1);
			encodedMassage += currentSimbol;
		}

		outputTextarea.value = encodedMassage;
		inputTextarea.value = '';
	}

	function decode(){
		let messageToDecode = outputTextarea.value;
		let decodedMessage = '';

		for(let i = 0; i < messageToDecode.length; i++){
			let currentSimbol = messageToDecode[i];
			let currentASCI = messageToDecode.charCodeAt(i);
			currentSimbol = String.fromCharCode(currentASCI - 1);
			decodedMessage += currentSimbol;
		}

		outputTextarea.value = decodedMessage;
	}
}