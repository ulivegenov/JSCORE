const app = Sammy('#container', function(){
    // Introducing Handlebars to Sammy
    this.use('Handlebars', 'hbs');
    
        //HOME
        this.get('#/home', homeController.getHome); /* --> Calling homeController. */
    
        //USER
        this.get('#/register', userController.getRegister);  /* --> Calling userController. */
        this.post('#/register', userController.postRegister);  /* --> Calling userController. */
        this.get('#/login', userController.getLogin);  /* --> Calling userController. */
        this.post('#/login', userController.postLogin);  /* --> Calling userController. */
        this.get('#/logout', userController.logout); /* --> Calling userController. */
    
        //MOVIES
        this.get('#/addMovie', movieController.getCreateMovie); /* --> Calling movieController. */
        this.post('#/addMovie', movieController.postCreateMovie); /* --> Calling movieController. */ 
        this.get('#/allMovies', movieController.getAllMovies); /* --> Calling movieController. */
        this.get('#/myMovies', movieController.getMyMovies); /* --> Calling movieController. */
        this.get('#/movie/detailsMovie/:movieId', movieController.getDetails); /* --> Calling movieController. */
        this.get('#/movie/editMovie/:movieId', movieController.getEditMovie);
        this.post('#/movie/editMovie/:movieId', movieController.postEditMovie);
        this.get('#/movie/deleteMovie/:movieId', movieController.getDeleteMovie);
        this.post('#/movie/deleteMovie/:movieId', movieController.postDeleteMovie);
        this.get('/movie/buyTicket/:movieId', movieController.getBuyTicket);
});

(() => {
    app.run('#/home');
})();