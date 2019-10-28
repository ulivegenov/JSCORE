const requester = function(){
    let baseUrl = 'https://baas.kinvey.com';

    const get = function(url, headers){
        headers.method = 'GET';

        return makeRequest(url, headers); /* <-- userModel's call or eventModel's call */
    };

    const post = function(url, headers){
        headers.method = 'POST';

        return makeRequest(url, headers); /* <-- userModel's call or eventModel's call */
    };

    const put = function(url, headers){
        headers.method = 'PUT';

        return makeRequest(url, headers); /* <-- eventModel's call */
    };

    const del = function(url, headers){
        headers.method = 'DELETE';

        return makeRequest(url, headers); /* <-- eventModel's call */
    };

    const makeRequest = function(url, headers){

        //--> Authorization Kinvey in userModel or eventModel.
        headers.headers['Content-type'] = 'application/json';

        return fetch(baseUrl + url, headers)
    };

    return {
        get,
        post,
        put,
        del
    }
}();