const app = Sammy('#container', function(){
    // Introducing Handlebars to Sammy
    this.use('Handlebars', 'hbs');
    
        //HOME
        this.get('#/home', homeController.getHome);
    
        //USER
        this.get('#/register', userController.getRegister); 
        this.post('#/register', userController.postRegister); 
        this.get('#/login', userController.getLogin);
        this.post('#/login', userController.postLogin);
        this.get('#/logout', userController.logout);
    
        //OFFERS
        this.get('#/createOffer', offerController.getCreateOffer);
        this.post('#/createOffer', offerController.postCreateOffer);
        this.get('#/allOffers', offerController.getAllOffers); 
        this.get('#/editOffer/:offerId', offerController.getEditOffer);
        this.post('#/editOffer/:offerId', offerController.postEditOffer);
        this.get('#/detailsOffer/:offerId', offerController.getDetails);
        this.get('#/deleteOffer/:offerId', offerController.getDeleteOffer);
        this.post('#/deleteOffer/:offerId', offerController.postDeleteOffer);
});

(() => {
    app.run('#/home');
})();