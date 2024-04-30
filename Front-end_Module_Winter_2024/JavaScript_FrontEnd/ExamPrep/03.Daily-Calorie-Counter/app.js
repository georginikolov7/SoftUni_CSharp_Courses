//TODO
const loadButtonElement = document.getElementById('load-meals');
const editButtonElement = document.getElementById('edit-meal');
const addButtonElement = document.getElementById('add-meal');

const foodInputElement = document.getElementById('food');
const timeInputElement = document.getElementById('time');
const caloriesInputElement = document.getElementById('calories');

const mealListElement = document.getElementById('list');
const url = 'http://localhost:3030/jsonstore/tasks';
let currentMealId = null;
const loadMeals = async () => {
    const response = await fetch(url);
    const data = await response.json();
    console.log(data);

    //Clear list:
    mealListElement.innerHTML = '';

    for (const meal of Object.values(data)) {

        const changeButonElement = document.createElement('button');
        changeButonElement.textContent = "Change";
        changeButonElement.classList.add('change-meal');

        const deleteButonElement = document.createElement('button');
        deleteButonElement.textContent = 'Delete';
        deleteButonElement.classList.add('delete-meal');


        const buttonContainerElement = document.createElement('div');
        buttonContainerElement.classList.add('meal-buttons');
        buttonContainerElement.appendChild(changeButonElement);
        buttonContainerElement.appendChild(deleteButonElement);

        const foodH2Element = document.createElement('h2');
        foodH2Element.textContent = meal.food;

        const timeH3Element = document.createElement('h3');
        timeH3Element.textContent = meal.time;
        const caloriesH3Element = document.createElement('h3');
        caloriesH3Element.textContent = meal.calories;

        const divContainer = document.createElement('div');
        divContainer.classList.add('meal');
        divContainer.appendChild(foodH2Element);
        divContainer.appendChild(timeH3Element);
        divContainer.appendChild(caloriesH3Element);
        divContainer.appendChild(buttonContainerElement);

        //Attach to DOM:
        mealListElement.appendChild(divContainer);


        //Attach onChange:
        changeButonElement.addEventListener('click', () => {
            currentMealId = meal._id;
            foodInputElement.value = meal.food;
            timeInputElement.value = meal.time;
            caloriesInputElement.value = meal.calories;

            addButtonElement.setAttribute('disabled', 'disabled');
            editButtonElement.removeAttribute('disabled');
        });

        //Attach onDelete:
        deleteButonElement.addEventListener('click', async () => {
            const response = await fetch(`${url}/${meal._id}`,
                { method: 'DELETE' });

            await loadMeals();
        });

    }
    editButtonElement.disabled = true;
};

loadButtonElement.addEventListener('click', async () => {
    await loadMeals();
});

addButtonElement.addEventListener('click', async () => {
    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ food, calories, time })
    });
    if (!response.ok) {
        return;
    }

    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';
    await loadMeals();

});

editButtonElement.addEventListener('click', async () => {
    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;

    const response = await fetch(`${url}/${currentMealId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({
            _id: currentMealId,
            food,
            calories,
            time
        })
    });
    if (!response.ok) {
        return;
    }

    await loadMeals();

    editButtonElement.setAttribute('disabled', 'disabled');
    addButtonElement.removeAttribute('disabled');
    currentMealId = null;
    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';
})
