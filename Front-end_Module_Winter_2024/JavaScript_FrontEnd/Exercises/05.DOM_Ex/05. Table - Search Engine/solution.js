function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      //   TODO:

      const searchedWord = document.getElementById('searchField').value;
      const tableRowsElements = document.querySelectorAll('table.container tbody tr');
      for (const rowElement of tableRowsElements) {

         rowElement.classList.remove('select');
         if (Array
            .from(rowElement.children)
            .some(td => td.textContent
               .includes(searchedWord))) {
            rowElement.classList.add('select');
         }
      }
   }
}