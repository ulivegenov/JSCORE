const userModel = function(){

    /* <-- userController postRegister's call */
    const register = function(params){
        const data = {
            username : params.username,
            password : params.password
        };

        const url = `/user/${storage.appKey}`;
        const base_64 = btoa(`${storage.appKey}:${storage.appSecret}`);
        const authString = `Basic ${base_64}`;

        const headers = {
            body : JSON.stringify(data),
            headers : {
                Authorization : authString,
            }
        }

        return requester.post(url, headers); /* --> Calling requester in helpers. */
    }

    /* <-- userController postLogin's call */
    const login = function(params){
        const data = {
            username : params.username,
            password : params.password
        }

        const url = `/user/${storage.appKey}/login`;
        const base_64 = btoa(`${data.username}:${data.password}`);
        const authString = `Basic ${base_64}`;

        const headers = {
            body : JSON.stringify(data),
            headers : {
                Authorization : authString,
            }
        }

        return requester.post(url, headers); /* --> Calling requester in helpers. */
    }

    /* <-- userController logout's call */
    const logout = function(){

        const url = `/user/${storage.appKey}/_logout`;
        const token = JSON.parse(storage.getData('authToken'));
        const authString = `Kinvey ${token}`;

        const headers = {
            headers : {
                Authorization : authString,
            }
        }

        return requester.post(url, headers); /* --> Calling requester in helpers. */
    }

    return{
        register,
        login,
        logout,
    }
}();