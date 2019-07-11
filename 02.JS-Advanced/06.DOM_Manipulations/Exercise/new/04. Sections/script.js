function create(words) {
   let contentElement = document.getElementById('content');

    for (const currentSentence of words) {
        console.log(currentSentence);
        let divElement = document.createElement('div');
        let pElement = document.createElement('p');
        pElement.textContent = currentSentence;
        pElement.style.display = 'none';
        divElement.appendChild(pElement);
        divElement.addEventListener('click', onClick);
        contentElement.appendChild(divElement);
    }

    function onClick(e){
        let child = e.target.firstChild;
        child.style.display = 'block';
    }
}