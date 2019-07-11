function solve(){
    let fib = (function () {

        let firstNum = 0;
        let secondNum = 1;

        return function(){
            let result = secondNum;
            let sum = firstNum + secondNum;
            firstNum = secondNum;
            secondNum = sum;

            return result;
        }
    })();

    return fib;

    //console.log(fib());
    //console.log(fib());
    //console.log(fib());
    //console.log(fib());
}

solve();