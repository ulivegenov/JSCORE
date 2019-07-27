function renderMonkeyTemplate(scope){
    const getTemplsteString = async (name) => {
        let templateStringCache = {};

        if(!templateStringCache[name]){
            const path = `./templates/${name}-template.hbs`;
            const response = await fetch(path);
            const templateString = await response.text();
            templateStringCache[name] = templateString;
        }
        
        return templateStringCache[name];
    }

    const getTemplateFunc = async (name) => {
        const templateString = await getTemplsteString(name);

        return Handlebars.compile(templateString);
    }

    const registerPartial = async (partialName, templateName) => {
        const templateString = await getTemplsteString(templateName);
        Handlebars.registerPartial(partialName, templateString);
    }

    scope.monkeysTemplate = { getTemplateFunc, registerPartial}
}

renderMonkeyTemplate(window);