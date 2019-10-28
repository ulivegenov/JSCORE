const app = Sammy('#main', function(){
    // Introducing Handlebars to Sammy
    this.use('Handlebars', 'hbs');
    
        //HOME
        this.get('#/home', homeController.getHome); // Optional /* --> Calling homeController. */
    
        //USER
        this.get('#/register', userController.getRegister);  /* --> Calling userController. */
        this.post('#/register', userController.postRegister);  /* --> Calling userController. */
        this.get('#/login', userController.getLogin);  /* --> Calling userController. */
        this.post('#/login', userController.postLogin);  /* --> Calling userController. */
        this.get('#/logout', userController.logout); /* --> Calling userController. */
    
        //EVENTS
        this.get('#/createEvent', eventController.getCreateEvent); /* --> Calling eventController. */
        this.post('#/createEvent', eventController.postCreateEvent); /* --> Calling eventController. */ 
        this.get('#/home', eventController.getAllEvents); /* --> Calling eventController. */
        this.get('#/detailsEvent/:eventId', eventController.getDetails);
        //TODO LoadMY...
        this.get('#/editEvent/:eventId', eventController.getEditEvent);
        this.post('#/editEvent/:eventId', eventController.postEditEvent);
        this.get('#/deleteEvent/:eventId', eventController.deleteEvent);
        this.get('#/joinEvent/:eventId', eventController.joinEvent);
});

(() => {
    app.run('#/home');
})();