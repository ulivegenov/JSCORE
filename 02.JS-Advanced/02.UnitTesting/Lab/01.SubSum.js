function subSum(arr, startIndex, endIndex){

    if(!Array.isArray(arr)){
        return NaN;
    }

    if(arr.length === 0){
        return 0;
    }

    if(startIndex < 0){
        startIndex = 0;
    }

    if(endIndex >= arr.length){
        endIndex = arr.length - 1;
    }

    let subArr = Array.from(arr).slice(startIndex, endIndex + 1);
    console.log(subArr);

    for (const element of subArr) {
        if(!Number(element)){
            return NaN;
        }
    }

    let result = subArr.map(Number)
                       .reduce((a, b) => a + b);

    return result;
}
