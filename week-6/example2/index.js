'use strict';

document.addEventListener('DOMContentLoaded', () => {
  const form = document.getElementById('login-form');
  form.addEventListener('submit', event => {
    event.preventDefault();
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    if (username === 'matt' && password === 'asdf') {
      document.body.innerHTML = '';

      let div = document.createElement('div');
      let h1 = document.createElement('h1');

      h1.textContent = 'Welcome';

      div.append(h1);
      document.body.append(div);

      const logout_btn = document.createElement('button');
      logout_btn.textContent = 'Logout';

      logout_btn.addEventListener('click', () => {
        location.reload();
      });

      document.body.append(logout_btn);
    } else {
      alert('invalid credentials');
    }
  });
  
});

