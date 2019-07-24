(function stringExtension(){
    String.prototype.ensureStart = function(str){
        if(!this.startsWith(str)){
            return str + this.toString();
        } else{
            return this.toString();
        }
    };

    String.prototype.ensureEnd = function(str){
        if(!this.endsWith(str)){
            return this.toString() + str;
        } else{
            return this.toString();
        }
    };

    String.prototype.isEmpty = function(){
        if(this.toString() === ''){
            return true;
        } else{
            return false;
        }
    };

    String.prototype.truncate = function(n){
        if(n < 4){
            return '.'.repeat(n);
        } else if(this.length <= n){
            return this.toString();
        } else if(this.indexOf(' ') === -1){
            return this.substr(0, n - 3) + '...';
        } else if(this.length > n){
            let result = [];
            let data = this.split(' ');

            while ((result.join(' ').length + 3) < n) {
                result.push(data.shift());
            }

            if(result.join(' ').length + 3 > n){
                result.pop();
            }
            
            return result.join(' ') + '...';
        }
    };

    String.format = function (string, ...params) {
        for(let i=0; i<params.length; i++){
            let index = string.indexOf("{"+i+"}");
            while (index != -1) {
                string = string.replace("{"+i+"}", params[i]);
                index = string.indexOf("{"+i+"}");
            }
        }
        return string;
}
})();