const endpoint = 'api/user';

export function fetchLogin(userData) {
  return fetch(`${endpoint}/auth`, {
    method: 'POST',
    body: JSON.stringify(userData),
  });
}

export function fetchUser() {
  return 'hi';
}
