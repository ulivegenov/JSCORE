const element = document.querySelector('#allCats');
element.addEventListener('click', showStatus);

function showStatus(ev){
    if(ev.target.classList.contains('showBtn')){
        const parent = ev.target.parentNode;
        const statusElement = parent.querySelector('.status');
        if(statusElement.style.display){
            statusElement.style.display ='';
        } else {
            statusElement.style.display = 'none';
        }
    }
}