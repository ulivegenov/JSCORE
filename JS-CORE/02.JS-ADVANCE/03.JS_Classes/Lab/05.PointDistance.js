class Point {
    constructor (xCordinate, yCordinate){
        this.xCordinate = xCordinate;
        this.yCordinate = yCordinate;
    }

    static distance(pointOne, pointTwo ){
        return Math.sqrt((pointOne.xCordinate - pointTwo.xCordinate) ** 2 + (pointOne.yCordinate - pointTwo.yCordinate) ** 2);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));