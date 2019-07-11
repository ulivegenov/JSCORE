function extensibleObject(){
    let obj = {
        extend : function(template){
            for (const parentProp of Object.keys(template)) {
                if(typeof(template[parentProp]) == 'function'){
                    Object.getPrototypeOf(obj)[parentProp] = template[parentProp]
                } else{
                    obj[parentProp] = template[parentProp];
                }
            }
        }
    };

    return obj;
}