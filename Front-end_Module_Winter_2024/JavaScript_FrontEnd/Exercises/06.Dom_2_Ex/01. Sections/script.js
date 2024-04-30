function create(words) {
   console.log('TODO:...');
   const contentContainer = document.querySelector('div#content');
   const divElements = words.map(w => {
      const divElement = document.createElement('div');
      const paraElement = document.createElement('p');
      paraElement.textContent = w;
      paraElement.style.display = 'none';
      divElement.appendChild(paraElement);

      divElement.addEventListener('click', () => {
         paraElement.style.display = 'block';
      });
      return divElement;
   });

   divElements.forEach(divElement => contentContainer.appendChild(divElement));
}
