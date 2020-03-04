import {
    createStore,
    applyMiddleware

} from "redux"
import {
    composeWithDevTools
} from 'redux-devtools-extension'
import reducers from "./reducers"
import createSagaMiddleware from 'redux-saga'

const sagaMiddleware = createSagaMiddleware();
const enhancers = composeWithDevTools(applyMiddleware(sagaMiddleware))
const store = createStore(reducers, enhancers);
store.runSaga = sagaMiddleware.run;

export default store;