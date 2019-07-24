let getArticleGenerator = ((articles) => {
    
    let result = function showNext(){
        if(articles.length > 0){
        let content = document.getElementById('content');    
        let p = document.createElement('p');
        p.innerHTML = articles.shift();
        content.appendChild(p);
        }
                
        return showNext;
            
                
    };
    

    return result;
    
})();
