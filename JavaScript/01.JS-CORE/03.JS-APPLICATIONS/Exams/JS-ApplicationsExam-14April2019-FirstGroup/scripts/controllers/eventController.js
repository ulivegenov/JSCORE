const eventController = function (){

    const getCreateEvent = function(context){

        checker.isLoggedIn(context);

        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/event/createEvent.hbs');
        });
    }

    const postCreateEvent = function(context){
        eventModel.createEvent(context.params)
        .then(errorHandler.requestHandler)
        .then(response => response.json())
        .then(() => {
            //notify
            context.redirect('#/home');
        });
    }

    const getDetails = async function(context){
        try {
            let response = await eventModel.getEvent(context.params.eventId)
            let event = await response.json();
            context.event = event;
            console.log(context);
            checker.isLoggedIn(context);
            checker.isCreator(context);

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
            this.partial('./views/event/detailsEvent.hbs');
            });
        } catch (error) {
            console.log(error.message);
        };
    };

    const getEditEvent = async function(context){
        try {
            let response = await eventModel.getEvent(context.params.eventId);
            let event = await response.json();
            context.event = event;
            checker.isLoggedIn(context);
            
            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/event/editEvent.hbs');
            });
        } catch (error) {
            console.log(error.message);
        }
    };

    const postEditEvent = async function(context){
        console.log(context);
        try {
            const response = await eventModel.editEvent(context.params)
            const event = await response.json();
            context.event = event;
            context.redirect('#/home');
        } catch (error) {
            console.log(error.message);
        }
        //checker.isLoggedIn(context);
        // eventModel.editEvent(context)
        // .then(errorHandler.requestHandler)
        // .then(response => response.json())
        // .then(() => {
        //     context.redirect('#/home');
        // });
    };

    return{
        getCreateEvent,
        postCreateEvent,
        getDetails,
        getEditEvent,
        postEditEvent
    }
}();