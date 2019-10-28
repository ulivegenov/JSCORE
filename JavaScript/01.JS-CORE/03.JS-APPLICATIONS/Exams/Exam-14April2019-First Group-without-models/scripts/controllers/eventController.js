const eventController = function(){
    const getCreateEvent = function(context){
        helper.addHeaderInfo(context);
        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/event/createEvent.hbs');
        });   
    }

    const postCreateEvent = function(context){
        const data = {
             ...context.params,
             peopleInterestedIn : 0,
             organizer : sessionStorage.getItem('username') 
            };

        helper.notify('loading');

        requester.post('events', 'appdata', 'Kinvey', data)
        .then(helper.handler)
        .then(() => {
            helper.stopNotify();
            helper.notify('success', 'Event created successfully.');
            context.redirect('#/home');
        });
    };

    const getDetails = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.eventId;
        
        requester.get(`events/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((event) => {
            context.event = event; 
            context.isCreator = event.organizer === sessionStorage.getItem('username');
            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/event/detailsEvent.hbs');
            });
        });
    };

    const getEditEvent = function(context){
        const id = context.params.eventId;
        helper.addHeaderInfo(context);

        requester.get(`events/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((event) => {
            context.event = event; 

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/event/editEvent.hbs');
            });
        });
    };

    const postEditEvent = function(context){
        
        const id = context.params.eventId;
        const data = {
            ...context.params,
        };
        delete data.id;
        
        helper.addHeaderInfo(context);
        helper.notify('loading');

        requester.put(`events/${id}`, 'appdata', 'Kinvey', data)
        .then(helper.handler)
        .then(() => {
            helper.stopNotify();
            helper.notify('success', 'Event edited successfully.');
            context.redirect('#/home');
        });
    };

    const deleteEvent = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.eventId;
        
        requester.get(`events/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then(() => {

            requester.del(`events/${id}`, 'appdata', 'Kinvey')
            .then(helper.handler)
            .then(() => {
                context.redirect('#/home');
            });
        });
    };

    const joinEvent = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.eventId;
        
        requester.get(`events/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((event) => {
            event.peopleInterestedIn++;
            context.event = event;
            const data = context.event;

            helper.notify('loading');

            requester.put(`events/${id}`, 'appdata', 'Kinvey', data)
            .then(helper.handler)
            .then(() => {
                helper.stopNotify();
                helper.notify('success', 'You join the event successfully.');
                context.redirect('#/home');
            }); 
        });
    }

    return {
        getCreateEvent,
        postCreateEvent,
        getDetails,
        getEditEvent,
        postEditEvent,
        deleteEvent,
        joinEvent
    }
}();