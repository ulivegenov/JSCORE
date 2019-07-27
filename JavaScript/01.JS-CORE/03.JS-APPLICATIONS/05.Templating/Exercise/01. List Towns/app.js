function attachEvents(){
    const getTowns = () => {
        const input = document.getElementById('towns').value;
        towns = input.split(', ').map(element => ({name:element}));
        document.getElementById('towns').value = '';
        const templateString = document.getElementById('town-template').innerHTML;
        const townListFunc = Handlebars.compile(templateString);
        const rendered = townListFunc({ towns });

        document.getElementById('root').innerHTML = rendered;
    }
    
    let loadBtn = document.getElementById('btnLoadTowns');
    loadBtn.addEventListener('click', ev => {
        ev.preventDefault();
        getTowns();
    })
};

attachEvents();
