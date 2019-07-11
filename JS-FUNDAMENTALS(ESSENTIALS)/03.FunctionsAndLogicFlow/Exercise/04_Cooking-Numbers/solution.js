function solve() {
    
    let buttons = document.getElementsByTagName('button');
    Array.from(buttons).forEach((button) => {
        button.addEventListener('click', clickEvent);
    });

    let buttonClicks = 0;

    function clickEvent(e){

        
        let inputField = document.getElementsByTagName('input')[0];
        let outputField = document.getElementById('output');

        let currentNum = 0;

        if(Number(buttonClicks) === 0){
            if(inputField.value != ''){
                currentNum = Number(inputField.value);
            } else {
                currentNum = 0;
            }
        } else {
            currentNum = Number(outputField.innerHTML);
        }

        let buttonsWeights = {'Chop' : `${currentNum / 2}`,
                              'Dice' : `${Math.sqrt(currentNum)}`,
                              'Spice' : `${currentNum + 1}`,
                              'Bake' : `${currentNum * 3}`,
                              'Fillet' : `${currentNum * 0.8}`
        };

        currentButton = e.target;
        outputField.innerHTML = buttonsWeights[currentButton.innerHTML];
        buttonClicks++;
    }
}