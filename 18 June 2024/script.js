var form = document.getElementById("form");

// form.addEventListener('submit',function Login() {
//     event.preventDefault();
//     var email = document.getElementById("emailvalue").value;
//     var password = document.getElementById("passwordvalue").value;

//     const loginDTO = {
//         Email: email,
//         Password: password
//     };

//     fetch('http://localhost:5083/api/User/Customerlogin', {
//         method: 'POST', 
//         headers: {
//           'Content-Type': 'application/json',
//           'Access-Control-Allow-Origin': '*',
//           'Access-Control-Allow-Credentials': 'true'
//         },
//         body: JSON.stringify(loginDTO)
//       })
//       .then(response => response.json())
//       .then(data => {
//         console.log(data);
//         localStorage.setItem("userinfo",JSON.stringify(data));
//       })
//       .catch(error => console.error('Error:', error));
// })


form.addEventListener('submit',function Login() {
    event.preventDefault();
    var id = document.getElementById("cmtID").value;
    var commentbody = document.getElementById("commentbody").value;


    fetch(`https://dummyjson.com/comments/${id}`, {
        method: 'PUT', 
        headers: {
          'Content-Type': 'application/json',
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': 'true'
        },
        body: JSON.stringify({
            body: commentbody
        })
      })
      .then(response => response.json())
      .then(data => {
        console.log(data);
        var output = document.getElementById("updatedCmt");
        var result = `<p><b>ID    :             </b>${data.id}</p>
                      <p><b>Body  :           </b>${data.body}</p>
                      <p><b>Likes :         </b>${data.likes}</p>  
        `
        output.innerHTML= result;
        form.reset();
      })
      .catch(error => console.error('Error:', error));
})