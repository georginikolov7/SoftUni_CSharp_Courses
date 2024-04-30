function solve() {
  //TODO...
  let inputText = document.getElementById('text').value;
  let caseCommand = document.getElementById('naming-convention').value;

  const outputElement = document.getElementById('result');
  let words = inputText
    .toLowerCase()
    .split(' ')
    .map(w => w.charAt(0).toUpperCase() + w.slice(1))

  if (caseCommand === 'Camel Case') {
    words[0] = words[0].charAt(0).toLowerCase() + words[0].slice(1);
  } else if (caseCommand != 'Pascal Case') {
    outputElement.textContent = 'Error!';
    return;
  }
  outputElement.textContent = words.join('');
}