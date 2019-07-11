function solve() {
  let answers = document.getElementsByClassName('answer-wrap');

  for (let i = 0; i < answers.length; i++) {
    answers[i].addEventListener('click', clilckAnswer);
  }

  let rightAnswers = 0;
  let currentQuestion = 0;

  function clilckAnswer(e){
    let currentTarget = e.currentTarget;
    let quizIndex = currentTarget.parentNode.getAttribute('data-quizIndex');
    
    if((currentQuestion % 2 === 0 && quizIndex === '2') || (currentQuestion % 2 !== 0) && quizIndex === '4'){
      rightAnswers++;
    }

    let sections = document.getElementsByTagName('section');
    sections[currentQuestion].style.display = 'none';
    if(currentQuestion < 2){
      sections[currentQuestion + 1].style.display = 'block';
    } else{
      let result = document.querySelector('#results li h1');
      if(rightAnswers === 3){
        result.textContent = 'You are recognized as top JavaScript fan!';
      } else {
        result.textContent = `You have ${rightAnswers} right answers`
      }

      result.parentNode.parentNode.style.display = 'block';
    }
    
    currentQuestion++;
  }
}
