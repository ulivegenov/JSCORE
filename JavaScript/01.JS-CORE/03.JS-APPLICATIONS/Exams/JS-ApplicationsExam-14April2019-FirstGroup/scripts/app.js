const app = Sammy('#main', function(){
    //Introducing Handlebars to Sammy.
    this.use('Handlebars', 'hbs');

    //** USER **//
    //Get starting at #home.
    this.get('#/home', homeController.getHome); /* --> Calling homeController. */

    //Register methods.
    this.get('#/register', userController.getRegister);  /* --> Calling userController. */
    this.post('#/register', userController.postRegister);  /* --> Calling userController. */

    //Login methods.
    this.get('#/login', userController.getLogin);  /* --> Calling userController. */
    this.post('#/login', userController.postLogin);  /* --> Calling userController. */

    //Logout method
    this.get('#/logout', userController.logout); /* --> Calling userController. */

    //** EVENTS **//
    //CreateEvent method
    this.get('#/createEvent', eventController.getCreateEvent); /* --> Calling eventController. */
    this.post('#/createEvent', eventController.postCreateEvent); /* --> Calling eventController. */

    //Load All Events
    this.get('#/events', eventController.getAllEvents); /* --> Calling eventController. */

    //Edit event
    this.get('#/detailsEvent/:eventId', eventController.getDetails); /* --> Calling eventController. */
    this.get('#/editEvent/:eventId', eventController.getEditEvent); /* --> Calling eventController */
    this.post('#/editEvent/:eventId', eventController.postEditEvent); /* --> Calling eventController */

});

(() => {
    app.run('#/home');
})();