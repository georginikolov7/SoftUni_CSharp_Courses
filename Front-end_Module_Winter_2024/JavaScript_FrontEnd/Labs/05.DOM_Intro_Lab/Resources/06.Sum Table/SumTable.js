function sumTable() {
    const tableRows = document.querySelectorAll('table tr td:last-child');
    let sum = 0;
    for (let i = 0; i < tableRows.length - 1; i++) {
        sum += Number(tableRows[i].textContent);
    }
    console.log(sum);
    tableRows[tableRows.length-1].textContent=sum;
}