import { USER_LOGIN_STARTED, USER_LOGIN_SUCCSEED, USER_LOGIN_FAILED } from '../actions/user.action';

const initalState = {
  user: {},
  isLoading: false,
  error: null,
};

export default function user(state = initalState, action) {
  switch (action.type) {
    case USER_LOGIN_STARTED:
      return {
        ...state,
        isLoading: true,
      };
    case USER_LOGIN_SUCCSEED:
      return {
        user: action.payload,
        isLoading: false,
      };
    case USER_LOGIN_FAILED:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
}
