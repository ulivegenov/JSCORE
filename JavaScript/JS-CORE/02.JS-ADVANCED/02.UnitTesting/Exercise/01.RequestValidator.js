function requestValidator(obj){
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriRegex = new RegExp(/^[A-Za-z0-9.]+$/gm);
    let validVersion = ['HTTP/0.9','HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let messageRegex = new RegExp(/[<>\\&'"]+/g);

    if(obj.hasOwnProperty('method')){
        if(!validMethods.includes(obj['method'])){
            throw Error('Invalid request header: Invalid Method');
        }
    } else{
        throw Error('Invalid request header: Invalid Method');
    }

    if(obj.hasOwnProperty('uri')){
        if((!uriRegex.test(obj['uri'])) && (obj['uri'] !== '*')){
            throw Error('Invalid request header: Invalid URI');
        }
    } else{
        throw Error('Invalid request header: Invalid URI');
    }

    if(obj.hasOwnProperty('version')){
        if(!validVersion.includes(obj['version'])){
            throw Error('Invalid request header: Invalid Version');
        }
    } else{
        throw Error('Invalid request header: Invalid Version');
    }

    if(obj.hasOwnProperty('message')){
        if(messageRegex.test(obj['message'])){
            throw Error('Invalid request header: Invalid Message');
        }
    } else{
        throw Error('Invalid request header: Invalid Message');
    }

    return obj;
}

try {
    console.log(requestValidator({
        method: 'GET',
        uri: 'svn.public.catalog',
        version: 'HTTP/1.1',
        message: 'a'
      }));
} catch (error) {
    console.log(error.message);
}
