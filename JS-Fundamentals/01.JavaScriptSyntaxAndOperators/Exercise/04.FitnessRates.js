function solve(dayOfWeek, service, time){

    let weeklyPrices = {"Fitness" : 5 , "Sauna" : 4, "Instructor" : 10 };
    let weekendPrices = {"Fitness" : 8 , "Sauna" : 7, "Instructor" : 15};
    let priceToPay = 0;

    if(dayOfWeek === "Saturday" || dayOfWeek === "Sunday"){
        switch (service){
            case "Fitness" : priceToPay = weekendPrices.Fitness;
                break;
            case "Sauna" : priceToPay = weekendPrices.Sauna
                break;
            case "Instructor" : priceToPay = weekendPrices.Instructor;
                break;
        }
    }
    else{
        if(Number(time) <= 15){
            switch (service){
                case "Fitness" : priceToPay = weeklyPrices.Fitness;
                    break;
                case "Sauna" : priceToPay = weeklyPrices.Sauna;
                    break;
                case "Instructor" : priceToPay = weeklyPrices.Instructor;
                    break;
            }
        }
        else{
            switch (service){
                case "Fitness" : priceToPay = weeklyPrices.Fitness + 2.5;
                    break;
                case "Sauna" : priceToPay = weeklyPrices.Sauna + 2.5;
                    break;
                case "Instructor" : priceToPay = weeklyPrices.Instructor + 2.5;
                    break;
            }
        }
    }

    console.log(priceToPay);
}

solve('Monday', 'Sauna', 15.30)
