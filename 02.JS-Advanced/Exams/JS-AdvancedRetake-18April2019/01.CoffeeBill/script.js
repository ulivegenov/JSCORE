function addProduct() {
    //GET INPUT DATA
    let productName = document.querySelector('input[type="text"]').value;
    let productPrice = document.querySelector('input[type="number"]').value;
    
    //ADD PRODUCT TO THE LIST
    if(productName && productPrice > 0){
        let productList = document.getElementById('product-list');
        let totalPriceElement = document.querySelectorAll('tfoot tr td')[1];
        let totalPrice = Number(totalPriceElement.textContent) + Number(productPrice);
        
        let trElement = document.createElement('tr');
        let tdNameElement = document.createElement('td');
        let tdPriceElement = document.createElement('td');

        tdNameElement.textContent = productName;
        tdPriceElement.textContent = productPrice;
        trElement.appendChild(tdNameElement);
        trElement.appendChild(tdPriceElement);
        productList.appendChild(trElement);
        
        totalPriceElement.textContent = totalPrice;
    }

    //CLEAR INPUT BOXES
    document.querySelector('input[type="text"]').value = '';
    document.querySelector('input[type="number"]').value = '';   
}