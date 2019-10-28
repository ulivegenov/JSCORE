const offerController = function(){
    const getCreateOffer = function(context){
        helper.addHeaderInfo(context);
        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/offer/createOffer.hbs');
        });   
    };

    const postCreateOffer = function(context){
        const data = { ...context.params };

        helper.notify('loading');

        requester.post('offers', 'appdata', 'Kinvey', data)
        .then(helper.handler)
        .then(() => {
            helper.stopNotify();
            helper.notify('success', 'Offer created successfully.');
            context.redirect('#/allOffers');
        });
    };

    const getAllOffers = async function(context){
        
        helper.addHeaderInfo(context);
        try {
            const response = await requester.get('offers' , 'appdata', 'Kinvey');
            const offers = await response.json();
            context.offers = offers
            console.log(context.offers);
            for (const offer of context.offers) {
                offer.isCreator = offer._acl.creator === sessionStorage.getItem('id');
            }
            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs',
                offer : './views/offer/offer.hbs',
                noOffers : './views/offer/noOffers.hbs'
            })
            .then(function(){
                this.partial('./views/offer/allOffers.hbs');
            });
        } catch (error) {
            console.log(error.message);
        }
    };

    const getEditOffer = async function(context){
        const id = context.params.offerId;
        helper.addHeaderInfo(context);

        requester.get(`offers/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((offer) => {
            context.offer = offer; 

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/offer/editOffer.hbs');
            });
        });
    }

    const postEditOffer = function(context){
        const id = context.params.offerId;
        const data = {...context.params};
        delete data.id;
        helper.addHeaderInfo(context);
        helper.notify('loading');

        requester.put(`offers/${id}`, 'appdata', 'Kinvey', data)
        .then(helper.handler)
        .then(() => {
            helper.stopNotify();
            helper.notify('success', 'Offer edited successfully.');
            context.redirect('#/allOffers');
        });
    };

    const getDetails = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.offerId;
        
        requester.get(`offers/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((offer) => {
            context.offer = offer; 

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/offer/detailsOffer.hbs');
            });
        });
    };

    const getDeleteOffer = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.offerId;
        
        requester.get(`offers/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((offer) => {
            context.offer = offer; 

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/offer/deleteOffer.hbs');
            });
        });
    };

    const postDeleteOffer = function(context){
        const id = context.params.offerId;
        helper.addHeaderInfo(context);

        helper.notify('loading');

        requester.del(`offers/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then(() => {
            helper.stopNotify();
            helper.notify('success', 'Offer edited successfully.');

            context.redirect('#/allOffers');
        });
    };

    return {
        getCreateOffer,
        postCreateOffer,
        getAllOffers,
        getEditOffer,
        postEditOffer,
        getDetails,
        getDeleteOffer,
        postDeleteOffer,
    }
}();