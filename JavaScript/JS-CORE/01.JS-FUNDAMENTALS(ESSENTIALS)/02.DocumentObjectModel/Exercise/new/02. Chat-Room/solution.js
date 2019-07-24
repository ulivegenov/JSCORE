function solve() {
   let sendButton = document.getElementById('send');
   sendButton.addEventListener('click', onClick);

   function onClick(){
      let textAreaElement = document.getElementById('chat_input');
      let chatMessagesElement = document.getElementById('chat_messages');

      let currentMessageElement = document.createElement('div');
      currentMessageElement.setAttribute('class', 'message my-message');
      currentMessageElement.textContent = textAreaElement.value;
      chatMessagesElement.appendChild(currentMessageElement);
      textAreaElement.value = '';
   }
}