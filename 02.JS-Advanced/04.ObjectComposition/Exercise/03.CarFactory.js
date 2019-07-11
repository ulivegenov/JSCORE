let car = function (order){
    let model = (function(){
        return order.model.toString();
    })();

    let engine = (function(){
        let engines = {
            small : {power : 90, volume : 1800},
            normal : {power : 120, volume : 2400},
            monster : {power : 200, volume : 3500}
        }

        if(order.power <= engines.small.power){
            return engines.small;
        } else if( order.power <= engines.normal.power){
            return engines.normal;
        } else{
            return engines.monster;
        }
    })();

    let carriage = (function(){
        let carriages = {
            hatchback : {type : 'hatchback', color : order.color},
            coupe : {type: 'coupe', color : order.color}
        };

        if(order.carriage === 'hatchback'){
            return carriages.hatchback;
        } else{
            return carriages.coupe;
        }
    })();

    let wheels = (function(){
        let wheels = [];
        if(order.wheelsize % 2 === 0){
            order.wheelsize--;
        }

        for (let index = 0; index < 4; index++){
            wheels.push(order.wheelsize);
        }

        return wheels;
    })();

    return{
        model,
        engine,
        carriage,
        wheels
    }   
};

console.log(car({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }));