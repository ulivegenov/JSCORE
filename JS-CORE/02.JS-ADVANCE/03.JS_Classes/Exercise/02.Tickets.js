function sortTickets(ticketsArray, sortingCriterion){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (const currentElement of ticketsArray) {
        let data = currentElement.split('|');
        let currentDestination = data[0];
        let currentPrice = Number(data[1]);
        let currentStatus = data[2];

        let currentTicket = new Ticket(currentDestination, currentPrice, currentStatus);
        tickets.push(currentTicket);
    }

    tickets = sortArray(tickets, sortingCriterion);

    return tickets;

    function sortArray(array, sortingCriterion){

        if(sortingCriterion === 'destination'){
            array = array.sort((a, b) => {
                if(a.destination < b.destination){
                    return -1;
                } else if(a.destination > b.destination){
                    return 1;
                }
            });
        } else if(sortingCriterion === 'price'){
            array = array.sort((a, b) => a.price > b.price);
        } else if(sortingCriterion === 'status'){
            array = array.sort((a, b) => {
                if(a.status < b.status){
                    return -1;
                } else if(a.status > b.status){
                    return 1;
                }
            });
        }

        return array;
    }
}

console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'));

console.log('-------------------------------------');

console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'));

console.log('-------------------------------------');

console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'price'));


