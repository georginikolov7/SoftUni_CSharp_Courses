function solve() {
   //TODO...
   const addButtonElements = document.querySelectorAll('button.add-product');
   const checkoutButtonElement = document.querySelector('button.checkout');
   const textareaElement = document.querySelector('textarea');
   const currentProducts = [];
   for (const addButtonElement of addButtonElements) {
      addButtonElement.addEventListener('click', () => {
         const productElement = addButtonElement.parentElement.parentElement;
         const price = Number(productElement.querySelector('.product-line-price').textContent);
         const productName = productElement.querySelector('.product-title').textContent;
         currentProducts.push({ productName, price });
         textareaElement.textContent += `Added ${productName} for ${price.toFixed(2)} to the cart.\n`;
      });
   }

   checkoutButtonElement.addEventListener('click', () => {
      const totalMoney = currentProducts.reduce((sum, currentProduct) => {
         return sum + currentProduct.price;
      }, 0);
      const productNames = [];
      for (const product of currentProducts) {
         const name = product.productName;
         if (!productNames.includes(name)) {
            productNames.push(name);
         }
      }
      const output = `You bought ${productNames.join(", ")} for ${totalMoney.toFixed(2)}.`;
      textareaElement.textContent += output;

      checkoutButtonElement.setAttribute('disabled', 'disabled');
      for (const button of addButtonElements) {
         button.setAttribute('disabled', 'disabled');
      }
   });
}