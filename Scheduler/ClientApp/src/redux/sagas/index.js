import {
  put,
  call,
  all,
  fork
} from "redux-saga/effects"

import * as api from "../../services/api"

import {
  startLogin,
  loginSuccseed,
  loginFailed
} from "../actions/user.action"

function* fetchLogin(action) {
  const user = yield call(
    api.fetchLogin, action.payload
  )


}

export default function* root() {
  yield all([
    fork(fetchLogin),
  ])
}