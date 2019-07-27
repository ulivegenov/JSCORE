(() => {
     renderCatTemplate();

     function renderCatTemplate() {
         const template = document.getElementById('cat-template').innerHTML;
         const compiled = Handlebars.compile(template);
         const rendered = compiled({ cats : window.cats });

         document.getElementById('allCats').innerHTML = rendered;
     }
})();
