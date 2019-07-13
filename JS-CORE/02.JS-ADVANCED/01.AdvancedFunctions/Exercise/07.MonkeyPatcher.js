function solution(commandName){

    let commands = {
        upvote: () => this.upvotes++,
        downvote: () => this.downvotes++,
        score: () => {
            let rating = '';
            let reportedUpvotes = this.upvotes;
            let reportedDownvotes = this.downvotes;
            let balance = this.upvotes - this.downvotes;

            if((this.upvotes + this.downvotes) > 50){
                let valueToAdd = Math.ceil(Math.max(this.upvotes, this.downvotes) * 0.25);
                reportedUpvotes += valueToAdd;
                reportedDownvotes += valueToAdd;
            }

            if((this.upvotes + this.downvotes) < 10){
                rating = 'new';
            } else if((balance) < 0){
                rating = 'unpopular';
            } else if((this.upvotes/(this.upvotes + this.downvotes) * 100) > 66){
                rating = 'hot';
            } else if(((this.upvotes - this.downvotes) >= 0) && ((this.upvotes > 100) || (this.downvotes > 100))){
                rating = 'controversial';
            } else{
                rating = 'new';
            }

            return [reportedUpvotes, reportedDownvotes, balance, rating];
        }
    }

    return commands[commandName]();
}


let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
console.log(post.upvotes);
console.log(post.downvotes);
console.log(solution.call(post, 'score')); // [127, 127, 0, 'controversial']
for (let i = 0; i < 50; i++) {
    solution.call(post, 'downvote');  
}                                      // (executed 50 times)
console.log(solution.call(post, 'score')); // [139, 189, -50, 'unpopular']