function solve(countOfSteps, footprintLengthInMeters, speedInKilometersPerHour){

    let distance = countOfSteps*footprintLengthInMeters;
    let speedInMetersPerSecond = speedInKilometersPerHour/3.6;
    let countOfBreaks = Math.trunc(distance/500);
    let timeForBreaksInSeconds = countOfBreaks*60;
    let totalTimeInSeconds = Math.round(distance/speedInMetersPerSecond + timeForBreaksInSeconds);
    let hours = Math.trunc(totalTimeInSeconds/3600);
    let minutes = Math.trunc(totalTimeInSeconds/60 - hours*60);
    let seconds = totalTimeInSeconds - minutes*60 - hours*3600;

    console.log(`${FormatNumber(hours)}:${FormatNumber(minutes)}:${FormatNumber(seconds)}`);

    function FormatNumber(num){

        let formatedNum = ("0" + num).slice(-2);

        return formatedNum;
    }
}

solve(2564, 0.70, 5.5);