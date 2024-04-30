
function solve(nums) {
    let sortedAscending = nums.slice()
        .sort((a, b) => a - b);


    let resultArray = [];
    let bottomIndex = 0;
    let topIndex = sortedAscending.length - 1;
    for (let i = 0; i < sortedAscending.length; i++) {
        if (i % 2 == 0) {
            resultArray[i] = sortedAscending[bottomIndex];
            bottomIndex++;
        } else {
            resultArray[i] = sortedAscending[topIndex];
            topIndex--;
        }
    }

    return resultArray;
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);