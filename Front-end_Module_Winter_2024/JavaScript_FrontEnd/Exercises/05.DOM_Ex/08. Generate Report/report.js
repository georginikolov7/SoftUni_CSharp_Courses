function generateReport() {
    //TODO

    const thElements = document.querySelectorAll('table thead th');
    const headers =
        Array.from(thElements)
            .reduce((result, thElement) => {
                const checkBoxElement = thElement.querySelector('input[type=checkbox]');
                result.push({
                    name: thElement.textContent.toLowerCase().trim(),
                    active: checkBoxElement.checked
                });
                return result;
            }, []);

    const rowElements = document.querySelectorAll('table tbody tr');

    const reportData = Array.from(rowElements)
        .map(rowElement => {
            const tdElements = rowElement.querySelectorAll('td');
            const result = Array.from(tdElements)
                .reduce((data, tdElement, i) => {
                    if (!headers[i].active) {
                        return data;
                    }

                    data[headers[i].name] = tdElement.textContent;

                    return data;
                }, {})
            return result;
        });
    console.log(reportData);
    const outputElement = document.getElementById('output');
    outputElement.value = JSON.stringify(reportData,null,2);
}