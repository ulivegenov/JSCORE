const errorHandler = function(){
    const requestHandler = function(response){
        if(response.status >= 400 && response.status !== 401){
            throw new Error (`Something went wrong! Response: ${response.statusText}`);
        }

        return response;
    }

    return {
        requestHandler
    }
}();