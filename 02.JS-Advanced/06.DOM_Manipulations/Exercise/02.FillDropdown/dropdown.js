function addItem(){
    let text = document.getElementById('newItemText');
    let value = document.getElementById('newItemValue');
    let selectElement = document.getElementById('menu');

    let currentOption = document.createElement('option');
    currentOption.textContent = text.value;
    currentOption.setAttribute('value', value.value);

    selectElement.appendChild(currentOption);
    text.value = '';
    value.value = '';
}