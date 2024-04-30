function extract(content) {
    const textElement = document.getElementById(content);
    const matches = textElement.textContent.matchAll(/\((.*?)\)/g);

    const text = Array
        .from(matches)
        .map(match => match[1])
        .join('; ');
    return text;
}