import React from 'react';
import { Provider } from 'react-redux';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { ThemeProvider } from '@material-ui/core';
import sagas from './redux/sagas';
import { Auth } from './pages';
import { theme } from './constants/theme';
import store from './redux/store';

store.runSaga(sagas);

function App() {
  return (
    <Provider store={store}>
      <ThemeProvider theme={theme}>
        <Router>
          <Switch>
            <Route exact path="/" component={Auth} />
            <Route exact path="/home" component={Auth} />
          </Switch>
        </Router>
      </ThemeProvider>
    </Provider>
  );
}

export default App;
