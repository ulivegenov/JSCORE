function solve(){

  let contentElement = document.getElementById("input");
  let contentElementValue = String(contentElement.innerHTML);
  let contentElementValueArray = contentElementValue.split(".").filter(x  => x !== "");
  let countOfSentences = Number(contentElementValueArray.length);

  let outputElement = document.getElementById("output");
  let border = countOfSentences;

  if(countOfSentences <= 3){

    for(let i = 0; i < border; i++){
      let paragraphElement = document.createElement('p');
      
      paragraphBuilder(i, paragraphElement);
    }

    outputElement.appendChild(paragraphElement);
  } else{

    if(countOfSentences % 3 === 0){

      border = countOfSentences/3;

      for(let i = 0; i < border; i++){

        let paragraphElement = document.createElement('p');

        for(let j = i * 3; j < i * 3 + 3; j++){
          paragraphBuilder(j, paragraphElement);
        } 

        outputElement.appendChild(paragraphElement);
      }
    } else{

      border = (countOfSentences - (countOfSentences % 3))/3;

      for(let i = 0; i < border; i++){

        let paragraphElement = document.createElement('p');

        for(let j = i * 3; j < i * 3 + 3; j++){
          paragraphBuilder(j, paragraphElement);
        }

        outputElement.appendChild(paragraphElement);      
      }

      border = (countOfSentences - (countOfSentences % 3));

      for(let i = border; i < border + 1; i++){

        let paragraphElement = document.createElement('p');

        paragraphBuilder(i, paragraphElement);

        outputElement.appendChild(paragraphElement);
      }
    }
  }
    
  function paragraphBuilder(sentenceIndex, paragraphElement){
    if(contentElementValueArray[sentenceIndex]){
      paragraphElement.innerHTML += contentElementValueArray[sentenceIndex];
      paragraphElement.innerHTML += ".";
    }
  }
}