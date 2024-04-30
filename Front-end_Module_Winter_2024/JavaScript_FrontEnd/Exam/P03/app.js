//TODO...
const baseUrl = 'http://localhost:3030/jsonstore/games';

let selectedGameId = null;
//Buttons:
const loadButtonElement = document.getElementById('load-games');
const addButtonElement = document.getElementById('add-game');
const editButtonElement = document.getElementById('edit-game');

//Inputs:
const nameInputElement = document.getElementById('g-name');
const typeInputElement = document.getElementById('type');
const playersInputElement = document.getElementById('players');
//Lists:
const gamesListElement = document.getElementById('games-list');

async function loadGames() {
    const response = await fetch(baseUrl);
    if (!response.ok) {
        return;
    }
    const games = await response.json();
    //Clear div:
    gamesListElement.innerHTML = '';

    for (const game of Object.values(games)) {
        //Content:
        const namePElement = document.createElement('p');
        namePElement.textContent = game.name;

        const playersPElement = document.createElement('p');
        playersPElement.textContent = game.players;

        const typePElement = document.createElement('p');
        typePElement.textContent = game.type;

        const contentDivElement = document.createElement('div');
        contentDivElement.classList.add('content');
        contentDivElement.appendChild(namePElement);
        contentDivElement.appendChild(playersPElement);
        contentDivElement.appendChild(typePElement);

        //Buttons:
        const changeButtonElement = document.createElement('button');
        changeButtonElement.classList.add('change-btn');
        changeButtonElement.textContent = "Change";

        const deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('delete-btn');
        deleteButtonElement.textContent = 'Delete';

        const buttonsDivContainerElement = document.createElement('div');
        buttonsDivContainerElement.classList.add('buttons-container');
        buttonsDivContainerElement.appendChild(changeButtonElement);
        buttonsDivContainerElement.appendChild(deleteButtonElement);

        //main div:
        const gameDivElement = document.createElement('div');
        gameDivElement.classList.add('board-game');
        gameDivElement.appendChild(contentDivElement);
        gameDivElement.appendChild(buttonsDivContainerElement);
        gamesListElement.appendChild(gameDivElement);


        //button event handlers:
        changeButtonElement.addEventListener('click', () => {
            selectedGameId = game._id;
            nameInputElement.value = game.name;
            playersInputElement.value = game.players;
            typeInputElement.value = game.type;

            //Disable addGame button:
            addButtonElement.setAttribute('disabled', 'disabled');
            //Enable edit btn:
            editButtonElement.removeAttribute('disabled');
        });

        deleteButtonElement.addEventListener('click', async () => {
            selectedGameId = game._id;
            await fetch(`${baseUrl}/${selectedGameId}`, {
                method: "DELETE"
            });
            await loadGames();
        });
    }
    console.log(games);
}
//Click  handlers:
loadButtonElement.addEventListener('click', async () => {
    console.log(loadButtonElement);
    await loadGames();
    //Deactivate edit btn:
    editButtonElement.setAttribute('disabled', 'disabled');
    console.log(editButtonElement);
});

addButtonElement.addEventListener('click', async () => {
    const name = nameInputElement.value;
    const type = typeInputElement.value;
    const players = playersInputElement.value;

    await fetch(baseUrl, {
        method: "POST",
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ name, type, players })
    });

    nameInputElement.value = '';
    playersInputElement.value = '';
    typeInputElement.value = '';
    await loadGames();
});

editButtonElement.addEventListener('click', async () => {
    console.log('IBAAAA');
    const name = nameInputElement.value;
    const type = typeInputElement.value;
    const players = playersInputElement.value;
    await fetch(`${baseUrl}/${selectedGameId}`, {
        method: "PUT",
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ _id: selectedGameId, name, type, players })
    });

    editButtonElement.setAttribute('disabled', 'disabled');
    addButtonElement.removeAttribute('disabled');
    await loadGames();
    nameInputElement.value = '';
    playersInputElement.value = '';
    typeInputElement.value = '';
});