import { put, call, takeLatest, all } from 'redux-saga/effects';

import * as api from '../../services/api';

import { USER_LOGIN_REQUESTED, loginSuccseed, loginFailed } from '../actions/user.action';

function* fetchLogin(action) {
  try {
    const user = yield call(api.fetchLogin, action.payload.credentials);
    yield put(loginSuccseed(user));
  } catch (error) {
    yield put(loginFailed());
  }
}

function* watchLogin() {
  yield takeLatest(USER_LOGIN_REQUESTED, fetchLogin);
}

export default function* rootSage() {
  yield all([watchLogin()]);
}
