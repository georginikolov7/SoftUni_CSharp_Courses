window.addEventListener("load", solve);

function solve() {

  function addLiToList(name, phone, category) {
    const namePElement = document.createElement('p');
    namePElement.textContent = `name:${name}`;

    const phonePElement = document.createElement('p');
    phonePElement.textContent = `phone:${phone}`;

    const catPElement = document.createElement('p');
    catPElement.textContent = `category:${category}`;

    const articleElement = document.createElement('article'); 4
    articleElement.appendChild(namePElement);
    articleElement.appendChild(phonePElement);
    articleElement.appendChild(catPElement);

    const divButtonsElement = document.createElement('div');
    divButtonsElement.classList.add('buttons');

    const editButtonElement = document.createElement('button');
    editButtonElement.classList.add('edit-btn');

    const saveButtonElement = document.createElement('button');
    saveButtonElement.classList.add('save-btn');

    divButtonsElement.appendChild(editButtonElement);
    divButtonsElement.appendChild(saveButtonElement);

    const liElement = document.createElement('li');
    liElement.appendChild(articleElement);
    liElement.appendChild(divButtonsElement);

    checkListElement.appendChild(liElement);

    //OnCLick of edit button:
    editButtonElement.addEventListener('click', () => {
      nameInputElement.value = name;
      phoneInputElement.value = phone;
      categorySelectElement.value = category;

      //Remove from list:
      checkListElement.removeChild(liElement);
    });

    //Onclick of save button:
    saveButtonElement.addEventListener('click', () => {
      checkListElement.removeChild(liElement);

      const finalLiElement = document.createElement('li');

      finalLiElement.appendChild(articleElement);

      //Create delete btn:
      const deleteButtonELement = document.createElement('button');
      deleteButtonELement.classList.add('del-btn');
      finalLiElement.appendChild(deleteButtonELement);

      //Append to contact list:
      contactListElement.appendChild(finalLiElement);

      //Onclick of delete btn:
      deleteButtonELement.addEventListener('click', () => {
        contactListElement.removeChild(finalLiElement);
      });
    });
  }
  const addButtonElement = document.getElementById('add-btn');
  const checkListElement = document.getElementById('check-list');
  const contactListElement = document.getElementById('contact-list');
  //Input fields:
  const nameInputElement = document.getElementById('name');
  const phoneInputElement = document.getElementById('phone');
  const categorySelectElement = document.getElementById('category');
  addButtonElement.addEventListener('click', () => {
    if (!nameInputElement.value || !phoneInputElement.value || !categorySelectElement.value) {
      return;
    }
    addLiToList(nameInputElement.value, phoneInputElement.value, categorySelectElement.value);
    nameInputElement.value = '';
    phoneInputElement.value = '';
    categorySelectElement.value = '';
  });
}
