import { put, call, takeLatest } from 'redux-saga/effects';

import * as api from '../../services/api';

import { USER_LOGIN_REQUESTED, loginSuccseed, loginFailed } from '../actions/user.action';

function* fetchLogin(action) {
  try {
    const user = yield call(api.fetchLogin, action.payload.credentials);
    console.log(user);
    yield put(loginSuccseed(user));
  } catch (error) {
    yield put(loginFailed());
  }
}

export default function* mySaga() {
  yield takeLatest(USER_LOGIN_REQUESTED, fetchLogin);
}
