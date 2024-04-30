
function calculate(number1, number2, operator) {
    const executeOperation = {
        add: (a, b) => a + b,
        multiply: (a, b) => a * b,
        subtract: (a, b) => a - b,
        divide: (a, b) => a / b
    };

    console.log(executeOperation[operator](number1, number2));
}

calculate(number1, number2, operator)


calculate(2, 5, 'multiply');