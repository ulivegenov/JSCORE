class SrotedList{
    constructor(){
        this.elements = [];
        this.size = 0;
    }

    add(element){
        this.elements.push(element);
        this.size++;
        this.elements.sort((a, b) => a - b);
    }

    remove(index){
        if(index >= 0 && index < this.elements.length && this.size > 0){
            this.elements.splice(index, 1);
        } else{
            throw Error('Invalid index!');
        }

        this.size--;
    }

    get(index){
        if(index >= 0 && index < this.elements.length && this.size > 0){
            return this.elements[index];
        } else{
            throw Error('Invalid index!');
        }
    }
}

try {
    sortedList = new SrotedList();
    sortedList.add(3);
    sortedList.add(1);
    sortedList.add(9);
    sortedList.add(10);
    sortedList.add(5);
    sortedList.remove(3);
    console.log(sortedList);
    console.log(sortedList.get(3));
    sortedList.remove(15);
} catch (Error) {
    console.log(Error.message);
}