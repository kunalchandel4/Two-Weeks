var url1 = 'http://localhost:9006/convert';
var url2 = 'http://localhost:9006/qualitycheck';
var url3 = 'http://localhost:9006/debug';

async function convertCode() {
    const code = document.getElementById('inputCode').value;
    const selectedLanguage = document.getElementById('languageSelect').value;
    if (!code.trim()) {
        alert('Please provide some text in the input.');
        return;
    }else{

    
    // Send the code and selected language to the backend for conversion
    const convertedCode = await sendToBackend(code, url1+"?language="+selectedLanguage);
  
    document.getElementById('output').value = convertedCode;
    }
    
}
  
async function sendToBackend(code, url) {
  try {
      const data = {
         code:  code
      };
      const response = await fetch(url, {
          method: 'POST',
          headers: {
              'Content-Type': 'application/json'
          },
          body: JSON.stringify(data)
      });

      if (!response.ok) {
          throw new Error('Network response was not ok');
      }

      const res = await response.text();
      return res;
  } catch (error) {
      console.error('Error:', error);
      throw new Error('Failed to send request to the backend.');
  }
}

  
  async function debug() {

    // Implement debug functionality
    const code = document.getElementById('inputCode').value;
      
    if (!code.trim()) {
        alert('Please provide some text in the input.');
        return;
    }else{
    // Send the code and selected language to the backend for conversion
      const convertedCode = await sendToBackend(code, url3);
  
      document.getElementById('output').value = convertedCode;
  
   
    }
  }
  
  async function qualityCheck() {
    // Implement quality check functionality
    const code = document.getElementById('inputCode').value;
      
    if (!code.trim()) {
        alert('Please provide some text in the input.');
        return;
    }else{
    // Send the code and selected language to the backend for conversion
      const convertedCode = await sendToBackend(code, url2);
  
      document.getElementById('output').value = convertedCode;
  
   
    }
  }
  