function solve() {

  //TODO...
  const inputElement = document.querySelector('div#exercise:first-child textarea');
  const outputElement = document.querySelector('div#exercise textarea:last-of-type');
  const furnitureTBodyElement = document.querySelector('.table tbody');
  const generateButtonElement = document.querySelector('div#exercise:first-child button');
  const buyButtonElement = document.querySelector('div#exercise button:last-of-type');
  generateButtonElement.addEventListener('click', () => {
    const json = inputElement.value;
    const furnitures = JSON.parse(json);
    inputElement.value = '';

    for (const furniture of furnitures) {
      const newRowElement = document.createElement('tr');

      const imageElement = document.createElement('img');
      imageElement.src = furniture.img;
      const tdImgElement = document.createElement('td');
      tdImgElement.appendChild(imageElement);
      newRowElement.appendChild(tdImgElement);

      const pNameElement = document.createElement('p');
      pNameElement.textContent = furniture.name;
      const tdNameElement = document.createElement('td');
      tdNameElement.appendChild(pNameElement);
      newRowElement.appendChild(tdNameElement);

      const pPriceElement = document.createElement('p');
      pPriceElement.textContent = furniture.price;
      const tdPriceElement = document.createElement('td');
      tdPriceElement.appendChild(pPriceElement);
      newRowElement.appendChild(tdPriceElement);

      const pDecoElement = document.createElement('p');
      pDecoElement.textContent = furniture.decFactor;
      const tdDecoElement = document.createElement('td');
      tdDecoElement.appendChild(pDecoElement);
      newRowElement.appendChild(tdDecoElement);

      const checkmarkElement = document.createElement('input');
      checkmarkElement.setAttribute('type', 'checkbox');

      const checkmarkTdElement=document.createElement('td');
      checkmarkTdElement.appendChild(checkmarkElement);
      newRowElement.appendChild(checkmarkTdElement);
      furnitureTBodyElement.appendChild(newRowElement);
    }

    //checkMarkElement.checked = checked;
  });

  buyButtonElement.addEventListener('click', () => {
    let names = [];
    let totalPrice = 0;
    let totalDeco = 0;
    Array
      .from(furnitureTBodyElement.children)
      .forEach(tr => {
        if (!tr.querySelector('input[type=checkbox]').checked) {
          return;
        }

        const name = tr.children.item(1).textContent;
        const price = Number(tr.children.item(2).textContent);
        const decoFactor = Number(tr.children.item(3).textContent);
        totalPrice += price;
        totalDeco += decoFactor;
        names.push(name);
      })
    const outputString = `Bought furniture: ${names.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${totalDeco / names.length}`;
    outputElement.value = outputString;
  });
}