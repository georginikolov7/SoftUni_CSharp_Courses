function editElement(element, match, replacer) {
    // TODO
    while (element.textContent.includes(match)) {
        element.textContent = element.textContent.replace(match, replacer);
    }
}