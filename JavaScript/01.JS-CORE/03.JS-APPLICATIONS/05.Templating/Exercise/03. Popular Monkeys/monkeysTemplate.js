function renderMonkeyTemplate(){
    const templateString = document.getElementById('monkey-template').innerHTML;
    const monkeyListFunc = Handlebars.compile(templateString);
    const rendered = monkeyListFunc({ monkeys });

    document.querySelector('.monkeys').innerHTML = rendered;
}

renderMonkeyTemplate();