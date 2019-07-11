
    let solution = (function (){
        
        const add = ([xA, yA], [xB,yB]) => {
            return [(xA + xB), (yA + yB)];
        }

        const multiply = ([xA, yA], scalar) => {
            return [xA*scalar, yA*scalar];
        }
        
        const length = ([xA, yA]) => {
            return Math.sqrt(xA**2 + yA**2);
        }
        
        const dot = ([xA,yA], [xB, yB]) => {
            return xA*xB + yA*yB;
        }
        
        const cross = ([xA, yA], [xB, yB]) => {
            return xA*yB - yA*xB;
        }
        
        return {
            add,
            multiply,
            length,
            dot,
            cross
        };
    })();



console.log(solution.add([1, 1], [1, 0]));
console.log(solution.multiply([3.5, -2], 2));
console.log(solution.length([3, -4]));
console.log(solution.dot([1, 0], [0, -1]));
console.log(solution.cross([3, 7], [1, 0]));
