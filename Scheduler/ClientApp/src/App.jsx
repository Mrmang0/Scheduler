import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { ThemeProvider } from "@material-ui/core";
import sagas from "./redux/sagas";
import { Auth } from "./pages";
import { theme } from "./constants";
import { Provider } from "react-redux";
import store from "./redux/store";
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
