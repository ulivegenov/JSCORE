function solve() {

   let buttons = Array.from(document.getElementsByTagName('button'));

   for(let i = 0; i < buttons.length; i++){
      buttons[i].addEventListener('click', clickEvent);
   }

   function clickEvent(e){

      let profile = e.target.parentNode;
      let isLocked = profile.getElementsByTagName('input')[0];
      let button = profile.getElementsByTagName('button')[0];

      if(!isLocked.checked && button.textContent === 'Show more'){
         profile.getElementsByTagName('div')[1].style.display = 'block';
         button.textContent = 'Hide it';
      } else if(!isLocked.checked && button.textContent === 'Hide it'){
         profile.getElementsByTagName('div')[1].style.display = 'none';
         button.textContent = 'Show more';
      }
   }
} 