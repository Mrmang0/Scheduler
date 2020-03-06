import { handleResponse } from '../httpService';

const endpoint = 'api/user';

export function fetchLogin(userData) {
  return fetch(`${endpoint}/authenticate`, {
    method: 'POST',
    body: JSON.stringify(userData),
    headers: {
      'Content-Type': 'application/json',
    },
  }).then(handleResponse);
}

export function fetchUser() {
  return 'hi';
}
