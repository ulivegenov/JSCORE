// NOTE: The comment sections inside the index.html file is an example of how suppose to be structured the current elements.
//       - You can use them as an example when you create those elements, to check how they will be displayed, just uncomment them.
//       - Also keep in mind that, the actual skeleton in judge does not have this comment sections. So do not be dependent on them!
//       - Тhey are present in the skeleton just to help you!


// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.
function mySolution(){
    //GET "SEND" BUTTON
    let btnSend = document.querySelector('#inputSection div button');
    //ADD EVENTLISTENEER TO "SEND" BUTTON
    btnSend.addEventListener('click', send);

    function send(){
        //GET INPUT DATA
        let question = document.querySelector('#inputSection textarea').value;
        let username = document.querySelector('#inputSection div input[type="username"]').value;
        
        if(!username){
            username = 'Anonymous';
        }

        //FORMAT PENDING SECTION
        let pendingQuestions = document.getElementById('pendingQuestions');
        let divElementPending = document.createElement('div');
        divElementPending.setAttribute('class', 'pendingQuestion');

        let imgElementPending = document.createElement('img');
        imgElementPending.src = './images/user.png';
        imgElementPending.width = 32;
        imgElementPending.height = 32;

        let  spanElementPending = document.createElement('span');
        spanElementPending.textContent = username;

        let pElementPending = document.createElement('p');
        pElementPending.textContent = question;

        let innerDivElementPending = document.createElement('div');
        innerDivElementPending.setAttribute('class', 'actions');

        let btnArchive = document.createElement('button');
        btnArchive.setAttribute('class', 'archive');
        btnArchive.textContent = 'Archive';

        let btnOpen = document.createElement('button');
        btnOpen.setAttribute('class', 'open');
        btnOpen.textContent = 'Open';

        innerDivElementPending.appendChild(btnArchive);
        innerDivElementPending.appendChild(btnOpen);

        divElementPending.appendChild(imgElementPending);
        divElementPending.appendChild(spanElementPending);
        divElementPending.appendChild(pElementPending);
        divElementPending.appendChild(innerDivElementPending);

        pendingQuestions.appendChild(divElementPending);

        //ADD EVENTLISTENER TO "ARCHIVE" BUTTON
        btnArchive.addEventListener('click', archive);

        function archive(){
            divElementPending.remove();
        }

        //ADD EVENTLISTENER TO "OPEN" BUTTON
        btnOpen.addEventListener('click', open);

        function open(){
            innerDivElementPending.removeChild(btnArchive);
            innerDivElementPending.removeChild(btnOpen);
            let btnReply = document.createElement('button');
            btnReply.setAttribute('class', 'reply');
            btnReply.textContent = 'Reply';
            innerDivElementPending.appendChild(btnReply);

            let openQuestions = document.getElementById('openQuestions');
            pendingQuestions.removeChild(divElementPending);
            divElementPending.setAttribute('class', 'openQuestion');
            openQuestions.appendChild(divElementPending);

            let divElementOpen = document.createElement('div');
            divElementOpen.setAttribute('class', 'replySection');
            divElementOpen.setAttribute('style', 'display');
            divElementOpen.style.display = 'none';

            let inputElementReply = document.createElement('input');
            inputElementReply.setAttribute('class', 'replyInput');
            inputElementReply.type = 'text';
            inputElementReply.placeholder = 'Reply to this question here...';

            let btnRepSend = document.createElement('button');
            btnRepSend.setAttribute('class', 'replyButton');
            btnRepSend.textContent = 'Send';

            let olElement = document.createElement('ol');
            olElement.setAttribute('class', 'reply');
            olElement.type = '1';

            divElementOpen.appendChild(inputElementReply);
            divElementOpen.appendChild(btnRepSend);
            divElementOpen.appendChild(olElement);

            divElementPending.appendChild(divElementOpen);

            //ADD EVENTLISTENER TO "REPLY" BUTTON
            btnReply.addEventListener('click', reply);

            function reply(){
                if(btnReply.textContent === 'Reply'){
                    divElementOpen.style.display = 'block';
                    btnReply.textContent = 'Back';
                } else {
                    divElementOpen.style.display = 'none';
                    btnReply.textContent = 'Reply';
                }
            }

            //ADD EVENTLISTENER TO "REPSEND" BUTTON
            btnRepSend.addEventListener('click', repSend);

            function repSend(){
                let reply = inputElementReply.value;
                let liElement = document.createElement('li');
                liElement.textContent = reply;

                olElement.appendChild(liElement);
            }
        }
    }
}
// To check out your solution, just submit mySolution() function in judge system.
