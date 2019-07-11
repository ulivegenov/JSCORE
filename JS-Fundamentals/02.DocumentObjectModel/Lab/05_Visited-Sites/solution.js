function solve() {

  let sites = document.querySelectorAll('#exercise a');
  
  for (let i = 0; i < sites.length; i++){
    sites[i].addEventListener("click", countVisits);
  }

  function countVisits(){
    let text = this.parentNode.children[1];
    let currentSiteText = text.innerHTML.toString();
    let num = currentSiteText[9];

    if(currentSiteText.length > 16){
      for(let i = 10; i < currentSiteText.length - 6; i++){
        num += currentSiteText[i];
      } 
    }

    let counter = Number(num);
    text.innerHTML = `Visited: ${++counter} times`;

    return text.innerHTML;
  }
}