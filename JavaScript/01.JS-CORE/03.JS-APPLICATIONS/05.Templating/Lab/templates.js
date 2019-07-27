(async function(scope) {
    const tempalteStringsCache = {};

    const getTemplateString = async (name) => {
        if(!tempalteStringsCache[name]){
            const path = `./templates/${name}-template.hbs`;
            const response = await fetch(path);
            const templateString = await response.text();
            tempalteStringsCache[name] = templateString;
        }
        
        return tempalteStringsCache[name];
    };

    const getTemplateFunc = async (name) => {
        const templateString = await getTemplateString(name);
        return Handlebars.compile(templateString);
    };

    const registerPartial = async (partialName, templateName) => {
        const templateString = await getTemplateString(templateName);
        Handlebars.registerPartial(partialName, templateString);
    }

    scope.templates = { getTemplateFunc, registerPartial };
})(window)