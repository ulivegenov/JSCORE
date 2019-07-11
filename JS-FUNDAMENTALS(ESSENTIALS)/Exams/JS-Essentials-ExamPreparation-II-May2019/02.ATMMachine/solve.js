function atmMachine(input){
    let totalCashInATM = 0;
    let atmBanknotes = [];
    for (let currentCommand of input) {
        switch(currentCommand.length){
            case 2 : withdraw(currentCommand);
            break;
            case 1 : report(currentCommand);
            break;
            default : insert(currentCommand);
            break;
        }
    }

    function insert(banknotes){
        for(let i = 0; i < banknotes.length; i++){
            atmBanknotes.push(banknotes[i]);
        }
        atmBanknotes.sort((a,b) => b-a);
        let insertedCash = banknotes.reduce((a,b) => a+b);
        totalCashInATM += insertedCash;

        console.log(`Service Report: ${insertedCash}$ inserted. Current balance: ${totalCashInATM}$.`);
    }

    function withdraw(sums){
        let personAccountBalance = Number(sums.shift());
        let moneyToWithdraw = Number(sums.shift());

        if(personAccountBalance < moneyToWithdraw){
            console.log(`Not enough money in your account. Account balance: ${personAccountBalance}$.`);
        } else if(totalCashInATM < moneyToWithdraw){
            console.log(`ATM machine is out of order!`);
        } else{
            let withdraw = 0;
            let remainingToWitdraw = moneyToWithdraw
            for (let i = 0; i < atmBanknotes.length; i++) {
                if(atmBanknotes[i] <= remainingToWitdraw){
                    withdraw += Number(atmBanknotes.splice(i, 1));
                    remainingToWitdraw = moneyToWithdraw - withdraw;
                    i--;
                } 

                if(withdraw === moneyToWithdraw){
                    break;
                }   
            }

            personAccountBalance -= withdraw;

            totalCashInATM -= withdraw;
            console.log(`You get ${withdraw}$. Account balance: ${personAccountBalance}$. Thank you!`);
        }
    }

    function report(banknote){
        let counter = 0;
        for (let i = 0; i < atmBanknotes.length; i++) {
            if(banknote == atmBanknotes[i]){
                counter++;
            }
        }

        console.log(`Service Report: Banknotes from ${banknote}$: ${counter}.`)
    }
}

atmMachine([[20, 5, 100, 20, 1],
            [457, 25],
            [1],
            [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
            [20, 85],
            [5000, 4500],]);