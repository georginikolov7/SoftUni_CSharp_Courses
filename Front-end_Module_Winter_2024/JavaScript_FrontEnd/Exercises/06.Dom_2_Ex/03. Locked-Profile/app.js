function lockedProfile() {
    console.log('TODO...')

    const showButtonElements = document.querySelectorAll('button');
    for (const buttonElement of showButtonElements) {
        buttonElement.addEventListener('click', (e) => {

            const hiddenDiv = e.target.parentElement.querySelector('div');
            //get current radios:
            const lockRadioObject = e.target.parentElement.querySelector('input[type=radio][value=lock]');
            const unlockRadioObject = e.target.parentElement.querySelector('input[type=radio][value=unlock]');

            if (unlockRadioObject.checked && e.target.textContent == 'Show more') {
                console.log(hiddenDiv);
                hiddenDiv.style.display = 'block';
                e.target.textContent = 'Hide it';
            } else if (unlockRadioObject.checked && e.target.textContent == "Hide it") {
                hiddenDiv.style.display = 'none';
                e.target.textContent = 'Show more';

            }

        });
    }
}