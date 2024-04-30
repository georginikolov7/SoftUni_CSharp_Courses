function colorize() {
    // TODO
    const evenRows = document.querySelectorAll('table tr:nth-child(2n)');
    for(const row of evenRows){
        row.style.backgroundColor='teal';
    }
}