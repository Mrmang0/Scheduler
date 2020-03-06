export const USER_LOGIN_REQUESTED = 'USER_LOGIN_STARTED';
export const USER_LOGIN_SUCCSEED = 'USER_LOGIN_SUCCSEED';
export const USER_LOGIN_FAILED = 'USER_LOGIN_FAILED';

export const requestLogin = () => ({ type: USER_LOGIN_REQUESTED });

export const startLogin = credentials => ({
  type: USER_LOGIN_REQUESTED,
  payload: {
    isLoading: true,
    credentials,
  },
});

export const loginSuccseed = user => ({
  type: USER_LOGIN_SUCCSEED,
  payload: user,
});

export const loginFailed = error => ({
  type: USER_LOGIN_FAILED,
  payload: error,
});
