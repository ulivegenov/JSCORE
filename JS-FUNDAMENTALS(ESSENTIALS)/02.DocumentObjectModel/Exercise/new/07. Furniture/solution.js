function solve() {
  
  let generateButton = document.getElementsByTagName('button')[0];
  let buyButton = document.getElementsByTagName('button')[1];

  generateButton.addEventListener('click', generateProduct);
  buyButton.addEventListener('click', buyProducts);

  function generateProduct(){
    let textarea = document.querySelector('#container #exercise textarea');
    let inputArray = JSON.parse(textarea.value);
    let table = document.getElementsByTagName('tbody')[0];

    for (let product of inputArray) {
      let productName = product['name'];
      let productImage = product['img'];
      let productPrice = Number(product['price']);
      let productDecFactor = Number(product['decFactor']);

      let tableRow = document.createElement('tr');

      let tdOne = document.createElement('td');
      let image = document.createElement('img');
      image.setAttribute('src', productImage);
      tdOne.appendChild(image);
      tableRow.appendChild(tdOne);

      generateTd(productName, tableRow);
      generateTd(productPrice, tableRow);
      generateTd(productDecFactor, tableRow);

      let tdFive = document.createElement('td');
      let markField = document.createElement('input');
      markField.setAttribute('type', 'checkbox');
      tdFive.appendChild(markField);
      tableRow.appendChild(tdFive);

      table.appendChild(tableRow);
    }
  }

  function generateTd(text, tableRow){
    let td = document.createElement('td');
    let p = document.createElement('p');
    p.textContent = text;
    td.appendChild(p);
    tableRow.appendChild(td);
  }


  function buyProducts(){
    let boughtProducts = [];
    let totalPrice = 0;
    let sumDecFactor = 0;
    let checkedProducts = 0;

    let products = document.getElementsByTagName('input');

    for (let i = 0; i < products.length; i++) {
      if(products[i].checked === true){
        checkedProducts++;

        let currentRow = products[i].parentNode.parentNode;
        let currentPrice = currentRow.children[2].children[0].textContent;
        totalPrice += Number(currentPrice);

        let currentDecFactor = currentRow.children[3].children[0].textContent;
        sumDecFactor += Number(currentDecFactor);

        let currentProductName = currentRow.children[1].children[0].textContent;
        boughtProducts.push(currentProductName);
      }
    }

    let avgDecFactor = sumDecFactor/checkedProducts;

    let outPutTextArea = document.getElementsByTagName('textarea')[1];
    outPutTextArea.value +=`Bought furniture: ${boughtProducts.join(', ')}\n`;
    outPutTextArea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    outPutTextArea.value += `Average decoration factor: ${avgDecFactor}`;
  }
}