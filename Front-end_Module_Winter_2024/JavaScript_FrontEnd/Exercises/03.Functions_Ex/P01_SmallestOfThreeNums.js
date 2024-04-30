function minOfThreeNums(num1, num2, num3) {
    if (num1 < num2) {
        if (num1 < num3) {
            return num1;
        }
        return num3;
    }
    if (num2 < num3) {
        return num2;
    }
    return num3;
}