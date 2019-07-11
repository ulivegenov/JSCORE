class Vacation{
    constructor(organizer, destination, budget){
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    get numberOfChildren(){
        let num = 0;
        for (const grade in this.kids) {
            for (const kid of this.kids[grade]) {
                num++;
            }
        }
        return num;
    }

    registerChild(name, grade, budget){
        if(budget < this.budget){
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }   

        if(!this.kids.hasOwnProperty(grade)){
            this.kids[grade] = [];
        }

        for (const kid of this.kids[grade]) {
            let kidName = kid.split('-')[0];

            if(kidName === name){
                return `${name} is already in the list for this ${this.destination} vacation.`;
            }
        }

        this.kids[grade].push(`${name}-${budget}`);

        return this.kids[grade];
    }

    removeChild(name, grade){
       if(!this.kids.hasOwnProperty(grade)){
           return `We couldn't find ${name} in ${grade} grade.`;
       }

       for (let i = 0; i < this.kids[grade].length; i++) {
           let kidName = this.kids[grade][i].split('-')[0];
           
           if(name === kidName){
               this.kids[grade].splice(i, 1);
               return this.kids[grade];
           }
       }

       return `We couldn't find ${name} in ${grade} grade.`;
    }

    toString(){
        if(this.numberOfChildren === 0){
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        }

        let result = [];
        Object.entries(this.kids).sort((a,b) => a[0] - b[0]);
        for (const grade in this.kids) {
            result.push(`Grade: ${grade}`);
            for (let i = 0; i < this.kids[grade].length; i++) {
                result.push(`${i+1}. ${this.kids[grade][i]}`);
            }
        }

        result.unshift(`${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}`);

        return result.join('\n') + '\n';
    }
}

let vacation = new Vacation('Mr Pesho', 'San diego', 2000);
console.log(vacation.registerChild('Gosho', 5, 2000));
console.log(vacation.registerChild('Lilly', 6, 2100));
console.log(vacation.registerChild('Pesho', 6, 2400));
console.log(vacation.registerChild('Gosho', 5, 2000));
console.log(vacation.registerChild('Tanya', 5, 6000));
console.log(vacation.registerChild('Mitko', 10, 1590));
console.log('----------------------------------------');
let vacation2 = new Vacation('Mr Pesho', 'San diego', 2000);
vacation2.registerChild('Gosho', 5, 2000);
vacation2.registerChild('Lilly', 6, 2100);
console.log(vacation2.removeChild('Gosho', 9));
vacation2.registerChild('Pesho', 6, 2400);
vacation2.registerChild('Gosho', 5, 2000);
console.log(vacation2.removeChild('Lilly', 6));
console.log(vacation2.registerChild('Tanya', 5, 6000));
console.log('----------------------------------------');
let vacation3 = new Vacation('Miss Elizabeth', 'Dubai', 2000);
vacation3.registerChild('Mitko', 10, 5500);
vacation3.registerChild('Gosho', 5, 3000);
vacation3.registerChild('Lilly', 6, 1500);
vacation3.registerChild('Pesho', 7, 4000);
vacation3.registerChild('Tanya', 5, 5000);

console.log(vacation3.toString());


