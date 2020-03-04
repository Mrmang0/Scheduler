const endpoint = "api/user"

export function fetchLogin(userData) {
  return fetch(`${endpoint}/auth`, {
    method: "POST"
  })
}