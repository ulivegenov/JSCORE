function solve() {
    
    let matrixes = document.querySelectorAll('#exercise form div input');
    let matrixOne = JSON.parse(matrixes[0].value);
    let matrixTwo = JSON.parse(matrixes[1].value);

    dotProduct(matrixOne, matrixTwo);

    function dotProduct(matrixOne, matrixTwo){

        let resultDiv = document.getElementById('result');
        
        for(let firstCurrentArray = 0; firstCurrentArray < matrixOne.length; firstCurrentArray++){
            let resultString = '';

            for(secondCurrentArray = 0; secondCurrentArray < matrixTwo.length; secondCurrentArray++){
                let currentResultElement = 0;

                for(let i = 0; i < matrixOne[firstCurrentArray].length; i++){
                    currentResultElement += matrixOne[firstCurrentArray][i] * matrixTwo[secondCurrentArray][i];
                }

                if(secondCurrentArray !== matrixTwo.length - 1){
                    resultString += String(currentResultElement);
                    resultString += ',';
                    resultString += ' ';
                } else{
                    resultString += String(currentResultElement);
                }
            }

            let currentParagrph = document.createElement('p');
            currentParagrph.innerHTML = resultString.trim();
            resultDiv.appendChild(currentParagrph);
        }
    }
}