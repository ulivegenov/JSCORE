function attachEvents(){
    const getTowns = () => {
        const input = document.getElementById('towns').value;
        towns = input.split(', ').map(element => ({name:element}));
        document.getElementById('towns').value = '';
    
        (async function() {
            const { getTemplateFunc, registerPartial } = window.templates;
            await registerPartial('town', 'town');
            const townListFunc = await getTemplateFunc('list-town');
            document.getElementById('root').innerHTML = townListFunc({towns});
        })();
    }
    
    let loadBtn = document.getElementById('btnLoadTowns');
    loadBtn.addEventListener('click', ev => {
        ev.preventDefault();
        getTowns();
    });
}

attachEvents();
