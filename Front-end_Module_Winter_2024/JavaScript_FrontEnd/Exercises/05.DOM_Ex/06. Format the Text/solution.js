function solve() {
  //TODO
  const inputText = document.getElementById('input').value;
  const outputElement = document.getElementById('output');
  outputElement.textContent = '';
  const sentences = inputText
    .split('.')
    .filter(w => w.length > 0);

  const paras = sentences.reduce((paras, s, i) => {
    const currentParaIndex = Math.floor(i / 3);
    if (!paras[currentParaIndex]) {
      paras[currentParaIndex] = [];
    }
    paras[currentParaIndex].push(s + '.');
    return paras;
  }, []);

  for (const para of paras) {
    const pElement = document.createElement('p');
    pElement.textContent = para;
    outputElement.appendChild(pElement);
  }
}