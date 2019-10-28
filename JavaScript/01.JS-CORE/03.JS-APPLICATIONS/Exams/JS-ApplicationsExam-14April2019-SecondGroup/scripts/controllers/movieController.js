const movieController = function(){
    const getCreateMovie = function(context){
        helper.addHeaderInfo(context);
        context.loadPartials({
            header : './views/common/header.hbs',
            footer : './views/common/footer.hbs'
        })
        .then(function(){
            this.partial('./views/movie/addMovie.hbs');
        });   
    }

    const postCreateMovie = function(context){
        const data = { ...context.params };

        requester.post('movies', 'appdata', 'Kinvey', data)
        .then(helper.handler)
        .then(() => {
            context.redirect('#/home');
        });
    };

    const getAllMovies = async function(context){
        
        helper.addHeaderInfo(context);
        try {
            const response = await requester.get('movies' , 'appdata', 'Kinvey');
            const movies = await response.json();
            context.movies = movies.sort((a,b) => b.tickets - a.tickets);
            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs',
                movie : './views/movie/movie.hbs'
            })
            .then(function(){
                this.partial('./views/movie/allMovies.hbs');
            });
        } catch (error) {
            console.log(error.message);
        }

        // requester.get('movies' , 'appdata', 'Kinvey')
        // .then(helper.handler)
        // .then((movies) => {
        //     context.movies = movies.sort((a,b) => b.tickets - a.tickets);
        //     context.loadPartials({
        //         header : './views/common/header.hbs',
        //         footer : './views/common/footer.hbs',
        //         movie : './views/movie/movie.hbs'
        //     })
        //     .then(function(){
        //         this.partial('./views/movie/allMovies.hbs');
        //     });
        // });
    };

    const getMyMovies = async function(context){
        const currentUserId = sessionStorage.getItem('id');
        
        helper.addHeaderInfo(context);
        try {
            const response = await requester.get('movies' , 'appdata', 'Kinvey');
            const movies = await response.json();
            context.movies = movies.filter(m => m._acl.creator === currentUserId);
            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs',
                myMovie : './views/movie/myMovie.hbs'
            })
            .then(function(){
                this.partial('./views/movie/myMovies.hbs');
            });
        } catch (error) {
            console.log(error.message);
        }
    }

    const getEditMovie = async function(context){
        const id = context.params.movieId;
        helper.addHeaderInfo(context);

        requester.get(`movies/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((movie) => {
            context.movie = movie; 

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/movie/editMovie.hbs');
            });
        });
    }

    const postEditMovie = function(context){
        const id = context.params.movieId;
        const data = {...context.params};
        delete data.id;
        helper.addHeaderInfo(context);

        requester.put(`movies/${id}`, 'appdata', 'Kinvey', data)
        .then(helper.handler)
        .then(() => {
            context.redirect('#/myMovies');
        });
    };

    const getDetails = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.movieId;
        
        requester.get(`movies/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((movie) => {
            context.movie = movie; 

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/movie/detailsMovie.hbs');
            });
        });
    };

    const getDeleteMovie = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.movieId;
        
        requester.get(`movies/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((movie) => {
            context.movie = movie; 

            context.loadPartials({
                header : './views/common/header.hbs',
                footer : './views/common/footer.hbs'
            })
            .then(function(){
                this.partial('./views/movie/deleteMovie.hbs');
            });
        });
    };

    const postDeleteMovie = function(context){
        const id = context.params.movieId;
        helper.addHeaderInfo(context);

        requester.del(`movies/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then(() => {
            context.redirect('#/home');
        });
    };

    const getBuyTicket = function(context){
        helper.addHeaderInfo(context);
        const id = context.params.movieId;
        
        requester.get(`movies/${id}`, 'appdata', 'Kinvey')
        .then(helper.handler)
        .then((movie) => {
            movie.tickets--;
            context.movie = movie;
            const data = context.movie; 

            requester.put(`movies/${id}`, 'appdata', 'Kinvey', data)
            .then(helper.handler)
            .then(() => {
                context.redirect('#/allMovies');
            }); 
        });
    };

    return {
        getCreateMovie,
        postCreateMovie,
        getAllMovies,
        getMyMovies,
        getEditMovie,
        postEditMovie,
        getDetails,
        getDeleteMovie,
        postDeleteMovie,
        getBuyTicket
    }
}();