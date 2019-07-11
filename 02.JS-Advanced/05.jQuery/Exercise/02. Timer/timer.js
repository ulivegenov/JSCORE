function timer() {

   let time = 0,
   interval,
   isRunning = false;

   $('#start-timer').on('click', function(){
      if(!isRunning){
         interval = setInterval(step, 1000);
         isRunning = true;
      }
   });

   $('#stop-timer').on('click', function(){
      clearInterval(interval);
      isRunning = false;
   });

   function step(){
      time++;

      $('#hours').text(("0" + Math.trunc(time/3600)).slice(-2));
      $('#minutes').text(("0" + Math.trunc((time/60)%60)).slice(-2));
      $('#seconds').text(("0" + Math.trunc(time%60)).slice(-2));
   }
}