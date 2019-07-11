function solve(examPoints, completedHomework, totalHomework){
    const MAX_POINTS = 100;
    const MAX_EXAM_POINTS = 300;
    const MAX_BONUS_IN_PURCENT = 10;
    const bonusInPurcent = completedHomework/totalHomework*MAX_BONUS_IN_PURCENT;
    const purcentExamPoints = examPoints/MAX_EXAM_POINTS*0.9*100;
    const totalPoints =  purcentExamPoints + bonusInPurcent;
    let grade = 3 + 2 * (totalPoints - MAX_POINTS / 5) / (MAX_POINTS / 2);

    if(grade < 3 || grade > 6){
        grade = Math.trunc(grade)
    }
    if(purcentExamPoints >= 90){
        grade = 6;
    }
    console.log(grade.toFixed(2));
}

solve(300, 10, 10);
solve(200, 5, 5);
solve(400, 5, 5);
solve(4, 1, 1);