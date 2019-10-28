const userController = function(){
    
    //Register methods
    /* <-- app's call */
    const getRegister = function(context){
        context.loadPartials({
            header : `./views/common/header.hbs`,
            footer : `./views/common/footer.hbs`,
            registerForm : `./views/register/registerForm.hbs`
        })
        .then(function(){
            this.partial(`./views/register/registerPage.hbs`);
        });
    };

    const postRegister = function(context){
        userModel.register(context.params) /* --> Calling userModel */
        .then(errorHandler.requestHandler)
        .then(response => response.json())
        .then((data) => {
            storage.saveUser(data) /* --> Calling storage in helpers */
            context.redirect('#/home'); /* Redirecting to homePage, with current context */
        });
    };

    //Login methods
    /* <-- app's call */
    const getLogin = function(context){
        context.loadPartials({
            header : `./views/common/header.hbs`,
            footer : `./views/common/footer.hbs`,
            loginForm : `./views/login/loginForm.hbs`
        })
        .then(function(){
            this.partial(`./views/login/loginPage.hbs`);
        })
    }

    const postLogin = function(context){
        userModel.login(context.params) /* --> Calling userModel */
        .then(errorHandler.requestHandler)
        .then(response => response.json())
        .then((data) => {
            storage.saveUser(data); /* --> Calling storage in helpers */
            context.redirect('#/home'); /* Redirecting to homePage, with current context */
        });
    }

    const logout = function(context){
        userModel.logout() /* --> Calling userModel */
        .then(errorHandler.requestHandler)
        .then(() => {
            storage.deleteUser();
            context.redirect('#/home');
        })
    }

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout,
    }
}();