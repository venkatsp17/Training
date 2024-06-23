document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault();
    
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    const validCredentials = [
        { username: 'user1', password: 'pass1' },
        { username: 'user2', password: 'pass2' },
        { username: 'user3', password: 'pass3' }
    ];

    const isValid = validCredentials.some(cred => cred.username === username && cred.password === password);

    const messageDiv = document.getElementById('message');
    if (isValid) {
        messageDiv.style.color = 'green';
        messageDiv.textContent = 'Login successful!';
    } else {
        messageDiv.style.color = 'red';
        messageDiv.textContent = 'Invalid username or password';
    }
});
