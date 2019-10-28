const homeController = function(){

    //Loading home view
    /* <-- app's call */
    const getHome = async function(context){

        checker.isLoggedIn(context);
        try {
            let response = await eventModel.getAllEvents(context);
            context.events = await response.json();
        } catch (error) {
            console.log(error.message);
        }
        
        
        context.loadPartials({
            header : '../views/common/header.hbs',
            footer : '../views/common/footer.hbs',
            event : '../views/event/event.hbs',
            noEvents : '../views/event/noEvents.hbs',
            eventsView : '../views/event/eventsView.hbs'
        })
        .then(function(){
            this.partial('../views/home/home.hbs');
        });
    };

    return {
        getHome
    }
}();