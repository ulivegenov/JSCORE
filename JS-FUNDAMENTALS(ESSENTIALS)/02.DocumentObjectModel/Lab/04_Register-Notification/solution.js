
 function register() {
   let usernameElement = document.querySelector("#username");
   let emailElement = document.querySelector("#email");
   let passwordElement = document.querySelector("#password");

   let usernameElementValue = usernameElement.value;
   let emailElementValue = emailElement.value;
   let passwordElementValue = passwordElement.value;
   let pattern = new RegExp('(.+)@(.+).(com|bg)/gm');

   let usernameValidation = usernameElementValue !== "";
   let emailValidation = pattern.test(emailElementValue);
   let passwordValidation = passwordElementValue !== "";

   let resultElement = document.querySelector("#result");

   let clear = setTimeout(() => {
    resultElement.remove();
  }, 5000);

   if(usernameValidation && emailValidation && passwordValidation){

     let titleElement = document.createElement("h1");
     titleElement.innerHTML ="Successful Registration!";
     resultElement.appendChild(titleElement);
     //console.log(resultElement);
     
     let usenameResultElement = document.createTextNode(`Username: ${usernameElementValue}`);
     resultElement.appendChild(usenameResultElement);
     let br = document.createElement("br");
     resultElement.appendChild(br);

     let emailResultElement = document.createTextNode(`Email: ${emailElementValue}`);
     resultElement.appendChild(emailResultElement);
     let br2 = document.createElement("br");
     resultElement.appendChild(br2);

     let passwordResultElement = document.createTextNode(`Password: ${starsApender(passwordElementValue.length)}`);
     resultElement.appendChild(passwordResultElement);

     //clearSuccesfulMessage();
   }

   function starsApender(num){
     let resultString ="";
     for(let i = 0; i < num; i++){
       resultString += "*";
     }
     return resultString;
   }

   function clearSuccesfulMessage(){
     return clear;
   }
 }
