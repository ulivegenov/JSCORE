const homeController = function(){

    //Loading home view
    /* <-- app's call */
    const getHome = async function(context){
        helper.addHeaderInfo(context);

        try {
            const response = await requester.get('events' , 'appdata', 'Kinvey');
            const events = await response.json();
            context.events = events

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs',
                event : './views/event/event.hbs',
                noEvent : './views/event/noEvents.hbs',
                allEvents : './views/event/allEvents.hbs'
            })
            .then(function(){
                this.partial('./views/home/home.hbs');
            });
        } catch (error) {
            console.log(error.message);
        }
    };

    return {
        getHome
    }
}();