function generateShayari() {
    const userInput = document.getElementById('userInput').value;
    const shayariType = document.getElementById('shayariDropdown').value;
    const url1 = 'http://localhost:9005/generateShayari';
    const url2 = 'http://localhost:9005/generateStory';
    const url3 = 'http://localhost:9005/generateQuotes';
    const data = {
        userInput
    };
  
    if(shayariType == "shayari"){
        fetch(url1, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
          })
          .then(response => response.text())
          .then(res => {
            const outputDiv = document.getElementById('output');
           
            outputDiv.innerHTML = `<h2>Generated Output:   </h2>   <h3>${res}</h3> `;
          })
          .catch(error => console.error('Error:', error));
    } 
     else if(shayariType == "quotes"){

        fetch(url3, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
          })
          .then(response => response.text())
          .then(shayari => {
            const outputDiv = document.getElementById('output');
            outputDiv.innerHTML = `<h2>Generated Output: ->  </h2>   <h3>${shayari}</h3> `;
          })
          .catch(error => console.error('Error:', error));
    }
    else if(shayariType == "story"){
        
        fetch(url2, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
          })
          .then(response => response.text())
          .then(shayari => {
            const outputDiv = document.getElementById('output');
            outputDiv.innerHTML = `<h2>Generated Output:   </h2>   <h3>${shayari}</h3> `;
          })
          .catch(error => console.error('Error:', error));
    }
  }