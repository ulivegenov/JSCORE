(async function() {
    const { getTemplateFunc, registerPartial} = window.templates;
    await registerPartial('card', 'card');
    const cardListFunc = await getTemplateFunc('cards-list');
    document.getElementById('contacts').innerHTML = cardListFunc({contacts}); 
})();

const contactsElement = document.getElementById('contacts');
contactsElement.addEventListener('click', showDetails);

function showDetails(ev){
    if(ev.target.classList.contains('detailsBtn')){
        const parent = ev.target.parentNode;
        const details = parent.querySelector('.details');
        if(details.style.display){
            details.style.display = '';
        } else {
            details.style.display = 'none';
        }
    }
}