function solve() {

    let buttons = document.querySelectorAll('button');

    for (let i = 0; i < buttons.length; i++){

        buttons[i].addEventListener('click', clickEvent);
    }

    function clickEvent(e){
        
        let currentButton = e.target;
        let senderName = '';
        let message = '';

        if(currentButton.name === 'myBtn'){
            senderName = 'Me';
            message = document.querySelector('#exercise #myChatBox').value;
        } else{
            senderName = 'Pesho';
            message = document.querySelector('#exercise #peshoChatBox').value;
        }

        if(message !== ''){
            let span = document.createElement('span');
        span.innerHTML = senderName;

        let paragraph = document.createElement('p');
        paragraph.innerHTML = message;

        let resultMasssage = document.createElement('div');
        resultMasssage.appendChild(span);
        resultMasssage.appendChild(paragraph);
        

        if(currentButton.name === 'myBtn'){
            resultMasssage.style.textAlign = 'left';
            document.querySelector('#exercise #myChatBox').value = '';
        } else{
            resultMasssage.style.textAlign = 'right';
            document.querySelector('#exercise #peshoChatBox').value = '';
        }


        let chatChronology = document.querySelector('#exercise #chatChronology');

        chatChronology.appendChild(resultMasssage);
        }
    }
}