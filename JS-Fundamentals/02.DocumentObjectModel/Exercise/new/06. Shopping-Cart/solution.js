function solve() {
   let sum = 0;
   let boughtProducts = [];
   let addButtons = document.getElementsByClassName('add-product');
   let checkoutButton = document.getElementsByClassName('checkout')[0];

   for (let i = 0; i < addButtons.length; i++) {
      addButtons[i].addEventListener('click', addProductToCart);
   }

   checkoutButton.addEventListener('click', checkout);

   function addProductToCart(e){
      let currentTarget = e.currentTarget;
      let currentProductBlockElement = currentTarget.parentNode.parentNode;
      let currentProductName = currentProductBlockElement.children[1].children[0].textContent;
      let currentProductPrice = Number(currentProductBlockElement.children[3].textContent);
      sum += currentProductPrice;
      
      let textArea = document.getElementsByTagName('textarea')[0];
      textArea.value += `Added ${currentProductName} for ${currentProductPrice.toFixed(2)} to the cart.\n`;
      if(!boughtProducts.includes(currentProductName)){
         boughtProducts.push(currentProductName);
      }
   }

   function checkout(){
      let textArea = document.getElementsByTagName('textarea')[0];
      textArea.value += `You bought ${boughtProducts.join(', ')} for ${sum.toFixed(2)}.`;

      for (let i = 0; i < addButtons.length; i++) {
         addButtons[i].removeEventListener('click', addProductToCart);
      }

      checkoutButton.removeEventListener('click', checkout);
   }
}