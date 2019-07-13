class CheckingAccount{
    constructor(clientId, email, firstName, lastName){
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.products = [];
    }

    get clientId(){
        return this._clientId;
    }

    set clientId(clientId){

        const regex = /^[0-9]{6}$/gm;

        if(!regex.test(clientId)){
            throw new TypeError('Client ID must be a 6-digit number');
        }

        this._clientId = clientId;
    }

    get email(){
        return this._email;
    }

    set email(email){
        const regex = /\w+@[a-zA-Z\.]+/gm;

        if(!regex.test(email)){
            throw new TypeError('Invalid e-mail');
        }

        this._email = email;
    }

    get firstName(){
        return this._firstName;
    }

    set firstName(name){
        const regex = /^[a-zA-Z]{3,20}$/gm;

        if(name.length < 3 || name.length > 20){
            throw new TypeError('First name must be between 3 and 20 characters long');
        }

        if(!regex.test(name)){
            throw new TypeError('First name must contain only Latin characters');
        }

        this._firstName = name;
    }

    get lastName(){
        return this._lastName;
    }

    set lastName(name){
        const regex = /^[a-zA-Z]{3,20}$/gm;

        if(name.length < 3 || name.length > 20){
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }

        if(!regex.test(name)){
            throw new TypeError('Last name must contain only Latin characters');
        }
        this._lastName = name;
    }
}


try {
    let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov');
} catch (TypeError) {
    console.log(TypeError.message);
}
