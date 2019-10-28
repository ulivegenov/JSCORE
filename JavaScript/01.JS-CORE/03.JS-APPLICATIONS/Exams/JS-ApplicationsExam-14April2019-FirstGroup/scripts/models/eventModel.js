const eventModel = function(){
    const createEvent = function(params){
        const data = {
            ...params,
            peopleInterestedIn : 0,
            organizer : JSON.parse(storage.getData('userInfo')).username
        }

        const url = `/appdata/${storage.appKey}/events`;
        const token = JSON.parse(storage.getData('authToken'));
        const authString = `Kinvey ${token}`;

        const headers = {
            body : JSON.stringify(data),
            headers : {
                Authorization : authString,
                'Content-type' : 'application/json',
            }
        }

        return requester.post(url, headers); /* --> Calling requester in helpers. */
    }

    const getAllEvents = function(){

        const url = `/appdata/${storage.appKey}/events`;
        const token = JSON.parse(storage.getData('authToken'));
        const authString = `Kinvey ${token}`;

        const headers = {
            headers : {
                Authorization : authString,
                'Content-type' : 'application/json',
            }
        }

        return requester.get(url, headers); /* --> Calling requester in helpers. */
    };

    const getEvent = function(id){
        const eventId = id
        const url = `/appdata/${storage.appKey}/events/${eventId}`;
        const token = JSON.parse(storage.getData('authToken'));
        const authString = `Kinvey ${token}`;
        const headers = {
            headers : {
                Authorization : authString,
                'Content-type' : 'application/json',
            }
        }

        return requester.get(url, headers); /* --> Calling requester in helpers. */
    }

    const editEvent = function(params){
        // console.log(params);
        // const url = `/appdata/${storage.appKey}/events/${params.eventId}`;
        // const data = { ...params }
        // delete data.eventId;
        
        // const token = JSON.parse(storage.getData('authToken'));
        // const authString = `Kinvey ${token}`;
        // const headers = {
        //     body : JSON.stringify(data),
        //     headers : {
        //         Authorization : authString,
        //         'Content-type' : 'application/json',
        //     }
        // }

        // return requester.put(url, headers); /* --> Calling requester in helpers. */
    }

    return {
        createEvent,
        getAllEvents,
        getEvent,
        editEvent
    }
}();