function attachEventsListeners() {
    const inputElements = document.querySelectorAll('input[type=text]');
    const buttonElements = document.querySelectorAll('input[type=button][value=Convert]');
    const toSeconds = (value, unit) => {
        switch (unit) {
            case 'days':
                return value * 24 * 60 * 60;

            case 'hours':
                return value * 60 * 60;

            case 'minutes':
                return value * 60;
            case "seconds":
                return value;
        }
    };

    converters = {
        days(seconds) {
            return seconds / 60 / 60 / 24;
        }, hours(seconds) {
            return seconds / 60 / 60;
        },
        minutes(seconds) {
            return seconds / 60;
        }, seconds(seconds) {
            return seconds;
        }
    }

    for (const buttonElement of buttonElements) {
        buttonElement.addEventListener('click', (e) => {
            const currentInputElement = e.currentTarget.parentElement.querySelector('input[type=text]');

            for (const inputElement of inputElements) {
                value = toSeconds(Number(currentInputElement.value), currentInputElement.id);
                inputElement.value = converters[inputElement.id](value);
            }

        });
    }
}