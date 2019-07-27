const monkeysElement = document.getElementsByClassName('monkeys')[0];
monkeysElement.addEventListener('click', showInfo);

function showInfo(ev){
    if(ev.target.tagName === 'BUTTON'){
        const parent = ev.target.parentNode;
        const info = parent.querySelector('p');
        if(info.style.display){
            info.style.display = '';
        } else {
            info.style.display = 'none';
        }
    }
}