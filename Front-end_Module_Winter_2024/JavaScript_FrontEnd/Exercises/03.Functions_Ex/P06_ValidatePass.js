function validate(password) {

    const checkPasswordLength = password => password.length >= 6 && password.length <= 10;
    const passwordConsistsOnlyOfLettersAndNumbers = password => /^[a-zA-Z0-9]+$/.test(password);
    const passwordContainsAtLeast2Digits = password => password
        .split('')
        .filter(char => Number.isInteger(Number(char)))
        .length >= 2;
    let isValid = true;
    if (!checkPasswordLength(password)) {
        console.log('Password must be between 6 and 10 characters');
        isValid = false;
    }
    if (!passwordConsistsOnlyOfLettersAndNumbers(password)) {
        console.log('Password must consist only of letters and digits');
        isValid = false;
    }
    if (!passwordContainsAtLeast2Digits(password)) {
        console.log('Password must have at least 2 digits');
        isValid = false;
    }

    if (isValid) {
        console.log('Password is valid');
    }
}

validate("123wewe");