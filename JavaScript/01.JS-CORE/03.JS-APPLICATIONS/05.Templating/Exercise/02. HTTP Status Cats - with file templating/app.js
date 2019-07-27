(async () =>{
    const { getTemplateFunc, registerPartial} = window.template;
    await registerPartial('cat', 'cat');
    const catListFunc = await getTemplateFunc('list-cat');
    const cats = window.cats;
    document.getElementById('allCats').innerHTML = catListFunc({ cats });
})();

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