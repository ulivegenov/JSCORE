function sortArray(inputArray, sortMethod){
    
    let ascendingOrder = function(a, b){
        return a - b;
    }

    let descendingOrder = function( a, b){
        return b - a;
    }

    let sortingStrategies = {
        'asc' : ascendingOrder,
        'desc' : descendingOrder
    };

    return inputArray.sort(sortingStrategies[sortMethod]);
}
