function extractText() {
   let extractedText = $('li')
            .toArray()
            .map(e => e.textContent);

   let result = $('#result');

   result.append(extractedText.join(', '));
}
