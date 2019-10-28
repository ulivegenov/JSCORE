const checker = function(currentContext){
    const isLoggedIn = function(currentContext){
        const loggedIn = storage.getData('userInfo') !== null;
    
        if(loggedIn){
            const username = JSON.parse(storage.getData('userInfo')).username;   
            currentContext.loggedIn = loggedIn;
            currentContext.username = username;
        }
    };

    const isCreator = function(currentContext){
        const isCreator = JSON.parse(storage.getData('userInfo')).username === currentContext.event.organizer;

        currentContext.isCreator = isCreator;
    } 

    return{
        isLoggedIn,
        isCreator
    } 
}();