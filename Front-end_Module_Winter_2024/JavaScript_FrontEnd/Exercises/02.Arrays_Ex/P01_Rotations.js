function nhehehehehehehe(array, rotations) {
    let startIndex = rotations % array.length;
    let newArr = [];
    //2 3 4  51 1       3
    let newIndex = 0;
    for (let i = startIndex; i < array.length; i++) {
        newArr[newIndex] = array[i];
        newIndex++;
    }
    //3 4 5 6 7       3
    for (let i = 0; i < startIndex; i++) {
        newArr[newIndex] = array[i];
        newIndex++;
    }
    console.log(newArr.join(' '));
}

nhehehehehehehe([51, 47, 32, 61, 21], 2);
nhehehehehehehe([32, 21, 61, 1], 4);