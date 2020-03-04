export const USER_LOGIN_STARTED = "USER_LOGIN";
export const USER_LOGIN_SUCCSEED = "USER_LOGIN_SUCCSEED";
export const USER_LOGIN_FAILED = "USER_LOGIN_FAILED";

export const startLogin = () => ({
    type: USER_LOGIN_STARTED,
    payload: true
});

export const loginSuccseed = user => ({
    type: USER_LOGIN_SUCCSEED,
    payload: user
});

export const loginFailed = () => ({
    type: USER_LOGIN_FAILED,
    payload: false
})