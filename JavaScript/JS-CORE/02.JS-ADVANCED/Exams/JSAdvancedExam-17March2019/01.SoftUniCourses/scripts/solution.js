function solve() {
   let totalPrice = 0;
   let myCourses = [];

   let prices = {
       'js-fundamentals' : 170,
       'js-advanced' : 180,
       'js-applications' : 190,
       'js-web' : 490
   }

   //GET INPUT DATA
   let fundamentals = document.querySelector('.courseBody ul li input[name="js-fundamentals"]');
   let advanced = document.querySelector('.courseBody ul li input[name="js-advanced"]');
   let applications = document.querySelector('.courseBody ul li input[name="js-applications"]');
   let web = document.querySelector('.courseBody ul li input[name="js-web"]');
   let btnSignMeUp = document.querySelector('.courseFoot button');
   btnSignMeUp.addEventListener('click', signMeUp);

   let onlineForm = document.querySelector('#educationForm input[value="online"]');

   // ADD EVENT LISTENER TO 'SIGN ME UP' BUTTON
   function signMeUp(){
       //CALCULATE TOTAL PRICE
       if(fundamentals.checked){
           totalPrice += prices[fundamentals.getAttribute('name')];
           myCourses.push(fundamentals.parentNode.children[1].textContent);
       }

       if(advanced.checked){
           if(fundamentals.checked){
               totalPrice += prices[advanced.getAttribute('name')]*0.9;
           } else{
               totalPrice += prices[advanced.getAttribute('name')];
           }
           myCourses.push(advanced.parentNode.children[1].textContent);
       }

       if(applications.checked){
           totalPrice += prices[applications.getAttribute('name')];

           if(fundamentals.checked && advanced.checked){
               totalPrice *= 0.94;
           }
           myCourses.push(applications.parentNode.children[1].textContent);
       }

       if(web.checked){
           totalPrice += prices[web.getAttribute('name')];
           myCourses.push(web.parentNode.children[1].textContent);

           if(fundamentals.checked && advanced.checked && applications.checked){
               myCourses.push('HTML and CSS');
           }
       }

       if(onlineForm.checked){
           totalPrice *= 0.94;
       }
       
       //FORMAT OUTPUT
            //TOTALPRICE OUTPUT
            let totalPriceElement = document.querySelector('.courseFoot p');
            totalPriceElement.textContent = `Cost: ${Math.floor(totalPrice).toFixed(2)} BGN`;

            //MY COURSES OUTPUT
            let myCoursesList = document.querySelector('#myCourses .courseBody ul');

            for (let course of myCourses) {
                if(course.startsWith('JS')){
                    course = course.split('-')[0];
                    course = course.split(' ')[0] + '-' + course.split(' ')[1];
                }

                let liElement = document.createElement('li');
                liElement.textContent = course;
                myCoursesList.appendChild(liElement);
            }

        //REMOVE EVENT LISTENER
        btnSignMeUp.removeEventListener('click', signMeUp);
   }
}

solve();