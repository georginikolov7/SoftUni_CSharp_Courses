function solve() {
  //TODO...
  const quizAnswerElements = document.querySelectorAll('.quiz-answer');
  const QNA = {
    'Question #1: Which event occurs when the user clicks on an HTML element?': 'onclick',
    'Question #2: Which function converting JSON to string?': 'JSON.stringify()',
    'Question #3: What is DOM?': 'A programming API for HTML and XML documents'
  };

  let answeredCount = 0;
  for (const answerElement of quizAnswerElements) {
    answerElement.addEventListener('click', (e) => {
      const sectionElement = e.currentTarget.parentElement.parentElement;
      const questionTitle = e.currentTarget.parentElement.querySelector('.question h2').textContent;
      const answerText = answerElement.querySelector('.answer-text').textContent;
      if (answerText == QNA[questionTitle]) {
        answeredCount++;
      }
      sectionElement.classList.add('hidden');
      const nextSection = sectionElement.nextElementSibling;
      console.log(nextSection);
      sectionElement.style.display = 'none'
      nextSection.classList.remove('hidden');
      nextSection.style.display = 'block';
      if (nextSection.id === 'results') {
        nextSection.style.display = 'block';
        const headingElement = nextSection.querySelector('.results-inner h1');
        if (answeredCount == 3) {
          headingElement.textContent = 'You are recognized as top JavaScript fan!';
        } else {
          headingElement.textContent = `You have ${answeredCount} right answers`;
        }
      }
    });
  }
}
