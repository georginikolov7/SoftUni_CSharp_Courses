function printLoadingBar(level) {
    function getBar(level) {
        let bar = '.'
            .repeat(10)
            .split('');
        const completion = level / 10;
        bar.fill('%', 0, completion );
        return bar.join('');
    }

    const bar = getBar(level);
    if (level === 100) {
        console.log(`100% Complete!`);
        console.log(`[${bar}]`);
        return;
    }

    console.log(`${level}% [${bar}]`);
    console.log('Still loading...');
}
printLoadingBar(10);