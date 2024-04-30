function solve(number, ...operations) {
    for (let i = 1; i < arguments.length; i++) {
        switch (arguments[i]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number = 0.80 * number;
                break;
        }
        console.log(number);
    }

}