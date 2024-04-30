function search() {
   // TODO
   function resetStyles(townsList) {
      for (let town of townsList) {
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none';
      }
   }
   const searchedTown = document.getElementById('searchText').value;
   const towns = document.querySelectorAll('ul#towns li');
   resetStyles(towns);
   let count = 0;
   for (let town of towns) {
      if (town.textContent.includes(searchedTown)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         count++;
      }
   }
   const resultElement = document.getElementById('result');
   resultElement.textContent = `${count} matches found`;
}
