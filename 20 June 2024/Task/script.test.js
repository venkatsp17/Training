const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');

test('CheckLoginSuccess',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'./index.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'./script.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById('username').value = 'user1';
    dom.window.document.getElementById('password').value = 'pass1';

    //Raising the event
    dom.window.document.getElementById('sbtbtn').click();
    const actual = dom.window.document.getElementById('message').innerHTML;
    const color = dom.window.document.getElementById('message').style.color;
    expect(actual).toBe('Login successful!');
    expect(color).toBe('green');
})



test('CheckLoginFailed',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'./index.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'./script.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById('username').value = 'user1';
    dom.window.document.getElementById('password').value = 'pass12';

    //Raising the event
    dom.window.document.getElementById('sbtbtn').click();
    const actual = dom.window.document.getElementById('message').innerHTML;
    const color = dom.window.document.getElementById('message').style.color;
    expect(actual).toBe('Invalid username or password');
    expect(color).toBe('red');
})