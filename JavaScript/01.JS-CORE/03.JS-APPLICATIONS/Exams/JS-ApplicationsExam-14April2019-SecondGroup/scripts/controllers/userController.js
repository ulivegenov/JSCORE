const userController = function(){
    const getRegister = function(context){
        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/register/registerForm.hbs');
        });
    };

    const getLogin = function(context){
        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/login/loginForm.hbs');
        });   
    }

    const postRegister = function(context){
        const data = {
            username : context.params.username,
            password : context.params.password
        };

        requester.post('', 'user', 'Basic', data)
        .then(helper.handler)
        .then((resData) => {
            sessionStorage.setItem('username', resData.username);
            sessionStorage.setItem('authtoken', resData._kmd.authtoken);
            sessionStorage.setItem('id', resData._id);

            context.redirect('#/home');
        });
    };

    const postLogin = function(context){
        const data = {
            username : context.params.username,
            password : context.params.password
        };

        requester.post('login', 'user', 'Basic', data)
        .then((resData) => {
            sessionStorage.setItem('username', resData.username);
            sessionStorage.setItem('authtoken', resData._kmd.authtoken);
            sessionStorage.setItem('id', resData._id);

            context.redirect('#/home');
        });
    };

    const logout = function(context){
        requester.post('_logout', 'user', 'Kinvey')
        .then(helper.handler)
        .then(() => {
            sessionStorage.clear();

            context.redirect('#/login');
        })
    }

    return {
        getRegister,
        getLogin,
        postRegister,
        postLogin,
        logout
    }
}();