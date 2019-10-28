const helper = function () {

    const handler = function (response) {

        if (response.status >= 400) {
            stopNotify();
            notify('error', 'Invalid credentials. Please retry your request with correct credentials!');
            document.getElementById('inputUsername').value = '';
            document.getElementById('inputPassword').value = '';

            setTimeout(function(){ stopNotify(); }, 1000);
            
            
            throw new Error(`Something went wrong. Error: ${response.statusText}`);
        }

        if (response.status !== 204) {
            response = response.json();
        }

        return response;
    };

    const passwordCheck = function (params) {
        return params.password === params.rePassword;
    };

    const addHeaderInfo = function (context) {
        const loggedIn = sessionStorage.getItem('authtoken') !== null;

        if(loggedIn){
            context.loggedIn = loggedIn;
            context.username = sessionStorage.getItem('username');
        }
    }

    const loadPartials = function (context, externalPartials) {
        let defaultPartials = {
            header: "./views/common/header.hbs",
            footer: "./views/common/footer.hbs"
        };

        if (externalPartials) {
            for (const key in externalPartials) {
                const element = externalPartials[key];
                
                defaultPartials[key] = element;
            }
        }

        return context.loadPartials(defaultPartials);
    }

    const notify = function(type, textContent){
        let element;

        switch(type){
            case 'success' :
                element = document.getElementById('successBox');
                element.textContent = textContent;
                element.addEventListener('click', (e) => e.currentTarget.style.display = 'none');
                break;
            case 'error' :
                    element = document.getElementById('errorBox');
                    element.textContent = textContent;
                    element.addEventListener('click', (e) => e.currentTarget.style.display = 'none');
                break;
            case 'loading' :
                    element = document.getElementById('loadingBox');
                    element.textContent = 'Loading...';
                break;
        }

        element.style.display = 'block';
    };

    const stopNotify = function(){
        Array.from(document.getElementById('notifications').children)
            .forEach((child) => {
                child.style.display = 'none';
            });
    };

    return {
        handler,
        passwordCheck,
        addHeaderInfo,
        loadPartials,
        notify,
        stopNotify
    }
}();