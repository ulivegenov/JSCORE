class Hotel{
    constructor(name, capacity){
        this.name = name;
        this.capacity = capacity;
        this.bookings = [];
        this.currentBookingNumber = 1;

        this.roomsPricing = {
            single : 50,
            double : 90,
            maisonette : 135
        };

        this.servicesPricing = {
            food : 10,
            drink : 15,
            housekeeping : 25
        };

        this.roomTypeCapacity = {
            single : Math.floor(this.capacity*0.5),
            double : Math.floor(this.capacity*0.3),
            maisonette : Math.floor(this.capacity*0.2)
        }
    }

    rentARoom(clientName, roomType, nights){
        if(this.roomTypeCapacity[roomType] === 0){
            let message = [`No ${roomType} rooms available!`];
            Object.entries(this.roomTypeCapacity)
                  .filter(e => e[1] > 0)
                  .map(([type, availableRooms]) => {
                      message.push(`Available ${type} rooms: ${availableRooms}.`)
                  });

            return message.join(' ');
        }

        let currentClient = {
            currentBookingNumber : this.currentBookingNumber,
            clientName,
            roomType,
            nights
        }

        this.currentBookingNumber++;
        this.roomTypeCapacity[roomType]--;
        this.bookings.push(currentClient);

        return `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${currentClient.currentBookingNumber}.`
    }

    roomService(currentBookingNumber, serviceType){
        let currentClient = this.bookings.filter(e => e.currentBookingNumber === currentBookingNumber);
        if(currentClient.length === 0){
            return `The booking ${currentBookingNumber} is invalid.`;
        }

        if(!this.servicesPricing[serviceType]){
            return `We do not offer ${serviceType} service.`;
        }

        if(!currentClient[0].hasOwnProperty('services')){
            currentClient[0].services = [];
        }

        currentClient[0].services.push(serviceType);

        return `Mr./Mrs. ${currentClient[0].clientName}, Your order for ${serviceType} service has been successful.`
    }

    checkOut(currentBookingNumber){
        let currentClient = this.bookings.filter(e => e.currentBookingNumber === currentBookingNumber);
        if(currentClient.length === 0){
            return `The booking ${currentBookingNumber} is invalid.`;
        }

        let totalMoney = this.roomsPricing[currentClient[0].roomType]*currentClient[0].nights;
        this.roomTypeCapacity[currentClient.roomType]++;
        let currentClientIndex = this.bookings.findIndex(e => e.currentBookingNumber === currentBookingNumber);
        this.bookings.splice(currentClientIndex, 1);

        if(currentClient[0].hasOwnProperty('services')){
            let totalServiceMoney = 0;
            for (const service of currentClient[0].services) {
                totalServiceMoney += this.servicesPricing[service];
            }

            return `We hope you enjoyed your time here, Mr./Mrs. ${currentClient[0].clientName}. The total amount of money you have to pay is ${totalMoney + totalServiceMoney} BGN. You have used additional room services, costing ${totalServiceMoney} BGN.`
        }

        return `We hope you enjoyed your time here, Mr./Mrs. ${currentClient[0].clientName}. The total amount of money you have to pay is ${totalMoney} BGN.`
    }

    report(){
        let output = [`${this.name.toUpperCase()} DATABASE:`]
        let dashes = '';
        for (let i = 0; i < 20; i++) {
            dashes +='-';
        }

        output.push(dashes);
        
        if(this.bookings.length === 0){
            output.push('There are currently no bookings.')
            return output.join('\n');
        }

        for (const client of this.bookings) {
            output.push(`bookingNumber - ${client.currentBookingNumber}`);
            output.push(`clientName - ${client.clientName}`);
            output.push(`roomType - ${client.roomType}`);
            output.push(`nights - ${client.nights}`);

            if(client.services){
                output.push(`services: ${client.services.join(', ')}`);
            }

            dashes = '';
            for (let i = 0; i < 10; i++) {
                dashes +='-';
            }

            output.push(dashes);
        }

        output.splice(output.length-1, 1);

        return output.join('\n');
    }
}

let hotel = new Hotel('HotUni', 10);

hotel.rentARoom('Peter', 'single', 4);
hotel.rentARoom('Robert', 'double', 4);
hotel.rentARoom('Geroge', 'maisonette', 6);

hotel.roomService(3, 'housekeeping');
hotel.roomService(3, 'drink');
hotel.roomService(2, 'room');
hotel.checkOut(1); 

console.log(hotel.report());




