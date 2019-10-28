const homeController = function(){

    //Loading home view
    /* <-- app's call */
    const getHome = function(context){
        helper.addHeaderInfo(context);

        context.loadPartials({
            header : '../views/common/header.hbs',
            footer : '../views/common/footer.hbs'
        })
        .then(function(){
            this.partial('../views/home/home.hbs');
        })
    };

    return {
        getHome
    }
}();