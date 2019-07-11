function solve() {
    let nextBtn = document.querySelectorAll('#buttons button')[0];
    let cancelBtn = document.querySelectorAll('#buttons button')[1];

    cancelBtn.addEventListener('click', function(){
        document.getElementsByTagName('section')[0].style.display = 'none';
    });

    let firstStepDiv = document.getElementById('firstStep');
    let secondStepDiv = document.getElementById('secondStep');
    let thirdStepDiv = document.getElementById('thirdStep');

    let licenseBtns = document.getElementsByName('license');

    Array.from(licenseBtns).forEach(function(currentBtn){
        currentBtn.addEventListener('click', function(){

            currentBtn.setAttribute('checked', '');

            for(let index = 0; index < licenseBtns.length; index++){
                if(licenseBtns[index] != currentBtn){
                    licenseBtns[index].removeAttribute('checked');
                }
            }
        });
    });

    nextBtn.addEventListener('click', function(){

        if(firstStepDiv.display != 'block' && secondStepDiv.display != 'block' && thirdStepDiv.display != 'block'){
            DisplayFirstStep();
        } else if(firstStepDiv.display != 'none' && secondStepDiv.display != 'block' && thirdStepDiv.display != 'block'){
            DisplaySecondStep();
        } else if(firstStepDiv.display != 'block' && secondStepDiv.display != 'none' && thirdStepDiv.display != 'block'){
            DisplayThirdStep()
        }

    })


    function DisplayFirstStep(){
        document.getElementById('content').style.backgroundImage = 'url()';
        firstStepDiv.style.display = 'block';
    }

    function DisplaySecondStep(){
        Array.from(licenseBtns).forEach(function(currentBtn){
            if(currentBtn.hasAttribute('checked') && currentBtn.value == 'agree'){
                    firstStepDiv.style.display = 'none';
                    secondStepDiv.style.display = 'block';
                    nextBtn.style.display = 'none';
            }
        })
    }

    function DisplayThirdStep(){
        setTimeout(function(){
            nextBtn.style.display = 'inline';

            nextBtn.addEventListener('click', function(){
                secondStepDiv.style.display = 'none';
                thirdStepDiv.style.display = 'block';
            });
        }, 3000);
    }
}