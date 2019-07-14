function attachEvents() {
    let url = `https://blog-apps-c12bf.firebaseio.com/posts.json`;
    let btnLoadPosts = document.getElementById('btnLoadPosts');
    let btnViewPosts = document.getElementById('btnViewPost');
    let postOptions = document.getElementById('posts');
    let postsInfo = [];
    btnLoadPosts.addEventListener('click', loadPosts);
    btnViewPosts.addEventListener('click', viewPosts);

    function loadPosts() {
        fetch(url)
            .then(response => response.json())
            .then((data) => {
                postOptions.innerHTML = '';
                let fragment = document.createDocumentFragment();
                const keys = Object.keys(data);
                for (const key of keys) {
                    const postInfo = data[key];
                    const postTitle = postInfo.title;

                    let currentOption = document.createElement('option');
                    currentOption.textContent = postTitle;
                    currentOption.setAttribute('value', key);
                    fragment.appendChild(currentOption);
                }

                postOptions.appendChild(fragment);
            });
    }

    function viewPosts() {
        const selectedOption = document.getElementById('posts');
        const postId = selectedOption.options[selectedOption.selectedIndex].value;
        let viewUrl = `https://blog-apps-c12bf.firebaseio.com/posts/${postId}.json`;

        fetch(viewUrl)
            .then(response => response.json())
            .then((data) => {
                let postTitleElement = document.getElementById('post-title');
                let postBodyElement = document.getElementById('post-body');
                let postCommentsList = document.getElementById('post-comments');
                postTitleElement.innerHTML = '';
                postBodyElement.innerHTML = '';
                postCommentsList.innerHTML = '';

                let postBody = data.body;
                let postId = data.id;
                let postTitle = data.title;

                let h1Element = document.createElement('h1');
                h1Element.textContent = postTitle;
                let liBodyElement = document.createElement('li');
                liBodyElement.textContent = postBody;

                postTitleElement.appendChild(h1Element);
                postBodyElement.appendChild(liBodyElement);

                const commentsUrl = 'https://blog-apps-c12bf.firebaseio.com/comments.json';

                fetch(commentsUrl)
                .then(response => response.json())
                .then((data) => {
                    let comments = Object.values(data)
                                         .filter(c => c.postId === postId)
                                         .map(c => c.text);
                    for (const comment of comments) {
                        let liCommentElement = document.createElement('li');
                        liCommentElement.textContent = comment;
                        postCommentsList.appendChild(liCommentElement);
                    }
                });
            });
    }
}

attachEvents();