const userController = function(){
    const getRegister = function(context){
        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/register/register.hbs');
        });
    };

    const getLogin = function(context){
        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/login/login.hbs');
        });   
    }

    const postRegister = function(context){
        const data = {
            username : context.params.username,
            password : context.params.password,
            boughts : 0
        };

        helper.notify('loading');

        requester.post('', 'user', 'Basic', data)
        .then(helper.handler)
        .then((resData) => {
            helper.stopNotify();
            helper.notify('success', 'User registration successful.');
            sessionStorage.setItem('username', resData.username);
            sessionStorage.setItem('authtoken', resData._kmd.authtoken);
            sessionStorage.setItem('id', resData._id);

            context.redirect('#/home');
        });
    };

    const postLogin = function(context){
        const data = {
            username : context.params.username,
            password : context.params.password,

        };

        helper.notify('loading');

        requester.post('login', 'user', 'Basic', data)
        .then(helper.handler)
        .then((resData) => {
            helper.stopNotify();
            helper.notify('success', 'Login successful.');
            
            sessionStorage.setItem('username', resData.username);
            sessionStorage.setItem('authtoken', resData._kmd.authtoken);
            sessionStorage.setItem('id', resData._id);

            context.redirect('#/home');
        });
    };

    const logout = function(context){
        helper.notify('loading');

        requester.post('_logout', 'user', 'Kinvey')
        .then(helper.handler)
        .then(() => {
            helper.stopNotify();
            helper.notify('success', 'Logout successful.');
            
            sessionStorage.clear();

            context.redirect('#/home');
        })
    }

    return {
        getRegister,
        getLogin,
        postRegister,
        postLogin,
        logout,
    }
}();